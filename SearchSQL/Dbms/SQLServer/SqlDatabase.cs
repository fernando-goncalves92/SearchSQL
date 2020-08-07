using System;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SearchSQL
{
    public class SqlDatabase
    {
        private readonly Setting _setting;

        public SqlDatabase(Setting setting)
        {
            _setting = setting;
        }

        private string GetObjectBody(string objectName)
        {
            string objectBody = string.Empty;

            var query = new StringBuilder();

            query.Append("  DECLARE @COUNTER INT,                                                                 ").Append(Environment.NewLine);
            query.Append("          @ROWS INT,                                                                    ").Append(Environment.NewLine);
            query.Append("          @CONTENT VARCHAR(MAX)                                                         ").Append(Environment.NewLine);
                                                                                                                  
            query.Append("  SET @COUNTER = 1                                                                      ").Append(Environment.NewLine);
            query.Append($" SET @ROWS = (SELECT COUNT(*) FROM SYSCOMMENTS WHERE ID = OBJECT_ID('{ objectName }')) ").Append(Environment.NewLine);
            query.Append("  SET @CONTENT = ''                                                                     ").Append(Environment.NewLine);
                                                                                                                  
            query.Append("  WHILE @COUNTER <= @ROWS                                                               ").Append(Environment.NewLine);
            query.Append("  BEGIN                                                                                 ").Append(Environment.NewLine);            
                                                                                                                  
            query.Append("     SELECT                                                                             ").Append(Environment.NewLine);            
            query.Append("         @CONTENT = @CONTENT + TEXT                                                     ").Append(Environment.NewLine);
            query.Append("     FROM                                                                               ").Append(Environment.NewLine);
            query.Append("         SYSCOMMENTS                                                                    ").Append(Environment.NewLine);
            query.Append("     WHERE                                                                              ").Append(Environment.NewLine);
            query.Append($"        ID = OBJECT_ID('{ objectName }')                                               ").Append(Environment.NewLine);
            query.Append("     AND COLID = @COUNTER                                                               ").Append(Environment.NewLine);
                            
            query.Append("     SET @COUNTER = @COUNTER + 1                                                        ").Append(Environment.NewLine);
            query.Append("  END                                                                                   ").Append(Environment.NewLine);

            query.Append("  SELECT @CONTENT AS CONTENT                                                            ").Append(Environment.NewLine);

            using (SqlConnection connection = new SqlConnection(_setting.StringConnection))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = query.ToString();

                    objectBody = command.ExecuteScalar().ToString();
                    
                }
            }

            return objectBody;
        }

        public IEnumerable<SqlDatabaseObject> FindContentAndObjects(string word)
        {
            var objectsAndContents = new List<SqlDatabaseObject>();

            try
            {   
                var query = new StringBuilder();
                                                                                              
                query.Append("  SELECT                                                                        ").Append(Environment.NewLine);                
                query.Append("      SYS.OBJECTS.NAME                                                          ").Append(Environment.NewLine);
                query.Append($"    ,CASE TYPE WHEN 'P'  THEN '{ SqlDatabaseObjectType.Procedure }'            ").Append(Environment.NewLine);
                query.Append($"               WHEN 'TR' THEN '{ SqlDatabaseObjectType.Trigger }'              ").Append(Environment.NewLine);
                query.Append($"               WHEN 'FN' THEN '{ SqlDatabaseObjectType.ScalarFunction }'       ").Append(Environment.NewLine);
                query.Append($"               WHEN 'IS' THEN '{ SqlDatabaseObjectType.ScalarFunction }'       ").Append(Environment.NewLine);
                query.Append($"               WHEN 'V'  THEN '{ SqlDatabaseObjectType.View }'                 ").Append(Environment.NewLine);
                query.Append($"               WHEN 'TF' THEN '{ SqlDatabaseObjectType.TableFunction }'        ").Append(Environment.NewLine);
                query.Append($"               WHEN 'IF' THEN '{ SqlDatabaseObjectType.TableFunction }'        ").Append(Environment.NewLine);
                query.Append($"               WHEN 'U'  THEN '{ SqlDatabaseObjectType.Table }'                ").Append(Environment.NewLine);
                query.Append($"               ELSE '{ SqlDatabaseObjectType.Unknown }'                        ").Append(Environment.NewLine);
                query.Append("      END AS TYPE                                                               ").Append(Environment.NewLine);
                query.Append("     ,MAX(SYS.OBJECTS.CREATE_DATE) AS CREATE_DATE                               ").Append(Environment.NewLine);
                query.Append("     ,MAX(SYS.OBJECTS.MODIFY_DATE) AS MODIFY_DATE                               ").Append(Environment.NewLine);
                query.Append("     ,MAX(DB_NAME()) AS [DATABASE]                                              ").Append(Environment.NewLine);
                query.Append("  FROM                                                                          ").Append(Environment.NewLine); 
                query.Append("      SYS.OBJECTS                                                               ").Append(Environment.NewLine);
                query.Append("  LEFT JOIN SYSCOMMENTS ON                                                      ").Append(Environment.NewLine);                
                query.Append($"     SYS.OBJECTS.OBJECT_ID = SYSCOMMENTS.ID                                    ").Append(Environment.NewLine);                
                query.Append("  WHERE                                                                         ").Append(Environment.NewLine);
                query.Append($"      SYSCOMMENTS.TEXT LIKE '%{ word }%' OR SYS.OBJECTS.NAME LIKE '%{ word }%' ").Append(Environment.NewLine);
                query.Append("  GROUP BY                                                                      ").Append(Environment.NewLine);
                query.Append("      SYS.OBJECTS.NAME, SYS.OBJECTS.TYPE                                        ").Append(Environment.NewLine);

                using (SqlConnection connection = new SqlConnection(_setting.StringConnection))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = query.ToString();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Enum.TryParse<SqlDatabaseObjectType>(reader["TYPE"].ToString(), out var convertedType);

                                if (convertedType != SqlDatabaseObjectType.Unknown)
                                {
                                    var databaseObj = new SqlDatabaseObject(
                                        reader["NAME"].ToString(),
                                        GetObjectBody(reader["NAME"].ToString()),
                                        Convert.ToDateTime(reader["CREATE_DATE"]),
                                        Convert.ToDateTime(reader["MODIFY_DATE"]),
                                        convertedType,
                                        reader["DATABASE"].ToString());

                                    objectsAndContents.Add(databaseObj);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(
                    $"Error trying to find objects and contents in database.\n\nError Message: { error.Message } \n\nStack Trace: { error.StackTrace }",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return objectsAndContents;
        }

        public IEnumerable<SqlDatabaseObject> GetObjectsFromDb()
        {
            var objects = new List<SqlDatabaseObject>();

            try
            {   
                var query = new StringBuilder();

                query.Append("  SELECT                                                                  ").Append(Environment.NewLine);
                query.Append("      NAME                                                                ").Append(Environment.NewLine);
                query.Append($"    ,CASE TYPE WHEN 'P'  THEN '{ SqlDatabaseObjectType.Procedure }'      ").Append(Environment.NewLine);                
                query.Append($"               WHEN 'TR' THEN '{ SqlDatabaseObjectType.Trigger }'        ").Append(Environment.NewLine);
                query.Append($"               WHEN 'FN' THEN '{ SqlDatabaseObjectType.ScalarFunction }' ").Append(Environment.NewLine);
                query.Append($"               WHEN 'IS' THEN '{ SqlDatabaseObjectType.ScalarFunction }' ").Append(Environment.NewLine);
                query.Append($"               WHEN 'V'  THEN '{ SqlDatabaseObjectType.View }'           ").Append(Environment.NewLine);
                query.Append($"               WHEN 'TF' THEN '{ SqlDatabaseObjectType.TableFunction }'  ").Append(Environment.NewLine);
                query.Append($"               WHEN 'IF' THEN '{ SqlDatabaseObjectType.TableFunction }'  ").Append(Environment.NewLine);
                query.Append($"               WHEN 'U'  THEN '{ SqlDatabaseObjectType.Table }'          ").Append(Environment.NewLine);
                query.Append($"               ELSE '{ SqlDatabaseObjectType.Unknown }'                  ").Append(Environment.NewLine);
                query.Append("      END AS TYPE                                                         ").Append(Environment.NewLine);
                query.Append("     ,SYS.OBJECTS.CREATE_DATE                                             ").Append(Environment.NewLine);
                query.Append("     ,SYS.OBJECTS.MODIFY_DATE                                             ").Append(Environment.NewLine);
                query.Append("     ,DB_NAME() AS [DATABASE]                                             ").Append(Environment.NewLine);
                query.Append("  FROM                                                                    ").Append(Environment.NewLine);
                query.Append("      SYS.OBJECTS                                                         ").Append(Environment.NewLine);
                query.Append("  WHERE                                                                   ").Append(Environment.NewLine);
                query.Append("      TYPE IN ('P', 'TR', 'TF', 'FN', 'V', 'IS', 'IF', 'U')               ").Append(Environment.NewLine);
                query.Append("  ORDER BY                                                                ").Append(Environment.NewLine);
                query.Append("      TYPE                                                                ").Append(Environment.NewLine);
                
                using (SqlConnection connection = new SqlConnection(_setting.StringConnection))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = query.ToString();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Enum.TryParse<SqlDatabaseObjectType>(reader["TYPE"].ToString(), out var convertedType);

                                if (convertedType != SqlDatabaseObjectType.Unknown)
                                {
                                    var databaseObj = new SqlDatabaseObject(
                                        reader["NAME"].ToString(),
                                        GetObjectBody(reader["NAME"].ToString()),
                                        Convert.ToDateTime(reader["CREATE_DATE"]),
                                        Convert.ToDateTime(reader["MODIFY_DATE"]),
                                        convertedType,
                                        reader["DATABASE"].ToString());

                                    objects.Add(databaseObj);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(
                    $"Error trying to list all objects from database.\n\nError Message: { error.Message } \n\nStack Trace: { error.StackTrace }", 
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }

            return objects;
        }

        public IEnumerable<string> GetColumns(string table)
        {
            var columns = new List<string>();

            try
            {
                var query = new StringBuilder();

                query.Append("  SELECT                         ").Append(Environment.NewLine);
                query.Append("      COLUMN_NAME                ").Append(Environment.NewLine);                
                query.Append("     ,IS_NULLABLE                ").Append(Environment.NewLine);
                query.Append("     ,DATA_TYPE                  ").Append(Environment.NewLine);
                query.Append("     ,CHARACTER_MAXIMUM_LENGTH   ").Append(Environment.NewLine);
                query.Append("  FROM                           ").Append(Environment.NewLine);
                query.Append("      INFORMATION_SCHEMA.COLUMNS ").Append(Environment.NewLine);
                query.Append("  WHERE                          ").Append(Environment.NewLine);
                query.Append($"     TABLE_NAME = '{ table }'   ").Append(Environment.NewLine);
                query.Append("  ORDER BY                       ").Append(Environment.NewLine);
                query.Append("      ORDINAL_POSITION           ").Append(Environment.NewLine);

                using (SqlConnection connection = new SqlConnection(_setting.StringConnection))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = query.ToString();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var columnName = reader["COLUMN_NAME"];
                                var isNullable = reader["IS_NULLABLE"].ToString() == "YES" ? true : false;
                                var dataType = reader["DATA_TYPE"].ToString();
                                var maxLenght = reader["CHARACTER_MAXIMUM_LENGTH"] != null ? reader["CHARACTER_MAXIMUM_LENGTH"].ToString() : string.Empty;
                                var formatedColumnName = string.Format("{0} ({1}{2}, {3})", columnName, dataType, (string.IsNullOrEmpty(maxLenght) ? string.Empty : "(" + maxLenght + ")"), (isNullable ? "null" : "not null"));

                                columns.Add(formatedColumnName);
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(
                    $"Error trying to list all columns from table { table }.\n\nError Message: { error.Message } \n\nStack Trace: { error.StackTrace }",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return columns;
        }

        public void TestConnectionString(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Close();
            }

            MessageBox.Show("Successfully connected!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

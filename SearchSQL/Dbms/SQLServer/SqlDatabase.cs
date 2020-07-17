using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SearchSQL
{
    public class SqlDatabase
    {
        private const string STRING_CONNECTION_TEMP = @"Server=SQO-062\SQLEXPRESS;Database=dbAI1860SLD;User Id=sa; Password=sequor;";

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

            using (SqlConnection connection = new SqlConnection(STRING_CONNECTION_TEMP))
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
                                                                                              
                query.Append("  SELECT                                  ").Append(Environment.NewLine);                
                query.Append("      sysobjects.NAME                     ").Append(Environment.NewLine);
                query.Append("     ,sysobjects.TYPE                     ").Append(Environment.NewLine);                                                                                
                query.Append("  FROM                                    ").Append(Environment.NewLine); 
                query.Append("      sysobjects                          ").Append(Environment.NewLine);
                query.Append("  INNER JOIN syscomments ON               ").Append(Environment.NewLine);                
                query.Append("      sysobjects.id = syscomments.id      ").Append(Environment.NewLine);                
                query.Append("  WHERE                                   ").Append(Environment.NewLine);
                query.Append($"      syscomments.text LIKE '%{ word }%' ").Append(Environment.NewLine);
                query.Append("  GROUP BY                                ").Append(Environment.NewLine);
                query.Append("      sysobjects.NAME, sysobjects.TYPE    ").Append(Environment.NewLine);

                using (SqlConnection connection = new SqlConnection(STRING_CONNECTION_TEMP))
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

                                objectsAndContents.Add(new SqlDatabaseObject(reader["NAME"].ToString(), GetObjectBody(reader["NAME"].ToString()), convertedType));
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

                query.Append("  SELECT                                                               ").Append(Environment.NewLine);
                query.Append("      NAME,                                                            ").Append(Environment.NewLine);
                query.Append($"     CASE TYPE WHEN 'P'  THEN '{ SqlDatabaseObjectType.Procedure }'           ").Append(Environment.NewLine);                
                query.Append($"               WHEN 'TR' THEN '{ SqlDatabaseObjectType.Trigger }'             ").Append(Environment.NewLine);
                query.Append($"               WHEN 'FN' THEN '{ SqlDatabaseObjectType.ScalarFunction }'      ").Append(Environment.NewLine);
                query.Append($"               WHEN 'IS' THEN '{ SqlDatabaseObjectType.ScalarFunction }'      ").Append(Environment.NewLine);
                query.Append($"               WHEN 'V'  THEN '{ SqlDatabaseObjectType.View }'                ").Append(Environment.NewLine);
                query.Append($"               WHEN 'TF' THEN '{ SqlDatabaseObjectType.TableFunction }'       ").Append(Environment.NewLine);
                query.Append($"               WHEN 'IF' THEN '{ SqlDatabaseObjectType.TableFunction }'       ").Append(Environment.NewLine);
                query.Append($"               ELSE '{ SqlDatabaseObjectType.Unknown }'                       ").Append(Environment.NewLine);
                query.Append("      END AS TYPE                                                      ").Append(Environment.NewLine);
                query.Append("  FROM                                                                 ").Append(Environment.NewLine);
                query.Append("      SYS.objects                                                      ").Append(Environment.NewLine);
                query.Append("  WHERE                                                                ").Append(Environment.NewLine);
                query.Append("      TYPE IN ('P', 'TR', 'TF', 'FN', 'V', 'IS', 'IF')                 ").Append(Environment.NewLine);
                query.Append("  ORDER BY                                                             ").Append(Environment.NewLine);
                query.Append("      TYPE                                                             ").Append(Environment.NewLine);
                
                using (SqlConnection connection = new SqlConnection(STRING_CONNECTION_TEMP))
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

                                objects.Add(new SqlDatabaseObject(reader["NAME"].ToString(), GetObjectBody(reader["NAME"].ToString()), convertedType));
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
    }
}

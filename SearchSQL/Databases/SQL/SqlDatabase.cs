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
            return string.Empty;
        }

        public IEnumerable<DatabaseObject> FindContentAndObjects(string word)
        {
            var objectsAndContents = new List<DatabaseObject>();

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
                                Enum.TryParse<DatabaseObjectType>(reader["TYPE"].ToString(), out var convertedType);

                                objectsAndContents.Add(new DatabaseObject(reader["NAME"].ToString(), GetObjectBody(reader["NAME"].ToString()), convertedType));
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return objectsAndContents;
        }

        public IEnumerable<DatabaseObject> GetObjectsFromDb()
        {
            var objects = new List<DatabaseObject>();

            try
            {   
                var query = new StringBuilder();

                query.Append("  SELECT                                                               ").Append(Environment.NewLine);
                query.Append("      NAME,                                                            ").Append(Environment.NewLine);
                query.Append($"     CASE TYPE WHEN 'P'  THEN '{ DatabaseObjectType.Procedure }'      ").Append(Environment.NewLine);                
                query.Append($"               WHEN 'TR' THEN '{ DatabaseObjectType.Trigger }'        ").Append(Environment.NewLine);
                query.Append($"               WHEN 'FN' THEN '{ DatabaseObjectType.ScalarFunction }' ").Append(Environment.NewLine);
                query.Append($"               WHEN 'IS' THEN '{ DatabaseObjectType.ScalarFunction }' ").Append(Environment.NewLine);
                query.Append($"               WHEN 'V'  THEN '{ DatabaseObjectType.View }'           ").Append(Environment.NewLine);
                query.Append($"               WHEN 'TF' THEN '{ DatabaseObjectType.TableFunction }'  ").Append(Environment.NewLine);
                query.Append($"               WHEN 'IF' THEN '{ DatabaseObjectType.TableFunction }'  ").Append(Environment.NewLine);
                query.Append($"               ELSE '{ DatabaseObjectType.Unknown }'                  ").Append(Environment.NewLine);
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
                                Enum.TryParse<DatabaseObjectType>(reader["TYPE"].ToString(), out var convertedType);

                                objects.Add(new DatabaseObject(reader["NAME"].ToString(), GetObjectBody(reader["NAME"].ToString()), convertedType));
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

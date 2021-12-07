using CSVExport.Common;
using CSVExport.Interface;
using CSVExport.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CSVExport.Implementation
{
    public class Database : IDatabase
    {
        public void SaveDatabase(List<AssessModel> records)
        {
            DataTable myDataTable = Operations.ToDataTable(records);

            string connectionString = @"Data Source = MUM-LAP-700230; Integrated Security=true; Initial Catalog=Assessment";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    foreach (DataColumn c in myDataTable.Columns)
                        bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);

                    bulkCopy.DestinationTableName = "AssessTable";
                    try
                    {
                        bulkCopy.WriteToServer(myDataTable);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}

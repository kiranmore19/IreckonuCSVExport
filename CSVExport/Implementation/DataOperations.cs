using CSVExport.Interface;
using CSVExport.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSVExport.Implementation
{
    public class DataOperations : IDataOperation
    {
        private IDatabase _database;
        private IJson _json;
        public DataOperations()
        {
            _database = new Database();
            _json = new Json();
        }

        public void PeformDataOperation(List<AssessModel> records)
        {
            _database.SaveDatabase(records);
            _json.SaveJson(records);
        }
    }
}

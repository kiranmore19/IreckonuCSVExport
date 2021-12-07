using CSVExport.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSVExport.Interface
{
    public interface IDatabase
    {
        void SaveDatabase(List<AssessModel> records);
    }
}

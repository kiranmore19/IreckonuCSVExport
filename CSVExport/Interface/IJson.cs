using CSVExport.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSVExport.Interface
{
    public interface IJson
    {
        void SaveJson(List<AssessModel> records);
    }
}

using CSVExport.Model;
using System.Collections.Generic;

namespace CSVExport.Interface
{
    public interface IDataOperation
    {
        public void PeformDataOperation(List<AssessModel> records);
    }
}
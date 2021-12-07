using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text;
using CsvHelper;
using CSVExport.Model;
using System.Globalization;
using CSVExport.Implementation;

namespace CSVExport.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CSVExportController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CSVExportController> _logger;
        private const int BATCHCOUNT = 100;

        public CSVExportController(ILogger<CSVExportController> logger)
        {
            _logger = logger;
        }

        [Route("ReadFile")]
        [HttpPost]
        public async Task<IActionResult> ReadFile(IFormFile file)
        {
            DataOperations dataOperation = new DataOperations();
            try
            {
                #region Variable Declaration
                var result = new StringBuilder();
                if (file == null || file.Length == 0)
                    throw new Exception("file should not be null");

                var records = new List<AssessModel>();
                using (var streamReader = new StreamReader(file.OpenReadStream()))
                {
                    using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                    {
                        //records = csvReader.GetRecords<AssessModel>().ToList();

                        while (csvReader.Read())
                        {
                            records.Add(csvReader.GetRecord<AssessModel>());

                            if (records.Count >= BATCHCOUNT)
                            {
                                dataOperation.PeformDataOperation(records);
                                records.Clear();
                            }

                            //LogHandler.LogEvent(data.Count().ToString());
                        }
                    }
                }

                //return records;

                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    while (!reader.EndOfStream)
                        result.AppendLine(await reader.ReadLineAsync());
                }


                    return Content("File uploaded");
                #endregion
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

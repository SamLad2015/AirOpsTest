using System;
using System.IO;
using System.Linq;
using AirOpsTest.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AirOpsTest.Repositories
{
    public class WriteRepository<T>: IWriteRepository<T> where T : class
    {
        private string _path;
        private string _delimiter;
        private IConfiguration _configuration;
        public WriteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _path = _configuration.GetValue<string>("StatusMessageLogging:FilePath");
            _delimiter = _configuration.GetValue<string>("StatusMessageLogging:FileDelimiter");
        }
        public void Insert(T obj)
        {
            using (StreamWriter sw = File.AppendText(_path))
            {
                foreach (var property in obj.GetType().GetProperties().OrderBy(p => p.Name))
                {
                    var value = property.GetValue(obj);
                    if (property.Name.Contains("Date"))
                    {
                        value = Convert.ToDateTime(property.GetValue(obj)).ToShortDateString();
                    }
                    sw.WriteLineAsync(property.Name + ": " + value);
                }
                sw.WriteLineAsync(_delimiter);
            }
        }
    }
}
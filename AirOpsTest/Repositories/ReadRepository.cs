using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using AirOpsTest.Entities;
using AirOpsTest.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AirOpsTest.Repositories
{
    public class ReadRepository<T>: IReadRepository<T> where T : BaseEntity
    {
        private string _path;
        private string _delimiter;
        private IConfiguration _configuration;
        public ReadRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _path = _configuration.GetValue<string>("StatusMessageLogging:FilePath");
            _delimiter = _configuration.GetValue<string>("StatusMessageLogging:FileDelimiter");
        }
        public async Task<IList<string>> GetAll()
        {
            using (StreamReader sr = File.OpenText(_path))
            {
                List<string> messages = new List<string>();
                var logMessage = "";
                var s = "";
                while ((s = await sr.ReadLineAsync()) != null)
                {
                    if (s == _delimiter)
                    {
                        messages.Add(logMessage);
                        logMessage = "";
                    }
                    else
                    {
                        logMessage = $"{logMessage} {s}";
                    }
                }
                return messages;
            }
        }
    }
}
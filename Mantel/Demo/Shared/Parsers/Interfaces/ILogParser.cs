using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Parsers.Interfaces
{
    public interface ILogParser
    {
        LogItem Parse(string rawStringLog);
    }
}

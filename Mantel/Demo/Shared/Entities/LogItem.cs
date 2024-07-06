using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public abstract class LogItem
    {
        public LogItem(string rawStringLog)
        {
            RawStringLog = rawStringLog;
        }

        public string RawStringLog { get; private set; }
    }
}

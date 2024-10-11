using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class Log
    {
        public long IdLog { get; set; }
        public long IdUser { get; set; }
        public string Ip { get; set; }
        public DateTime InsertDate { get; set; }
        public string Message { get; set; }
        public string LogType { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}

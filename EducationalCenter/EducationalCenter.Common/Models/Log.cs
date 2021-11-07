using EducationalCenter.Common.Enums;
using System;

namespace EducationalCenter.Common.Models
{
    public class Log
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string MessageTemplate { get; set; }

        public string Level { get; set; }

        public DateTimeOffset TimeStamp { get; set; }

        public string Exception { get; set; }

        public string Properties { get; set; }

        public int? UserId { get; set; }

        public string UserName { get; set; }

        public LogType LogType { get; set; }

        public string IP { get; set; }
    }
}

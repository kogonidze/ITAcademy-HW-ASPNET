using EducationalCenter.Common.Enums;
using System;

namespace EducationalCenter.Common.Dtos.Log
{
    public class LogDto
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string UserName { get; set; }

        public string Ip { get; set; }

        public LogType LogType { get; set; }

        public DateTime LogDate { get; set; }
    }
}

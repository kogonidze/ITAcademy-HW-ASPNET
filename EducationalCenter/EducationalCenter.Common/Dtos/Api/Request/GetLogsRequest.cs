using EducationalCenter.Common.Enums;
using System;

namespace EducationalCenter.Common.Dtos.Api.Request
{
    public class GetLogsRequest
    {
        public string SortField { get; set; }

        public int? SortOrder { get; set; }

        public int? Page { get; set; }

        public int? PageSize { get; set; }

        public string GlobalFilter { get; set; }

        public LogType? LogType { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}

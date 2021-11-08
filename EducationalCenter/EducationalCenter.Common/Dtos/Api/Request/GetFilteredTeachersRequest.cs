using EducationalCenter.Common.Enums;

namespace EducationalCenter.Common.Dtos.Api.Request
{
    public class GetFilteredTeachersRequest
    {
        public string FIO { get; set; }

        public int? Experience { get; set; }

        public Formation? Formation { get; set; }

        public Category? Category { get; set; }

        public int? Page { get; set; }

        public int? PageSize { get; set; }
    }
}

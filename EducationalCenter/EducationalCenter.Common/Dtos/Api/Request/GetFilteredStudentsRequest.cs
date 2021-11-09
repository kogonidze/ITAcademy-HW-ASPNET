namespace EducationalCenter.Common.Dtos.Api.Request
{
    public class GetFilteredStudentsRequest
    {
        public string FIO { get; set; }

        public int? GroupId { get; set; }

        public int? Page { get; set; }

        public int? PageSize { get; set; }
    }
}

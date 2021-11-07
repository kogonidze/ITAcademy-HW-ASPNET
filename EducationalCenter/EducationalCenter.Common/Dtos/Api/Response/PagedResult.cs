using System.Collections.Generic;

namespace EducationalCenter.Common.Dtos.Api.Response
{
    public class PagedResult<TData>
    {
        public IEnumerable<TData> Data { get; set; }

        public int CountAllDocuments { get; set; }

        public PagedResult()
        {
            Data = new List<TData>();
        }
    }
}

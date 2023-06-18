using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.dtos.common
{
    public class FillterDto
    {
        private string _keyword;

        [FromQuery(Name = "keyword")]
        public string Keyword
        {
            get => _keyword;
            set => _keyword = value?.Trim();
        }

        [FromQuery(Name = "pageSize")]
        public int PageSize { get; set; }

        [FromQuery(Name = "pageIndex")]
        public int PageIndex { get; set; }

        public int Skip()
        {
            return (PageIndex - 1) * PageSize;
        }
    }
}

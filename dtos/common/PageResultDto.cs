namespace WebApplication1.dtos.common
{
    public class PageResultDto<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalItem { get; set; }
    }
}

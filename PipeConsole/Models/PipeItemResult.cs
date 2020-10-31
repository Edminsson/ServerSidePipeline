namespace PipeConsole.Models
{
    class PipeItemResult
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public ErrorResult ErrorResult { get; set; }
    }
}

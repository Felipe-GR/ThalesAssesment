namespace ThalesAssesment.Model.Entities
{
    public class HttpWrapper<T>
    {
        public string? Status { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
    }
}

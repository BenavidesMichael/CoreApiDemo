namespace CoreApiDemo.Models
{
    public class ApiResoponse<T>
    {
        public T Data { get; set; }
        public string[] Errors { get; set; }
    }
}

namespace MovieFinder.Client.Services
{
    public class ServiceResult<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
    }
}

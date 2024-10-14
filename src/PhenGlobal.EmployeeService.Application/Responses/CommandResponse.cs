namespace PhenGlobal.EmployeeService.Application.Responses
{
    public class CommandResponse<T>
    {
        public bool Success {  get; set; } = true;
        public string Message { get; set; } = default!;
        public List<string> Errors { get; set; } = new();
        public T Data { get; set; } = default!;
    }
}
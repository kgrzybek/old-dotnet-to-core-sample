namespace NETFramework.App
{
    public class RequestDto
    {
        public RequestDto(string type, string data)
        {
            Type = type;
            Data = data;
        }

        public string Type { get; }

        public string Data { get; }
    }
}
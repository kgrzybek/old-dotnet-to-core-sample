using NETCore.App.Contracts;
using Newtonsoft.Json;
using RestSharp;

namespace NETFramework.App
{
    public class NewAppGateway : INewAppGateway
    {
        private readonly string _backendBaseUrl;

        private readonly IUserContext _userContext;

        public NewAppGateway(string backendBaseUrl, IUserContext userContext)
        {
            _backendBaseUrl = backendBaseUrl;
            _userContext = userContext;
        }

        public void ExecuteCommand(ICommand command)
        {
            RestClient client = new RestClient(_backendBaseUrl);

            var type = command.GetType().FullName;
            var data = JsonConvert.SerializeObject(command);
            var request = CreateRequest("api/commands", type, data);

            client.Execute(request);
        }

        public T ExecuteCommand<T>(ICommand<T> command) where T : class, new()
        {
            RestClient client = new RestClient(_backendBaseUrl);

            var type = command.GetType().FullName;
            var data = JsonConvert.SerializeObject(command);
            var request = CreateRequest("api/commands-with-result", type, data);

            var response = client.Execute<T>(request);

            return response.Data;
        }

        public T ExecuteQuery<T>(IQuery<T> query) where T : class, new()
        {
            var client = new RestClient(_backendBaseUrl);

            var type = query.GetType().FullName;
            var data = JsonConvert.SerializeObject(query);
            var request = CreateRequest("api/queries", type, data);

            var response = client.Execute<T>(request);

            return response.Data;
        }

        private IRestRequest CreateRequest(string resource, string type, string data)
        {
            IRestRequest request = new RestRequest(resource, Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new CustomJsonSerializer();
            if (_userContext.UserId.HasValue)
            {
                request.AddHeader(HttpHeaderKeys.AuthorizationUserIdKey, _userContext.UserId.ToString());
            }

            var requestDto = new RequestDto(type, data);
            request.AddBody(requestDto);

            return request;
        }
    }
}
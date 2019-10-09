using System.Threading.Tasks;

namespace FluentMediator
{
    public interface IAsyncPipelineMediator
    {
        Task PublishAsync(object request);
        Task<Response> SendAsync<Response>(object request);
    }
}
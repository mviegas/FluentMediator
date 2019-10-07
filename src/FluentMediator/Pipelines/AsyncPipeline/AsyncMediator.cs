using System;
using System.Threading.Tasks;

namespace FluentMediator
{
    public partial class Mediator : IAsyncPipelineMediator
    {
        public PipelineCollection<IAsyncPipeline> AsyncPipelineCollection { get; }

        public async Task PublishAsync<Request>(Request request)
        {
            if (AsyncPipelineCollection.Contains<Request>(out var asyncPipeline))
            {
                await asyncPipeline?.PublishAsync(request!) !;
            }
        }

        public async Task<Response> SendAsync<Response>(object request)
        {
            if (AsyncPipelineCollection.Contains(request.GetType(), out var asyncPipeline))
            {
                if (!(asyncPipeline is null))
                {
                    return await asyncPipeline.SendAsync<Response>(request!) !;
                }
            }

            throw new Exception("Send Pipeline Not Found.");
        }
    }
}
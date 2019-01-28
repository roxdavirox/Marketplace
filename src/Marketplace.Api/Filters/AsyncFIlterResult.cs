using Marketplace.App.Notifications;
using Marketplace.Infra.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace Marketplace.Api.Filters
{
    public class AsyncFilterResult : IAsyncResultFilter
    {

        private readonly NotificationContext _notificationContext;
        private readonly IUnitOfWork _uow;
        
        public AsyncFilterResult(NotificationContext notificationContext, IUnitOfWork uow)
        {
            _notificationContext = notificationContext;
            _uow = uow;
        }

        public async Task OnResultExecutionAsync(
            ResultExecutingContext context, ResultExecutionDelegate next
            )
        {
            if(_notificationContext.HasNotifications)
            {
                context.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                var notifications = JsonConvert.SerializeObject(_notificationContext.Notifications);

                await context.HttpContext.Response.WriteAsync(notifications);

                return;
            }

            await _uow.CommitAsync();

            await next();
        }
    }
}

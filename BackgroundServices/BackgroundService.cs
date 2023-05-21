using System;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reservation.Services;


namespace Reservation.BackgroundServices
{
    public class RequestProcessingService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public RequestProcessingService(IServiceScopeFactory serviceScopeFactory) : base()
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var requestService = scope.ServiceProvider.GetService<IRequestService>();
                var notificationService = scope.ServiceProvider.GetService<INotificationService>();
                                
                Console.WriteLine("Request processing is starting.");
                
                stoppingToken.Register(() => Console.WriteLine("Request processing service is stopping."));

                while (!stoppingToken.IsCancellationRequested)
                {
                    var requests = requestService.ListAsync().Result;                    
                    Console.WriteLine($"The number of requests: {requests.Count()}");

                    foreach (var request in requests)
                    {
                        var message = $"Processing of request #{request.Id} has started.";
                        Console.WriteLine(message);
                        var notification = notificationService.AddAsync(request.HolderId, message).Result;
                    }
                    await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
                }

                Console.WriteLine("Request processing service background task is stopping.");
            }
            
        }
    }
}
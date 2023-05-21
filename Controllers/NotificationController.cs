using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Reservation.Services;

namespace Reservation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        
        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;   
        }

        [HttpGet]
        public async Task<IEnumerable<Notification>> GetAllAsync()
        {
            return await _notificationService.ListAsync();;
        }
    }
}

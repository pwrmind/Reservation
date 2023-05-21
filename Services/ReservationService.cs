using System;
using System.Collections.Generic;
using System.Linq;

namespace Reservation.Services
{
    public class ReservationService
    {
        private readonly ResourceService _resourceService;
        private readonly LogRecordService _logRecordService;

        public ReservationService(ResourceService rs, LogRecordService lrs)
        {
            _resourceService = rs;
            _logRecordService = lrs;
        }

    }
}
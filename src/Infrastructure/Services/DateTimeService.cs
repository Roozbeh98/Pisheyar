using Pisheyar.Application.Common.Interfaces;
using System;

namespace Pisheyar.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}

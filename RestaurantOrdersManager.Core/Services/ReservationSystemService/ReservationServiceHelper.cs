using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.Services.ReservationSystemService
{
    public class ReservationServiceHelper
    {
        private readonly ILogger<ReservationServiceHelper> _logger;
        public ReservationServiceHelper(ILogger<ReservationServiceHelper> logger)
        {
            _logger = logger;
        }
        public string GenerateVerificationCode()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXY";
            var stringChars = new char[4];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var verificationCode = new string(stringChars);

            _logger.LogInformation($"Added cache entry with code: {verificationCode}");

            return verificationCode;
        }
        public List<(DateTime, DateTime)> Generate15minuteSlots(DateTime startTime, DateTime endTime)
        {
            List<(DateTime, DateTime)> slotsList = new List<(DateTime, DateTime)>();

            for (var slotStart = startTime; slotStart < endTime; slotStart = slotStart.AddMinutes(15))
            {
                var slotEnd = slotStart.AddMinutes(15);
                slotsList.Add((slotStart, slotEnd));
            }

            return slotsList;
        }
        public DateTime RoundUpTime(DateTime dateTime, bool roundUp)
        {
            int quarterHour = 15;
            int minutes = dateTime.Minute;
            int roundedMinutes;

            if (roundUp)
            {
                roundedMinutes = minutes / quarterHour * quarterHour;
            }
            else
            {
                roundedMinutes = (minutes / quarterHour + 1) * quarterHour;
                if (roundedMinutes == 60)
                {
                    roundedMinutes = 0;
                    dateTime = dateTime.AddHours(1);
                }
            }

            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, roundedMinutes, 0);
        }
    }
}

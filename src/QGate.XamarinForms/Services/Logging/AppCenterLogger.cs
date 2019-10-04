using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AppCenter.Analytics;
using QGate.Core.Logging;

namespace QGate.XamarinForms.Services.Logging
{
    public class AppCenterLogger<TSource> : ILogger<TSource>
    {
        public void Error(Exception exception, object data = null)
        {

            TrackError(null, exception, data);
        }

        public void Error(string message, object data = null)
        {
            TrackError(message, null, data);
        }

        public void Error(string message, Exception exception, object data = null)
        {
            TrackError(message, exception, data);
        }

        private void TrackError(string message, Exception exception, object data)
        {
            IDictionary<string, string> dataDictionary = null;
            if (data != null)
            {
                dataDictionary = new Dictionary<string, string>
                {
                    ["Data"] = JsonSerializer.Serialize(data)
                };
            }

            Analytics.TrackEvent(string.Concat("Error message:", message, " , Exception: ",  exception.ToString()), dataDictionary);

            //Currently does not support UWP
            //Crashes.TrackError(exception, dataDictionary);
        }
    }
}

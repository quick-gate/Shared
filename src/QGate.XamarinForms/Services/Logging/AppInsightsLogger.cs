using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using QGate.Core.Exceptions;
using QGate.Core.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace QGate.XamarinForms.Services.Logging
{
    public class AppInsightsLogger<TSource> : ILogger<TSource>
    {
        private readonly TelemetryClient _telemetryClient;

        public AppInsightsLogger(TelemetryConfiguration telemetryConfiguration)
        {
            Throw.IfNull(telemetryConfiguration, nameof(telemetryConfiguration));
            _telemetryClient = new TelemetryClient(telemetryConfiguration);
        }

        public void Error(Exception exception, object data = null)
        {
            Error(null, exception, data);
        }

        public void Error(string message, object data = null)
        {
            Error(message, null, data);
        }

        public void Error(string message, Exception exception, object data = null)
        {
            Exception resolvedException;
            if(string.IsNullOrWhiteSpace(message))
            {
                resolvedException = exception;
            }
            else
            {
                resolvedException = exception == null ? new ApplicationException(message) : new ApplicationException(message, exception);
            }

            if(resolvedException == null)
            {
                resolvedException = new ApplicationException("Unknown Error");
            }

            _telemetryClient.TrackException(resolvedException, GetDataAsDictionary(data));
        }

        public void Info(string message, object data = null)
        {
            _telemetryClient.TrackTrace(message, Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Information, GetDataAsDictionary(data));
        }

        private IDictionary<string, string> GetDataAsDictionary(object data)
        {
            if(data == null)
            {
                return null;
            }

            IDictionary<string, string> dataDictionary = null;
            if (data != null)
            {
                dataDictionary = new Dictionary<string, string>
                {
                    ["Data"] = JsonSerializer.Serialize(data)
                };
            }

            return dataDictionary;

        }
    }
}

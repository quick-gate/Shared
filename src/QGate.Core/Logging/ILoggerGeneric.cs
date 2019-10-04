namespace QGate.Core.Logging
{
    /// <summary>
    /// Logger
    /// </summary>
    /// <typeparam name="TSource">Determines class which will sending logs (source)</typeparam>
    public interface ILogger<TSource>: ILogger
    {
    }
}

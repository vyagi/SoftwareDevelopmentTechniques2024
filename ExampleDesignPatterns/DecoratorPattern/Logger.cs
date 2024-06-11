using MD5Hash;

namespace DecoratorPattern;

public interface ILogger
{
    string Log(string message);
}

public class SimpleLogger : ILogger
{
    public string Log(string message) => $"Information: {message}";
}

public class TimestampingLogger : ILogger
{
    ILogger _logger;

    public TimestampingLogger(ILogger logger) => _logger = logger;

    public string Log(string message) => $"{DateTime.Now:yyyy-MM-ddTHH:mm:ss}: {_logger.Log(message)}";
}

public class HashingLogger : ILogger
{
    ILogger _logger;

    public HashingLogger(ILogger logger) => _logger = logger;

    public string Log(string message) => Hash.GetMD5(_logger.Log(message));
}

public class EncryptingLogger : ILogger
{
    ILogger _logger;

    public EncryptingLogger(ILogger logger) => _logger = logger;

    public string Log(string message) => $"Encrypted: {_logger.Log(message)}";
}

//This approach leads to hell !
//public class TimestampingEncryptingLogger : Logger
//{
//    //You do your job here
//}

//public class EncryptingTimestampingLogger : Logger 
//{
//    //You do your job here
//}

//public class EncryptingLogger : Logger
//{
//    public override string Log(string message) => $"Encrypted: {base.Log(message)}";
//}

//public class HashingLogger : Logger
//{
//    public override string Log(string message) => MD5Hash.Hash.GetMD5(base.Log(message));
//}

//public class TimestampingLogger : Logger
//{
//    public override string Log(string message) => $"{DateTime.Now:yyyy-MM-ddTHH:mm:ss} {base.Log(message)}";
//}

//public class Logger
//{
//    public virtual string Log(string message) => $"Information: {message}";
//}


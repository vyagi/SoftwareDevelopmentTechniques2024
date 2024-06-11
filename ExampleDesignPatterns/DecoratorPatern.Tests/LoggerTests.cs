using DecoratorPattern;
using FluentAssertions;

namespace DecoratorPatern.Tests;
public class LoggerTests
{
    [Fact]
    public void Logger_logs_proper_message()
    {
        var logger = new SimpleLogger();

        var log = logger.Log("Something imporant happened");

        log.Should().Be("Information: Something imporant happened");
    }
    
    [Fact]
    public void TimestampingLogger_logs_proper_message()
    {
        var logger = new TimestampingLogger(new SimpleLogger());

        var log = logger.Log("Something imporant happened");

        log.Should().StartWith("2024-06-11"); //It's a crappy unit test (it will not work tomorrow), but for us it is enough
        log.Should().EndWith("Information: Something imporant happened");
    }

    [Fact]
    public void HashingLogger_logs_proper_message()
    {
        var logger = new HashingLogger(new SimpleLogger());

        var log = logger.Log("Something imporant happened");

        log.Should().NotBe("Information: Something imporant happened");//Again crappy test
    }

    [Fact]
    public void EncryptingLogger_logs_proper_message()
    {
        var logger = new EncryptingLogger(new SimpleLogger());

        var log = logger.Log("Something imporant happened");

        log.Should().StartWith("Encrypted:");//Again crappy test
    }

    [Fact]
    public void EncryptingTimestampingLogger_logs_proper_message()
    {
        var logger = new EncryptingLogger(new TimestampingLogger(new SimpleLogger()));

        var log = logger.Log("Something imporant happened");

        log.Should().StartWith("Encrypted:");//Again crappy test
    }

    [Fact]
    public void TimestampingEncryptingLogger_logs_proper_message()
    {
        var logger = new TimestampingLogger(new EncryptingLogger(new SimpleLogger()));

        var log = logger.Log("Something imporant happened");

        log.Should().StartWith("2024-06-11"); //It's a crappy unit test (it will not work tomorrow), but for us it is enough
        log.Should().EndWith("Information: Something imporant happened");
    }

    //    [Fact]
    //    public void EncryptingLogger_logs_proper_message()
    //    {
    //        var logger = new EncryptingLogger();

    //        var log = logger.Log("Something imporant happened");

    //        log.Should().StartWith("Encrypted:");//Again crappy test
    //    }

    //    [Fact]
    //    public void HashingLogger_logs_proper_message()
    //    {
    //        var logger = new HashingLogger();

    //        var log = logger.Log("Something imporant happened");

    //        log.Should().NotBe("Information: Something imporant happened");//Again crappy test
    //    }

    //    [Fact]
    //    public void TimestampingLogger_logs_proper_message()
    //    {
    //        var logger = new TimestampingLogger();

    //        var log = logger.Log("Something imporant happened");

    //        log.Should().StartWith("2024-06-11"); //It's a crappy unit test (it will not work tomorrow), but for us it is enough
    //        log.Should().EndWith("Information: Something imporant happened");
    //    }

    //    [Fact]
    //    public void Logger_logs_proper_message()
    //    {
    //        var logger = new Logger();

    //        var log = logger.Log("Something imporant happened");

    //        log.Should().Be("Information: Something imporant happened");
    //    }
}

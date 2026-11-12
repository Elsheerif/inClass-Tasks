using System;
using System.Collections.Generic;

// ISP: sending notifications and logging messages are separate
public interface INotificationChannel
{
    void Send(string message);
}
public interface IMessageLogger
{
    void Log(string message);
}
public class EmailChannel : INotificationChannel
{
    public void Send(string message)
    {
        Console.WriteLine("[Email] {0}", message);
    }
}
public class SmsChannel : INotificationChannel
{
    public void Send(string message)
    {
        Console.WriteLine("[SMS] {0}", message);
    }
}
public class FileLogger : IMessageLogger
{
    public void Log(string message)
    {
        Console.WriteLine("[Log] {0}", message);
    }
}
public class NotificationService
{
    private readonly INotificationChannel _channel;
    private readonly IMessageLogger _logger;

    // DIP: the service receives abstractions instead of creating concrete dependencies
    public NotificationService(INotificationChannel channel, IMessageLogger logger)
    {
        _channel = channel;
        _logger = logger;
    }

    public void Send(string message)
    {
        _channel.Send(message);
        _logger.Log(message);
    }
}

class NotificationProgram
{
    static void Main()
    {
        IMessageLogger logger = new FileLogger();
        List<INotificationChannel> channels = new List<INotificationChannel>
        {
            new EmailChannel(),
            new SmsChannel()
        };

        // Polymorphism selects each channel Send method through the interface,
        // so the service works with either channel without any if/else checks
        foreach (INotificationChannel channel in channels)
        {
            NotificationService service = new NotificationService(channel, logger);
            service.Send("Hello from Session 7!");
        }
    }
}

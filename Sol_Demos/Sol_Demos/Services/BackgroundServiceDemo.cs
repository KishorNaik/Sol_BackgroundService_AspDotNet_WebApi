namespace Sol_Demos.Services;

public class BackgroundServiceDemo : BackgroundService
{
    private readonly ILogger<BackgroundServiceDemo> _logger;

    public BackgroundServiceDemo(ILogger<BackgroundServiceDemo> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("BackgroundService is starting.");

        stoppingToken.Register(() =>
            _logger.LogInformation("BackgroundService is stopping."));

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("BackgroundService is doing background work.");

            // Simulate some background work
            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }

        _logger.LogInformation("BackgroundService has stopped.");
    }
}
using Newtonsoft.Json.Linq;

namespace AdapterPattern;

//Let's imagine that we've found some better Thermometer in the nuget packages.

public class InternetThermometer //we cannot change this class
{
    private static readonly HttpClient Client = new();

    public InternetThermometer() => Client.BaseAddress = new Uri("http://api.openweathermap.org/");

    public string Themperature =>
        ((dynamic)JObject.Parse(Client.GetAsync("data/2.5/weather?q=Rzeszow&appid=ccef0127848996431ec751a199c5f956")
            .Result.Content.ReadAsStringAsync()
            .Result))["main"]["temp"];
}

//The clue - THE ADAPTER WHICH WILL ADJUST INCOMPATIBLE InternetThermometer TO FIT INTO IThermometer
public class InternetThermometerAdapter : IThermometer
{
    private InternetThermometer _thermometer;

    public InternetThermometerAdapter(InternetThermometer thermometer) => _thermometer = thermometer;

    public double GetTemperature() => double.Parse(_thermometer.Themperature.Replace(".", ",")) - 273.15;
}

public class WeatherConditionsDetector
{
    IThermometer _thermometer;

    public WeatherConditionsDetector(IThermometer thermometer) => _thermometer = thermometer;

    public Decision Detect() => _thermometer.GetTemperature() switch
    {
        < 5 => Decision.TooCold,
        > 25 => Decision.TooHot,
        _ => Decision.JustRight
    };
}

public class MercuryThermometer : IThermometer
{
    private readonly Random Randomizer = new Random();

    public double GetTemperature() => Randomizer.NextDouble() * 100 - 50;
}

public interface IThermometer
{
    double GetTemperature();
}

public enum Decision
{
    TooCold,
    TooHot,
    JustRight
}
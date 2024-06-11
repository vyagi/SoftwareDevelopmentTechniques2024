using AdapterPattern;

//var detector = new WeatherConditionsDetector(new MercuryThermometer());
//Console.WriteLine(detector.Detect());

var detector = new WeatherConditionsDetector(new InternetThermometerAdapter(new InternetThermometer()));

Console.WriteLine(detector.Detect());

//FAVOUR COMPOSITION OVER INHERITANCE
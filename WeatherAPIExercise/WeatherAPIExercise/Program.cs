using Newtonsoft.Json.Linq;

namespace WeatherAPIExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();


            //Take API key
            //Console.WriteLine("Please enter your key:");
            //Console.ReadLine();
            var apiKey = "a72a8e95c813f97a891610d899110159";
            //Take city input
            //Console.WriteLine("For which city would you like to see the local weather?");
            //Console.ReadLine();
            var city = "Mooresville";

            //URL for OpenWeather 
            //Includes usage of Imperial units, uses city and apiKey variables
            var openWeatherUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=imperial&appid={apiKey}";


            //Stores response in a local variable
            var weatherResponse = client.GetStringAsync(openWeatherUrl).Result;
            //Formats weatherResponse to a string we can parse for the temperature value
            var formattedResponse = JObject.Parse(weatherResponse).GetValue("main").ToString();

            Console.WriteLine($"Current air temperature in {city}: {JObject.Parse(formattedResponse).GetValue("temp")} degrees (Fahrenheit).");
        }
    }
}
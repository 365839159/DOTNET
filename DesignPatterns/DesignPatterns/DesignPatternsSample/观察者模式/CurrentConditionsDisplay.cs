using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.观察者模式
{
    public class CurrentConditionsDisplay : DisplayElement, Observer
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
        public Subject WeatherData { get; set; }
        public CurrentConditionsDisplay(Subject subject)
        {
            this.WeatherData = subject;
            subject.RegisterObserver(this);
        }
        public void Display()
        {
            Console.WriteLine($"当前温度 {Temperature}，湿度{Humidity}");
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            this.Temperature = temperature;
            this.Humidity = humidity;
            this.Pressure = pressure;
            Display();
        }
    }
}

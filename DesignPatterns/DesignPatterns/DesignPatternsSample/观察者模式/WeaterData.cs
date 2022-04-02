using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsSample.观察者模式
{
    public class WeaterData : Subject
    {
        List<Observer> observers = null;

        public WeaterData()
        {
            this.observers = new List<Observer>();
        }

        public double Temperature { get; set; }//温度
        public double Humidity { get; set; }//湿度
        public double Pressure { get; set; }//气压

        public void NotifyObserver()
        {
            foreach (var observer in observers)
            {
                observer.Update(Temperature, Humidity, Pressure);
            }
        }

        public void RegisterObserver(Observer observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(Observer observer)
        {
            observers.Remove(observer);
        }

        private void MeasurementsChanged()
        {
            NotifyObserver();
        }

        public void SetMeasurements(double temperature, double humidity, double pressure)
        {
            this.Temperature = temperature;
            this.Humidity = humidity;
            this.Pressure = pressure;
            MeasurementsChanged();
        }

    }
}

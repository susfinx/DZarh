namespace MyFirstWebApplication.Models
{
    /// <summary>
    /// Объект на базе класса WeatherForecastHolder будет хранить список показателей по температуре
    /// </summary>
    public class WeatherForecastHolder
    {
        //private static WeatherForecastHolder _instance;

        //public static WeatherForecastHolder Instance()
        //{
        //    if (_instance == null)
        //        _instance = new WeatherForecastHolder();
        //    return _instance;
        //}

        // Коллекция для хранения показателей по температуре
        private List<WeatherForecast> _values;


        public WeatherForecastHolder()
        {
            _values = new List<WeatherForecast>();
        }

        /// <summary>
        /// Добавить новый показатель по температуре
        /// </summary>
        /// <param name="date"></param>
        /// <param name="temperatureC"></param>
        public bool Add(DateTime date, int temperatureC)
        {
            WeatherForecast forecast = new WeatherForecast();
            forecast.TemperatureC = temperatureC;
            forecast.Date = date;
            _values.Add(forecast);
            return true;
        }

        /// <summary>
        /// Обновить показатель по температуре
        /// </summary>
        /// <param name="date"></param>
        /// <param name="temperatureC"></param>
        /// <returns></returns>
        public bool Update(DateTime date, int temperatureC)
        {
            foreach (WeatherForecast forecast in _values)
            {
                if (forecast.Date == date)
                {
                    forecast.TemperatureC = temperatureC;
                    return true;
                }
            }
            return false;
        }

        //public bool Delete()
        //{

        //}

        /// <summary>
        /// Получить показатели по температуре за период
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public List<WeatherForecast> Get(DateTime from, DateTime to)
        {
            List<WeatherForecast> resultList = new List<WeatherForecast>();
            foreach (WeatherForecast forecast in _values)
            {
                if (forecast.Date >= from && forecast.Date <= to)
                {
                    resultList.Add(forecast);
                }
            }
            return resultList;
        }

        /// <summary>
        /// Удалить показатель по температуре
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool Delete(DateTime date)
        {
            WeatherForecast forecastToRemove = _values.FirstOrDefault(f => f.Date == date);

            if (forecastToRemove != null)
            {
                _values.Remove(forecastToRemove);
                return true;
            }
            else
            {
                return false; // Возвращаем false, если элемент для удаления не найден.
            }
        }

    }
}

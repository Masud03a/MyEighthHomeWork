
using System;

namespace Task_1
{
    class Converter
    {
        public enum Exchange
        {
            USD,  
            EUR, 
            RUB
        }
        private double UsdCourse = 0.0;

        private double EurCourse = 0.0;

        private double RubCourse = 0.0;

        public double TjsCourseRUB { get; set; }

        public double TjsCourseEUR { get; set; }

        public double TjsCourseUSD { get; set; }

        private Converter(double _usd, double _eur, double _rub)
        {
            UsdCourse = _usd;
            EurCourse = _eur;
            RubCourse = _rub;
        }

        public double TransformToTJS(double _tjs, Exchange exchange)
        {
            switch (exchange)
            {
                case Exchange.EUR:
                return _tjs * EurCourse;
                case Exchange.RUB:
                return _tjs * RubCourse;
                case Exchange.USD:
                return _tjs * UsdCourse;
                default:
                return 0.0f;
            }
        }

        public double TransformTJSTo(double _money, Exchange exchange)
        {
            switch (exchange)
            {
                case Exchange.EUR:
                return _money * TjsCourseEUR;
                case Exchange.RUB:
                return _money * TjsCourseRUB;
                case Exchange.USD:
                return _money * TjsCourseUSD;
                default:
                return 0.0f;
            }
        }

    }
    class ProgramConsole
    {
        static double ReadDouble()
        {
            return Transform.ToDouble(Console.ReadLine().Replace(".", ","));
        }
        static void Main(string[] args)
        {
            string menu = "Меню:\n 1 - Конвертация Таджитского сомони в (EUR, USD, RUB)\n" + 
                          "2 - Тоже самое, только Наоборот!!!\n" + 
                          "Выход - Закрыть программу";
            Converter convert = new Converter(10.23, 11.05, 0.14);
            convert.TjsCourseEUR = 0.09;
            convert.TjsCourseUSD = 0.099;
            convert.TjsCourseRUB = 7.48;
            Console.WriteLine(menu);
            string _cmd = String.Empty;
            while(_cmd != "Выход")
            {
               _cmd = Console.ReadLine();
               switch (_cmd)
               {
                   case "1":
                   {
                        Console.WriteLine("Таджитский Сомони в (выберите одну из приведённых валют: EUR, USD, RUB): ");
                        string exchStr = Console.ReadLine().ToUpper();
                        Console.WriteLine("Введите сомони: ");
                        double _tjsMoney = ReadDouble();
                        if(echStr == "EUR")
                            Console.WriteLine($"{_tjsMoney} сомони в {exchStr} = " + convert.TransformTJSTo(_tjsMoney, Converter.Exchange.EUR));
                        else if(exchStr == "USD")
                            Console.WriteLine($"{_tjsMoney} сомони в {exchStr} = " + convert.TransformTJSTo(_tjsMoney, Converter.Exchange.USD));
                        else if(exchStr == "RUB")
                            Console.WriteLine($"{_tjsMoney} сомони в {exchStr} = " + convert.TransformTJSTo(_tjsMoney, Converter.Exchange.RUB));
                        Console.WriteLine(menu);
                   }
                   break;
                   case "2":
                   {
                        Console.WriteLine("(Введите одну из приведённых валют: EUR, USD, RUB) в Таджитских Сомони: ");
                        string exchStr = Console.ReadLine().ToUpper();
                        Console.WriteLine("Введите счёт: ");
                        double _fullMoney = ReadDouble();
                        if(exchStr == "EUR")
                            Console.WriteLine($"{_fullMoney} {exchStr} в сомони = " + convert.TransformToTJS(_fullMoney, Converter.Exchange.EUR));
                        else if(exchStr == "USD")
                            Console.WriteLine($"{_fullMoney} {exchStr} в сомони = " + convert.TransformToTJS(_fullMoney, Converter.Exchange.USD));
                        else if(exchStr == "RUB")
                            Console.WriteLine($"{_fullMoney} {exchStr} в сомони = " + convert.TransformToTJS(_fullMoney, Converter.Exchange.RUB));
                        Console.WriteLine(menu);
                   }
                   break;
               }
            }
        }
    }
}

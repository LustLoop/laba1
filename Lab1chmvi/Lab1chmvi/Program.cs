using System;

namespace Lab1chmvi
{
    class Program
    {
        public static double Calc(string f, double x0)
        {
            string x = Convert.ToString(x0);
            string newstr = f.Replace("x", "(" + x + ")");
            MathParser.Parser p = new MathParser.Parser();
            p.Evaluate(newstr);
            return p.Result;
        }
        static void Main(string[] args)
        {
            string result = "";
            double eps = 0.01;
            Console.WriteLine("Введiть функцiю");
            string func = Console.ReadLine();
            Console.WriteLine("Введiть межi");
            int bord1 = Convert.ToInt32(Console.ReadLine());
            int bord2 = Convert.ToInt32(Console.ReadLine());
            for (double i = bord1; i <= bord2; i += eps)
            {
                double fx0 = Calc(func, i);
                double fx1 = Calc(func, (i + eps));
                double dfx0 = (Calc(func, (i + eps)) - fx0) / eps;
                double dfx1 = (Calc(func, (i + eps + eps)) - fx1) / eps;
                if (fx0 * fx1 < 0 && dfx0 * dfx1 > 0)
                {
                    double locfx0 = i;
                    if (Math.Abs(locfx0) < eps)
                    {
                        result += " " + Convert.ToString(Math.Round(i, 5));
                        continue;
                    }
                    int locvar = 0;
                    while (!(Math.Abs(Calc(func, locfx0)) < eps || locvar == 10))
                    {
                        locvar++;
                        locfx0 = locfx0 - (Calc(func, locfx0) / ((Calc(func, locfx0 + eps) - Calc(func, locfx0)) / eps));
                    }
                    result += " " + Convert.ToString(Math.Round(locfx0, 5));
                    continue;
                }
            }
            Console.WriteLine("Коренi:" + result);
        }
    }
}
//(x^4-1)/x^3
using System.Numerics;

namespace _3_11_2022_WebAPI.Services
{
    public static class CalculationsService
    {
        public static long LCM1ToNumber(int number)
        {
            if (number < 3)
                return number;

            return FindLCM(number, number - 1);
        }

        public static long Hcf(long a, long b)
        {
            if (b == 0)
                return a;

            return Hcf(b, a % b);
        }

        public static long FindLCM(long a, long b)
        {
            if (b == 1)
                return a;

            a = (a * b) / Hcf(a, b);
            b -= 1;
            
            return FindLCM(a, b);
        }
    }
}

using System;

namespace BTTH1_Bai02

{
    class Program
    {
        static void Main(string[] args)
        {
            //Nhap n
            Console.Write("Nhap n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            // Tinh tong cac so la so nguyen to
            int sum = 0;
            for ( int i = 2; i < n; i++)
            {
                if (LaSnt(i))
                    sum += i;
            }

            // Xuat ra man hinh
            Console.WriteLine("Tong cac so nguyen to nho hon " + n + " la: " + sum);
        }

        // Kiem tra co phai la so nguyen to khong
        static bool LaSnt(int n)
        {
            if (n < 2)
                return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0)
                    return false;
            return true;
        }
    }
}
using System;

namespace BTTH1_Bai01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nhap n
            Console.Write("Nhap so phan tu cua mang: ");
            int n = Convert.ToInt32(Console.ReadLine());

            // Tao mang ngau nhien
            int[] a = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
                a[i] = rand.Next(-50, 50 + 1);

            // In mang
            Console.Write("Cac phan tu trong mang: ");
            foreach (int i in a)
                Console.Write(i + " ");

            // a) Tinh tong cac so le
            Console.WriteLine("\nTong cac so le trong mang: " + TongSoLe(a));

            // b) Dem so nguyen to trong mang
            Console.WriteLine("So luong so nguyen to trong mang: " + DemSnt(a));

            // c) Tim so chinh phuong nho nhat
            if (SoChinhPhuongMin(a) == -1)
                Console.WriteLine("Khong ton tai so chinh phuong");
            else
                Console.WriteLine("So chinh phuong nho nhat: " + SoChinhPhuongMin(a));
        }

        // Tinh tong cac so le
        static int TongSoLe(int[] a)
        {
            int sum = 0;
            foreach (int i in a)
                if (i % 2 != 0)
                    sum += i;
            return sum;
        }

        // Kiem tra mot so co la so nguyen to
        static bool LaSnt(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0)
                    return false;
            return true;
        }

        // Dem so luong so nguyen to
        static int DemSnt(int[] a)
        {
            int count = 0;
            foreach (int i in a)
                if (LaSnt(i))
                    ++count;
            return count;
        }

        // Tim so chinh phuong nho nhat
        static int SoChinhPhuongMin(int[] a)
        {
            int value = -1;
            foreach (int i in a)
            {
                int x = (int)Math.Sqrt(i);
                if (x * x == i)
                {
                    if (value == -1)
                        value = i;
                    else
                        value = Math.Min(value, i);
                }
            }
            return value;
        }
    }
}
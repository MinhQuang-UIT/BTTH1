using System;
using System.Runtime.ExceptionServices;
using System.Xml.Serialization;

namespace BTTH1_Bai06
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nhap so dong, so cot
            Console.Write("Nhap so dong cua ma tran: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Nhap so cot cua ma tran: ");
            int m = int.Parse(Console.ReadLine());
            if ( m < 1 || n < 1)
            {
                Console.WriteLine("Khong the tao duoc ma tran!");
                return;
            }

            // Tao ma tran ngau nhien
            int[,] a = new int[n, m];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = rand.Next(-100, 100 + 1);
                }
            }
            // Xuat ma tran
            Console.WriteLine("Ma tran: "); Output(a, n, m);

            // Tim phan tu lon nhat
            Console.WriteLine("Phan tu lon nhat cua ma tran la: " + PhanTuMax(a, n, m));

            // Tim phan tu nho nhat
            Console.WriteLine("Phan tu nho nhat cua ma tran la: " + PhanTuMin(a, n, m));

            // Tim dong co tong lon nhat
            Console.WriteLine("Dong co tong lon nhat la: " + DongCoTongMax(a, n, m));

            // Tinh tong cac so khong la so nguyen to
            Console.WriteLine("Tong cac so khong phai so nguyen to cua ma tran: " + TongCacSoKhongLaSnt(a, n, m));
            // Xoa dong thu k trong ma tran

            Console.Write("Nhap dong can xoa( 0 < k <= n ): ");
            int k = int.Parse(Console.ReadLine());
            XoaDongThuK(a, n, m, k);

            // Xoa cot chua phan tu lon nhat trong ma tran
            XoaCotThuCoPhanTuMax(a, n, m); 
        }

        // Xuat ma tran
        static void Output(int[,] a, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(a[i, j] + " ");
                Console.Write("\n");
            }
        }

        // Tim phan tu lon nhat 
        static int PhanTuMax(int[,] a, int n, int m)
        {
            int value = a[0, 0];
            foreach (int i in a)
                value = Math.Max(value, i);
            return value;
        }

        // Tim phan tu nho nhat 
        static int PhanTuMin(int[,] a, int n, int m)
        {
            int value = a[0, 0];
            foreach (int i in a)
                value = Math.Min(value, i);
            return value;
        }

        // Tim dong co tong lon nhat 
        static int DongCoTongMax(int[,] a, int n, int m)
        {
            int idx = 0, summax = 0;
            for (int j = 0; j < m; j++)
                summax += a[0, j];
            for (int i = 1; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < m; j++)
                    sum += a[i, j];
                if (sum > summax)
                {
                    summax = sum;
                    idx = i;
                }
            }
            return idx + 1;
        }

        // Kiem tra co phai la so nguyen to
        static bool LaSnt(int n)
        {
            if (n < 2)
                return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        // Tinh tong cac so khong phai la so nguyen to
        static int TongCacSoKhongLaSnt(int[,] a, int n, int m)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    if (!LaSnt(a[i, j]))
                        sum += a[i, j];
            }
            return sum;
        }

        // Xoa dong thu k trong ma tran
        static void XoaDongThuK(int[,] a, int n, int m, int k)
        {
            if (k < 1 || k > n)
            {
                Console.WriteLine("Khong the xoa duoc!");
                return;
            }
            int[,] arr = new int[n - 1, m];
            for (int i = 0; i < k - 1; i++)
                for (int j = 0; j < m; j++)
                    arr[i, j] = a[i, j];
            for (int i = k - 1; i < n - 1; i++)
            {
                for (int j = 0; j < m; j++)
                    arr[i, j] = a[i + 1, j];
            }
            Console.WriteLine("Ma tran sau khi xoa dong thu " + k + ": ");
            Output(arr, n - 1, m);
        }

        // Tim vi tri cot chua phan tu lon nhat
        static int CotMax(int[,] a, int n, int m)
        {
            int idx = 0, value = a[0, 0];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    if (a[j, i] > value)
                    {
                        value = a[j, i];
                        idx = i;
                    }
            }
            return idx + 1;
        }

        // Xoa cot chua phan tu lon nhat trong ma tran
        static void XoaCotThuCoPhanTuMax(int[,] a, int n, int m)
        {
            int k = CotMax(a, n, m);
            int[,] arr = new int[n, m - 1];
            for (int i = 0; i < k - 1; i++)
                for (int j = 0; j < n; j++)
                    arr[j, i] = a[j, i];
            for (int i = k - 1; i < m - 1; i++)
            {
                for (int j = 0; j < n; j++)
                    arr[j, i] = a[j, i + 1];
            }
            Console.WriteLine("Ma tran sau khi xoa cot chua phan tu max: ");
            Output(arr, n, m - 1);
        }
    }
}




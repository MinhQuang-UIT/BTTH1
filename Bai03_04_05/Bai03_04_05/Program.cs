using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BTTH1_BT3_4_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nhap ngay thang nam
            Console.Write("Nhap vao ngay thang nam(dd/mm/yyyy): "); 
            string thoigian = Console.ReadLine();
            string[] part = thoigian.Split('/');
            if (part.Length != 3)
                return;
            int date = Convert.ToInt32(part[0]);
            int month = Convert.ToInt32(part[1]);
            int year = Convert.ToInt32(part[2]);

            //Bai 03
            if (KiemTraNgayThangHopLe(date, month, year)) 
                Console.WriteLine("Hop le");
            else
                Console.WriteLine("Khong hop le");

            //Bai04
            if (SoNgayCuaThang(month, year) == 0)
                Console.WriteLine("Khong ton tai so ngay cua thang " + month + " nam " + year );
            else
                Console.WriteLine("So ngay cua thang " + month + " nam " + year + " la: " + SoNgayCuaThang(month, year));

            //Bai 05
            Console.Write("Ngay " + thoigian + " la: ");  XacDinhThuTrongTuan(date, month, year);
            
        }

        // Kiem tra nam nhuan
        static bool NamNhuan(int n)
        {
            return ((n % 4 == 0 && n % 100 != 0) || (n % 400 == 0));         
        }

        // (Bai 03) Kiem tra ngay thang nam co hop le khong
        static bool KiemTraNgayThangHopLe(int date, int month, int year)
        {
            if (year < 1 || month < 1 || month > 12)
                return false;
            else
            {
                switch (month)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        if (date < 1 || date > 31)
                            return false;
                        break;
                    case 2:
                        if (NamNhuan(year)) {
                            if (date < 1 || date > 29)
                                return false;
                        }
                        else
                        {
                            if (date < 1 || date > 28)
                                return false;
                        }
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        if (date < 1 || date > 30)
                            return false;
                        break;
                }
            }
            return true;
        }

        // (Bai04) In ra so ngay cua thang
        static int SoNgayCuaThang(int month, int year)
        {
            if (year < 1)
                return 0;
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    if (NamNhuan(year))
                        return 29;
                    else
                        return 28;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
            }
            return 0;
        }

        //(Bai 05) Dua vao ngay thang nam de xac dinh thu trong tuan
        static void XacDinhThuTrongTuan(int date, int month, int year)
        {
            if (!KiemTraNgayThangHopLe(date, month, year))
            {
                Console.WriteLine("Khong xac dinh duoc");
                return;
            }
            if ( month == 1 || month == 2){
                month += 12;
                year -= 1;
            }
            int k = year % 100;
            int j = year / 100;
            int h = (date + 13 * (month + 1) / 5 + k + k / 4 + j / 4 + 5 * j) % 7;
            switch (h)
            {
                case 0:
                    Console.WriteLine("Thu Bay");
                    break;
                case 1:
                    Console.WriteLine("Chu Nhat");
                    break;
                case 2:
                    Console.WriteLine("Thu Hai");
                    break;
                case 3:
                    Console.WriteLine("Thu Ba");
                    break;
                case 4:
                    Console.WriteLine("Thu Tu");
                    break;
                case 5:
                    Console.WriteLine("Thu Nam");
                    break;
                case 6:
                    Console.WriteLine("Thu Sau");
                    break;
            }
        }
    }

}
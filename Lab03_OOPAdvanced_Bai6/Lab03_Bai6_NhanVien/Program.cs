using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03_Bai6_NhanVien
{
    public abstract class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public double LuongCoBan { get; set; }

        public NhanVien(string ma, string ten, double lcb)
        {
            MaNV = ma;
            HoTen = ten;
            LuongCoBan = lcb;
        }

        public abstract double TinhLuong();

        public virtual void HienThi()
        {
            Console.WriteLine($"Mã: {MaNV,-6} | Họ tên: {HoTen,-18} | Chức danh: {GetType().Name,-18} | Lương thực lĩnh: {TinhLuong(),12:N0} VNĐ");
        }
    }

    public class NhanVienVanPhong : NhanVien
    {
        public int SoNgayCong { get; set; }

        public NhanVienVanPhong(string ma, string ten, double lcb, int soNgayCong)
            : base(ma, ten, lcb)
        {
            SoNgayCong = soNgayCong;
        }

        public override double TinhLuong()
        {
            return LuongCoBan * (SoNgayCong / 22.0);
        }
    }

    public class NhanVienKinhDoanh : NhanVien
    {
        public double DoanhSo { get; set; }
        public double HoaHong { get; set; } // % hoa hồng (VD: 0.05 = 5%)

        public NhanVienKinhDoanh(string ma, string ten, double lcb, double doanhSo, double hoaHong)
            : base(ma, ten, lcb)
        {
            DoanhSo = doanhSo;
            HoaHong = hoaHong;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + (DoanhSo * HoaHong);
        }
    }

    public class GiangVien : NhanVien
    {
        public int SoTietDay { get; set; }
        public double DonGiaTiet { get; set; }

        public GiangVien(string ma, string ten, double lcb, int soTiet, double donGia)
            : base(ma, ten, lcb)
        {
            SoTietDay = soTiet;
            DonGiaTiet = donGia;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + (SoTietDay * DonGiaTiet);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<NhanVien> ds = new List<NhanVien>
            {
                new NhanVienVanPhong("NV01", "Nguyễn Văn A", 8000000, 22),
                new NhanVienKinhDoanh("NV02", "Trần Thị B", 5000000, 150000000, 0.05),
                new GiangVien("GV01", "Lê Hoàng C", 6000000, 45, 120000)
            };

            Console.WriteLine("================ BẢNG TÍNH LƯƠNG NHÂN VIÊN CÔNG TY ================");
            double tongLuong = 0;
            foreach (var nv in ds)
            {
                nv.HienThi();
                tongLuong += nv.TinhLuong();
            }
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine($"TỔNG QUỸ LƯƠNG CHI TRẢ: {tongLuong:N0} VNĐ");

            Console.ReadKey();
        }
    }
}
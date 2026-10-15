using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03_Bai1Den5
{
    // --- BÀI 4: Interfaces ---
    public interface IValidatable
    {
        bool IsValid(out string message);
    }

    public interface IPrintable
    {
        string ToDisplayText();
    }

    // --- BÀI 1 & BÀI 2: Lớp cơ sở Nguoi ---[cite: 1, 2]
    public class Nguoi
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }

        public Nguoi(string hoTen, DateTime ngaySinh)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
        }

        public virtual string MoTa()
        {
            return HoTen + " - " + NgaySinh.ToString("dd/MM/yyyy");
        }
    }

    // --- BÀI 1, BÀI 2 & BÀI 4: Lớp SinhVien kế thừa Nguoi và thực thi Interface ---[cite: 1, 2, 3]
    public class SinhVien : Nguoi, IValidatable, IPrintable
    {
        public string MaSV { get; set; }
        public double DiemTB { get; set; }

        public SinhVien(string ma, string ten, DateTime ngaySinh, double diem)
            : base(ten, ngaySinh)
        {
            MaSV = ma;
            DiemTB = diem;
        }

        // Bài 2: Ghi đè phương thức MoTa()[cite: 2]
        public override string MoTa()
        {
            return base.MoTa() + " - Mã: " + MaSV + " - ĐTB: " + DiemTB.ToString("N2");
        }

        // Bài 4: Cài đặt phương thức của IValidatable
        public bool IsValid(out string message)
        {
            if (string.IsNullOrWhiteSpace(MaSV)) { message = "Thiếu mã sinh viên!"; return false; }
            if (string.IsNullOrWhiteSpace(HoTen)) { message = "Thiếu họ tên!"; return false; }
            if (DiemTB < 0 || DiemTB > 10) { message = "Điểm TB không hợp lệ (phải từ 0-10)!"; return false; }
            message = "Dữ liệu hợp lệ.";
            return true;
        }

        // Bài 4: Cài đặt phương thức của IPrintable
        public string ToDisplayText()
        {
            return $"{MaSV} - {HoTen} - ĐTB: {DiemTB:N2}";
        }
    }

    // --- BÀI 3: Lớp trừu tượng NguoiHoc ---[cite: 2]
    public abstract class NguoiHoc
    {
        public string HoTen { get; set; }
        public int SoTinChi { get; set; }

        public abstract decimal TinhHocPhi();
    }

    public class SinhVienChinhQuy : NguoiHoc
    {
        public override decimal TinhHocPhi()
        {
            return SoTinChi * 450000m;
        }
    }

    public class SinhVienLienThong : NguoiHoc
    {
        public override decimal TinhHocPhi()
        {
            return SoTinChi * 520000m;
        }
    }

    // --- Hàm Main khởi chạy ---
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("================ DEMO BÀI 1 ĐẾN BÀI 5 ================");

            // 1. Kiểm tra Bài 1 & Bài 2: Kế thừa và Ghi đè phương thức[cite: 1, 2]
            Console.WriteLine("\n--- BÀI 1 & 2: KẾ THỪA VÀ GHI ĐÈ MO TẢ ---");
            SinhVien sv1 = new SinhVien("SV01", "Nguyễn Như An", new DateTime(2006, 3, 15), 8.5);
            Console.WriteLine(sv1.MoTa());

            // 2. Kiểm tra Bài 4: Interface
            Console.WriteLine("\n--- BÀI 4: KIỂM TRA INTERFACE ---");
            if (sv1.IsValid(out string msg))
            {
                Console.WriteLine("Xác thực: " + msg);
                Console.WriteLine("Hiển thị: " + sv1.ToDisplayText());
            }

            // 3. Kiểm tra Bài 3 & Bài 5: Lớp trừu tượng và Tính đa hình danh sách học phí[cite: 2, 3]
            Console.WriteLine("\n--- BÀI 3 & 5: DANH SÁCH ĐA HÌNH TÍNH HỌC PHÍ ---");
            List<NguoiHoc> dsHocPhi = new List<NguoiHoc>
            {
                new SinhVienChinhQuy { HoTen = "Nguyễn Như An", SoTinChi = 18 },
                new SinhVienLienThong { HoTen = "Trần Văn Bình", SoTinChi = 15 },
                new SinhVienChinhQuy { HoTen = "Lê Thị Cường", SoTinChi = 20 }
            };

            decimal tongHocPhi = 0;
            foreach (NguoiHoc item in dsHocPhi)
            {
                decimal hp = item.TinhHocPhi();
                tongHocPhi += hp;
                Console.WriteLine($"{item.HoTen,-15} ({item.GetType().Name,-20}): {hp,12:N0} VNĐ");
            }
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"TỔNG HỌC PHÍ KHÓA HỌC: {tongHocPhi:N0} VNĐ");

            Console.ReadKey();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab03_Bai7Den10
{
    #region --- BÀI 7: QUẢN LÝ PHƯƠNG TIỆN GIAO THÔNG (INTERFACE IMOVE) ---

    public interface IMove
    {
        void VanHanh(double quangDuong);
        double TinhChiPhi(double quangDuong);
        void HienThiThongTin();
    }

    public class XeMay : IMove
    {
        public string TenPhuongTien { get; set; } = "Xe máy Honda";
        public double MucTieuThuXang { get; set; } = 2.0; // L/100km
        public double GiaXang { get; set; } = 23000; // VNĐ/L

        public void VanHanh(double quangDuong)
        {
            Console.WriteLine($"[Xe máy] Di chuyển {quangDuong} km với vận tốc trung bình 40 km/h.");
        }

        public double TinhChiPhi(double quangDuong)
        {
            return (quangDuong / 100.0) * MucTieuThuXang * GiaXang;
        }

        public void HienThiThongTin()
        {
            Console.WriteLine($"Phương tiện: {TenPhuongTien,-20} | Mức tiêu thụ: {MucTieuThuXang}L/100km");
        }
    }

    public class OTo : IMove
    {
        public string TenPhuongTien { get; set; } = "Ô tô Toyota";
        public double MucTieuThuXang { get; set; } = 8.5; // L/100km
        public double GiaXang { get; set; } = 23000;

        public void VanHanh(double quangDuong)
        {
            Console.WriteLine($"[Ô tô] Di chuyển {quangDuong} km trên cao tốc với vận tốc 80 km/h.");
        }

        public double TinhChiPhi(double quangDuong)
        {
            return (quangDuong / 100.0) * MucTieuThuXang * GiaXang;
        }

        public void HienThiThongTin()
        {
            Console.WriteLine($"Phương tiện: {TenPhuongTien,-20} | Mức tiêu thụ: {MucTieuThuXang}L/100km");
        }
    }

    public class XeDap : IMove
    {
        public string TenPhuongTien { get; set; } = "Xe đạp Thống Nhất";

        public void VanHanh(double quangDuong)
        {
            Console.WriteLine($"[Xe đạp] Thong thả đạp xe {quangDuong} km rèn luyện sức khỏe.");
        }

        public double TinhChiPhi(double quangDuong) => 0;

        public void HienThiThongTin()
        {
            Console.WriteLine($"Phương tiện: {TenPhuongTien,-20} | Không dùng nhiên liệu");
        }
    }

    public static class Bai07_PhuongTien
    {
        public static void ThucHien()
        {
            Console.WriteLine("================ BÀI 7: QUẢN LÝ PHƯƠNG TIỆN GIAO THÔNG ================");
            List<IMove> dsPhuongTien = new List<IMove> { new XeMay(), new OTo(), new XeDap() };
            double quangDuong = 50.0;

            Console.WriteLine($"\n--> Mô phỏng vận hành quãng đường {quangDuong} km:");
            foreach (var pt in dsPhuongTien)
            {
                pt.HienThiThongTin();
                pt.VanHanh(quangDuong);
                Console.WriteLine($"   ==> Chi phí nhiên liệu: {pt.TinhChiPhi(quangDuong):N0} VNĐ\n");
            }
        }
    }

    #endregion

    #region --- BÀI 8: QUẢN LÝ TÀI LIỆU THƯ VIỆN ---

    public abstract class TaiLieu
    {
        public string MaTaiLieu { get; set; }
        public string TenTaiLieu { get; set; }
        public string NhaXuatBan { get; set; }
        public int NamXuatBan { get; set; }

        public TaiLieu(string ma, string ten, string nxb, int nam)
        {
            MaTaiLieu = ma;
            TenTaiLieu = ten;
            NhaXuatBan = nxb;
            NamXuatBan = nam;
        }

        public virtual void InThongTin()
        {
            Console.Write($"[{MaTaiLieu,-5}] {TenTaiLieu,-30} | NXB: {NhaXuatBan,-15} | Năm: {NamXuatBan}");
        }
    }

    public class Sach : TaiLieu
    {
        public string TacGia { get; set; }
        public int SoTrang { get; set; }

        public Sach(string ma, string ten, string nxb, int nam, string tacGia, int soTrang)
            : base(ma, ten, nxb, nam)
        {
            TacGia = tacGia;
            SoTrang = soTrang;
        }

        public override void InThongTin()
        {
            base.InThongTin();
            Console.WriteLine($" | Tác giả: {TacGia,-15} | Số trang: {SoTrang}");
        }
    }

    public class TapChi : TaiLieu
    {
        public int SoPhatHanh { get; set; }
        public int ThangPhatHanh { get; set; }

        public TapChi(string ma, string ten, string nxb, int nam, int soPH, int thangPH)
            : base(ma, ten, nxb, nam)
        {
            SoPhatHanh = soPH;
            ThangPhatHanh = thangPH;
        }

        public override void InThongTin()
        {
            base.InThongTin();
            Console.WriteLine($" | Số PH: {SoPhatHanh,-5} | Tháng: {ThangPhatHanh}/2026");
        }
    }

    public class LuanVan : TaiLieu
    {
        public string ChuyenNganh { get; set; }
        public string TrinhDo { get; set; }

        public LuanVan(string ma, string ten, string nxb, int nam, string chuyenNganh, string trinhDo)
            : base(ma, ten, nxb, nam)
        {
            ChuyenNganh = chuyenNganh;
            TrinhDo = trinhDo;
        }

        public override void InThongTin()
        {
            base.InThongTin();
            Console.WriteLine($" | Chuyên ngành: {ChuyenNganh,-15} | Trình độ: {TrinhDo}");
        }
    }

    public static class Bai08_ThuVien
    {
        public static void ThucHien()
        {
            Console.WriteLine("================ BÀI 8: QUẢN LÝ TÀI LIỆU THƯ VIỆN ================");
            List<TaiLieu> dsThuVien = new List<TaiLieu>
            {
                new Sach("S01", "Lập trình C# Nâng cao", "NXB Giáo Dục", 2023, "Nguyễn Văn A", 350),
                new TapChi("TC01", "Tạp chí CNTT & Truyền thông", "NXB KH&KT", 2026, 12, 10),
                new LuanVan("LV01", "Nghiên cứu AI & Học máy", "ĐH Công nghệ", 2025, "Khoa học máy tính", "Thạc sĩ")
            };

            Console.WriteLine("\n--> Danh sách tài liệu hiện có:");
            foreach (var tl in dsThuVien) tl.InThongTin();

            Console.Write("\nNhập từ khóa tìm kiếm (Mã hoặc Tên): ");
            string tuKhoa = Console.ReadLine().Trim();

            var ketQua = dsThuVien.Where(x => x.MaTaiLieu.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                              x.TenTaiLieu.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            Console.WriteLine($"\n--- KẾT QUẢ TÌM KIẾM ({ketQua.Count} tài liệu) ---");
            foreach (var item in ketQua) item.InThongTin();
        }
    }

    #endregion

    #region --- BÀI 9: HỆ THỐNG THANH TOÁN ĐA PHƯƠNG THỨC (INTERFACE IPAYMENT) ---

    public interface IPayment
    {
        bool ThanhToan(decimal soTien, out string maGiaoDich);
        void InHoaDon();
    }

    public class ThanhToanTienMat : IPayment
    {
        private decimal _soTienDaTra;
        private string _maGD;

        public bool ThanhToan(decimal soTien, out string maGiaoDich)
        {
            _soTienDaTra = soTien;
            _maGD = "CASH_" + DateTime.Now.Ticks.ToString().Substring(12);
            maGiaoDich = _maGD;
            Console.WriteLine($"[Tiền mặt] Thanh toán trực tiếp {soTien:N0} VNĐ tại quầy.");
            return true;
        }

        public void InHoaDon()
        {
            Console.WriteLine($"--> HÓA ĐƠN TIỀN MẶT | Mã GD: {_maGD} | Số tiền: {_soTienDaTra:N0} VNĐ | Trạng thái: Thành công");
        }
    }

    public class ChuyenKhoan : IPayment
    {
        public string NganHang { get; set; } = "Vietcombank";
        public string SoTaiKhoan { get; set; } = "999888777";
        private decimal _soTienDaTra;
        private string _maGD;

        public bool ThanhToan(decimal soTien, out string maGiaoDich)
        {
            _soTienDaTra = soTien;
            _maGD = "BANK_" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            maGiaoDich = _maGD;
            Console.WriteLine($"[Chuyển khoản] Chuyển {soTien:N0} VNĐ qua {NganHang} (STK: {SoTaiKhoan}).");
            return true;
        }

        public void InHoaDon()
        {
            Console.WriteLine($"--> HÓA ĐƠN CHUYỂN KHOẢN | Mã GD: {_maGD} | Số tiền: {_soTienDaTra:N0} VNĐ | Trạng thái: Thành công");
        }
    }

    public class ViDienTu : IPayment
    {
        public string TenVi { get; set; } = "Momo";
        private decimal _soTienDaTra;
        private string _maGD;

        public bool ThanhToan(decimal soTien, out string maGiaoDich)
        {
            _soTienDaTra = soTien;
            _maGD = "MOMO_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            maGiaoDich = _maGD;
            Console.WriteLine($"[Ví điện tử] Quét mã QR thanh toán {soTien:N0} VNĐ qua {TenVi}.");
            return true;
        }

        public void InHoaDon()
        {
            Console.WriteLine($"--> HÓA ĐƠN VÍ ĐIỆN TỬ | Mã GD: {_maGD} | Số tiền: {_soTienDaTra:N0} VNĐ | Trạng thái: Thành công");
        }
    }

    public static class Bai09_ThanhToan
    {
        public static void ThucHien()
        {
            Console.WriteLine("================ BÀI 9: HỆ THỐNG THANH TOÁN ĐA PHƯƠNG THỨC ================");
            decimal soTien = 1250000m;
            List<IPayment> dsThanhToan = new List<IPayment> { new ThanhToanTienMat(), new ChuyenKhoan(), new ViDienTu() };

            Console.WriteLine($"\nThực hiện thanh toán số tiền: {soTien:N0} VNĐ qua các phương thức:\n");
            foreach (var pt in dsThanhToan)
            {
                if (pt.ThanhToan(soTien, out string maGD))
                {
                    pt.InHoaDon();
                }
                Console.WriteLine("------------------------------------------------------------------");
            }
        }
    }

    #endregion

    #region --- BÀI 10: NÂNG CẤP QUẢN LÝ SINH VIÊN HOÀN CHỈNH ---

    public interface IValidatable
    {
        bool IsValid(out string message);
    }

    public abstract class NguoiHoc : IValidatable
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public int SoTinChi { get; set; }

        public NguoiHoc() { }

        public NguoiHoc(string ma, string ten, int tinChi)
        {
            MaSV = ma;
            HoTen = ten;
            SoTinChi = tinChi;
        }

        public abstract decimal TinhHocPhi();

        public virtual bool IsValid(out string message)
        {
            if (string.IsNullOrWhiteSpace(MaSV)) { message = "Mã SV không được để rỗng!"; return false; }
            if (string.IsNullOrWhiteSpace(HoTen)) { message = "Họ tên không được để rỗng!"; return false; }
            if (SoTinChi <= 0) { message = "Số tín chỉ phải lớn hơn 0!"; return false; }
            message = "Hợp lệ.";
            return true;
        }

        public virtual void HienThi()
        {
            Console.WriteLine($"Mã: {MaSV,-8} | Tên: {HoTen,-20} | Loại: {GetType().Name,-20} | Tín chỉ: {SoTinChi,2} | Học phí: {TinhHocPhi(),12:N0} VNĐ");
        }
    }

    public class SinhVienChinhQuy : NguoiHoc
    {
        public SinhVienChinhQuy(string ma, string ten, int tinChi) : base(ma, ten, tinChi) { }
        public override decimal TinhHocPhi() => SoTinChi * 450000m;
    }

    public class SinhVienLienThong : NguoiHoc
    {
        public SinhVienLienThong(string ma, string ten, int tinChi) : base(ma, ten, tinChi) { }
        public override decimal TinhHocPhi() => SoTinChi * 520000m;
    }

    public class SinhVienQuocTe : NguoiHoc
    {
        public decimal PhuPhiMoiTruong { get; set; } = 3000000m;
        public SinhVienQuocTe(string ma, string ten, int tinChi) : base(ma, ten, tinChi) { }
        public override decimal TinhHocPhi() => (SoTinChi * 800000m) + PhuPhiMoiTruong;
    }

    public static class Bai10_NangCapQLSV
    {
        private static List<NguoiHoc> dsNguoiHoc = new List<NguoiHoc>
        {
            new SinhVienChinhQuy("SV01", "Nguyễn Như An", 18),
            new SinhVienLienThong("SV02", "Trần Văn Bình", 15),
            new SinhVienQuocTe("SV03", "John Smith", 20),
            new SinhVienChinhQuy("SV04", "Lê Thị Cường", 22)
        };

        public static void ThucHien()
        {
            int subChon;
            do
            {
                Console.Clear();
                Console.WriteLine("================ NÂNG CẤP HỆ THỐNG QUẢN LÝ SINH VIÊN (BÀI 10) ================");
                Console.WriteLine("1. Xem danh sách sinh viên toàn trường");
                Console.WriteLine("2. Thêm sinh viên mới (Chính quy / Liên thông / Quốc tế)");
                Console.WriteLine("3. Tìm kiếm sinh viên theo Mã hoặc Tên");
                Console.WriteLine("4. Sắp xếp danh sách theo Học phí GIẢM DẦN");
                Console.WriteLine("5. Thống kê tổng học phí và phân loại người học");
                Console.WriteLine("0. Quay lại Menu chính");
                Console.WriteLine("============================================================================");
                Console.Write("Mời bạn chọn chức năng (0-5): ");

                if (!int.TryParse(Console.ReadLine(), out subChon)) subChon = -1;

                Console.WriteLine();
                switch (subChon)
                {
                    case 1: HienThiDanhSach(); break;
                    case 2: ThemSinhVien(); break;
                    case 3: TimKiemSinhVien(); break;
                    case 4: SapXepHocPhi(); break;
                    case 5: ThongKe(); break;
                    case 0: break;
                    default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
                }

                if (subChon != 0)
                {
                    Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                    Console.ReadKey();
                }
            } while (subChon != 0);
        }

        private static void HienThiDanhSach()
        {
            Console.WriteLine("--- DANH SÁCH SINH VIÊN TOÀN TRƯỜNG ---");
            if (dsNguoiHoc.Count == 0) { Console.WriteLine("Danh sách trống."); return; }
            foreach (var nh in dsNguoiHoc) nh.HienThi();
        }

        private static void ThemSinhVien()
        {
            Console.WriteLine("--- THÊM SINH VIÊN MỚI ---");
            Console.WriteLine("1. Sinh viên Chính quy");
            Console.WriteLine("2. Sinh viên Liên thông");
            Console.WriteLine("3. Sinh viên Quốc tế");
            Console.Write("Chọn loại sinh viên: ");
            int.TryParse(Console.ReadLine(), out int loai);

            Console.Write("Mã sinh viên: ");
            string ma = Console.ReadLine().Trim();
            Console.Write("Họ và tên: ");
            string ten = Console.ReadLine().Trim();
            Console.Write("Số tín chỉ đăng ký: ");
            int.TryParse(Console.ReadLine(), out int tinChi);

            NguoiHoc nh = null;
            if (loai == 1) nh = new SinhVienChinhQuy(ma, ten, tinChi);
            else if (loai == 2) nh = new SinhVienLienThong(ma, ten, tinChi);
            else if (loai == 3) nh = new SinhVienQuocTe(ma, ten, tinChi);

            if (nh == null)
            {
                Console.WriteLine("Lỗi: Loại sinh viên không hợp lệ!");
            }
            else if (!nh.IsValid(out string msg))
            {
                Console.WriteLine("Lỗi: " + msg);
            }
            else
            {
                dsNguoiHoc.Add(nh);
                Console.WriteLine("Thêm thành công!");
            }
        }

        private static void TimKiemSinhVien()
        {
            Console.Write("Nhập từ khóa cần tìm: ");
            string tk = Console.ReadLine().Trim();

            var kq = dsNguoiHoc.Where(x => x.MaSV.IndexOf(tk, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                           x.HoTen.IndexOf(tk, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            Console.WriteLine($"Tìm thấy {kq.Count} kết quả:");
            foreach (var item in kq) item.HienThi();
        }

        private static void SapXepHocPhi()
        {
            dsNguoiHoc = dsNguoiHoc.OrderByDescending(x => x.TinhHocPhi()).ToList();
            Console.WriteLine("Đã sắp xếp danh sách theo Học phí GIẢM DẦN.");
            HienThiDanhSach();
        }

        private static void ThongKe()
        {
            Console.WriteLine("--- THỐNG KÊ TỔNG QUAN ---");
            Console.WriteLine($"Tổng số sinh viên: {dsNguoiHoc.Count}");
            decimal tongHP = dsNguoiHoc.Sum(x => x.TinhHocPhi());
            Console.WriteLine($"Tổng học phí thu được: {tongHP:N0} VNĐ");

            Console.WriteLine("\nPhân loại sinh viên:");
            var nhom = dsNguoiHoc.GroupBy(x => x.GetType().Name);
            foreach (var g in nhom)
            {
                Console.WriteLine($" - {g.Key,-20}: {g.Count()} sinh viên | Tổng học phí nhóm: {g.Sum(x => x.TinhHocPhi()):N0} VNĐ");
            }
        }
    }

    #endregion

    #region --- MAIN KHỞI CHẠY CHƯƠNG TRÌNH ---

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            int luaChon;
            do
            {
                Console.Clear();
                Console.WriteLine("=================== LAB 03 (BÀI 7 - 10) ===================");
                Console.WriteLine("7.  Bài 7: Quản lý Phương tiện giao thông (Interface IMove)");
                Console.WriteLine("8.  Bài 8: Quản lý Tài liệu thư viện (Lớp trừu tượng TaiLieu)");
                Console.WriteLine("9.  Bài 9: Hệ thống Thanh toán đa phương thức (Interface IPayment)");
                Console.WriteLine("10. Bài 10: Nâng cấp Hệ thống Quản lý Sinh viên (Menu hoàn chỉnh)");
                Console.WriteLine("0.  Thoát chương trình");
                Console.WriteLine("=========================================================================");
                Console.Write("Mời bạn chọn bài tập (7-10 hoặc 0): ");

                if (!int.TryParse(Console.ReadLine(), out luaChon)) luaChon = -1;

                Console.WriteLine();
                switch (luaChon)
                {
                    case 7: Bai07_PhuongTien.ThucHien(); break;
                    case 8: Bai08_ThuVien.ThucHien(); break;
                    case 9: Bai09_ThanhToan.ThucHien(); break;
                    case 10: Bai10_NangCapQLSV.ThucHien(); break;
                    case 0: Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!"); break;
                    default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
                }

                if (luaChon != 0)
                {
                    Console.WriteLine("\nNhấn phím bất kỳ để quay lại Menu chính...");
                    Console.ReadKey();
                }
            } while (luaChon != 0);
        }
    }

    #endregion
}
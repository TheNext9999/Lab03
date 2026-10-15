================================================================================
                    HƯỚNG DẪN DỰ ÁN C# CONSOLE - LAB 03 (OOP)
               KẾ THỪA, ĐA HÌNH, LỚP TRỪU TƯỢNG VÀ INTERFACE
================================================================================

1. GIỚI THIỆU DỰ ÁN
Tên dự án: Lab03_OOPAdvanced
Môn học: Lập trình .NET (IT3212) - Khoa CNTT
Trường: Đại học Công nghệ Đông Á
Tác giả: Nguyễn Như An (2006) - Mã SV: SV01

2. CẤU TRÚC DỰ ÁN
Dự án bao gồm 3 Solution/Project C# Console được phân chia theo bài tập:

├── Lab03_Bai1Den5/
│   └── Program.cs          # Bài 1 - 5: Kế thừa (Nguoi/SinhVien), Abstract Class (NguoiHoc) & Interface (IValidatable, IPrintable)
│
├── Lab03_Bai6_NhanVien/
│   └── Program.cs          # Bài 6: Quản lý Nhân viên đa hình (NhanVienVanPhong, NhanVienKinhDoanh, GiangVien)
│
└── Lab03_Bai7Den10/
    └── Program.cs          # Bài 7 - 10: Gộp hoàn chỉnh (Phương tiện IMove, Thư viện TaiLieu, Thanh toán IPayment & QLSV Nâng cấp)

3. DANH SÁCH BÀI TẬP VÀ KIẾN THỨC NÒNG CỐT
- Bài 1 & 2: Kế thừa lớp Nguoi -> SinhVien, ghi đè phương thức virtual/override MoTa().
- Bài 3 & 5: Lớp trừu tượng NguoiHoc (SinhVienChinhQuy, SinhVienLienThong), danh sách đa hình tính tổng học phí.
- Bài 4: Interface IValidatable (IsValid) & IPrintable (ToDisplayText).
- Bài 6: Bảng tính lương Nhân viên đa hình (phương thức abstract TinhLuong()).
- Bài 7: Interface IMove quy định hành vi vận hành & tính chi phí nhiên liệu (XeMay, OTo, XeDap).
- Bài 8: Lớp trừu tượng TaiLieu quản lý thư viện (Sach, TapChi, LuanVan) & tìm kiếm từ khóa.
- Bài 9: Interface IPayment hỗ trợ thanh toán đa phương thức (ThanhToanTienMat, ChuyenKhoan, ViDienTu).
- Bài 10: Menu Quản lý Sinh viên nâng cấp, bắt lỗi nhập liệu & khắc phục triệt để lỗi CS0165.

4. XỬ LÝ LỖI BIÊN DỊCH CS0165 (TIPS)
- Lỗi: CS0165 Use of unassigned local variable 'msg' trong câu lệnh:
  `if (nh != null && nh.IsValid(out string msg))`
- Nguyên nhân: Do cơ chế ngắt ngắn (short-circuit) `&&`, khi `nh == null`, vế hai không chạy khiến `msg` chưa được gán giá trị ở nhánh `else`.
- Khắc phục: Tách điều kiện thành `if - else if`:
  if (nh == null) Console.WriteLine("Lỗi: Loại sinh viên không hợp lệ!");
  else if (!nh.IsValid(out string msg)) Console.WriteLine("Lỗi: " + msg);
  else { dsNguoiHoc.Add(nh); Console.WriteLine("Thêm thành công!"); }

5. HƯỚNG DẪN CHẠY CHƯƠNG TRÌNH
- Môi trường: Visual Studio 2022 (hoặc VS Code / Rider), .NET Framework 4.8 hoặc .NET 6.0/8.0 SDK trở lên.
- Các bước thực hiện:
  1. Mở file Solution/Project tương ứng trên Visual Studio.
  2. Bấm phím F5 để biên dịch và khởi chạy chương trình trên cửa sổ Console.
  3. Mọi dự án đều đã được mã hóa UTF-8 (`Console.OutputEncoding = Encoding.UTF8;`) để hiển thị đúng tiếng Việt có dấu.
================================================================================
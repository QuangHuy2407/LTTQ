using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLBinh
{
    public partial class Order : Form
    {
        private DataProcess dataProcess;
        // public DataGridView dgvDanhSach;
        MenuItems menu = new MenuItems();

        Boolean checkBan01 = false;
        Boolean checkBan02 = false;
        Boolean checkBan03 = false;
        Boolean checkBan04 = false;
        Boolean checkBan05 = false;
        Boolean checkBan06 = false;
        Boolean checkBan07 = false;
        Boolean checkBan08 = false;
        Boolean checkBan09 = false;

        HoaDon hoaDon01;
        HoaDon hoaDon02;
        HoaDon hoaDon03;
        HoaDon hoaDon04;
        HoaDon hoaDon05;
        HoaDon hoaDon06;
        HoaDon hoaDon07;
        HoaDon hoaDon08;
        HoaDon hoaDon09;

        public Order()
        {
            InitializeComponent();


            this.FormClosed += (sender, e) => Application.Exit();

            // Dùng cho MenuStrip 
            MenuStripHelper.ApplyHoverEffect(danhMucToolStripMenuItem);
            MenuStripHelper.ApplyHoverEffect(nhapHangToolStripMenuItem);
            MenuStripHelper.ApplyHoverEffect(banHangToolStripMenuItem);
            MenuStripHelper.ApplyHoverEffect(nhanVienToolStripMenuItem);
            MenuStripHelper.ApplyHoverEffect(nhaCungCapToolStripMenuItem);
            MenuStripHelper.ApplyHoverEffect(tienIchToolStripMenuItem);
            MenuStripHelper.ApplyHoverEffect(troGiupToolStripMenuItem);

            hoaDon01 = new HoaDon(null,DateTime.Now,null,null,null);
            hoaDon02 = new HoaDon(null, DateTime.Now, null, null, null);
            hoaDon03 = new HoaDon(null, DateTime.Now, null, null, null);
            hoaDon04 = new HoaDon(null, DateTime.Now, null, null, null);
            hoaDon05 = new HoaDon(null, DateTime.Now, null, null, null);
            hoaDon06 = new HoaDon(null, DateTime.Now, null, null, null);
            hoaDon07 = new HoaDon(null, DateTime.Now, null, null, null);
            hoaDon07 = new HoaDon(null, DateTime.Now, null, null, null);
            hoaDon08 = new HoaDon(null, DateTime.Now, null, null, null);
            hoaDon09 = new HoaDon(null, DateTime.Now, null, null, null);

            dataProcess = new DataProcess();

            // Khởi tạo datagridview
            SetupDataGridView();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            addDataGridView();
        }

        private void danhMucToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void nhapHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo một thể hiện mới của Form2`1
            Form2 form2 = new Form2();

            // Hiển thị Form2
            form2.Show();

            // Nếu bạn muốn đóng Form1 sau khi mở Form2, hãy thêm dòng sau:
            this.Hide();
        }

        private void banHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();

            form3.Show();

            this.Hide();
        }

        private void nhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();

            form5.Show();
        }

        private void nhaCungCapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();

            form4.Show();
        }

        //-------------------------------------------------------------------------------------------
        // Phần dưới này là các phương thức

        private void SetupDataGridView()
        {
            // Xóa tất cả các cột và hàng hiện tại nếu có
            dgv_hoaDon.Columns.Clear();
            dgv_hoaDon.Rows.Clear();

            // Thêm các cột vào DataGridView
            dgv_hoaDon.Columns.Add("SanPham", "Sản phẩm");
            dgv_hoaDon.Columns.Add("SoLuong", "Số lượng");
            dgv_hoaDon.Columns.Add("ThanhTien", "Thành tiền");
            dgv_hoaDon.Columns.Add("KhuyenMai", "Khuyến mãi");

            // Thêm dữ liệu mẫu vào DataGridView
            dgv_hoaDon.Rows.Add("Cà phê", 2, 50000, "Giảm 10%");
            dgv_hoaDon.Rows.Add("Trà sữa", 3, 60000, "Giảm 20%");
            dgv_hoaDon.Rows.Add("Bánh mì", 5, 25000, "Không có khuyến mãi");
        }

        private void ResetControlsInGroupBox(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty; // Đặt giá trị của TextBox là rỗng
                }
                else if (control is DateTimePicker)
                {
                    ((DateTimePicker)control).Value = DateTime.Now; // Đặt giá trị của DateTimePicker là ngày hiện tại
                }
                else if (control is DataGridView)
                {
                    ((DataGridView)control).Rows.Clear(); // Xóa tất cả các hàng trong DataGridView
                }
            }
        }

        private void buttonColor() // Đang lỗi 
        {
            if (checkBan01 == true)
            {
                btBan01.ForeColor = Color.Yellow;
            } else if (checkBan02 == true)
            {
                btBan02.ForeColor = Color.Yellow;
            }
        }

        // Phương thức dùng để hiển thị dữ liệu hóa đơn lên các control
        private void LoadHoaDon(HoaDon hoaDon)
        {
            txtMaHoaDon.Text = hoaDon.MaHoaDon;
            dtpNgayVao.Value = hoaDon.NgayVao;
            txtMaNhanVien.Text = hoaDon.MaNhanVien;
            txtMaKhachHang.Text = hoaDon.MaKhachHang;
            txtTenKhachHang.Text = hoaDon.TenKhachHang;
        }

        private void UpdateHoaDon(HoaDon hoaDon)
        {
            hoaDon.MaHoaDon = txtMaHoaDon.Text;
            hoaDon.NgayVao = dtpNgayVao.Value;
            hoaDon.MaNhanVien = txtMaNhanVien.Text;
            hoaDon.MaKhachHang = txtMaKhachHang.Text;
            hoaDon.TenKhachHang = txtTenKhachHang.Text;
        }

        private void DeleteHoaDon(HoaDon hoaDon)
        {
            hoaDon.MaHoaDon = null;
            hoaDon.NgayVao = DateTime.Now;
            hoaDon.MaNhanVien = null;
            hoaDon.MaKhachHang = null;
            hoaDon.TenKhachHang = null;
        }

        // Hàm để lấy giá tiền từ cơ sở dữ liệu dựa trên tên sản phẩm
        private decimal GetGiaTien(string tenSanPham)
        {
            // Câu truy vấn SQL để lấy giá tiền
            string query = $"SELECT GiaBan FROM SANPHAM WHERE TenSp = '{tenSanPham}'";

            // Sử dụng DataConnect để thực hiện câu truy vấn
            DataTable dt = dataProcess.DataConnect(query);

            if (dt.Rows.Count > 0)
            {
                // Nếu tìm thấy kết quả, chuyển đổi giá trị thành decimal
                return Convert.ToDecimal(dt.Rows[0]["GiaBan"]);
            }
            else return 0;
        }

        private void addDataGridView()
        {

            int soLuong1 = menu.GetNumCapheDen();
            int soLuong2 = menu.GetNumCapheSua();
            int soLuong3 = menu.GetNumTraSuaTranChau();
            int soLuong4 = menu.GetNumSinhToDau();
            int soLuong5 = menu.GetNumNuocCamEp();
            int soLuong6 = menu.GetNumSodaChanh();
            int soLuong7 = menu.GetNumBanhNgotDau();
            int soLuong8 = menu.GetNumBanhMiThit();
            int soLuong9 = menu.GetNumPizza();
            int soLuong10 = menu.GetNumSalad();
            int soLuong11 = menu.GetNumHamburger();
            int soLuong12 = menu.GetNumKemDua();
            int soLuong13 = menu.GetNumNuocEpTao();
            int soLuong14 = menu.GetNumCaPheDaXay();
            int soLuong15 = menu.GetNumTraSuaMatcha();

            decimal giaTien1 = 0;
            decimal giaTien2 = 0;
            decimal giaTien3 = 0;
            decimal giaTien4 = 0;
            decimal giaTien5 = 0;
            decimal giaTien6 = 0;
            decimal giaTien7 = 0;
            decimal giaTien8 = 0;
            decimal giaTien9 = 0;
            decimal giaTien10 = 0;
            decimal giaTien11 = 0;
            decimal giaTien12 = 0;
            decimal giaTien13 = 0;
            decimal giaTien14 = 0;
            decimal giaTien15 = 0;

            giaTien1 = GetGiaTien(menu.getCaPheDen());
            giaTien2 = GetGiaTien(menu.getCaPheSua());
            giaTien3 = GetGiaTien(menu.getTraSuaTranChau());
            giaTien4 = GetGiaTien(menu.getSinhToDau());
            giaTien5 = GetGiaTien(menu.getNuocCamEp());
            giaTien6 = GetGiaTien(menu.getSodaChanh());
            giaTien7 = GetGiaTien(menu.getBanhNgotDau());
            giaTien8 = GetGiaTien(menu.getBanhMiThit());
            giaTien9 = GetGiaTien(menu.getPizza());
            giaTien10 = GetGiaTien(menu.getSalad());
            giaTien11 = GetGiaTien(menu.getHamburger());
            giaTien12 = GetGiaTien(menu.getKemDua());
            giaTien13 = GetGiaTien(menu.getNuocEpTao());
            giaTien14 = GetGiaTien(menu.getCaPheDaXay());
            giaTien15 = GetGiaTien(menu.getTraSuaMatcha());


        }

        //private void addDataGridView()
        //{
        //    // Khởi tạo danh sách để chứa các món
        //    List<OrderItem> orderItems = new List<OrderItem>
        //    {
        //        new OrderItem { Name = "Cà phê đen", SoLuong = menu.GetNumCapheDen(), GiaTien = GetGiaTien(menu.getCaPheDen()), KhuyenMai = 0 },
        //        new OrderItem { Name = "Cà phê sữa", SoLuong = menu.GetNumCapheSua(), GiaTien = GetGiaTien(menu.getCaPheSua()), KhuyenMai = 0 },
        //        new OrderItem { Name = "Trà sữa trân châu", SoLuong = menu.GetNumTraSuaTranChau(), GiaTien = GetGiaTien(menu.getTraSuaTranChau()), KhuyenMai = 0 },
        //        new OrderItem { Name = "Sinh tố dâu", SoLuong = menu.GetNumSinhToDau(), GiaTien = GetGiaTien(menu.getSinhToDau()), KhuyenMai = 0 },
        //        new OrderItem { Name = "Nước cam ép", SoLuong = menu.GetNumNuocCamEp(), GiaTien = GetGiaTien(menu.getNuocCamEp()), KhuyenMai = 0 },
        //        new OrderItem { Name = "Soda chanh", SoLuong = menu.GetNumSodaChanh(), GiaTien = GetGiaTien(menu.getSodaChanh()), KhuyenMai = 0 },
        //        new OrderItem { Name = "Bánh ngọt dâu", SoLuong = menu.GetNumBanhNgotDau(), GiaTien = GetGiaTien(menu.getBanhNgotDau()), KhuyenMai = 0 },
        //        new OrderItem { Name = "Bánh mì thịt", SoLuong = menu.GetNumBanhMiThit(), GiaTien = GetGiaTien(menu.getBanhMiThit()), KhuyenMai = 0 },
        //        new OrderItem { Name = "Pizza", SoLuong = menu.GetNumPizza(), GiaTien = GetGiaTien(menu.getPizza()), KhuyenMai = 0 },
        //        new OrderItem { Name = "Salad", SoLuong = menu.GetNumSalad(), GiaTien = GetGiaTien(menu.getSalad()), KhuyenMai = 0 },
        //        new OrderItem { Name = "Hamburger", SoLuong = menu.GetNumHamburger(), GiaTien = GetGiaTien(menu.getHamburger()), KhuyenMai = 0 },
        //        new OrderItem { Name = "Kem dừa", SoLuong = menu.GetNumKemDua(), GiaTien = GetGiaTien(menu.getKemDua()), KhuyenMai = 0 },
        //        new OrderItem { Name = "Nước ép táo", SoLuong = menu.GetNumNuocEpTao(), GiaTien = GetGiaTien(menu.getNuocEpTao()), KhuyenMai = 0 },
        //        new OrderItem { Name = "Cà phê đá xay", SoLuong = menu.GetNumCaPheDaXay(), GiaTien = GetGiaTien(menu.getCaPheDaXay()), KhuyenMai = 0 },
        //        new OrderItem { Name = "Trà sữa matcha", SoLuong = menu.GetNumTraSuaMatcha(), GiaTien = GetGiaTien(menu.getTraSuaMatcha()), KhuyenMai = 0 }
        //    };

        //    if (menu.Submit == true)
        //    {
        //        // Duyệt qua các món trong danh sách và thêm vào DataGridView nếu SoLuong > 0
        //        foreach (var item in orderItems)
        //        {
        //            if (item.SoLuong > 0)
        //            {
        //                dgv_hoaDon.Rows.Add(item.Name, item.SoLuong, item.GiaTien, item.KhuyenMai);
        //            }
        //        }
        //        menu.Submit = false;
        //    }

        //}


        //--------------------------------------------------------------------------------------------

        private void txtLuuThongTin_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult dialogResult = MessageBox.Show(
                "Bạn có muốn lưu thông tin không?", // Nội dung câu hỏi
                "Xác nhận",                        // Tiêu đề của hộp thoại
                MessageBoxButtons.YesNo,            // Các nút Yes/No
                MessageBoxIcon.Question);           // Biểu tượng câu hỏi

            // Kiểm tra xem người dùng chọn Yes hay No
            if (dialogResult == DialogResult.Yes)
            {
                // Nếu chọn Yes, thực hiện lưu thông tin
                if (lbSoBan.Text == "Bàn số 01")
                {
                    UpdateHoaDon(hoaDon01);
                    checkBan01 = true;
                    MessageBox.Show("Lưu thông thành công");
                }
                else if (lbSoBan.Text == "Bàn số 02")
                {
                    UpdateHoaDon(hoaDon02);
                    checkBan02 = true;
                    MessageBox.Show("Lưu thông thành công");
                }
                else if (lbSoBan.Text == "Bàn số 03")
                {
                    UpdateHoaDon(hoaDon03);
                    checkBan03 = true;
                    MessageBox.Show("Lưu thông thành công");
                }
                else if (lbSoBan.Text == "Bàn số 04")
                {
                    UpdateHoaDon(hoaDon04);
                    checkBan04 = true;
                    MessageBox.Show("Lưu thông thành công");
                }
                else if (lbSoBan.Text == "Bàn số 05")
                {
                    UpdateHoaDon(hoaDon05);
                    checkBan05 = true;
                    MessageBox.Show("Lưu thông thành công");
                }
                else if (lbSoBan.Text == "Bàn số 06")
                {
                    UpdateHoaDon(hoaDon06);
                    checkBan06 = true;
                    MessageBox.Show("Lưu thông thành công");
                }
                else if (lbSoBan.Text == "Bàn số 07")
                {
                    UpdateHoaDon(hoaDon07);
                    checkBan07 = true;
                    MessageBox.Show("Lưu thông thành công");
                }
                else if (lbSoBan.Text == "Bàn số 08")
                {
                    UpdateHoaDon(hoaDon08);
                    checkBan08 = true;
                    MessageBox.Show("Lưu thông thành công");
                }
                else if (lbSoBan.Text == "Bàn số 09")
                {
                    UpdateHoaDon(hoaDon09);
                    checkBan09 = true;
                    MessageBox.Show("Lưu thông thành công");
                }
            }
            // Nếu chọn No, không thực hiện gì thêm
            else
            {
                // Bạn có thể để trống hoặc thông báo gì đó nếu muốn
                MessageBox.Show("Lưu thông tin bị hủy.");
            }
        }


        private void btBan01_Click(object sender, EventArgs e)
        {
            lbSoBan.Text = "Bàn số 01";

            // Xóa dữ liệu cũ trong groupBox và tạo hóa đơn mới
            ResetControlsInGroupBox(groupBox1);

            if (checkBan01 == true)
            {
                LoadHoaDon(hoaDon01);
            }
        }

        private void btBan02_Click(object sender, EventArgs e)
        {
            lbSoBan.Text = "Bàn số 02";
            // Xóa dữ liệu cũ trong groupBox và tạo hóa đơn mới
            ResetControlsInGroupBox(groupBox1);

            if (checkBan02 == true)
            {
                LoadHoaDon(hoaDon02);
            }
        }

        private void btBan03_Click(object sender, EventArgs e)
        {
            lbSoBan.Text = "Bàn số 03";
            // Xóa dữ liệu cũ trong groupBox và tạo hóa đơn mới
            ResetControlsInGroupBox(groupBox1);

            if (checkBan03 == true)
            {
                LoadHoaDon(hoaDon03);
            }
        }

        private void btBan04_Click(object sender, EventArgs e)
        {
            lbSoBan.Text = "Bàn số 04";
            // Xóa dữ liệu cũ trong groupBox và tạo hóa đơn mới
            ResetControlsInGroupBox(groupBox1);

            if (checkBan04 == true)
            {
                LoadHoaDon(hoaDon04);
            }
        }

        private void btBan05_Click(object sender, EventArgs e)
        {
            lbSoBan.Text = "Bàn số 05";
            // Xóa dữ liệu cũ trong groupBox và tạo hóa đơn mới
            ResetControlsInGroupBox(groupBox1);

            if (checkBan05 == true)
            {
                LoadHoaDon(hoaDon05);
            }
        }

        private void btBan06_Click(object sender, EventArgs e)
        {
            lbSoBan.Text = "Bàn số 06";
            // Xóa dữ liệu cũ trong groupBox và tạo hóa đơn mới
            ResetControlsInGroupBox(groupBox1);

            if (checkBan06 == true)
            {
                LoadHoaDon(hoaDon06);
            }
        }

        private void btBan07_Click(object sender, EventArgs e)
        {
            lbSoBan.Text = "Bàn số 07";
            // Xóa dữ liệu cũ trong groupBox và tạo hóa đơn mới
            ResetControlsInGroupBox(groupBox1);

            if (checkBan07 == true)
            {
                LoadHoaDon(hoaDon07);
            }
        }

        private void btBan08_Click(object sender, EventArgs e)
        {
            lbSoBan.Text = "Bàn số 08";
            // Xóa dữ liệu cũ trong groupBox và tạo hóa đơn mới
            ResetControlsInGroupBox(groupBox1);

            if (checkBan08 == true)
            {
                LoadHoaDon(hoaDon08);
            }
        }

        private void btBan09_Click(object sender, EventArgs e)
        {
            lbSoBan.Text = "Bàn số 09";
            // Xóa dữ liệu cũ trong groupBox và tạo hóa đơn mới
            ResetControlsInGroupBox(groupBox1);

            if (checkBan09 == true)
            {
                LoadHoaDon(hoaDon09);
            }
        }

        private void btHuyHoaDon_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult dialogResult = MessageBox.Show(
                "Bạn có chắc chắn muốn hủy hóa đơn này không?", // Nội dung câu hỏi
                "Xác nhận hủy hóa đơn",                        // Tiêu đề của hộp thoại
                MessageBoxButtons.YesNo,                        // Các nút Yes/No
                MessageBoxIcon.Warning);                         // Biểu tượng cảnh báo

            // Kiểm tra xem người dùng chọn Yes hay No
            if (dialogResult == DialogResult.Yes)
            {
                // Tiến hành hủy hóa đơn nếu người dùng chọn Yes
                if (lbSoBan.Text == "Bàn số 01")
                {
                    DeleteHoaDon(hoaDon01);
                    checkBan01 = false;
                    MessageBox.Show("Hủy hóa đơn thành công");
                }
                else if (lbSoBan.Text == "Bàn số 02")
                {
                    DeleteHoaDon(hoaDon02);
                    checkBan02 = false;
                    MessageBox.Show("Hủy hóa đơn thành công");
                }
                else if (lbSoBan.Text == "Bàn số 03")
                {
                    DeleteHoaDon(hoaDon03);
                    checkBan03 = false;
                    MessageBox.Show("Hủy hóa đơn thành công");
                }
                else if (lbSoBan.Text == "Bàn số 04")
                {
                    DeleteHoaDon(hoaDon04);
                    checkBan04 = false;
                    MessageBox.Show("Hủy hóa đơn thành công");
                }
                else if (lbSoBan.Text == "Bàn số 05")
                {
                    DeleteHoaDon(hoaDon05);
                    checkBan05 = false;
                    MessageBox.Show("Hủy hóa đơn thành công");
                }
                else if (lbSoBan.Text == "Bàn số 06")
                {
                    DeleteHoaDon(hoaDon06);
                    checkBan06 = false;
                    MessageBox.Show("Hủy hóa đơn thành công");
                }
                else if (lbSoBan.Text == "Bàn số 07")
                {
                    DeleteHoaDon(hoaDon07);
                    checkBan07 = false;
                    MessageBox.Show("Hủy hóa đơn thành công");
                }
                else if (lbSoBan.Text == "Bàn số 08")
                {
                    DeleteHoaDon(hoaDon08);
                    checkBan08 = false;
                    MessageBox.Show("Hủy hóa đơn thành công");
                }
                else if (lbSoBan.Text == "Bàn số 09")
                {
                    DeleteHoaDon(hoaDon09);
                    checkBan09 = false;
                    MessageBox.Show("Hủy hóa đơn thành công");
                }
            }
            else
            {
                // Nếu chọn No, không thực hiện hành động gì
                MessageBox.Show("Hủy hóa đơn bị hủy.");
            }
        }

        private void btChonMon_Click(object sender, EventArgs e)
        {
            menu.Show();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            // Thêm một hàng mới vào DataGridView
            int index = dgv_hoaDon.Rows.Add();

            // Thiết lập giá trị cho các ô trong hàng mới
            dgv_hoaDon.Rows[index].Cells["SanPham"].Value = "Giá trị 1"; // Giá trị cột 1
            dgv_hoaDon.Rows[index].Cells["SoLuong"].Value = "Giá trị 2"; // Giá trị cột 2
            dgv_hoaDon.Rows[index].Cells["ThanhTien"].Value = "Giá trị 3"; // Giá trị cột 3
            dgv_hoaDon.Rows[index].Cells["KhuyenMai"].Value = "0"; // Giá trị cột 3
            // Hoặc bạn có thể dùng giá trị từ các điều khiển khác như TextBox nếu muốn
            // Ví dụ: dataGridView1.Rows[index].Cells["Column1"].Value = textBox1.Text;
        }
    }
}

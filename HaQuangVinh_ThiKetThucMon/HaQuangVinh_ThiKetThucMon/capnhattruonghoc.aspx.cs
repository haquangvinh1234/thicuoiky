using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaQuangVinh_ThiKetThucMon
{
    public partial class capnhattruonghoc : System.Web.UI.Page
    {
        public static string chuoiKetnoi = "Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=QL_SINHVIEN;Integrated Security=True";
        public static SqlConnection con = new SqlConnection(chuoiKetnoi);
        protected void Page_Load(object sender, EventArgs e)
        {
            Show();
        }

        public void Show()
        {
            try
            {
                string load = "SELECT * FROM tbl_truong";
                SqlDataAdapter adapter = new SqlDataAdapter(load, con);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                grvDSTH.DataSource = dataTable;
                grvDSTH.DataBind();

            }
            catch (Exception)
            {
                lblErorr.Style["color"] = "red";
                lblErorr.Text = "Lỗi kết nối";
            }
        }

        protected void grvDSTH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string load = "SELECT * FROM tbl_truong";
                SqlDataAdapter adapter = new SqlDataAdapter(load, con);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                int dong = grvDSTH.SelectedIndex;
                int trang = grvDSTH.PageIndex;
                txtMaTruong.Text = dataTable.Rows[trang * 4 + dong][0].ToString();
                txtTentruong.Text = dataTable.Rows[trang * 4 + dong][1].ToString();

            }
            catch (Exception)
            {
                lblErorr.Style["color"] = "red";
                lblErorr.Text = "Lỗi. Vui lòng kiểm tra lại !";
            }
        }

        protected void grvDSTH_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvDSTH.PageIndex = e.NewPageIndex;
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            txtMaTruong.Text = "";
            txtTentruong.Text = "";
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaTruong.Text == null || txtMaTruong.Text.Length == 0 || txtTentruong.Text == null || txtTentruong.Text.Length == 0)
                {
                    lblErorr.Style["color"] = "red";
                    lblErorr.Text = "Lỗi. Vui lòng nhập mã và tên trưởng để lưu !";
                }
                else
                {
                    string check = "SELECT * FROM tbl_truong WHERE MaTruong=N'" + txtMaTruong.Text + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(check, con);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        lblErorr.Style["color"] = "red";
                        lblErorr.Text = "Dữ liệu đã tồn tại !";
                    }
                    else
                    {
                        string insert = "INSERT INTO tbl_truong(MaTruong, TenTruong)VALUES(N'" + txtMaTruong.Text + "', N'" + txtTentruong.Text + "')";
                        SqlCommand sqlCommand = new SqlCommand(insert, con);
                        con.Open();
                        sqlCommand.ExecuteNonQuery();
                        con.Close();
                        Show();
                        lblErorr.Style["color"] = "blue";
                        lblErorr.Text = "Thêm thành công";
                        txtMaTruong.Text = "";
                        txtTentruong.Text = "";
                    }
                }
            }
            catch (Exception)
            {
                lblErorr.Style["color"] = "red";
                lblErorr.Text = "Lỗi. Vui lòng kiểm tra lại !";
            }
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaTruong.Text == null || txtMaTruong.Text.Length == 0)
                {
                    lblErorrMatruong.Style["color"] = "red";
                    lblErorrMatruong.Text = "Nhập mã trường cần xoá";
                }
                else
                {
                    string delete = "DELETE FROM tbl_truong WHERE MaTruong='" + txtMaTruong.Text + "'";
                    SqlCommand sqlCommand = new SqlCommand(delete, con);
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                    con.Close();
                    Show();
                    lblErorr.Style["color"] = "blue";
                    lblErorr.Text = "Xoá thành công trường có mã: " + txtMaTruong.Text.ToString();
                    txtMaTruong.Text = "";
                    txtTentruong.Text = "";
                    lblErorrMatruong.Text = "";
                }
            }
            catch (Exception)
            {
                lblErorr.Style["color"] = "red";
                lblErorr.Text = "Lỗi. Vui lòng kiểm tra lại !";
            }
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaTruong.Text == null || txtMaTruong.Text.Length == 0 || txtTentruong.Text == null || txtTentruong.Text.Length == 0)
                {
                    lblErorr.Style["color"] = "red";
                    lblErorr.Text = "Lỗi. Vui lòng nhập Mã của trường và tên mới của Trường muốn cập nhật !";
                }
                else
                {
                    string update = "UPDATE tbl_truong SET TenTruong=N'" + txtTentruong.Text + "' WHERE MaTruong='" + txtMaTruong.Text + "'";
                    SqlCommand sqlCommand = new SqlCommand(update, con);
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                    con.Close();
                    Show();
                    lblErorr.Style["color"] = "blue";
                    lblErorr.Text = "Cập nhật thành công trường có mã: " + txtMaTruong.Text.ToString();
                    txtMaTruong.Text = "";
                    txtTentruong.Text = "";
                }
            }
            catch (Exception)
            {
                lblErorr.Style["color"] = "red";
                lblErorr.Text = "Lỗi. Vui lòng kiểm tra lại !";
            }
        }
    }
}
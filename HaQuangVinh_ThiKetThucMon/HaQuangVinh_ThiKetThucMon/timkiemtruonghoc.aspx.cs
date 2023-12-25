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
    public partial class timkiemtruonghoc : System.Web.UI.Page
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
                txtMaTruong.Text = dataTable.Rows[trang * 8 + dong][0].ToString();
                txtTentruong.Text = dataTable.Rows[trang * 8 + dong][1].ToString();

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

        protected void btnTimtheoma_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaTruong.Text == null || txtMaTruong.Text.Length == 0)
                {
                    lblErorr.Style["color"] = "red";
                    lblErorr.Text = "Vui lòng nhập mã trường muốn tìm !";
                }
                else
                {
                    string search_by_id = "SELECT * FROM tbl_truong WHERE MaTruong='" + txtMaTruong.Text + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(search_by_id, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    grvDSTH.DataSource = dt;
                    grvDSTH.DataBind();
                    txtMaTruong.Text = "";
                    lblErorr.Text = "";
                }

            }
            catch (Exception)
            {
                lblErorr.Style["color"] = "red";
                lblErorr.Text = "Lỗi. Vui lòng kiểm tra lại";
            }
        }

        protected void btnTimtheoten_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTentruong.Text == null || txtTentruong.Text.Length == 0)
                {
                    lblErorr.Style["color"] = "red";
                    lblErorr.Text = "Vui lòng nhập Tên trường muốn tìm !";
                }
                else
                {
                    string search_by_name = "SELECT * FROM tbl_truong WHERE TenTruong=N'" + txtTentruong.Text + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(search_by_name, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    grvDSTH.DataSource = dt;
                    grvDSTH.DataBind();
                    txtTentruong.Text = "";
                    lblErorr.Text = "";

                }
            }
            catch (Exception)
            {
                lblErorr.Style["color"] = "red";
                lblErorr.Text = "Lỗi. Vui lòng kiểm tra lại";
            }
        }
    }
}
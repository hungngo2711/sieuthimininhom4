using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sieuthiwinform
{
    public partial class SellingForm : Form
    {
        public SellingForm()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\PHONG VU\Downloads\C-quanlybanahang\C-quanlybanahang\sieuthiwinform\supermarket.mdf"";Integrated Security=True");


        private void showdata()
        {
            connection.Open();
            string query = "select tensp, gia, soluong from sanphamtbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);
            sanphamDGV.DataSource = ds.Tables[0];
            sanphamDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connection.Close();
        }
        private void showdatabill()
        {
            connection.Open();
            string query = "select* from billtbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);
            billDGV.DataSource = ds.Tables[0];
            billDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connection.Close();
        }



        private void SellingForm_Load(object sender, EventArgs e)
        {
            showdata();
            showdatabill();
            fillcombo();
            nhanvientb.Text = Form1.tennv;
        }

        int flag = 0;


        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sanphamDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tensptb.Text = sanphamDGV.SelectedRows[0].Cells[0].Value.ToString();
            giatb.Text = sanphamDGV.SelectedRows[0].Cells[1].Value.ToString();
            soluongtb.Text = sanphamDGV.SelectedRows[0].Cells[2].Value.ToString();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            datetb.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();

        }
        int Grdtotal = 0, n = 0;

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (idtb.Text == "")
            {
                MessageBox.Show("id bill error");
            }
            else
            {
                try
                {
                    connection.Open();
                    String query = "insert into billtbl values(" + idtb.Text + ", '" + nhanvientb.Text + "', '" + datetb.Text + "', " + tongtientb.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm thành công");
                    connection.Close();
                    showdatabill();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(giatb.Text) * Convert.ToInt32(soluongtb.Text);

            if (tensptb.Text == "" || soluongtb.Text == "")
            {
                MessageBox.Show("không được trống !");
            }
            else
            {


                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(orderDGV);
                row.Cells[0].Value = n + 1;
                row.Cells[1].Value = tensptb.Text;
                row.Cells[2].Value = giatb.Text;
                row.Cells[3].Value = soluongtb.Text;
                row.Cells[4].Value = Convert.ToInt32(giatb.Text) * Convert.ToInt32(soluongtb.Text);
                orderDGV.Rows.Add(row);
                n++;
                Grdtotal = Grdtotal + total;
                tongtientb.Text = "" + Grdtotal;

            }




        }

        private void billDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Siêu thị Mini", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Red, new Point(230));
            e.Graphics.DrawString("Bill ID: " + billDGV.SelectedRows[0].Cells[0].Value.ToString(), new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Red, new Point(100, 70));

            e.Graphics.DrawString("Nhân viên: " + billDGV.SelectedRows[0].Cells[1].Value.ToString(), new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Red, new Point(100, 100));

            e.Graphics.DrawString("Ngày: " + billDGV.SelectedRows[0].Cells[2].Value.ToString(), new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Red, new Point(100, 130));
            e.Graphics.DrawString("Tổng tiền: " + billDGV.SelectedRows[0].Cells[3].Value.ToString(), new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Red, new Point(100, 160));
            e.Graphics.DrawString("Cảm ơn quý khách ", new Font("Century Gothic", 25, FontStyle.Italic), Brushes.Red, new Point(230, 230));

        }

        private void inbillbtn_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();

            }
        }

        private void refreshbtn_Click(object sender, EventArgs e)
        {
            showdata();
            fillcombo();
            showdatabill();
        }

        private void phanloaicb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            connection.Open();
            string query = "select tensp, soluong from sanphamtbl where phanloai = '" + phanloaicb.SelectedValue.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);
            sanphamDGV.DataSource = ds.Tables[0];
            sanphamDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connection.Close();

        }
        private void fillcombo()
        {
            connection.Open();
            string query = "select ten from phanloaitbl";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("ten", typeof(string));
            dt.Load(rdr);
            phanloaicb.ValueMember = "ten";
            phanloaicb.DataSource = dt;


            connection.Close();

        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 lg = new Form1();
            lg.Show();
        }

        private void resettext()
        {
            idtb.Text = "";
            tensptb.Text = "";
            soluongtb.Text = "";
            giatb.Text = "";
            phanloaicb.Text = "chọn";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

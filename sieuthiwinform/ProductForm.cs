using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace sieuthiwinform
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\PHONG VU\Downloads\C-quanlybanahang\C-quanlybanahang\sieuthiwinform\supermarket.mdf"";Integrated Security=True");


        private void exitid_Click(object sender, EventArgs e)
        {
            Application.Exit();


        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                String query = "insert into sanphamtbl values(" + idtb.Text + ", '" + tensptb.Text + "', '" + soluongtb.Text + "', '" + giatb.Text + "', '" + phanloaicb.Text + "')";
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm thành công");
                connection.Close();
                showdata();
                resettext();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }
        private void showdata()
        {
            connection.Open();
            string query = "select * from sanphamtbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);
            sanphamDGV.DataSource = ds.Tables[0];
            sanphamDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connection.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            fillcombo();
            showdata();

        }




        private void fillcombo()
        {
            connection.Open();
            string query = "select ten from phanloaitbl";
            SqlCommand cmd = new SqlCommand(query,  connection);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("ten", typeof(string));
            dt.Load(rdr);
            phanloaicb.ValueMember = "ten";
            phanloaicb.DataSource = dt;
            timkiemcb.ValueMember = "ten";
            timkiemcb.DataSource = dt;

            connection.Close();

        }
        private void resettext()
        {
            idtb.Text = "";
            tensptb.Text = "";
            soluongtb.Text = "";
            giatb.Text = "";
            phanloaicb.Text = "chọn";
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            category cat = new category();
            cat.Show();
            this.Hide();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (idtb.Text == "")
                {
                    MessageBox.Show("Chọn để xóa");

                }
                else
                {
                    connection.Open();
                    string query = "delete from sanphamtbl where Id=" + idtb.Text + "";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công");
                    connection.Close();
                    showdata();
                    resettext();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (idtb.Text == "" || tensptb.Text == "" || giatb.Text == "" ||  soluongtb.Text == "")
                {
                    MessageBox.Show("Chọn để xóa");
                }
                else
                {
                    connection.Open();
                    string query = "update sanphamtbl set tensp= '" + tensptb.Text + "', soluong = '" + soluongtb.Text + "', gia= '" + giatb.Text + "', phanloai = '" + phanloaicb.Text + "' where id = " + idtb.Text + "";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật thành công");

                    connection.Close();
                    showdata();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sanphamDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idtb.Text = sanphamDGV.SelectedRows[0].Cells[0].Value.ToString();
            tensptb.Text = sanphamDGV.SelectedRows[0].Cells[1].Value.ToString();
            giatb.Text = sanphamDGV.SelectedRows[0].Cells[2].Value.ToString();
            soluongtb.Text = sanphamDGV.SelectedRows[0].Cells[3].Value.ToString();
            phanloaicb.Text = sanphamDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void timkiemcb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            connection.Open();
            string query = "select * from sanphamtbl where phanloai ='"+timkiemcb.SelectedValue.ToString()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);
            sanphamDGV.DataSource = ds.Tables[0];
            sanphamDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connection.Close();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            showdata();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 lg = new Form1();
            lg.Show();
        }
    }
}

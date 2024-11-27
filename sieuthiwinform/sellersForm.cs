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
    public partial class sellersForm : Form
    {
        public sellersForm()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\PHONG VU\Downloads\C-quanlybanahang\C-quanlybanahang\sieuthiwinform\supermarket.mdf"";Integrated Security=True");


        private void editbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (idtb.Text == "" || hotentb.Text == "" || tuoitb.Text == "" || phonetb.Text == "" || passtb.Text == "")
                {
                    MessageBox.Show("Chọn để xóa");
                }
                else
                {
                    connection.Open();
                    string query = "update nhanvientbl set hoten = '" + hotentb.Text + "', tuoi = " + tuoitb.Text + ", sdt = " + phonetb.Text + ", matkhau = '" + passtb.Text + "' where Id = " + idtb.Text + "";
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

        private void sellersForm_Load(object sender, EventArgs e)
        {
            showdata();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                String query = "insert into nhanvientbl values(" + idtb.Text + ", '" + hotentb.Text + "', '" + tuoitb.Text + "', '" + phonetb.Text + "', '" + passtb.Text + "')";
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
            string query = "select * from nhanvientbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);
            nhanvienDGV.DataSource = ds.Tables[0];
            nhanvienDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connection.Close();
        }
        private void resettext()
        {
            idtb.Text = "";
            hotentb.Text = "";
            tuoitb.Text = "";
            phonetb.Text = "";
            passtb.Text = "";
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
                    string query = "delete from nhanvientbl where Id=" + idtb.Text + "";

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

        private void nhanvienDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idtb.Text = nhanvienDGV.SelectedRows[0].Cells[0].Value.ToString();
            hotentb.Text = nhanvienDGV.SelectedRows[0].Cells[1].Value.ToString();
            tuoitb.Text = nhanvienDGV.SelectedRows[0].Cells[2].Value.ToString();
            phonetb.Text = nhanvienDGV.SelectedRows[0].Cells[3].Value.ToString();
            passtb.Text = nhanvienDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void exitid_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            category cat = new category();
            cat.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ProductForm cat = new ProductForm();
            cat.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 lg = new Form1();
            lg.Show();
        }
    }
}

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
    public partial class category : Form
    {
        public category()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\PHONG VU\Downloads\C-quanlybanahang\C-quanlybanahang\sieuthiwinform\supermarket.mdf"";Integrated Security=True");
        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                String query = "insert into phanloaitbl values(" + idtb.Text + ", '" + tentb.Text + "', '" + motatb.Text + "')";
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.ExecuteNonQuery();
                
                MessageBox.Show("Thêm thành công");
                connection.Close();
                showdata();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void showdata()
        {
            connection.Open();
            string query = "select * from phanloaitbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var ds = new DataSet();
            sda.Fill(ds);
            phanloaiDGV.DataSource = ds.Tables[0];
            phanloaiDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connection.Close();
        }







        private void exitid_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void category_Load(object sender, EventArgs e)
        {
            showdata();
        }

        private void phanloaiDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void phanloaiDGV_Click(object sender, EventArgs e)
        {

            idtb.Text = phanloaiDGV.SelectedRows[0].Cells[0].Value.ToString();
            tentb.Text = phanloaiDGV.SelectedRows[0].Cells[1].Value.ToString();
            motatb.Text = phanloaiDGV.SelectedRows[0].Cells[2].Value.ToString();
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
                    string query = "delete from phanloaitbl where Id="+idtb.Text+"";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công");
                    connection.Close();
                    showdata();

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(idtb.Text == "" || tentb.Text == "" || motatb.Text == "")
                {
                    MessageBox.Show("Chọn để xóa");
                }
                else
                {
                    connection.Open();
                    string query ="update phanloaitbl set ten= '"+tentb.Text+"', mota = '"+motatb.Text+"' where id = "+idtb.Text+"";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật thành công");

                    connection.Close();
                    showdata();

                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ProductForm cat = new ProductForm();
            cat.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            sellersForm cat = new sellersForm();
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

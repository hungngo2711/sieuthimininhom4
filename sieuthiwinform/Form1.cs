using System.Data;
using System.Data.SqlClient;

namespace sieuthiwinform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\PHONG VU\Downloads\C-quanlybanahang\C-quanlybanahang\sieuthiwinform\supermarket.mdf"";Integrated Security=True");
        public static string tennv = "";
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            if (usertb.Text == "" || passtb.Text == "")
            {
                MessageBox.Show("không được để trống vui lòng nhập tài khoản mật khẩu !");

            }
            else
            {
                if(roleCb.SelectedIndex > -1)
                 {
                    if (roleCb.SelectedItem.ToString() == "Admin")
                    {
                        if (usertb.Text == "Admin" && passtb.Text == "123")
                        {
                            ProductForm prod = new ProductForm();
                            prod.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Nhập đúng tài khoản mật khẩu");
                        }
                    }
                    else
                    {
                        //MessageBox.Show("bạn là nhân viên");
                        connection.Open();
                        string query = "Select count (*) from nhanvientbl where hoten = '" + usertb.Text + "' and matkhau = '" + passtb.Text + "'";
                        SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            tennv = usertb.Text;
                            SellingForm sell = new SellingForm();
                            sell.Show();
                            this.Hide();
                            connection.Close();
                        }
                        else
                        {
                            MessageBox.Show("sai tài khoản mật khẩu");
                        }
                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Chọn đối tượng");

                }
             

            }
        }

        private void roleCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
        }
    }
}
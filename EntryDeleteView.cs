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

namespace WindowsFormsApplication1
{
    public partial class EntryDeleteView : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=SUMON-PC\SQLEXPRESS;Initial Catalog=Sumon;Integrated Security= true;");
        public EntryDeleteView()
        {
            InitializeComponent();
            LoadData();
        }

        //previous(Log In page)
        private void button5_Click(object sender, EventArgs e)
        {
            AdminLogIn obj = new AdminLogIn();

            obj.Show();
            this.Hide();
        }

        //Entry new bus
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "" && textBox5.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox9.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                conn.Open();
                string query = "INSERT INTO new_bus_info (bus_id,bus_name,from_where,to_where,date_of_journey,dep_time,arr_time,avai_seat,fare)VALUES (@bus_id,@bus_name,@from_where,@to_where,@date_of_journey,@dep_time,@arr_time,@avai_seat,@fare) ";
                SqlCommand bcmd = new SqlCommand(query, conn);
                bcmd.Parameters.AddWithValue("@bus_id", Convert.ToInt32(textBox8.Text));
                bcmd.Parameters.AddWithValue("@bus_name", textBox5.Text);
                bcmd.Parameters.AddWithValue("@from_where", textBox1.Text);
                bcmd.Parameters.AddWithValue("@to_where", textBox2.Text);
                bcmd.Parameters.AddWithValue("@date_of_journey", textBox9.Text);
                bcmd.Parameters.AddWithValue("@dep_time", textBox3.Text);
                bcmd.Parameters.AddWithValue("@arr_time", textBox4.Text);
                bcmd.Parameters.AddWithValue("@avai_seat", Convert.ToInt32(textBox6.Text));
                bcmd.Parameters.AddWithValue("@fare", Convert.ToInt32(textBox7.Text));
                bcmd.ExecuteNonQuery();
                MessageBox.Show("Information Inserted Successfully");
                conn.Close();
                LoadData();
                ClearData();  
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            } 
        }

        //Customer details
        private void button4_Click(object sender, EventArgs e)
        {
            CustomerDetails obj = new CustomerDetails();

            obj.Show();
            this.Hide();
        }

        //Delete bus schedule
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "")
            {
                conn.Open();
                string query = "delete from new_bus_info where bus_id='" + textBox8.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                sda.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Delete successfully");
                conn.Close();
                LoadData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            } 
        }

        //Update bus schedule
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "" && textBox5.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox9.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                conn.Open();
                string query = "update new_bus_info set bus_id = '" + textBox8.Text + "', bus_name = '" + textBox5.Text + "', from_where = '" + textBox1.Text + "', to_where = '" + textBox2.Text + "', dep_time = '" + textBox3.Text + "', arr_time = '" + textBox4.Text + "', avai_seat = '" + textBox6.Text + "', fare = '" + textBox7.Text + "', date_of_journey = '" + textBox9.Text + "'  where bus_id = '" + textBox8.Text + "'";
                SqlCommand bcmd = new SqlCommand(query, conn);
                bcmd.Parameters.AddWithValue("@bus_id", Convert.ToInt32(textBox8.Text));
                bcmd.Parameters.AddWithValue("@bus_name", textBox5.Text);
                bcmd.Parameters.AddWithValue("@from_where", textBox1.Text);
                bcmd.Parameters.AddWithValue("@to_where", textBox2.Text);
                bcmd.Parameters.AddWithValue("@date_of_journey", textBox9.Text);
                bcmd.Parameters.AddWithValue("@dep_time", textBox3.Text);
                bcmd.Parameters.AddWithValue("@arr_time", textBox4.Text);
                bcmd.Parameters.AddWithValue("@avai_seat", Convert.ToInt32(textBox6.Text));
                bcmd.Parameters.AddWithValue("@fare", Convert.ToInt32(textBox7.Text));
                bcmd.ExecuteNonQuery();
                MessageBox.Show("Updated successfully");
                conn.Close();
                LoadData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record To Update");
            } 
        }

        private void LoadData()
        {
            string cmd = "select * from new_bus_info";
            SqlDataAdapter adp = new SqlDataAdapter(cmd, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        } 

        private void ClearData()
        {
            textBox8.Text = "";
            textBox5.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox9.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        } 
    }
}

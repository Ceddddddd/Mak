using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leilanie
{
    public partial class Form2 : Form
    {
        private void SetDarkModeForDataGridView(DataGridView dataGridView)
        {
            dataGridView.BackgroundColor = Color.FromArgb(207, 151, 95); ;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // Set the foreground color (text color) of the DataGridView
            dataGridView.ForeColor = Color.White;

            // Set the header background color
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(207, 151, 95); // Change to black

            // Set the header foreground color (text color)
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(207, 151, 95);

            // Set the selection background color
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(207, 151, 95);

            // Set the selection foreground color
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;

            // Set the border color
            dataGridView.GridColor = Color.FromArgb(37, 42, 64);

            // Set the cell border style
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;


            dataGridView.RowsDefaultCellStyle.BackColor = Color.FromArgb(207, 151, 95);
            // Optionally, set specific column styles
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.DefaultCellStyle.BackColor = Color.FromArgb(207, 151, 95); ;
                column.DefaultCellStyle.ForeColor = Color.White;
                column.HeaderCell.Style.BackColor = Color.FromArgb(207, 151, 95); ;
                column.HeaderCell.Style.ForeColor = Color.White;
                column.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular); // Adjust font size as needed

            }
            dataGridView.RowTemplate.Height = 60;
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                // Center-align text in each column
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        }
        public static string connectionString = "Data Source=DESKTOP-2DKQGSL\\SQLEXPRESS;Initial Catalog=leilanie;Integrated Security=True";
        public Form2()
        {
            InitializeComponent();
            d1();
            SetDarkModeForDataGridView(dataGridView1);
        }
        private void d1() {

            string query = @"Select * from logbook";

            try
            {
                // Establish connection to SQL Server
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.Width = 164;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Leilanie" && textBox2.Text == "Leilanie")
            {
                DateTime dateTime = DateTime.Now;
                string sqlDateTimeFormat = dateTime.ToString("yyyy-MM-dd HH:mm:ss");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $"INSERT INTO logbook (time_in) VALUES ('{sqlDateTimeFormat}')";

                    // Create a SqlCommand to execute the query
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                this.Hide();
                Form1 form1 = new Form1();
                form1.ShowDialog();
            }
            else if (textBox1.Text != "Leilanie" && textBox2.Text == "Leilanie")
            {
                MessageBox.Show("Wrong Username");
            }
            else if (textBox1.Text == "Leilanie" && textBox2.Text != "Leilanie")
            {
                MessageBox.Show("Wrong Password");
            }
            else
            {
                MessageBox.Show("Wrong Password and Username");
            }
        }
    }
}

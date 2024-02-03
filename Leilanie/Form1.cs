using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leilanie
{
    public partial class Form1 : Form
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
        public Form1()
        {
            InitializeComponent();
            Customer.Hide();
            Orders.Hide();
            displaymain();
            displayorders();
            displayCustomers();
            displaytotalprice();
            displaycustomers1();
            d4();
            d3();
            SetDarkModeForDataGridView(dataGridView1);
            SetDarkModeForDataGridView(dataGridView2);
            SetDarkModeForDataGridView(dataGridView3);
            SetDarkModeForDataGridView(dataGridView4);

        }

        private void d4() {
            string query = @"Select * from Orders";

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
                    dataGridView4.DataSource = dataTable;
                    foreach (DataGridViewColumn column in dataGridView4.Columns)
                    {
                        column.Width = 100;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void d3() {
            string query = @"Select * from Products";

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
                    dataGridView3.DataSource = dataTable;
                    foreach (DataGridViewColumn column in dataGridView3.Columns)
                    {
                        column.Width = 116;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void displaycustomers1() {
            string query = @"Select * from Customers";

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
                    dataGridView2.DataSource = dataTable;
                    foreach (DataGridViewColumn column in dataGridView2.Columns)
                    {
                        column.Width = 190;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void displaytotalprice()
        {
            try
            {
                // Establish connection to SQL Server
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // SQL query to get the total number of orders
                    string query = "SELECT \r\n    SUM(TotalPrice) AS OverallTotalPrice\r\nFROM (\r\n    SELECT \r\n        Products.Price * Orders.Quantity AS TotalPrice\r\n    FROM \r\n        Orders\r\n    INNER JOIN \r\n        Customers ON Orders.CustomerID = Customers.CustomerID\r\n    INNER JOIN \r\n        Products ON Orders.ProductID = Products.ProductID\r\n) AS Subquery;";

                    // Create a SqlCommand to execute the query
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query and retrieve the total number of orders
                        decimal totalOrders = (decimal)command.ExecuteScalar();

                        // Display the total number of orders in the label
                        label7.Text = totalOrders.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void displayCustomers() {
            try
            {
                // Establish connection to SQL Server
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // SQL query to get the total number of orders
                    string query = "SELECT COUNT(*) FROM Customers";

                    // Create a SqlCommand to execute the query
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query and retrieve the total number of orders
                        int totalOrders = (int)command.ExecuteScalar();

                        // Display the total number of orders in the label
                        label6.Text = totalOrders.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void displayorders()
        {
            try
            {
                // Establish connection to SQL Server
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // SQL query to get the total number of orders
                    string query = "SELECT Sum(Quantity) FROM Orders";

                    // Create a SqlCommand to execute the query
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query and retrieve the total number of orders
                        int totalOrders = (int)command.ExecuteScalar();

                        // Display the total number of orders in the label
                        label5.Text = totalOrders.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        
    }
        private void displaymain() {
            string query = @"
               SELECT 
    CONCAT(Customers.FirstName, ' ', Customers.LastName) AS CustomerName,
    Products.Price * Orders.Quantity AS TotalPrice,
    Products.ProductName AS ProductName,
    Orders.OrderDate
FROM 
    Orders
INNER JOIN 
    Customers ON Orders.CustomerID = Customers.CustomerID
INNER JOIN 
    Products ON Orders.ProductID = Products.ProductID;";

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
                        column.Width = 190;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Orders.Hide();
            Customer.Show();
            Home.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer.Hide();
            Orders.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Get values from text boxes
            int customer_id = int.Parse(textBox1.Text);
            string customer_name = textBox2.Text;
            string customer_lastname = textBox3.Text;
            // SQL query to insert data into the Customers table
            string query = "INSERT INTO Customers (CustomerID, FirstName, LastName) VALUES (@CustomerID, @FirstName, @LastName)";

            // Create a SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a SqlCommand with the query and connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@CustomerID", customer_id);
                    command.Parameters.AddWithValue("@FirstName", customer_name);
                    command.Parameters.AddWithValue("@LastName", customer_lastname);

                    try
                    {
                        // Execute the query
                        command.ExecuteNonQuery();
                        Console.WriteLine("Data inserted successfully.");
                        displaymain();
                        displayorders();
                        displayCustomers();
                        displaytotalprice();
                        displaycustomers1();
                        SetDarkModeForDataGridView(dataGridView1);
                        SetDarkModeForDataGridView(dataGridView2);
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error inserting data: " + ex.Message);
                    }
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Get values from text boxes
            int customer_id = int.Parse(textBox1.Text);
            string customer_name = textBox2.Text;
            string customer_lastname = textBox3.Text;

            // Connection string for your SQL Server database

            // SQL query to update data in the Customers table
            string query = "UPDATE Customers SET FirstName = @FirstName, LastName = @LastName WHERE CustomerID = @CustomerID";

            // Create a SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a SqlCommand with the query and connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@CustomerID", customer_id);
                    command.Parameters.AddWithValue("@FirstName", customer_name);
                    command.Parameters.AddWithValue("@LastName", customer_lastname);

                    try
                    {
                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Data updated successfully.");
                            displaymain();
                            displayorders();
                            displayCustomers();
                            displaytotalprice();
                            displaycustomers1();
                            SetDarkModeForDataGridView(dataGridView1);
                            SetDarkModeForDataGridView(dataGridView2);
                        }
                        else
                        {
                            Console.WriteLine("No rows affected. CustomerID not found.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error updating data: " + ex.Message);
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Get customer ID from the text box
            int customer_id = int.Parse(textBox1.Text);

            // Connection string for your SQL Server database
           

            // SQL query to delete data from the Customers table
            string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";

            // Create a SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a SqlCommand with the query and connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameter to the command
                    command.Parameters.AddWithValue("@CustomerID", customer_id);

                    try
                    {
                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Data deleted successfully.");
                            displaymain();
                            displayorders();
                            displayCustomers();
                            displaytotalprice();
                            displaycustomers1();
                            SetDarkModeForDataGridView(dataGridView1);
                            SetDarkModeForDataGridView(dataGridView2);
                        }
                        else
                        {
                            Console.WriteLine("No rows affected. CustomerID not found.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error deleting data: " + ex.Message);
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private decimal CalculateTotalPrice(int product_id, int quantity)
        {
            // Retrieve the price of the product from the database
                decimal price = 0;
      // Query to retrieve the price based on the product_id
            string query = "SELECT Price FROM Products WHERE ProductID = @ProductID";

            // Establish connection to the database and execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", product_id);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        price = Convert.ToDecimal(result);
                    }
                    else
                    {
                        // Handle the case where the product ID does not exist
                        MessageBox.Show("Product ID not found.");
                    }
                }
            }

            // Calculate total price based on quantity and price
            decimal totalPrice = price * quantity;
            return totalPrice;
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row index is clicked
            {
                // Get the DataGridViewRow corresponding to the clicked cell
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                // Fill the textboxes with the values from the selected row
                textBox1.Text = row.Cells["CustomerID"].Value.ToString(); // Replace "Column1_Name" with the actual name of the column for fee_id
                textBox2.Text = row.Cells["FirstName"].Value.ToString(); // Replace "Column2_Name" with the actual name of the column for fee_name
                textBox3.Text = row.Cells["LastName"].Value.ToString();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

            int orderid = int.Parse(textBox6.Text);
            int custId = int.Parse(textBox5.Text);
            int prodId = int.Parse(textBox4.Text);
            DateTime dateTime = DateTime.Now;
            int quantity = int.Parse(textBox9.Text);
            int pointsEarned = 50; // Points earned per order

            string orderInsertQuery = "INSERT INTO Orders (OrderID, CustomerID, ProductID, OrderDate, Quantity) " +
                                      "VALUES (@OrderID, @CustomerID, @ProductID, @OrderDate, @Quantity)";

            // Create a SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Begin a SQL transaction
                SqlTransaction transaction = connection.BeginTransaction();

                // Create a SqlCommand with the query and connection
                using (SqlCommand command = new SqlCommand(orderInsertQuery, connection, transaction))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@OrderID", orderid);
                    command.Parameters.AddWithValue("@CustomerID", custId);
                    command.Parameters.AddWithValue("@ProductID", prodId);
                    command.Parameters.AddWithValue("@OrderDate", dateTime);
                    command.Parameters.AddWithValue("@Quantity", quantity);

                    try
                    {
                        // Execute the order insertion query
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Update pointsEarned for the customer
                            string updateQuery = "UPDATE Customers SET pointsEarned = pointsEarned + @PointsEarned WHERE CustomerID = @CustomerID";
                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction))
                            {
                                // Add parameters to the update command
                                updateCommand.Parameters.AddWithValue("@PointsEarned", pointsEarned);
                                updateCommand.Parameters.AddWithValue("@CustomerID", custId);

                                // Execute the update command
                                updateCommand.ExecuteNonQuery();
                            }

                            // Commit the transaction
                            transaction.Commit();

                            Console.WriteLine("Data inserted successfully.");
                            displaymain();
                            displayorders();
                            displayCustomers();
                            displaytotalprice();
                            displaycustomers1();
                            d4();
                            d3();
                            SetDarkModeForDataGridView(dataGridView1);
                            SetDarkModeForDataGridView(dataGridView2);
                            SetDarkModeForDataGridView(dataGridView3);
                            SetDarkModeForDataGridView(dataGridView4);
                        }
                        else
                        {
                            Console.WriteLine("No rows affected.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Rollback the transaction if an error occurs
                        transaction.Rollback();
                        Console.WriteLine("Error inserting data: " + ex.Message);
                    }
                }
            }


        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Get values from text boxes
            int orderid = int.Parse(textBox6.Text);
            int custId = int.Parse(textBox5.Text);
            int prodId = int.Parse(textBox4.Text);
            DateTime dateTime = DateTime.Now;
            int quantity = int.Parse(textBox9.Text);

            string query = "UPDATE Orders " +
                           "SET CustomerID = @CustomerID, " +
                           "    ProductID = @ProductID, " +
                           "    OrderDate = @OrderDate, " +
                           "    Quantity = @Quantity " +
                           "WHERE OrderID = @OrderID";

            // Create a SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a SqlCommand with the query and connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@OrderID", orderid);
                    command.Parameters.AddWithValue("@CustomerID", custId);
                    command.Parameters.AddWithValue("@ProductID", prodId);
                    command.Parameters.AddWithValue("@OrderDate", dateTime);
                    command.Parameters.AddWithValue("@Quantity", quantity);

                    try
                    {
                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Data updated successfully.");
                            displaymain();
                            displayorders();
                            displayCustomers();
                            displaytotalprice();
                            displaycustomers1();
                            d4();
                            d3();
                            SetDarkModeForDataGridView(dataGridView1);
                            SetDarkModeForDataGridView(dataGridView2);
                            SetDarkModeForDataGridView(dataGridView3);
                            SetDarkModeForDataGridView(dataGridView4);
                        }
                        else
                        {
                            Console.WriteLine("No rows affected. OrderID not found.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error updating data: " + ex.Message);
                    }
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Get order ID from the text box
            int orderid = int.Parse(textBox6.Text);

            // SQL query to delete data from the Orders table
            string query = "DELETE FROM Orders WHERE OrderID = @OrderID";

            // Create a SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a SqlCommand with the query and connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameter to the command
                    command.Parameters.AddWithValue("@OrderID", orderid);

                    try
                    {
                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Data deleted successfully.");
                            displaymain();
                            displayorders();
                            displayCustomers();
                            displaytotalprice();
                            displaycustomers1();
                            d4();
                            d3();
                            SetDarkModeForDataGridView(dataGridView1);
                            SetDarkModeForDataGridView(dataGridView2);
                            SetDarkModeForDataGridView(dataGridView3);
                            SetDarkModeForDataGridView(dataGridView4);
                        }
                        else
                        {
                            Console.WriteLine("No rows affected. OrderID not found.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error deleting data: " + ex.Message);
                    }
                }
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row index is clicked
            {
                // Get the DataGridViewRow corresponding to the clicked cell
                DataGridViewRow row = dataGridView4.Rows[e.RowIndex];

                // Fill the textboxes with the values from the selected row
                textBox6.Text = row.Cells["OrderID"].Value.ToString(); // Replace "Column1_Name" with the actual name of the column for fee_id
                textBox5.Text = row.Cells["CustomerID"].Value.ToString(); // Replace "Column2_Name" with the actual name of the column for fee_name
                textBox4.Text = row.Cells["ProductID"].Value.ToString();
                textBox9.Text = row.Cells["Quantity"].Value.ToString(); // Replace "Column1_Name" with the actual name of the column for fee_id
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox9.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home.Show();
            Orders.Show();
            Customer.Show();
        }

        private void button4_Click(object sender, EventArgs e)
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
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}

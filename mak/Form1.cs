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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace mak
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            displayPosition();
            displayNoofCandidates(); 
            displaytotalvoters();
            displayvoted();
            DisplayVoters();
            displaycandidates();
            addcandidatesview();
            view();
            candidatesPanel.Hide();
        }
        private string connectionString = "Data Source=DESKTOP-2DKQGSL\\SQLEXPRESS;Initial Catalog=mak;Integrated Security=True";
        private void view() {
            dataGridView3.DataSource = null;

            // Create a DataTable to hold the candidate data
            DataTable dataTable = new DataTable();

            // Create a SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Define the SQL query to fetch candidate data
                string query = @"SELECT * FROM Position";

                // Create a SqlCommand to execute the query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Create a SqlDataReader to read the data
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Load the data into the DataTable
                        dataTable.Load(reader);
                    }
                }

                // Close the connection
                connection.Close();
            }

            // Bind the DataTable to the DataGridView
            dataGridView3.DataSource = dataTable;
            foreach (DataGridViewColumn column in dataGridView3.Columns)
            {
                // Set the desired width for each column
                column.Width = 135; // Adjust the width as needed
            }
        }
        private void addcandidatesview() {
            // Clear existing data in DataGridView5
            dataGridView2.DataSource = null;

            // Create a DataTable to hold the candidate data
            DataTable dataTable = new DataTable();

            // Create a SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Define the SQL query to fetch candidate data
                string query = @"SELECT * FROM Candidate";

                // Create a SqlCommand to execute the query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Create a SqlDataReader to read the data
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Load the data into the DataTable
                        dataTable.Load(reader);
                    }
                }

                // Close the connection
                connection.Close();
            }
            
            // Bind the DataTable to the DataGridView
            dataGridView2.DataSource = dataTable;
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                // Set the desired width for each column
                column.Width = 278; // Adjust the width as needed
            }

        }
        private void DisplayVoters()
        {   
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a SqlCommand to fetch data from the Voter table
                string query = "SELECT * FROM Voter";
                SqlCommand command = new SqlCommand(query, connection);

                // Create a SqlDataAdapter to fill a DataSet
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                // Create a new DataSet
                DataSet dataSet = new DataSet();

                // Fill the DataSet with data from the Voter table
                adapter.Fill(dataSet, "Voter");

                // Close the connection
                connection.Close();

                // Bind the DataSet to DataGridView2
                dataGridView5.DataSource = dataSet.Tables["Voter"];
            }
        }
        private void displaycandidates()
    {
            // Create a SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a SqlCommand to fetch data from the Voter table
                string query = "SELECT c.CandidateID, c.CandidateName, p.PositionName, COUNT(vp.VoterID) AS NumVotes\r\nFROM Candidate c\r\nJOIN VoterPosition vp ON c.CandidateID = vp.CandidateID\r\nJOIN Position p ON c.PositionID = p.PositionID\r\nGROUP BY c.CandidateID, c.CandidateName, p.PositionName\r\nORDER BY COUNT(vp.VoterID) DESC;";
                SqlCommand command = new SqlCommand(query, connection);

                // Create a SqlDataAdapter to fill a DataSet
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                // Create a new DataSet
                DataSet dataSet = new DataSet();

                // Fill the DataSet with data from the Voter table
                adapter.Fill(dataSet, "Voter");

                // Close the connection
                connection.Close();
                
                // Bind the DataSet to the DataGridView
                dataGridView1.DataSource = dataSet.Tables["Voter"];

            }

        }

        private void displayvoted() {
            string query = "SELECT \r\n    COUNT(*) AS NumberOfVotersVoted\r\nFROM \r\n    Voter\r\nWHERE \r\n    HasVoted = 1;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int candidateCount = (int)command.ExecuteScalar();
                        lvlvoted.Text = candidateCount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void displaytotalvoters() {
            string query = "SELECT COUNT(*) AS 'Total Voters'\r\nFROM Voter;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int candidateCount = (int)command.ExecuteScalar();
                        lvlvtrs.Text = candidateCount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void displayNoofCandidates() {
            string query = "SELECT COUNT(*) FROM Candidate";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int candidateCount = (int)command.ExecuteScalar();
                        lvlcandi.Text = candidateCount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void displayPosition() {
            string query = "SELECT COUNT(*) FROM Position";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int positionCount = (int)command.ExecuteScalar();
                        lvlpos.Text = positionCount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void candidatesPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            candidatesPanel.Hide();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            candidatesPanel.Show();
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string candidateName = textBox2.Text;
            int candidateID;
            if (int.TryParse(textBox3.Text, out candidateID))
            {
                string updateQuery = "UPDATE Candidate SET CandidateName = @CandidateName WHERE CandidateID = @CandidateID";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CandidateName", candidateName);
                        command.Parameters.AddWithValue("@CandidateID", candidateID);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Candidate updated successfully.");
                            addcandidatesview();
                        }
                        else
                        {
                            MessageBox.Show("No candidate with the specified ID found.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid CandidateID. Please enter a valid integer.");
            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string deleteVoterQuery = "DELETE FROM VoterPosition";
            string deleteVoterPositionQuery = "DELETE FROM Voter";

            // Open connection and execute delete queries
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Delete data from Voter table
                using (SqlCommand command = new SqlCommand(deleteVoterQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Delete data from VoterPosition table
                using (SqlCommand command = new SqlCommand(deleteVoterPositionQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                displayPosition();
                displayNoofCandidates();
                displaytotalvoters();
                displayvoted();
                DisplayVoters();
                displaycandidates();
                addcandidatesview();
                view();
                // Display success message
                MessageBox.Show("All data from Voter and VoterPosition tables deleted successfully.");

                // Close connection
                connection.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3();
            form.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dataGridView = (DataGridView)sender;
                object cellValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                textBox2.Text = cellValue?.ToString();
                textBox3.Text = e.ColumnIndex.ToString();
            }
        }
    }
}

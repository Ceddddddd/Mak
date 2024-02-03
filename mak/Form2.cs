using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mak
{
    public partial class Form2 : Form
    {
        public static Form3 instance;
        string connectionString = "Data Source=DESKTOP-2DKQGSL\\SQLEXPRESS;Initial Catalog=mak;Integrated Security=True";
        public Form2()
        {
            InitializeComponent();
            displayPresidents();
            displayVPresidents();
            Secretary();
            Treasurer();
            Auditor();
            PRC();
            panel23.Hide();
        }
        private void PRC()
        {
            string query1 = @"SELECT CandidateName
                        FROM Candidate
                        WHERE CandidateID = 11 AND PositionID = 7; ";
            string query2 = @"SELECT CandidateName
                        FROM Candidate
                        WHERE CandidateID = 6 AND PositionID = 7; ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            radioButton13.Text = result.ToString();
                        }
                        else
                        {
                            radioButton13.Text = "No candidate for president found";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally { connection.Close(); }
                }
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            radioButton14.Text = result.ToString();
                        }
                        else
                        {
                            radioButton14.Text = "No candidate for president found";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally { connection.Close(); }
                }

            }
        }
        private void Auditor()
        {
            string query1 = @"SELECT CandidateName
                        FROM Candidate
                        WHERE CandidateID = 10 AND PositionID = 6; ";
            string query2 = @"SELECT CandidateName
                        FROM Candidate
                        WHERE CandidateID = 5 AND PositionID = 6; ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            radioButton15.Text = result.ToString();
                        }
                        else
                        {
                            radioButton15.Text = "No candidate for president found";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally { connection.Close(); }
                }
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            radioButton16.Text = result.ToString();
                        }
                        else
                        {
                            radioButton16.Text = "No candidate for president found";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally { connection.Close(); }
                }

            }
        }
        private void Treasurer()
        {
            string query1 = @"SELECT CandidateName
                        FROM Candidate
                        WHERE CandidateID = 9 AND PositionID = 5; ";
            string query2 = @"SELECT CandidateName
                        FROM Candidate
                        WHERE CandidateID = 4 AND PositionID = 5; ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            radioButton8.Text = result.ToString();
                        }
                        else
                        {
                            radioButton8.Text = "No candidate for president found";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally { connection.Close(); }
                }
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            radioButton7.Text = result.ToString();
                        }
                        else
                        {
                            radioButton7.Text = "No candidate for president found";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally { connection.Close(); }
                }

            }
        }
        private void Secretary()
        {
            string query1 = @"SELECT CandidateName
                        FROM Candidate
                        WHERE CandidateID = 8 AND PositionID = 4; ";
            string query2 = @"SELECT CandidateName
                        FROM Candidate
                        WHERE CandidateID = 3 AND PositionID = 4; ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            radioButton6.Text = result.ToString();
                        }
                        else
                        {
                            radioButton6.Text = "No candidate for president found";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally { connection.Close(); }
                }
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            radioButton5.Text = result.ToString();
                        }
                        else
                        {
                            radioButton5.Text = "No candidate for president found";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally { connection.Close(); }
                }

            }
        }

        private void displayVPresidents()
        {
            string query1 = @"SELECT CandidateName
                        FROM Candidate
                        WHERE CandidateID = 7 AND PositionID = 3; ";
            string query2 = @"SELECT CandidateName
                        FROM Candidate
                        WHERE CandidateID = 2 AND PositionID = 3; ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            radioButton3.Text = result.ToString();
                        }
                        else
                        {
                            radioButton3.Text = "No candidate for president found";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally { connection.Close(); }
                }
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            radioButton4.Text = result.ToString();
                        }
                        else
                        {
                            radioButton4.Text = "No candidate for president found";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally { connection.Close(); }
                }

            }
        }
        private void displayPresidents() {
            string query1 = @"SELECT CandidateName
                        FROM Candidate
                        WHERE CandidateID = 6 AND PositionID = 2; ";
            string query2 = @"SELECT CandidateName
                        FROM Candidate
                        WHERE CandidateID = 1 AND PositionID = 2; ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            radioButton2.Text = result.ToString();
                        }
                        else
                        {
                            radioButton2.Text = "No candidate for president found";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally { connection.Close(); }
                }
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            radioButton1.Text = result.ToString();
                        }
                        else
                        {
                            radioButton1.Text = "No candidate for president found";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                    finally { connection.Close(); }
                }
           
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string voterName = Form3.votername;
            int voterID = Form3.voterid;
            string voterAddress = Form3.voteaddress;
            int voterYear = Form3.year;
            int hasVoted = 1;
            try
            {
                string query = @"INSERT INTO Voter (VoterID, VoterName, VoterAddress, VoterYear, HasVoted)
                 VALUES (@VoterID, @VoterName, @VoterAddress, @VoterYear, @hasVoted)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VoterID", voterID);
                    command.Parameters.AddWithValue("@VoterName", voterName);
                    command.Parameters.AddWithValue("@VoterAddress", voterAddress);
                    command.Parameters.AddWithValue("@VoterYear", voterYear);
                    command.Parameters.AddWithValue("@HasVoted", hasVoted);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                int President = 0;
                int VPpresident = 0;
                int Secretary = 0;
                int Treasurer = 0;
                int Auditor = 0;
                int PRO = 0;
                if (radioButton1.Checked)
                {
                    President = 1;
                }
                else if (radioButton2.Checked)
                {
                    President = 6;
                }
                if (radioButton3.Checked)
                {
                    VPpresident = 7;
                }
                else if (radioButton4.Checked)
                {
                    VPpresident = 2;
                }
                if (radioButton5.Checked)
                {
                    Secretary = 3;
                }
                else if (radioButton6.Checked)
                {
                    Secretary = 8;
                }
                if (radioButton7.Checked)
                {
                    Treasurer = 4;
                }
                else if (radioButton8.Checked)
                {
                    Treasurer = 9;
                }
                if (radioButton15.Checked)
                {
                    Auditor = 10;
                }
                else if (radioButton16.Checked)
                {
                    Auditor = 5;
                }

                // Assuming you have already defined the voter information and connection string

                // Define insert queries for each position
                string queryPresident = @"INSERT INTO VoterPosition (VoterID, PositionID, CandidateID)
                          VALUES (@VoterID, @PositionID, @CandidateID)";
                string queryVPpresident = @"INSERT INTO VoterPosition (VoterID, PositionID, CandidateID)
                            VALUES (@VoterID, @PositionID, @CandidateID)";
                string querySecretary = @"INSERT INTO VoterPosition (VoterID, PositionID, CandidateID)
                            VALUES (@VoterID, @PositionID, @CandidateID)";
                string queryTreasurer = @"INSERT INTO VoterPosition (VoterID, PositionID, CandidateID)
                            VALUES (@VoterID, @PositionID, @CandidateID)";
                string queryAuditor = @"INSERT INTO VoterPosition (VoterID, PositionID, CandidateID)
                            VALUES (@VoterID, @PositionID, @CandidateID)";

                // Define queries for other positions...

                // Open the connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(queryPresident, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@VoterID", voterID);
                    command.Parameters.AddWithValue("@PositionID", 2); // Assuming PositionID for President is 2
                    command.Parameters.AddWithValue("@CandidateID", President); // CandidateID based on selected radio button
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(queryVPpresident, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@VoterID", voterID);
                    command.Parameters.AddWithValue("@PositionID", 3); // Assuming PositionID for Vice President is 3
                    command.Parameters.AddWithValue("@CandidateID", VPpresident); // CandidateID based on selected radio button
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(querySecretary, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@VoterID", voterID);
                    command.Parameters.AddWithValue("@PositionID", 4); // Assuming PositionID for Vice President is 3
                    command.Parameters.AddWithValue("@CandidateID", Secretary); // CandidateID based on selected radio button
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(queryTreasurer, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@VoterID", voterID);
                    command.Parameters.AddWithValue("@PositionID", 5); // Assuming PositionID for Vice President is 3
                    command.Parameters.AddWithValue("@CandidateID", Treasurer); // CandidateID based on selected radio button
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(queryAuditor, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@VoterID", voterID);
                    command.Parameters.AddWithValue("@PositionID", 6); // Assuming PositionID for Vice President is 3
                    command.Parameters.AddWithValue("@CandidateID", Auditor); // CandidateID based on selected radio button
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                this.Hide();
                Form3 form = new Form3();   
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            


        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

namespace DataAccessLayer
{
    public class clsPaymentData
    {

  

    
        public static int AddNewPayment(DateTime? PaymentDate, byte? PaymentMethod, decimal AmountPaid, string AdditionalNotes)
        {
            int InsertedID = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = "INSERT INTO Payments (PaymentDate, PaymentMethod, AmountPaid, AdditionalNotes) " +
                                   "VALUES (@PaymentDate, @PaymentMethod, @AmountPaid, @AdditionalNotes); " +
                                   "SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentDate", PaymentDate);
                        command.Parameters.AddWithValue("@PaymentMethod", (object)PaymentMethod ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AmountPaid", AmountPaid);
                        command.Parameters.AddWithValue("@AdditionalNotes", (object)AdditionalNotes ?? DBNull.Value);

                        connection.Open();
                         object result = command.ExecuteScalar();
                        if(result!=null&&int.TryParse(result.ToString(),out int ID))
                        {   
                            InsertedID=ID;
                        }
               
                    }
                }
            }
            catch (Exception ex)
            {
                string sourceName = "P1Clinic";
                // Create the event source if it does not exist
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }
                EventLog.WriteEntry(sourceName, $"{ex}", EventLogEntryType.Error);
            }
            return InsertedID;
        }

   
        public static bool UpdatePayment(int PaymentID, DateTime? PaymentDate, byte? PaymentMethod, decimal AmountPaid, string AdditionalNotes)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = "UPDATE Payments SET PaymentDate = @PaymentDate, PaymentMethod = @PaymentMethod, " +
                                   "AmountPaid = @AmountPaid, AdditionalNotes = @AdditionalNotes WHERE PaymentID = @PaymentID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);
                        command.Parameters.AddWithValue("@PaymentDate", PaymentDate);
                        command.Parameters.AddWithValue("@PaymentMethod", (object)PaymentMethod ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AmountPaid", AmountPaid);
                        command.Parameters.AddWithValue("@AdditionalNotes", (object)AdditionalNotes ?? DBNull.Value);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                 
                    }
                }

            }
            catch (Exception ex)
            {
                string sourceName = "P1Clinic";
                // Create the event source if it does not exist
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }
                EventLog.WriteEntry(sourceName, $"{ex}", EventLogEntryType.Error);
            }
            return rowsAffected > 0;

        }

  
        public static DataTable GetAllPayments()
        {
            DataTable dt = new DataTable();
            try
            {
           
                using (SqlConnection connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Payments";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                 
                    }
                }
            }
            catch (Exception ex)
            {
                string sourceName = "P1Clinic";
                // Create the event source if it does not exist
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }
                EventLog.WriteEntry(sourceName, $"{ex}", EventLogEntryType.Error);
            }
            return dt;
        }
         
        public static bool IsPaymentExistByID(int PaymentID)
        {
            bool IsExist = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = "SELECT IsExist FROM Payments WHERE PaymentID = @PaymentID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            IsExist = reader.HasRows;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                string sourceName = "P1Clinic";
                // Create the event source if it does not exist
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }
                EventLog.WriteEntry(sourceName, $"{ex}", EventLogEntryType.Error);
            }
            return IsExist;
        }

       
        public static bool FindPaymentByID(int PaymentID, ref DateTime? PaymentDate, ref byte? PaymentMethod, ref decimal AmountPaid, ref string AdditionalNotes)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Payments WHERE PaymentID = @PaymentID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;
                                PaymentDate = Convert.ToDateTime(reader["PaymentDate"]);
                                PaymentMethod = (byte)reader["PaymentMethod"];
                                AmountPaid = Convert.ToDecimal(reader["AmountPaid"]);
                                AdditionalNotes = reader["AdditionalNotes"].ToString();

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string sourceName = "P1Clinic";
                // Create the event source if it does not exist
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }
                EventLog.WriteEntry(sourceName, $"{ex}", EventLogEntryType.Error);
            }
            
            return IsFound;
        }

        public static int GetPatientIDByPaymentID(int PaymentID)
        {

            int InsertedID = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @" select pat.PatientID from Payments pay inner join Appointments app on app.PaymentID=pay.PaymentID
                                     inner join Patients pat on pat.PatientID=app.PatientID  where app.PaymentID=@PaymentID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);
                

                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int ID))
                        {
                            InsertedID = ID;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                string sourceName = "P1Clinic";
                // Create the event source if it does not exist
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }
                EventLog.WriteEntry(sourceName, $"{ex}", EventLogEntryType.Error);
            }
            return InsertedID;
        }
































    }
}

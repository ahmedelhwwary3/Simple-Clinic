using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace DataAccessLayer
{
    public class clsPatientData
    {
        public static DataTable GetAllPatients()
        {
            DataTable dtPatients = new DataTable();
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = "Select * From Patients ";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtPatients.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string sourceName = "P1Clinic";
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }
                EventLog.WriteEntry(sourceName, $"{ex}", EventLogEntryType.Error);
            }
            return dtPatients;
        }

        public static int AddNewPatient( int PersonID)
        {
            int InsertedID = 0;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Insert into Patients ( PersonID)
                                     Values ( @PersonID);
                                     Select Scope_Identity();";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                   
                        command.Parameters.AddWithValue("@PersonID", PersonID);

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
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }
                EventLog.WriteEntry(sourceName, $"{ex}", EventLogEntryType.Error);
            }
            return InsertedID;
        }

        public static bool UpdatePatient(int PatientID, int PersonID)
        {
            int AffectedRows = 0;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Update Patients Set PersonID=@PersonID
                                     Where PatientID=@PatientID;";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PatientID", PatientID);
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        AffectedRows = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                string sourceName = "P1Clinic";
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }
                EventLog.WriteEntry(sourceName, $"{ex}", EventLogEntryType.Error);
            }
            return AffectedRows > 0;
        }

        public static bool IsPatientExistByID(int PatientID)
        {
            bool IsExist = false;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Select IsExist=1 from Patients Where PatientID=@PatientID;";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PatientID", PatientID);
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
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }
                EventLog.WriteEntry(sourceName, $"{ex}", EventLogEntryType.Error);
            }
            return IsExist;
        }

        public static bool DeletePatientByID(int PatientID)
        {
            int AffectedRows = 0;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Delete from Patients Where PatientID=@PatientID;";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PatientID", PatientID);
                        AffectedRows = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                string sourceName = "P1Clinic";
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }
                EventLog.WriteEntry(sourceName, $"{ex}", EventLogEntryType.Error);
            }
            return AffectedRows > 0;
        }

        public static bool FindPatientByID(int PatientID, ref int PersonID)
        {
            bool IsExist = false;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Select * from Patients Where PatientID=@PatientID;";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PatientID", PatientID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsExist = true;
                                PersonID = (int)reader["PersonID"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string sourceName = "P1Clinic";
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }
                EventLog.WriteEntry(sourceName, $"{ex}", EventLogEntryType.Error);
            }
            return IsExist;
        }
    }
}

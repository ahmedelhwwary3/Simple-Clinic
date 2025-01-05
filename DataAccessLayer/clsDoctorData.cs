using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace DataAccessLayer
{
    public class clsDoctorData
    {
        public static DataTable GetAllDoctors()
        {
            DataTable dt=   new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Select * From Doctors;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.HasRows)
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
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }
                EventLog.WriteEntry(sourceName, ex.ToString(), EventLogEntryType.Error);
            }
            return dt;
        }
        public static DataTable GetAllDoctorsNames()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Select p.Name From Doctors d inner join People p on d.PersonID=p.PersonID;";

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
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }
                EventLog.WriteEntry(sourceName, ex.ToString(), EventLogEntryType.Error);
            }
            return dt;
        }
        public static bool FindDoctorByName(string Name, ref int DoctorID, ref int PersonID, ref string Specialization)
        {
            bool IsExist = false;   
            try
            {
                using (SqlConnection connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Select d.DoctorID,d.PersonID,d.Specialization From Doctors d inner join People p on d.PersonID=p.PersonID where p.Name=@Name";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name",Name);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            
                            if(reader.Read())
                            {
                                IsExist = true;
                                DoctorID = (int)reader["DoctorID"];
                                PersonID = (int)reader["PersonID"];
                                Specialization = (string)reader["Specialization"];
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
                EventLog.WriteEntry(sourceName, ex.ToString(), EventLogEntryType.Error);
            }
            return IsExist;
        }
        public static int AddNewDoctor(int PersonID, string Specialization)
        {
            int InsertedID = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = "INSERT INTO Doctors (PersonID, Specialization) " +
                                   "VALUES (@PersonID, @Specialization); " +
                                   "SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@Specialization", (object)Specialization ?? DBNull.Value);

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
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }
                EventLog.WriteEntry(sourceName, ex.ToString(), EventLogEntryType.Error);
            }
            return InsertedID;
        }

        public static bool UpdateDoctorByID(int DoctorID, int PersonID, string Specialization)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = "UPDATE Doctors SET PersonID = @PersonID, Specialization = @Specialization " +
                                   "WHERE DoctorID = @DoctorID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DoctorID", DoctorID);
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@Specialization", (object)Specialization ?? DBNull.Value);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
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
                EventLog.WriteEntry(sourceName, ex.ToString(), EventLogEntryType.Error);
            }
            return rowsAffected > 0;
        }
        public static bool DeleteDoctorByID(int DoctorID )
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"delete from Doctors WHERE DoctorID = @DoctorID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                 
                        command.Parameters.AddWithValue("@DoctorID", DoctorID);
                         
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
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
                EventLog.WriteEntry(sourceName, ex.ToString(), EventLogEntryType.Error);
            }
            return rowsAffected > 0;
        }

        public static bool FindDoctorByID(int DoctorID,ref int PersonID,ref string Specialization)
        {
            bool IsExist = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Doctors WHERE DoctorID = @DoctorID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                    
                        command.Parameters.AddWithValue("@DoctorID", DoctorID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                IsExist = true;
                                PersonID = (int)reader["PersonID"];
                                Specialization = (string)reader["Specialization"];
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
                EventLog.WriteEntry(sourceName, ex.ToString(), EventLogEntryType.Error);
            }
            return IsExist;
        }
        public static bool IsDoctorExistByID(int DoctorID )
        {
            bool IsExist = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = "SELECT IsExist=1 FROM Doctors WHERE DoctorID = @DoctorID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@DoctorID", DoctorID);

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
                EventLog.WriteEntry(sourceName, ex.ToString(), EventLogEntryType.Error);
            }
            return IsExist;
        }

    }
}

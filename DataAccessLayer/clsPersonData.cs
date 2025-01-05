using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;


namespace DataAccessLayer
{
 

    public class clsPersonData
    {
        public static DataTable GetAllPeople()
        {
            DataTable dtPeople = new DataTable();
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = "Select * From People";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtPeople.Load(reader);
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
            return dtPeople;
        }

        public static int AddNewPerson( string Name, DateTime? DateOfBirth, string Gender, string PhoneNumber, string Email, string Address)
        {
            int InsertedID = 0;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Insert into People ( Name, DateOfBirth, Gender, PhoneNumber, Email, Address)
                                 Values (  @Name, @DateOfBirth, @Gender, @PhoneNumber, @Email, @Address);
                                 Select Scope_Identity();";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                   
                        command.Parameters.AddWithValue("@Name", Name);
                        if(DateOfBirth==null)
                        {
                            command.Parameters.AddWithValue("@DateOfBirth", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        }
                   
                        command.Parameters.AddWithValue("@Gender", Gender.Substring(0,1));
                        command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                        if(Email==null)
                        {
                            command.Parameters.AddWithValue("@Email", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Email", Email);
                        }
                    
                        if(Address==null)
                        {
                            command.Parameters.AddWithValue("@Address", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Address", Address);
                        }

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

        public static bool UpdatePerson(int PersonID, string Name, DateTime? DateOfBirth, string Gender, string PhoneNumber, string Email, string Address)
        {
            int AffectedRows = 0;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Update People Set Name=@Name, DateOfBirth=@DateOfBirth, Gender=@Gender, PhoneNumber=@PhoneNumber, Email=@Email, Address=@Address
                                 Where PersonID=@PersonID;";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@Name", Name);
                        if (DateOfBirth == null)
                        {
                            command.Parameters.AddWithValue("@DateOfBirth", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        }
                        command.Parameters.AddWithValue("@PersonID", PersonID );
                    
                        command.Parameters.AddWithValue("@Gender", Gender.Substring(0, 1));
                        command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                        if (Email == null)
                        {
                            command.Parameters.AddWithValue("@Email", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Email", Email);
                        }

                        if (Address == null)
                        {
                            command.Parameters.AddWithValue("@Address", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Address", Address);
                        }

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

        public static bool IsPersonExistByID(int PersonID)
        {
            bool IsExist = false;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Select IsExist=1 from People Where PersonID=@PersonID;";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
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
        public static bool IsPersonExistByName(string Name)
        {
            bool IsExist = false;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Select IsExist=1 from People Where Name=@Name;";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name",Name);
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
        public static bool DeletePersonByID(int PersonID)
        {
            int AffectedRows = 0;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Delete from People Where PersonID=@PersonID;";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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


        public static bool FindPersonByID(int PersonID, ref string Name, ref DateTime? DateOfBirth, ref string Gender, ref string PhoneNumber, ref string Email, ref string Address)
        {
            bool IsExist = false;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Select * from People Where PersonID=@PersonID;";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsExist = true;
                                Name = reader["Name"].ToString();
                                DateOfBirth = (DateTime?)reader["DateOfBirth"];
                                Gender = reader["Gender"].ToString();
                                PhoneNumber = reader["PhoneNumber"].ToString();
                                Email = reader["Email"].ToString();
                                Address = reader["Address"].ToString();
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



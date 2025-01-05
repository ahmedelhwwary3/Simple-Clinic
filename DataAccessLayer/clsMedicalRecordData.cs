using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace DataAccessLayer
{
    public class clsMedicalRecordData
    {
        public static DataTable GetAllMedicalRecords()
        {
            DataTable dtMedicalRecords = new DataTable();
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"
                                    select MedicalRecordID,IsNull(VisitDescription,'Empty') as VisitDescription,
                                    IsNull(Diagnosis,'Empty') as Diagnosis ,IsNull(AdditionalNotes,'Empty') as AdditionalNotes
                                    from MedicalRecords 

                                     ";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtMedicalRecords.Load(reader);
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
            return dtMedicalRecords;
        }

        public static int AddNewMedicalRecord( string VisitDescription, string Diagnosis, string AdditionalNotes)
        {
            int InsertedID = 0;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"
                        Insert into MedicalRecords ( VisitDescription, Diagnosis, AdditionalNotes)
                        Values (@VisitDescription, @Diagnosis, @AdditionalNotes);
                        Select Scope_Identity();";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if(VisitDescription==null||VisitDescription=="")
                        {
                            command.Parameters.AddWithValue("@VisitDescription", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@VisitDescription", VisitDescription);
                        }
                        if (Diagnosis == null || Diagnosis == "")
                        {
                            command.Parameters.AddWithValue("@Diagnosis", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Diagnosis", VisitDescription);
                        }
                        if (AdditionalNotes == null || AdditionalNotes == "")
                        {
                            command.Parameters.AddWithValue("@AdditionalNotes", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@AdditionalNotes", AdditionalNotes);
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

        public static bool UpdateMedicalRecord(int MedicalRecordID,  string VisitDescription, string Diagnosis, string AdditionalNotes)
        {
            int AffectedRows = 0;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"
                        Update MedicalRecords 
                        Set   VisitDescription = @VisitDescription, Diagnosis = @Diagnosis, AdditionalNotes = @AdditionalNotes
                        Where MedicalRecordID = @MedicalRecordID;";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);

                        if (VisitDescription == null || VisitDescription == "")
                        {
                            command.Parameters.AddWithValue("@VisitDescription", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@VisitDescription", VisitDescription);
                        }
                        if (Diagnosis == null || Diagnosis == "")
                        {
                            command.Parameters.AddWithValue("@Diagnosis", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Diagnosis", VisitDescription);
                        }
                        if (AdditionalNotes == null || AdditionalNotes == "")
                        {
                            command.Parameters.AddWithValue("@AdditionalNotes", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@AdditionalNotes", AdditionalNotes);
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

        public static bool IsMedicalRecordExistByID(int MedicalRecordID)
        {
            bool IsExist = false;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Select IsExist=1 from MedicalRecords Where MedicalRecordID=@MedicalRecordID;";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);
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

        public static bool DeleteMedicalRecordByID(int MedicalRecordID)
        {
            int AffectedRows = 0;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Delete from MedicalRecords Where MedicalRecordID=@MedicalRecordID;";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);
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

        public static bool FindMedicalRecordByID(int MedicalRecordID, ref string VisitDescription, ref string Diagnosis, ref string AdditionalNotes)
        {
            bool IsExist = false;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Select * from MedicalRecords Where MedicalRecordID=@MedicalRecordID;";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsExist = true;
                                if (reader["VisitDescription"] ==DBNull.Value)
                                {
                                    VisitDescription = null;
                                }
                                else
                                {
                                    VisitDescription = reader["VisitDescription"].ToString();
                                }
                                if (reader["Diagnosis"] == DBNull.Value)
                                {
                                    Diagnosis = null;
                                }
                                else
                                {
                                    Diagnosis = reader["Diagnosis"].ToString();
                                }
                                if (reader["AdditionalNotes"] == DBNull.Value)
                                {
                                    AdditionalNotes = null;
                                }
                                else
                                {
                                    AdditionalNotes = reader["AdditionalNotes"].ToString();
                                }
                                 
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

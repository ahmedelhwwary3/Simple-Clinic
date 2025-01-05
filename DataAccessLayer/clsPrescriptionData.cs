using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace DataAccessLayer
{
    public class clsPrescriptionData
    {




        public static DataTable GetAllPrescriptionsUnionMedicalRecords()
        {
            DataTable dtPrescriptions = new DataTable();
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"select mr.MedicalRecordID ,pr.PrescriptionID,mr.Diagnosis,pr.MedicationName,pr.Dosage,pr.Frequency,pr.StartDate,pr.EndDate from MedicalRecords mr join Prescriptions pr on pr.MedicalRecordID=mr.MedicalRecordID";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtPrescriptions.Load(reader);
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
            return dtPrescriptions;
        }
        public static DataTable GetAllPrescriptions()
        {
            DataTable dtPrescriptions = new DataTable();
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Prescriptions";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtPrescriptions.Load(reader);
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
            return dtPrescriptions;
        }

        public static int AddNewPrescription(int MedicalRecordID, string MedicationName, string Dosage,
                                             string Frequency, DateTime? StartDate, DateTime? EndDate,
                                             string SpecialInstructions)
        {
            int InsertedID = 0;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"
                        INSERT INTO Prescriptions (MedicalRecordID, MedicationName, Dosage, Frequency, 
                                                   StartDate, EndDate, SpecialInstructions)
                        VALUES (@MedicalRecordID, @MedicationName, @Dosage, @Frequency, @StartDate, 
                                @EndDate, @SpecialInstructions);
                        SELECT Scope_Identity();";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);
                        command.Parameters.AddWithValue("@MedicationName", MedicationName);
                        command.Parameters.AddWithValue("@Dosage", Dosage);
                        command.Parameters.AddWithValue("@Frequency", Frequency);
                        command.Parameters.AddWithValue("@StartDate", StartDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);
                        if(SpecialInstructions==null)
                        {
                            command.Parameters.AddWithValue("@SpecialInstructions", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@SpecialInstructions", SpecialInstructions);
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

        public static bool UpdatePrescription(int PrescriptionID, int MedicalRecordID, string MedicationName,
                                               string Dosage, string Frequency, DateTime? StartDate,
                                               DateTime? EndDate, string SpecialInstructions)
        {
            int AffectedRows = 0;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"
                        UPDATE Prescriptions
                        SET MedicalRecordID = @MedicalRecordID, MedicationName = @MedicationName, 
                            Dosage = @Dosage, Frequency = @Frequency, StartDate = @StartDate, 
                            EndDate = @EndDate, SpecialInstructions = @SpecialInstructions
                        WHERE PrescriptionID = @PrescriptionID";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);
                        command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);
                        command.Parameters.AddWithValue("@MedicationName", MedicationName);
                        command.Parameters.AddWithValue("@Dosage", Dosage);
                        command.Parameters.AddWithValue("@Frequency", Frequency);
                        command.Parameters.AddWithValue("@StartDate", StartDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);
                        command.Parameters.AddWithValue("@SpecialInstructions", SpecialInstructions);

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

        public static bool IsPrescriptionExistByID(int PrescriptionID)
        {
            bool IsExist = false;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"SELECT IsExist=1 FROM Prescriptions WHERE PrescriptionID = @PrescriptionID";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);
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

        public static bool DeletePrescriptionByID(int PrescriptionID)
        {
            int AffectedRows = 0;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"DELETE FROM Prescriptions WHERE PrescriptionID = @PrescriptionID";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);
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

        public static bool FindPrescriptionByID(int PrescriptionID, ref int MedicalRecordID, ref string MedicationName,
                                                 ref string Dosage, ref string Frequency, ref DateTime? StartDate,
                                                 ref DateTime? EndDate, ref string SpecialInstructions)
        {
            bool IsExist = false;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"SELECT * FROM Prescriptions WHERE PrescriptionID = @PrescriptionID";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PrescriptionID", PrescriptionID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsExist = true;
                                MedicalRecordID = (int)reader["MedicalRecordID"];
                                MedicationName = reader["MedicationName"].ToString();
                                Dosage = reader["Dosage"].ToString();
                                Frequency = reader["Frequency"].ToString();
                                StartDate = (DateTime?)reader["StartDate"];
                                EndDate = (DateTime?)reader["EndDate"];
                                if (reader["SpecialInstructions"]==DBNull.Value)
                                {
                                    SpecialInstructions = null;
                                }
                                else
                                {
                                    SpecialInstructions = reader["SpecialInstructions"].ToString();
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

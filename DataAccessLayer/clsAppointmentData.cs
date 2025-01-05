using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsAppointmentData
    {

        public static int GetAppointmentIDForPayment(int PaymentID)
        {
            int InsertedID = 0;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"select app.AppointmentID from Appointments app inner join Payments pay on pay.PaymentID=app.PaymentID
                                     where pay.PaymentID=@PaymentID";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);
                         

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
        public static DataTable GetAllAppointments()
        {
            DataTable dtAppointments= new DataTable();
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @" select AppointmentID,PatientID,DoctorID,AppointmentDateTime,
 case 
 when AppointmentStatus=1 then 'Pending'
 when AppointmentStatus=2 then 'Confirmed'
 when AppointmentStatus=3 then 'Completed'
 when AppointmentStatus=4 then 'Cancelled'
 when AppointmentStatus=5 then 'Rescheduled'
 when AppointmentStatus=6 then 'No Show'
 else 'Not defined'
 end as AppointmentStatus,ISNULL(MedicalRecordID,0)as MedicalRecordID,ISNULL(PaymentID,0)as PaymentID
 from Appointments";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtAppointments.Load(reader);
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
            return dtAppointments;
             
        }
        public static int AddNewAppointment( int PatientID, int DoctorID, DateTime AppointmentDateTime, byte AppointmentStatus, int? MedicalRecordID, int? PaymentID)
        {
            int InsertedID = 0;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Insert into Appointments(  PatientID, DoctorID, AppointmentDateTime,  AppointmentStatus,  MedicalRecordID,  PaymentID)
                                            Values (@PatientID, @DoctorID, @AppointmentDateTime,  @AppointmentStatus,  @MedicalRecordID,  @PaymentID);
                                           Select Scope_Identity(); ";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PatientID", PatientID);
                        command.Parameters.AddWithValue("@DoctorID", DoctorID);
                        command.Parameters.AddWithValue("@AppointmentDateTime", AppointmentDateTime);
                        command.Parameters.AddWithValue("@AppointmentStatus", AppointmentStatus);
                   
                        if(MedicalRecordID==null)
                        {
                            command.Parameters.AddWithValue("@MedicalRecordID", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);
                        }
                        if(PaymentID==null)
                        {

                            command.Parameters.AddWithValue("@PaymentID",System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@PaymentID", PaymentID);
                        }
                        
                        object result = command.ExecuteScalar();
                        if (result != null&&int.TryParse(result.ToString(),out int ID))
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
        public static bool UpdateAppointment(int AppointmentID, int PatientID, int DoctorID, DateTime AppointmentDateTime, byte AppointmentStatus, int? MedicalRecordID, int? PaymentID)
        {
            int AffectedRows = 0;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Update Appointments Set PatientID=@PatientID
                                                             ,DoctorID=@DoctorID
                                                             ,AppointmentDateTime=@AppointmentDateTime
                                                             ,AppointmentStatus=@AppointmentStatus
                                                             ,MedicalRecordID=@MedicalRecordID
                                                             ,PaymentID=@PaymentID
                                                         Where  AppointmentID=@AppointmentID;";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))

                    {
                        command.Parameters.AddWithValue("@AppointmentID", AppointmentID);
                        command.Parameters.AddWithValue("@PatientID", PatientID);
                        command.Parameters.AddWithValue("@DoctorID", DoctorID);
                        command.Parameters.AddWithValue("@AppointmentDateTime", AppointmentDateTime);
                        command.Parameters.AddWithValue("@AppointmentStatus", AppointmentStatus);
                        if (MedicalRecordID == null|| MedicalRecordID==0)
                        {
                            command.Parameters.AddWithValue("@MedicalRecordID", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);
                        }
                        if (PaymentID == null|| MedicalRecordID==0)
                        {

                            command.Parameters.AddWithValue("@PaymentID", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@PaymentID", PaymentID);
                            
                        }
                        AffectedRows = command.ExecuteNonQuery();
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
            return (AffectedRows>0);
        }

        public static bool IsAppointmentExistByID(int AppointmentID)
        {
            bool IsExist = false;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Select IsExist=1 from Appointments Where AppointmentID=@AppointmentID;";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AppointmentID",AppointmentID);
                        using (SqlDataReader reader=command.ExecuteReader())
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

        public static bool DeleteAppointmentByID(int AppointmentID)
        {
            int AffectedRows = 0;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Delete from Appointments Where AppointmentID=@AppointmentID;";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AppointmentID", AppointmentID);
                        AffectedRows =command.ExecuteNonQuery();
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
            return (AffectedRows>0);
        }

        public static bool FindAppointmentByID(int AppointmentID,ref int PatientID,ref int DoctorID,ref DateTime AppointmentDateTime,ref byte AppointmentStatus,ref int? MedicalRecordID,ref int? PaymentID)
        {
            bool IsExist = false;
            try
            {
                using (var connection = new SqlConnection(clsSettings.ConnectionString))
                {
                    string query = @"Select * from Appointments Where AppointmentID=@AppointmentID;";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AppointmentID", AppointmentID);
                        using (SqlDataReader reader=command.ExecuteReader())
                        {
                            
                            if(reader.Read())
                            {
                                IsExist = true;
                                PatientID = (int)reader["PatientID"];
                                DoctorID= (int)reader["DoctorID"];
                                AppointmentDateTime = (DateTime)reader["AppointmentDateTime"];
                                AppointmentStatus = (byte)reader["AppointmentStatus"];
                                if (reader["MedicalRecordID"]==DBNull.Value)
                                {
                                    MedicalRecordID = null;
                                }
                                else
                                {
                                    MedicalRecordID = (int?)reader["MedicalRecordID"];
                                }
                                if (reader["PaymentID"]==DBNull.Value)
                                {
                                    PaymentID=null;
                                }else
                                {
                                    PaymentID = (int?)reader["PaymentID"];
                                }
                                
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
            return IsExist;
        }








    }
}

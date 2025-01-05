using DataAccessLayer;
using System;
using System.Data;

namespace BusinessLayer
{
    public class clsPrescription
    {
        private enum enMode { AddNew = 1, Update = 2 };
        private enMode _Mode = enMode.AddNew;

        public int PrescriptionID { get; set; }
        public int MedicalRecordID { get; set; }
        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string SpecialInstructions { get; set; }
 
        private clsPrescription(int prescriptionID, int medicalRecordID, string medicationName, string dosage,
                                string frequency, DateTime? startDate, DateTime? endDate, string specialInstructions)
        {
            this.PrescriptionID = prescriptionID;
            this.MedicalRecordID = medicalRecordID;
            this.MedicationName = medicationName;
            this.Dosage = dosage;
            this.Frequency = frequency;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.SpecialInstructions = specialInstructions;
            _Mode = enMode.Update;
        }

   
        public clsPrescription()
        {
            this.PrescriptionID = 0;
            this.MedicalRecordID = 0;
            this.MedicationName = string.Empty;
            this.Dosage = string.Empty;
            this.Frequency = string.Empty;
            this.StartDate = DateTime.MinValue;
            this.EndDate = DateTime.MinValue;
            this.SpecialInstructions = string.Empty;
            _Mode = enMode.AddNew;
        }

     
        private bool _AddNewPrescription()
        {
            this.PrescriptionID = clsPrescriptionData.AddNewPrescription(this.MedicalRecordID, this.MedicationName,
                                                                        this.Dosage, this.Frequency, this.StartDate,
                                                                        this.EndDate, this.SpecialInstructions);
            return (this.PrescriptionID != 0);
        }

 
        private bool _UpdatePrescription()
        {
            return clsPrescriptionData.UpdatePrescription(this.PrescriptionID, this.MedicalRecordID,
                                                           this.MedicationName, this.Dosage, this.Frequency,
                                                           this.StartDate, this.EndDate, this.SpecialInstructions);
        }

     
  
        public static bool IsExist(int prescriptionID)
        {
            return clsPrescriptionData.IsPrescriptionExistByID(prescriptionID);
        }

 
        public static DataTable GetAllPrescriptions()
        {
            return clsPrescriptionData.GetAllPrescriptions();
        }
        public static clsPrescription FindPrescription(int PrescriptionID)
        {
            int MedicalRecordID = 0;
            string MedicationName = null;
            string Dosage = null;
            string Frequency = null;
            DateTime? StartDate = DateTime.MinValue;
            DateTime? EndDate = DateTime.MinValue;
            string SpecialInstructions = null;

            bool IsFound = clsPrescriptionData.FindPrescriptionByID(PrescriptionID, ref MedicalRecordID,
                ref MedicationName, ref Dosage, ref Frequency, ref StartDate, ref EndDate, ref SpecialInstructions);

            return IsFound ? new clsPrescription(PrescriptionID, MedicalRecordID, MedicationName, Dosage,
                                                 Frequency, StartDate, EndDate, SpecialInstructions) : null;
        }


        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (!clsPrescriptionData.IsPrescriptionExistByID(this.PrescriptionID))
                        {
                            if (_AddNewPrescription())
                            {
                                _Mode = enMode.Update;
                                return true;
                            }
                        }
                        return false;
                    }
                case enMode.Update:
                    {
                        return _UpdatePrescription();
                    }
                default:
                    return false;
            }
        }

        public static DataTable GetAllPrescriptionsUnionMedicalRecords()
        {
            return clsPrescriptionData.GetAllPrescriptionsUnionMedicalRecords();
        }
        public static bool Delete(int PrescriptionID)
        {
            return clsPrescriptionData.DeletePrescriptionByID(PrescriptionID);
        }
    }
}

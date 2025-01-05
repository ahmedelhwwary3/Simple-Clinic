using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsDoctor
    {
        private enum enMode { AddNew = 1, Update = 2 };
        private enMode _Mode = enMode.AddNew;

        public int DoctorID { get; set; }
        public int PersonID { get; set; }
        public string Specialization { get; set; }  

 
        private clsDoctor(int DoctorID, int PersonID, string Specialization)
        {
            this.DoctorID = DoctorID;
            this.PersonID = PersonID;
            this.Specialization = Specialization;
            _Mode = enMode.Update;
        }

        public clsDoctor()
        {
            this.DoctorID = 0;
            this.PersonID = 0;
            this.Specialization = null;
            _Mode = enMode.AddNew;
        }

  
        private bool _AddNewDoctor()
        {
            this.DoctorID = clsDoctorData.AddNewDoctor(this.PersonID, this.Specialization);
            return (this.DoctorID != 0);
        }

         
        private bool _UpdateDoctor()
        {
            return clsDoctorData.UpdateDoctorByID(this.DoctorID, this.PersonID, this.Specialization);
        }
 
        public static clsDoctor FindDoctor(int DoctorID)
        {
            int PersonID = 0;
            string Specialization = null;
            bool IsFound = clsDoctorData.FindDoctorByID(DoctorID, ref PersonID, ref Specialization);

            if (IsFound)
            {
                return new clsDoctor(DoctorID, PersonID, Specialization);
            }
            else
            {
                return null;
            }
        }

     
        public static bool IsExist(int DoctorID)
        {
            return clsDoctorData.IsDoctorExistByID(DoctorID);
        }
        public static DataTable GetAllDoctorsNames()
        {
            return clsDoctorData.GetAllDoctorsNames();
        }
       
        public static DataTable GetAllDoctors()
        {
            return clsDoctorData.GetAllDoctors();
        }
        public static bool Delete(int DoctorID)
        {
            return clsDoctorData.DeleteDoctorByID(DoctorID);
        }
        public static clsDoctor FindDoctorByName(string Name)
        {
            int DoctorID = 0;
            int PersonID = 0;
            string Specialization = null;
            bool IsFound = clsDoctorData.FindDoctorByName(Name,ref DoctorID, ref PersonID, ref Specialization);

            if (IsFound)
            {
                return new clsDoctor(DoctorID, PersonID, Specialization);
            }
            else
            {
                return null;
            }
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (!clsDoctorData.IsDoctorExistByID(this.DoctorID))
                        {
                            if (_AddNewDoctor())
                            {
                                _Mode = enMode.Update;
                                return true;
                            }
                        }
                        return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateDoctor();
                    }
                default:
                    return false;
            }

        }
    }
}

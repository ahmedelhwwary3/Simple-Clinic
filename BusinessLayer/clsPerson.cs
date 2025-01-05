using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
        public class clsPerson
        {
        private enum enMode { AddNew,Update};
        private enMode _Mode = enMode.AddNew;
        public int PersonID { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

 
        public clsPerson(int PersonID, string Name, DateTime? DateOfBirth, string Gender, string Phone, string Email, string Address)
        {
            this.PersonID = PersonID;
            this.Name = Name;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            _Mode = enMode.Update;
        }

      
        public clsPerson()
        {
            this.PersonID = 0;
            this.Name = string.Empty;
            this.DateOfBirth = DateTime.MinValue;
            this.Gender = string.Empty;
            this.Phone = string.Empty;
            this.Email = string.Empty;
            this.Address = string.Empty;
            _Mode = enMode.AddNew;
        }

 
        private bool _AddNewPerson()
            {
                this.PersonID = clsPersonData.AddNewPerson(this.Name, this.DateOfBirth, this.Gender, this.Phone, this.Email, this.Address);
                return (this.PersonID != 0);
            }

        
        private bool _UpdatePerson()
            {
                return clsPersonData.UpdatePerson(this.PersonID, this.Name, this.DateOfBirth, this.Gender, this.Phone, this.Email, this.Address);
            }

 
        public static bool DeletePerson(int personID)
            {
                return clsPersonData.DeletePersonByID(personID);
            }

      
        public static clsPerson FindPerson(int personID)
            {
                string name = string.Empty, gender = string.Empty, phone = string.Empty, email = string.Empty, address = string.Empty;
                DateTime? dateOfBirth = DateTime.MinValue;
                bool isFound = clsPersonData.FindPersonByID(personID, ref name, ref dateOfBirth, ref gender, ref phone, ref email, ref address);
                return (isFound ? new clsPerson(personID, name, dateOfBirth, gender, phone, email, address) : null);
            }

 
        public static DataTable GetAllPeople()
            {
                return clsPersonData.GetAllPeople();
            }

        
        public static bool IsExist(int personID)
            {
                return clsPersonData.IsPersonExistByID(personID);
            }
        public static bool IsExist(string Name)
        {
            return clsPersonData.IsPersonExistByName(Name);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (!clsPersonData.IsPersonExistByID(this.PersonID))
                        {
                            if (_AddNewPerson())
                            {
                                _Mode = enMode.Update;
                                return true;
                            }
                        }
                        return false;

                    }

                case enMode.Update:
                    {
                        return _UpdatePerson();
                    }
                default:
                    return false;
            
            
            
            
            }

        }
















    }       
}


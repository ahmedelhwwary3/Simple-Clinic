using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    using DataAccessLayer;
    using System;
    using System.Data;

    namespace BusinessLayer
    {
        public class clsPayment
        {
     
            public enum enPaymentMethod { Cash = 1, CreditCard = 2, BankTransfer = 3, PayPal = 4, Other = 5 };

            private enum enMode { AddNew = 1, Update = 2 };
            private enMode _Mode = enMode.AddNew;
            public int PaymentID { get; set; }
            public DateTime? PaymentDate { get; set; }
            public enPaymentMethod? PaymentMethod { get; set; }
            public decimal AmountPaid { get; set; }
            public string AdditionalNotes { get; set; }

   
            private clsPayment(int PaymentID, DateTime? PaymentDate, enPaymentMethod? PaymentMethod, decimal AmountPaid, string AdditionalNotes)
            {
                this.PaymentID = PaymentID;
                this.PaymentDate = PaymentDate;
                this.PaymentMethod = PaymentMethod;
                this.AmountPaid = AmountPaid;
                this.AdditionalNotes = AdditionalNotes;
                _Mode = enMode.Update;
            }

 
            public clsPayment()
            {
                this.PaymentID = 0;
                this.PaymentDate = DateTime.MinValue;
                this.PaymentMethod = null;
                this.AmountPaid = 0;
                this.AdditionalNotes = null;
                _Mode = enMode.AddNew;
            }

       
            private bool _AddNewPayment()
            {
                this.PaymentID = clsPaymentData.AddNewPayment(this.PaymentDate,(byte) this.PaymentMethod, this.AmountPaid, this.AdditionalNotes);
                return this.PaymentID != 0;
            }

          
            private bool _UpdatePayment()
            {
                return clsPaymentData.UpdatePayment(this.PaymentID, this.PaymentDate,(byte) this.PaymentMethod, this.AmountPaid, this.AdditionalNotes);
            }

            public static string GetPaymentMethodName(enPaymentMethod Type)
            {
                switch(Type)
                {
                    case enPaymentMethod.Cash:
                        return "Cash";
                    case enPaymentMethod.CreditCard:
                        return "Credit Card";
                    case enPaymentMethod.BankTransfer:
                        return "Bank Transfer";
                    case enPaymentMethod.PayPal:
                        return "Paybal";
                    case enPaymentMethod.Other:
                        return "Other";
                }
                return "Not Defined";
            }
            public static enPaymentMethod GetPaymentMethodEnumByName(string Name)
            {
                switch (Name)
                {
                  
                    case "Cash":
                        return enPaymentMethod.Cash;
                    case "Credit Card":
                        return enPaymentMethod.CreditCard;
                    case "Bank Transfer":
                        return enPaymentMethod.BankTransfer;
                    case "Paybal":
                        return enPaymentMethod.PayPal;
                    default:
                        return enPaymentMethod.Other;
                }
               
               
            }
            public static DataTable GetAllPayments()
            {
                return clsPaymentData.GetAllPayments();
            }

    
            public bool IsExist(int PaymentID)
            {
                return clsPaymentData.IsPaymentExistByID(PaymentID);
            }

      
            public static clsPayment FindPayment(int PaymentID)
            {
                DateTime? PaymentDate = DateTime.MinValue;
                byte? PaymentMethod = null;
                decimal AmountPaid = 0;
                string AdditionalNotes = null;

                bool IsFound = clsPaymentData.FindPaymentByID(PaymentID, ref PaymentDate, ref PaymentMethod, ref AmountPaid, ref AdditionalNotes);

                return IsFound ? new clsPayment(PaymentID, PaymentDate,(enPaymentMethod) PaymentMethod, AmountPaid, AdditionalNotes) : null;
            }
            public static int GetPatientIDByPaymentID(int PaymentID)
            {
                return clsPaymentData.GetPatientIDByPaymentID( PaymentID);
            }
   
            
            public bool Save()
            {
                switch (_Mode)
                {
                    case enMode.AddNew:
                        if (!clsPaymentData.IsPaymentExistByID(this.PaymentID))
                        {
                            if (_AddNewPayment())
                            {
                                _Mode = enMode.Update;
                                return true;
                            }
                        }
                        return false;
                    case enMode.Update:
                        return _UpdatePayment();
                    default:
                        return false;
                }
            }
        }
    }

}

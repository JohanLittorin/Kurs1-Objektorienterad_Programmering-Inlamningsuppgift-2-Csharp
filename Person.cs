using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basgrupp5_Fall2
{
    public class Person
        //vi valde att ha en klass för person där vi kunde hämta informationen för varje kontakt
    {

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber1 { get; set; }
        public string phoneNumber2 { get; set; }
        public string address { get; set; }
        public string emailAddress { get; set; }

        //Nedan kan man redigera kontaktinformationen via edit-metoden:
        public string EditFirst(string FirstName = "")
        {
            this.firstName = FirstName;
            return FirstName;
        }

        public string EditFirst2(string LastName = "")
        {
            this.lastName = LastName;
            return LastName;
        }

        public string EditFirst3(string PhoneNumber1 = "")
        {
            this.phoneNumber1 = PhoneNumber1;
            return PhoneNumber1;
        }

        public string EditFirst4(string PhoneNumber2 = "")
        {
            this.phoneNumber2 = PhoneNumber2;
            return PhoneNumber2;
        }

        public string EditFirst5(string Address = "")
        {
            this.address = Address;
            return Address;
        }

        public string EditFirst6(string Email = "")
        {
            this.emailAddress = Email;
            return Email;
        }
    }
}

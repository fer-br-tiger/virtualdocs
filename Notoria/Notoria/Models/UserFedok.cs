namespace Notoria.Models
{
    public class UserFedok
    {
        public UserFedok()
        {
            rut = "";
            name = "";
            native_surname = "";
            surname = "";
            email = "";
            email_alt = "";
            phone_number = "";
            civil_state = "";
            birthdate = "";
        }
        public string rut {get; set;}
        public string name {get; set;}
        public string native_surname {get; set;}
        public string surname {get; set;}
        public string email {get; set;}
        public string email_alt {get; set;}
        public string phone_number {get; set;}
        public string civil_state {get; set;}
        public string birthdate {get; set;}
    }
}
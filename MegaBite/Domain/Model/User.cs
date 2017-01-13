using System.ComponentModel;

namespace MegaBite.Domain.Model
{
    public class User : BaseObject
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("E-mail")]
        public string Email { get; set; }
    }
}
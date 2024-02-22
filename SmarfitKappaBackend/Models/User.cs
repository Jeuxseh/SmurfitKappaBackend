using SmarfitKappaBackend.Interfaces;

namespace SmarfitKappaBackend.Models
{
    public partial class User : IUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}

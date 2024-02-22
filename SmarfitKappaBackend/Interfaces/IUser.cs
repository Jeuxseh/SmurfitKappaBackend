namespace SmarfitKappaBackend.Interfaces
{
    
    public interface IUser
    {
        int UserId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
    }
    
}

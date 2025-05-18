namespace ReceptsAPI.Contacts.UsersContancts.CreateUsers
{
    public record CreateUsersRequest(int Id, string FirstName, string LastName, string? PFP, string Role, string Login, string Password);
   
}

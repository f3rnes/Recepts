namespace ReceptsAPI.Contacts.ReceptsContacts.CreateRecepts
{
    public record CreateReceptsRequest(string Name, string Description, string? Photo, float Weight, string Ingredients );
    
}

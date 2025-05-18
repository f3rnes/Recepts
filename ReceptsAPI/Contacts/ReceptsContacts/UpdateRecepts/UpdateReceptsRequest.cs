namespace ReceptsAPI.Contacts.ReceptsContacts.UpdateRecepts
{
    public record UpdateReceptsRequest(string Name, string Description, string? Photo, float Weight, string Ingredients);
}
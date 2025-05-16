namespace ReceptsAPI.Contacts.ReceptsContacts.GetOneRecepts
{
    public record GetOneReceptsResponse(int Id, string Name, string Description, string? Photo, float Weight, string Ingredients, int AdminId);
}

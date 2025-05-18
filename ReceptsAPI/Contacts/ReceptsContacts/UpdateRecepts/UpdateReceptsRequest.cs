namespace ReceptsAPI.Contacts.ReceptsContacts.UpdateRecepts
{
    record UpdateReceptsRequest(string Name, string Description, string? Photo, float Weight, string Ingredients);
}
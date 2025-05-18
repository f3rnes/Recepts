namespace ReceptsAPI.Contacts.CommentsContacts.CreateComments
{
    public record CreateCommentsRequest(int ReceptId, int UserId, bool Mood, string Decription);
   
}

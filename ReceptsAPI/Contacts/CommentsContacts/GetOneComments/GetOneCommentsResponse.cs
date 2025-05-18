namespace ReceptsAPI.Contacts.CommentsContacts.GetOneComments
{
    public record GetOneCommentsResponse(int Id, int ReceptId, int UserId, bool Mood, string Description);    
}

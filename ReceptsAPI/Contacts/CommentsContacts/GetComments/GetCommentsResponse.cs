namespace ReceptsAPI.Contacts.CommentsContacts.GetComments
{
    public record GetCommentsResponse(int Id, int ReceptId, int UserId, bool Mood, string Description);
    
}

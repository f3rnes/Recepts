namespace ReceptsAPI.Contacts.StagesContacts.GetStages
{
    public record GetStagesResponse(int id, int ReceptId, int StageNumber, string? Photo, string Decription);
  
}

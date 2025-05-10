namespace ReceptsAPI.Contacts.CreateStages
{
        public record CreateStagesRequest(int Id, int ReceptId, int StageNumber, string? Photo, string Description);
    
}

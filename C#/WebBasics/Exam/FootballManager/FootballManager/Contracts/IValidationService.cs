namespace FootballManager.Contracts
{
    public interface IValidationService
    {
        public (bool isValid, string error) ValidateModel(object model);
    }
}

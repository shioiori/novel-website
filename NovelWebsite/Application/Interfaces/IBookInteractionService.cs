namespace Application.Interfaces
{
    public interface IBookInteractionService : IInteractionService
    {
        Task MarkAsync(string bId, string uId, string cId);
    }
}
namespace FlockWise.Application.Interfaces;

public interface ICurrentUserService
{
    int UserId { get; }
    int FarmId { get; }
}
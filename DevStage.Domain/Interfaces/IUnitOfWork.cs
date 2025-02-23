namespace DevStage.Domain.Interfaces;

public interface IUnitOfWork
{
    Task Commit();
}
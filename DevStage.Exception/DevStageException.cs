namespace DevStage.Exception;

public abstract class DevStageException(string message): SystemException(message)
{
    public abstract int GetStatusCode { get; }
    public abstract List<string> GetErrors { get; }
}
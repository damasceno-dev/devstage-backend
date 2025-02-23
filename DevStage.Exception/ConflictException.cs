using System.Net;

namespace DevStage.Exception;

public class ConflictException(string message) : DevStageException(message)
{
    public override int GetStatusCode => (int)HttpStatusCode.Conflict;

    public override List<string> GetErrors => [Message];
}
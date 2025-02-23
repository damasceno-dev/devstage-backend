using System.Net;

namespace DevStage.Exception;

public class NotFoundException(string message) : DevStageException(message)
{
    public override int GetStatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors => [Message];
}
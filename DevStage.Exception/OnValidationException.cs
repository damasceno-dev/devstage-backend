using System.Net;

namespace DevStage.Exception;

public class OnValidationException(List<string> errorMessages) : DevStageException(string.Empty)
{
    public override int GetStatusCode => (int)HttpStatusCode.BadRequest;

    public override List<string> GetErrors => errorMessages;
}
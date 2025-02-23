namespace DevStage.Communication.Responses;

public class ResponseErrorJson(List<string> errors)
{
    public List<string> ErrorMessages { get; set; } = errors;
    public string Method { get; set; } = string.Empty;

    public ResponseErrorJson(string error) : this([error])
    {
    }
}
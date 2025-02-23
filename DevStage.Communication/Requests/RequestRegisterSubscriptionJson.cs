namespace DevStage.Communication.Requests;

public class RequestRegisterSubscriptionJson
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    
    public Guid? ReferredId { get; set; }
}
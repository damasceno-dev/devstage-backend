namespace DevStage.Communication.Responses;

public class ResponseRegisterSubscriptionJson
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid? ReferredId { get; set; }
}
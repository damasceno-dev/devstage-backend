namespace DevStage.Communication.Responses;

public class ResponseSubscriberRankingPositionJson
{
    public Guid SubscriberId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Position { get; set; }
    public int Score { get; set; }
}
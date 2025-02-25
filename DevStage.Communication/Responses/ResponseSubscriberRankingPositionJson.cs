namespace DevStage.Communication.Responses;

public class ResponseSubscriberRankingPositionJson
{
    public Guid SubscriberId { get; set; }
    public int Position { get; set; }
    public int Score { get; set; }
}
using System;
using System.Collections.Generic;
using System.Linq;
using DevStage.Communication.Responses; // Assuming these types exist
using DevStage.Domain.Dtos;

namespace DevStage.Application.UseCases.Subscriptions.Rank
{
    public static class RankMapper
    {
        public static ResponseRank ToResponse(this List<RankDto> rankDtos)
        {
            var rank = rankDtos.Select(dto => new ResponseSubscriberRankingPosition {SubscriberId = dto.Id, Position = dto.Position }).ToList();
            return new ResponseRank {Ranking = rank};
        }
        
        public static ResponseSubscriberRankingPosition ToResponse(this RankDto rankDto)
        {
            return new ResponseSubscriberRankingPosition {SubscriberId = rankDto.Id, Position = rankDto.Position};
        }
    }
}
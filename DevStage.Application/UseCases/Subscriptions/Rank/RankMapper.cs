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
            var rank = rankDtos.Select(dto => new ResponseSubscriberRankingPositionJson {SubscriberId = dto.Id, Name = dto.Name, Position = dto.Position, Score = dto.Score}).ToList();
            return new ResponseRank {Ranking = rank};
        }
        
        public static ResponseSubscriberRankingPositionJson ToResponse(this RankDto rankDto)
        {
            return new ResponseSubscriberRankingPositionJson {SubscriberId = rankDto.Id, Position = rankDto.Position, Score = rankDto.Score};
        }
    }
}
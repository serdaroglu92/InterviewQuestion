using InterviewQuestion.Enums;
using InterviewQuestion.Models;
using System.Collections.Generic;

namespace InterviewQuestion
{
    public static class QueryElementList
    {
        public static List<QueryElement> GetList()
        {
            // QueryElement Objects
            List<QueryElement> queryElements = new List<QueryElement>();

            queryElements.Add(new QueryElement { Index = 1, Aggregate = AggregateType.sum });
            queryElements.Add(new QueryElement { Index = 2, Aggregate = AggregateType.avg });
            queryElements.Add(new QueryElement { Index = 3, Aggregate = AggregateType.avg });
            queryElements.Add(new QueryElement { Index = 4, Aggregate = AggregateType.max });
            queryElements.Add(new QueryElement { Index = 5, Aggregate = AggregateType.sum });
            queryElements.Add(new QueryElement { Index = 6, Aggregate = AggregateType.min });

            return queryElements;
        }
    }
}

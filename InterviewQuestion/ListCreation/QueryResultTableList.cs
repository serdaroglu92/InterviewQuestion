using InterviewQuestion.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace InterviewQuestion
{
    public static class QueryResultTableList
    {
        private const int _minutes = 5;

        public static List<QueryResultTable> GetList()
        {
            // QueryResultTable Objects
            List<QueryResultTable> queryResultTables = new List<QueryResultTable>();

            // Get Start Date
            DateTime startDate = DateTime.Parse(
                "01.01.2020 00:00", 
                new CultureInfo("en-GB"), 
                DateTimeStyles.NoCurrentDateDefault);

            for (int p = 1; p < 34560; p++)
            {
                queryResultTables.Add(new QueryResultTable
                {
                    perfdate = startDate.AddMinutes(p * _minutes),
                    column1 = "50",
                    column2 = "10",
                    column3 = "30",
                    column4 = "20",
                    column5 = "45",
                    column6 = "15"
                });

                queryResultTables.Add(new QueryResultTable
                {
                    perfdate = startDate.AddMinutes(p * _minutes),
                    column1 = "150",
                    column2 = "110",
                    column3 = "130",
                    column4 = "120",
                    column5 = "145",
                    column6 = "115"
                });

                queryResultTables.Add(new QueryResultTable
                {
                    perfdate = startDate.AddMinutes(p * _minutes),
                    column1 = "250",
                    column2 = "210",
                    column3 = "230",
                    column4 = "220",
                    column5 = "245",
                    column6 = "215"
                });

                queryResultTables.Add(new QueryResultTable
                {
                    perfdate = startDate.AddMinutes(p * _minutes),
                    column1 = "350",
                    column2 = "310",
                    column3 = "330",
                    column4 = "320",
                    column5 = "345",
                    column6 = "315"
                });
            }

            return queryResultTables;
        }
    }
}

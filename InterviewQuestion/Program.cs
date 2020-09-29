using InterviewQuestion.Enums;
using InterviewQuestion.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace InterviewQuestion
{
    public class Program
    {
        static void Main()
        {
            // QueryElement Objects
            List<QueryElement> queryElements = QueryElementList.GetList();

            // QueryResultTable Objects
            List<QueryResultTable> queryResultTables = QueryResultTableList.GetList();

            // Start Timer
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            ////////////////////////////////////
            /// Place your answer after this section
            ///////////////////////////////////

            Dictionary<DateTime, List<QueryResultTable>> dictionary = new Dictionary<DateTime, List<QueryResultTable>>();

            foreach (QueryResultTable item in queryResultTables)
            {
                if (dictionary.Keys.Contains(item.perfdate))
                {
                    dictionary[item.perfdate].Add(item);
                }
                else
                {
                    dictionary.Add(item.perfdate, new List<QueryResultTable>() { item });
                }
            }

            Parallel.ForEach(dictionary, dictionaryItem =>
            {
                List<QueryResultTable> queryResultTableList = new List<QueryResultTable>();
                queryResultTableList.AddRange(dictionaryItem.Value);
                dictionaryItem.Value.Clear();
                dictionaryItem.Value.Add(new QueryResultTable());

                for (int i = 0; i < queryElements.Count; i++)
                {
                    double value = 0;
                    
                    switch (queryElements[i].Aggregate)
                    {
                        case AggregateType.avg:
                            foreach (QueryResultTable item in queryResultTableList)
                            {
                                value += Convert.ToDouble(item.GetType().GetProperty("column" + queryElements[i].Index).GetValue(item));
                            }

                            value = value / queryResultTableList.Count;

                            dictionaryItem.Value[0].GetType().GetProperty("column" + queryElements[i].Index).SetValue(dictionaryItem.Value[0], value.ToString());
                            break;
                        case AggregateType.max:
                            foreach (QueryResultTable item in queryResultTableList)
                            {
                                value = Convert.ToDouble(item.GetType().GetProperty("column" + queryElements[i].Index).GetValue(item)) > value ? Convert.ToDouble(item.GetType().GetProperty("column" + queryElements[i].Index).GetValue(item)) : value;
                            }

                            dictionaryItem.Value[0].GetType().GetProperty("column" + queryElements[i].Index).SetValue(dictionaryItem.Value[0], value.ToString());
                            break;
                        case AggregateType.min:
                            value = Int32.MaxValue;

                            foreach (QueryResultTable item in queryResultTableList)
                            {
                                value = Convert.ToDouble(item.GetType().GetProperty("column" + queryElements[i].Index).GetValue(item)) < value ? Convert.ToDouble(item.GetType().GetProperty("column" + queryElements[i].Index).GetValue(item)) : value;
                            }

                            dictionaryItem.Value[0].GetType().GetProperty("column" + queryElements[i].Index).SetValue(dictionaryItem.Value[0], value.ToString());
                            break;
                        case AggregateType.sum:
                            foreach (QueryResultTable item in queryResultTableList)
                            {
                                value += Convert.ToDouble(item.GetType().GetProperty("column" + queryElements[i].Index).GetValue(item));
                            }

                            dictionaryItem.Value[0].GetType().GetProperty("column" + queryElements[i].Index).SetValue(dictionaryItem.Value[0], value.ToString());
                            break;
                    }

                }
            });

            Parallel.ForEach(queryResultTables, queryResultTableItem =>
            {
                QueryResultTable temp = dictionary.GetValueOrDefault(queryResultTableItem.perfdate)[0];
                queryResultTableItem.column0 = temp.column0;
                queryResultTableItem.column1 = temp.column1;
                queryResultTableItem.column2 = temp.column2;
                queryResultTableItem.column3 = temp.column3;
                queryResultTableItem.column4 = temp.column4;
                queryResultTableItem.column5 = temp.column5;
                queryResultTableItem.column6 = temp.column6;
                queryResultTableItem.column7 = temp.column7;
                queryResultTableItem.column8 = temp.column8;
                queryResultTableItem.column9 = temp.column9;
                queryResultTableItem.column10 = temp.column10;
                queryResultTableItem.column11 = temp.column11;
                queryResultTableItem.column12 = temp.column12;
                queryResultTableItem.column13 = temp.column13;
                queryResultTableItem.column14 = temp.column14;
                queryResultTableItem.column15 = temp.column15;
                queryResultTableItem.column16 = temp.column16;
                queryResultTableItem.column17 = temp.column17;
                queryResultTableItem.column18 = temp.column18;
                queryResultTableItem.column19 = temp.column19;
                queryResultTableItem.column20 = temp.column20;
                queryResultTableItem.column21 = temp.column21;
                queryResultTableItem.column22 = temp.column22;
                queryResultTableItem.column23 = temp.column23;
                queryResultTableItem.column24 = temp.column24;
                queryResultTableItem.column25 = temp.column25;
                queryResultTableItem.column26 = temp.column26;
                queryResultTableItem.column27 = temp.column27;
                queryResultTableItem.column28 = temp.column28;
                queryResultTableItem.column29 = temp.column29;
                queryResultTableItem.column30 = temp.column30;
            });

            ////////////////////////////////////
            /// Place your answer before this section
            ///////////////////////////////////

            // Stop Timer
            stopWatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            ////////////////////////////
            // Data Validation
            ////////////////////////////

            if (queryResultTables[0].column1 != "800")
            {
                Console.WriteLine("ERROR IN CALCULATION for column1!");
            }

            if (queryResultTables[0].column2 != "160")
            {
                Console.WriteLine("ERROR IN CALCULATION for column2!");
            }

            if (queryResultTables[0].column3 != "180")
            {
                Console.WriteLine("ERROR IN CALCULATION for column3!");
            }

            if (queryResultTables[0].column4 != "320")
            {
                Console.WriteLine("ERROR IN CALCULATION for column4!");
            }

            if (queryResultTables[0].column5 != "780")
            {
                Console.WriteLine("ERROR IN CALCULATION for column5!");
            }

            if (queryResultTables[0].column6 != "15")
            {
                Console.WriteLine("ERROR IN CALCULATION for column6!");
            }

            Console.WriteLine("Execution duration: " + elapsedTime);

            Thread.Sleep(10000);
        }
    }
}

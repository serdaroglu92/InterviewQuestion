using InterviewQuestion.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

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

            Console.WriteLine("Execution duration: " + elapsedTime);

            Thread.Sleep(10000);
        }
    }
}

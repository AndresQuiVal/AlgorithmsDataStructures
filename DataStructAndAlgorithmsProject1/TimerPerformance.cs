using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructAndAlgorithmsProject1
{
    public class TimerPerformance
    {
        public double StartTime { get; set; }
        public double EndTime { get; set; }

        public void StartTiming() { StartTime = DateTime.Now.Millisecond; }
        public double StopTiming() { return DateTime.Now.Millisecond - StartTime; }
    }
}

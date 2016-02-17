using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.Windows.Examples.HeatMap.CollegesAndUniversities
{
    public class Institution
    {
        public string Name { get; set; }

        public int? SmartRank { get; set; }
        public int? AcceptanceRate { get; set; }
        public int? TotalEnrolledStudents { get; set; }
        public int? AverageSATMathScore { get; set; }
        public int? AverageSATVerbalScore { get; set; }
        public int? AverageSATCompositeScore { get; set; }
        public int? FulltimeRetentionRate { get; set; }
        public int? InStateTuition { get; set; }
        public int? OutOfStateTuition { get; set; }
        public int? Endowment { get; set; }
    }
}

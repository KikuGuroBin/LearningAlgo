using System;
using SQLite.Net.Attributes;

namespace LearningAlgo
{
    public class OutputTable
    {
        [PrimaryKey]
        public string flow_id { get; set; }

        public int identification_id { get; set; }
        public int output_identification_id { get; set; }
        public string data { get; set; }

    }
}

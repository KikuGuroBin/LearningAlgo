using System;
using SQLite.Net.Attributes;

namespace LearningAlgo
{
    public class OutputTable
    {
        [PrimaryKey, AutoIncrement]
        public string flow_id { get; set; }
        [PrimaryKey, AutoIncrement]
        public int identification_id { get; set; }
        [PrimaryKey, AutoIncrement]
        public int output_identification_id { get; set; }
        public string data { get; set; }

    }
}

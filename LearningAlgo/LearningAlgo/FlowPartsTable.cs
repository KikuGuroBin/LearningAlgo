using System;
using SQLite.Net.Attributes;

namespace LearningAlgo
{
    public class FlowPartsTable
    {
        [PrimaryKey, AutoIncrement]
        public string flow_id { get; set; }
        [PrimaryKey, AutoIncrement]
        public int identification_id { get; set; }
        public int type_id { get; set; }
    }
}

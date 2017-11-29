using System;
using SQLite.Net.Attributes;

namespace LearningAlgo
{
    public class FlowTable
    {
        [PrimaryKey]
        public string flow_id { get; set; }
        public string flow_name { get; set; }
        public string comment  { get; set; }
    }
}

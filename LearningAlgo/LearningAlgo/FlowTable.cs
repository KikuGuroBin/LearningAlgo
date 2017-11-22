using System;
using SQLite.Net.Attributes;

namespace LearningAlgo
{
    public class FlowTable
    {
        [PrimaryKey, AutoIncrement]
        public string flow_id { get; set; }
        public string flow_name { get; set; }
        public string comment  { get; set; }
        //public DateTime calendaer { get; set; }
        ////deleteフラグ
        //public bool Delete { get; set; }
    }
}

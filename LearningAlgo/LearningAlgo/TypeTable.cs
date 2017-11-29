using System;
using SQLite.Net.Attributes;

namespace LearningAlgo
{
    public class TypeTable
    {
        [PrimaryKey]
        public string type_id { get; set; }
        public string type_name { get; set; }
        public int syuturyoku { get; set; }
    }
}

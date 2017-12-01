using System;
using SQLite.Net.Attributes;

namespace LearningAlgo
{

    //プリセットテーブル
    public class FlowTable
    {
        [PrimaryKey]
        public string flow_id { get; set; }
        public string flow_name { get; set; }
        public string comment { get; set; }
    }

    //プリセットの中身
    public class FlowPartsTable
    {
        [PrimaryKey]
        public string flow_id { get; set; }
        public string identification_id { get; set; }
        public string type_id { get; set; }
        public string data { get; set; }
        public string position { get; set; }
        public string startFlag { get; set; }
    }

    //各パーツの出力先・データ
    public class OutputTable
    {
        [PrimaryKey]
        public string flow_id { get; set; }
        public string identification_id { get; set; }
        public string output_identification_id { get; set; }
    }

    //パーツタイプ
    public class TypeTable
    {
        [PrimaryKey]
        public string type_id { get; set; }
        public string type_name { get; set; }
        public string output { get; set; }
    }

}
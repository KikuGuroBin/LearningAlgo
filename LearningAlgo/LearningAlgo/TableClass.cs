using System;
using SQLite.Net.Attributes;

namespace LearningAlgo
{

    //プリセットテーブル
    public class FlowTable
    {
        [PrimaryKey, AutoIncrement]
        public int flow_id { get; set; }
        public string flow_name { get; set; }
        public string comment { get; set; }
        public bool Delete { get; set; }
    }

    //プリセットの中身
    public class FlowPartsTable
    {
        [PrimaryKey,AutoIncrement]
        public int flow_id { get; set; }
        [PrimaryKey, AutoIncrement]
        public int identification_id { get; set; }
        public string type_id { get; set; }
        public string data { get; set; }
        public string position { get; set; }
        public string startFlag { get; set; }
    }

    //各パーツの出力先・データ
    public class OutputTable
    {
        [PrimaryKey, AutoIncrement]
        public int flow_id { get; set; }
        [PrimaryKey, AutoIncrement]
        public int identification_id { get; set; }
        public string output_identification_id { get; set; }
    }

    //パーツタイプ
    public class TypeTable
    {
        [PrimaryKey, AutoIncrement]
        public int type_id { get; set; }
        public string type_name { get; set; }
        public string output { get; set; }
    }

}
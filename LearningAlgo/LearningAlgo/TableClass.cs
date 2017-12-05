using System;
using SQLite.Net.Attributes;

namespace LearningAlgo
{

    /*プリセットテーブル*/
    public class FlowTable
    {
        [PrimaryKey]
        public string flow_id { get; set; }
        public string flow_name { get; set; }
        public string comment { get; set; }
    }
    /**/
    public class Flowtable
    {
        public string flow_id { get; set; }
        public string flow_name { get; set; }
        public string comment { get; set; }
    }

   
    /*プリセットの中身*/
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

    /**/
    public class FlowPartstable
    {
        [PrimaryKey]
        public string flow_id { get; set; }
        public string identification_id { get; set; }
        /* 0 
         * 1　しかく
         * 2　だいあ
         * 3　台形１
         * 4　台形２
         * 5　平行四辺形
         */
        public string type_id { get; set; }
        public string data { get; set; }
        public string position { get; set; }
        public string startFlag { get; set; }
    }


    /*各パーツの出力先・データ*/
    public class OutputTable
    {
        [PrimaryKey]
        public string flow_id { get; set; }
        public string identification_id { get; set; }
        public string blanch_flag { get; set; }
        /*
            -1→no
            0→yes
            1→1
            2→2
            3→3
         */
        public string output_identification_id { get; set; }
    }
    /**/
    public class Outputtable
    {
        [PrimaryKey]
        public string flow_id { get; set; }
        public string identification_id { get; set; }
        public string blanch_flag { get; set; }
        public string output_identification_id { get; set; }
    }
}
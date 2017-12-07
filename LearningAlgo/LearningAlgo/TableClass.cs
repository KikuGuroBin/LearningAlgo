using System;
using SQLite.Net.Attributes;

namespace LearningAlgo
{

    /// <summary>
    /// プリセットテーブル
    /// </summary>
    public class FlowTable
    {
        [PrimaryKey]
        /*プリセットID*/
        public string flow_id { get; set; }
        /*プリセット名前*/
        public string flow_name { get; set; }
        /**/
        public string comment { get; set; }
    }

    /// <summary>
    /// プリセット内のデータ
    /// </summary>
    public class FlowPartsTable
    {
        [PrimaryKey]
        /*プリセットID*/
        public string flow_id { get; set; }
        /*識別ID*/
        public string identification_id { get; set; }
        /*パーツ種別ID*/
        public string type_id { get; set; }
        /*式・データ*/
        public string data { get; set; }
        /*X座標*/
        public string position_X { get; set; }
        /*Y座標*/
        public string position_Y { get; set; }
        /*スタートフラグ*/
        public string startFlag { get; set; }
    }

    /// <summary>
    /// 各パーツの出力先・データ
    /// </summary>
    public class OutputTable
    {
        [PrimaryKey]
        /*プリセットID*/
        public string flow_id { get; set; }
        /*識別ID*/
        public string identification_id { get; set; }
        /*繋がっている識別ID*/
        public string output_identification_id { get; set; }
    }

    /// <summary>
    /// 各パーツタイプ
    /// </summary>
    public class TypeTable
    {
        [PrimaryKey]
        /*パーツ種別ID*/
        public string type_id { get; set; }
        /*パーツ種別名前*/
        public string type_name { get; set; }
        /*アウトプット数*/
        public string output { get; set; }
    }

    /// <summary>
    /// 穴抜きプリセットID
    /// </summary>
    public class QuizTable
    {
        [PrimaryKey]
        /*プリセットID*/
        public string flow_id { get; set; }
        /*プリセット内の穴抜きプリセットID*/
        public string quiz_flow_id { get; set; }
    }

    /// <summary>
    /// 穴抜きパーツID
    /// </summary>
    public class SpaceIdentificationTable
    {
        [PrimaryKey]
        /*穴抜きプリセットID*/
        public string quiz_flow_id { get; set; }
        /*穴抜きパーツID*/
        public string space_identification_id { get; set; }
    }

}
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningAlgo
{
    class PresetLoadClass
    {
        public PresetLoadClass()
        {
        }
        public Dictionary<string, List<string>> PresetLoad(Dictionary<string, List<string>> PreDB)
        {
            while (true)//プリセットテーブルを格納します
            {
                List<string> PreContent=new List<string>();
                while (true)//テーブルの中身をPreContent.Add(string型)で追加
                {
                    //try,catch使えってもつかわなくてもいいけど終ったらブレイク
                    try
                    {
                    }
                    catch (Exception e)
                    {
                        break;
                    }
                }
                PreDB["プリセットID"]= PreContent;

            }
            return PreDB;
        }
    }
}

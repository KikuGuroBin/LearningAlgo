using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningAlgo
{
    /// <summary>
    /// フローチャートをトレースする
    /// </summary>
    public class Tracer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flow">
        /// フローチャートの各部品の内容などが格納された構造体リスト
        /// </param>
        /// <param name="print">
        /// フローチャートの各部品の出力先などが格納された構造体リスト
        /// </param>
        public static void Trace(List<FlowTable> flows, List<PrintTable> prints)
        {
            if (flows == null || prints == null)
            {
                return;
            }

            /* フローチャートの開始部分を探す */
            var flow = flows
                .Where(f => f.StartFlag)
                .First();

            for (;;)
            {
                var con = flow.Content;

                /* ↓部品内の処理↓ */

                /* ↑ここまで↑ */

                /* 次の処理部分のIDを取得 */
                var work = prints
                    .Where(f => f.FlowID == flow.FlowID)
                    .Select(f => f.PrintID);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class FlowTable : IEquatable<PrintTable>
        {
            public string FlowID { get; set; }
            public string Content { get; set; }
            public bool StartFlag { get; set; }

            public bool Equals(PrintTable other)
            {
                return FlowID.Equals(other.FlowID);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class PrintTable : IEquatable<PrintTable>
        {
            public string FlowID { get; set; }
            public string PrintID { get; set; }

            public bool Equals(PrintTable other)
            {
                return FlowID.Equals(other.PrintID);
            }
        }
    }
}

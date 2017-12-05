
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using System.Threading;

namespace LearningAlgo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test1 : ContentPage
    {
        /// <summary>
        /// プリセットテーブル　プリID、各テーブルの中身(日にちとかプリIDとか)
        /// </summary>
        Dictionary<string, Flowtable> DbInsertListTb1 = new Dictionary<string, Flowtable>();
        /// <summary>
        /// 各プリセットの中身用テーブルパーツID,各テーブルの中身(パーツIDとか式とか)
        /// </summary>
        Dictionary<string, FlowPartstable> DbInsertListTb2 = new Dictionary<string, FlowPartstable>();
        /// <summary>
        /// 各パーツの中身用テーブルパーツID,各テーブルの中身(パーツIDとか出力先)
        /// </summary>
        Dictionary<(string, string), Outputtable> DbInsertListTb3 = new Dictionary<(string,string), Outputtable>();
        /// <summary>
        /// iとかjとか
        /// </summary>
        Dictionary<string, int> VarManegement = new Dictionary<string, int>();





        public Test1()
        {
            InitializeComponent();
            /*テストデータ用コネクション*/
            new DBTest().DBtest();

            /*プリセット一覧をロードするメソッド*/
            PresetLoad();
            /*プリセットをセットするメソッド1が選択されたと仮定する*/
            PresetSet("1");

            /*トレース実際にやってみた*/
            TracePreviewer();




            /*
             * リンクモンスター
             var a = from b in DbInsertListTTb1
                    where b.Key=="1"
                    select b;
             */



            //DbInsertList_tb1[1]System.out.plintln

            //選択ボタン押された後使う第弐テーブルを読み込む用
            //ここで選択したプリセットIDを保持する
            //読み込んだテーブルをIDと中の式で割り当てる
            //  DbInsertListTb2 = new PartsLoadClass().PartsLoad();

            //読み込んでない場合は新規の扱いとしてプリセットIDを最新のものにする


            // new TraceMode().CalculateTrace(DbInsertList_tb2); 


            // DBにする配列達
            string[] FlowTable = new string[3];
            string[] PrintTable = new string[4];
            string[] KindTable = new string[3];
            

           

        }
        public async void PresetLoad()
        {
            /*起動時にどうせ使う第壱テーブルを読み込む用コネクション*/
            PresetLoadClass PreClass = new PresetLoadClass();
            DbInsertListTb1 = await PreClass.OnAppearing();

        }
        public async void PresetSet(string Tb1Id)
        {
            /*選択後第弐テーブルを読み込んで配置する*/
            PartsLoadClass ParClass = new PartsLoadClass();
            (DbInsertListTb2,DbInsertListTb3) = await ParClass.OnAppearing(Tb1Id);
        }
        public void TracePreviewer()
        {
            /*スタートフラグを探す*/
            var StartPossition = from x in DbInsertListTb2
                    where x.Value.identification_id == "-1"
                    select x.Key;

           
            string NextId = TypeCalculate(DbInsertListTb2[StartPossition.ToString()]);
            
            /*トレース始めます*/
            for(; ; )
            {
                NextId = TypeCalculate(DbInsertListTb2[NextId]);




                if (NextId == "-1")
                {
                    break;
                }
            }


        }
        public string TypeCalculate(FlowPartstable PartsTb ,Outputtable OutTb)
        {

            if (PartsTb.type_id == "1")
            {
                VarManegement = new CalculateClass().SquareCalculate(VarManegement, PartsTb.data);
                System.Diagnostics.Debug.WriteLine("ここ一番で決める:" + VarManegement["i"].ToString());
                return DbInsertListTb3[(PartsTb.identification_id,Out.)].output_identification_id;
            }
            else if (PartsTb.type_id == "2")
            {
                
                (string Symbol, int b, int c) JudgAnsower = new CalculateClass().DiamondCalculat(VarManegement, PartsTb.data);
                string Symbol = JudgAnsower.Symbol;
                int before = JudgAnsower.b;
                int after = JudgAnsower.c;
                if (Symbol==":")
                {

                }
                else if(Symbol=="-1")
                {
                    var a = from x in DbInsertListTb2
                                         where x.Value.identification_id == "-1"
                                         select x.Key;
                    
                    return DbInsertListTb3[PartsTb.identification_id].output_identification_id;
                }
                else if (Symbol=="0")
                {

                }

            }
            else if (PartsTb.type_id == "3")
            {

            }
            else if (PartsTb.type_id == "4")
            {

            }
            else if (PartsTb.type_id == "5")
            {

            }

           

            //Symbolは-1がNo、0がYes、：が判定
            /// 


            //台形Symbolは0がNo、1がYes、：が判定
            /// bool Kekka2 = new CalculateClass().TrapezoidCalculat(VarManegement, Shiki);









            return NextId;
        }

    }
}
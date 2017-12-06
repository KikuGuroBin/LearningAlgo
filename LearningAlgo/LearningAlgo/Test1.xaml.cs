
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
        Dictionary<string, Outputtable> DbInsertListTb3 = new Dictionary<string, Outputtable>();
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
            /*プリセットをセットするメソッド1が選択されたと仮定する
            PresetSet("1");

            /*トレース実際にやってみた
            TracePreviewer();
            */



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
            /*プリセットをセットするメソッド1が選択されたと仮定する*/
            PresetSet("1");


        }
        public async void PresetSet(string Tb1Id)
        {
            /*選択後第弐テーブルを読み込んで配置する*/
            PartsLoadClass ParClass = new PartsLoadClass();
            (DbInsertListTb2,DbInsertListTb3) = await ParClass.OnAppearing(Tb1Id);
            Debug.WriteLine("プリセット読み込みメソッド：     " );


            /*トレース実際にやってみた*/
            TracePreviewer();
        }
        public　async void TracePreviewer()
        {
            /*スタートフラグを探す*/
            var StartPossition = from x in DbInsertListTb2
                                 where x.Value.startFlag == "1"
                                 select x.Value.identification_id;

            try
            {

                Debug.WriteLine("これってなにはいってるん？：     " + String.Concat(StartPossition));
            
            }
            catch (Exception e)
            {
                
            }


           
            string NextId = await TypeCalculate(DbInsertListTb2[String.Concat(StartPossition)]);
            
            /*トレース始めます*/
            for(; ; )
            {
                NextId = await TypeCalculate(DbInsertListTb2[NextId]);




                if (NextId == "-1")
                {
                    break;
                }
            }


        }
        public async Task<string> TypeCalculate(FlowPartstable PartsTb)
        {

            if (PartsTb.type_id == "1")
            {
                VarManegement = new CalculateClass().SquareCalculate(VarManegement, PartsTb.data);
                Debug.WriteLine("ここ一番で決める:" + VarManegement["i"].ToString());


                var StartPossition2 = from x in DbInsertListTb3
                                      where x.Value.identification_id == PartsTb.identification_id
                                      select x.Key;

                return DbInsertListTb3[StartPossition2.First()].output_identification_id;
            }
            else if (PartsTb.type_id == "2")
            {
                
                (string Symbol, int b, int c) JudgAnsower = new CalculateClass().DiamondCalculat(VarManegement, PartsTb.data);
                string Symbol = JudgAnsower.Symbol;
                int before = JudgAnsower.b;
                int after = JudgAnsower.c;

                Debug.WriteLine("台形返還アイテム： "+ Symbol+ before + after);
                if (Symbol==":")
                {

                }
                else if(Symbol=="-1")
                {
                    var NextIdFinder = from x in DbInsertListTb3
                                         where x.Value.identification_id==PartsTb.identification_id
                                         && x.Value.blanch_flag == "-1"
                                         select x.Value.output_identification_id;
                    Debug.WriteLine("Noだった場合(-1)の時のリターン値：　" + NextIdFinder.First());
                    return String.Concat(NextIdFinder.First());
                }
                else if (Symbol=="0")
                {
                    var NextIdFinder = from x in DbInsertListTb3
                                       where x.Value.identification_id == PartsTb.identification_id
                                         && x.Value.blanch_flag == "0"
                                       select x.Value.output_identification_id;

                    Debug.WriteLine("Yesだった場合(0)の時のリターン値：　" + NextIdFinder.First());
                    return String.Concat(NextIdFinder.First());

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
                var NextIdFinder = from x in DbInsertListTb3
                                   where x.Value.identification_id == PartsTb.identification_id
                                   select x.Value.output_identification_id;
                var Output = from x in DbInsertListTb2
                                   where x.Value.identification_id == PartsTb.identification_id
                                   select x.Value.data;

                Debug.WriteLine("最終結果ではなく:  "+  VarManegement[new CalculateClass().ParallelogramOutput(String.Concat(Output))]);
                return "-1";
            }
            return "-1";
          
        }

    }
}

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
           
            //DbInsertList_tb1[1]System.out.plintln

            //選択ボタン押された後使う第弐テーブルを読み込む用
            //ここで選択したプリセットIDを保持する
            //読み込んだテーブルをIDと中の式で割り当てる
            //  DbInsertListTb2 = new PartsLoadClass().PartsLoad();

            //読み込んでない場合は新規の扱いとしてプリセットIDを最新のものにする


            // new TraceMode().CalculateTrace(DbInsertList_tb2); 


            // DBにする配列達

          
        }
        public async void PresetLoad()
        {

            PrisetScroll.HeightRequest = 50;

            /*起動時にどうせ使う第壱テーブルを読み込む用コネクション*/
            PresetLoadClass PreClass = new PresetLoadClass();
            DbInsertListTb1 = await PreClass.OnAppearing();

            var a = from x in DbInsertListTb1
                    select x.Key;
            List<string> p = a.ToList<string>();

            for (int count = 0;count < p.Count;count++)
            {
                Button PriIdLabel = new Button
                {
                    Text = p[count]
                };
                /*sender eve as*/
                PriIdLabel.Clicked += (s, e) =>
                {
                    var l = s as Button;
                    var text = l.Text;
                    PresetSet(text);
                };
                
                Priset.Children.Add(PriIdLabel);
            }
        }

        public async void PresetSet(string Tb1Id)
        {
            /*選択後第弐テーブルを読み込んで配置する*/
            PartsLoadClass ParClass = new PartsLoadClass();
            (DbInsertListTb2,DbInsertListTb3) = await ParClass.OnAppearing(Tb1Id);

            
            Debug.WriteLine("プリセット読み込みメソッド：" );
        }



        public　async void TracePreviewer()
        {
            /*スタートフラグを探す*/
            var StartPossition = from x in DbInsertListTb2
                                 where x.Value.startFlag == "1"
                                 select x.Value.identification_id;
            string NextId = await TypeCalculate(DbInsertListTb2[String.Concat(StartPossition)]);
            /*トレース始めます*/
            for(; ; )
            {
                /*計算はほかのメソッドに任せて出力先を返してくる*/
                NextId = await TypeCalculate(DbInsertListTb2[NextId]);
                /*もし出力先ばなければbreak*/
                if (NextId == "-1")
                {
                    break;
                }
            }
        }


        /*計算本体クラス
         第二テーブルを受け取って
         アウトプット番号を返す
         */
        public async Task<string> TypeCalculate(FlowPartstable PartsTb)
        {
            
                /*形状四角のばあい*/
                if (PartsTb.type_id == "SideSikaku.png")
            {
                VarManegement = new CalculateClass().SquareCalculate(VarManegement, PartsTb.data);
                var StartPossition2 = from x in DbInsertListTb3
                                      where x.Value.identification_id == PartsTb.identification_id
                                      select x.Key;

                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        Debug.WriteLine("四角で受け取るiの値:" + VarManegement["i"].ToString());
                        label1.Text = "i:   " + VarManegement["i"].ToString();
                    }
                    catch (Exception e) { }
                    finally { }

                    try
                    {
                        Debug.WriteLine("四角で受け取るiの値:" + VarManegement["j"].ToString());
                        label2.Text = "j:   " + VarManegement["j"].ToString();
                    }
                    catch (Exception e) { }
                    finally { }
                });
                /*表示用*/
                await LabelInserter(PartsTb.data);
                return DbInsertListTb3[StartPossition2.First()].output_identification_id;
            }

            /*形状ひし形のばあい*/
            else if (PartsTb.type_id == "SideHisigata.png")
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

                    await Task.Run(() =>
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            label4.Text = label4.Text + "No" + "\n";
                        });
                        Thread.Sleep(1000);
                    });


                    Debug.WriteLine("Noだった場合(-1)の時のリターン値：　" + NextIdFinder.First());

                    /*表示用*/
                    await LabelInserter(PartsTb.data);
                    return String.Concat(NextIdFinder.First());
                }
                else if (Symbol=="0")
                {
                    var NextIdFinder = from x in DbInsertListTb3
                                       where x.Value.identification_id == PartsTb.identification_id
                                         && x.Value.blanch_flag == "0"
                                       select x.Value.output_identification_id;
                    await Task.Run(() =>
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            label4.Text = label4.Text + "Yes" + "\n";
                        });
                        Thread.Sleep(1000);
                    });
                    
                    Debug.WriteLine("Yesだった場合(0)の時のリターン値：　" + NextIdFinder.First());

                    /*表示用*/
                    await LabelInserter(PartsTb.data);
                    return String.Concat(NextIdFinder.First());

                }

            }
            else if (PartsTb.type_id == "SideDaikeiUe.png")
            {
            }
            else if (PartsTb.type_id == "SideDaikeiSita.png")
            {
            }
            else if (PartsTb.type_id == "SideHeikou.png")
            {
                var NextIdFinder = from x in DbInsertListTb3
                                   where x.Value.identification_id == PartsTb.identification_id
                                   select x.Value.output_identification_id;
                var Output = from x in DbInsertListTb2
                                   where x.Value.identification_id == PartsTb.identification_id
                                   select x.Value.data;

                /*表示用*/
                await LabelInserter(PartsTb.data);
                Debug.WriteLine("最終結果ではなく:  "+  VarManegement[new CalculateClass().ParallelogramOutput(String.Concat(Output))]);
                label3.Text = "終了"+ String.Concat(Output)+"の解は"+ VarManegement[new CalculateClass().ParallelogramOutput(String.Concat(Output))];
                return "-1";

            }
            return "-1";
          
        }

        private async Task<string> LabelInserter(string data)
        {
            await Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    label4.Text = label4.Text + data.ToString() + "\n";
                });

                Thread.Sleep(1000);
            });
            return "";
        }

        private void b1_Clicked(object sender, EventArgs e)
        {
            /*本来はプリセットが呼ばれた際のメソッド呼び出し
             * プリセットをセットするメソッド1が選択されたと仮定する*/
            label3.Text = "開始して";
            PresetSet("1");

        }
       
        private void b2_Clicked(object sender, EventArgs e)
        {
            /*本来はトレースボタンが押された際のメソッド呼び出し
             * トレース実際にやってみた*/
            label1.Text = "i:   0";
            label2.Text = "j:   0";
            VarManegement.Clear();
            label4.Text = "";
            label3.Text = "開始";
            TracePreviewer();
        }
    }
}
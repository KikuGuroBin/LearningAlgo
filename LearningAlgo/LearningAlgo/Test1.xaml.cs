
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
        /*プリセットテーブル　<プリID、各テーブルの中身(日にちとかプリIDとか)>*/
        Dictionary<string, Flowtable> DbInsertListTTb1 = new Dictionary<string, Flowtable>();
        /*各プリセットの中身用テーブル<パーツID,各テーブルの中身(パーツIDとか式とか)>*/
        Dictionary<string, List<string>> DbInsertListTb2 = new Dictionary<string, List<string>>();//<プリ>


        public Test1()
        {
            InitializeComponent();
            /*テストデータ用コネクション*/
            new DBTest().DBtest();

            /*プリセットをロードするメソッド*/
            PresetLoad();

            /*1が選択されたと仮定する*/
            PartsLoad("1");



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

            // 変数を格納したDBからDictionaryにぶち込む 変数と値
            Dictionary<string, int> VarManegement = new Dictionary<string, int>();
            string Shiki;

            /*
             * □*/
            Shiki = "1＋i＋3×j＋i→i";

            // VarManegement = new CalculateClass().SquareCalculate(VarManegement, Shiki);
            // System.Diagnostics.Debug.WriteLine("ここ一番で決める:"+VarManegement["i"].ToString());

            /*
             * ♢*/
            Shiki = "1＋i＋3×j＋i≧3＋4";
            VarManegement["i"] = 3;

            //Symbolは0がNo、1がYes、：が判定
            /// (string Symbol,int b,int c) Kekka = new CalculateClass().DiamondCalculat(VarManegement, Shiki);


            //台形Symbolは0がNo、1がYes、：が判定
            /// bool Kekka2 = new CalculateClass().TrapezoidCalculat(VarManegement, Shiki);


        }
        public async void PresetLoad()
        {

            //起動時にどうせ使う第壱テーブルを読み込む用コネクション
            PresetLoadClass PreClass = new PresetLoadClass();
            DbInsertListTTb1 = await PreClass.OnAppearing();
            Debug.WriteLine(DbInsertListTTb1 + "aaaaaaaaaaaaaa");

        }
        public async void PartsLoad(string Tb1Id)
        {

            //第弐テーブルを読み込む用コネクション
            PatrsLoadClass ParClass = new PartsLoadClass();
            DbInsertListTTb1 = await ParClass.OnAppearing();
            Debug.WriteLine(DbInsertListTTb2 + "aaaaaaaaaaaaaa");

        }
    }
}
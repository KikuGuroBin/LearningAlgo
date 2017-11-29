
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Attributes;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningAlgo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test1 : ContentPage
    {
        Dictionary<string , List<string>> DbInsertLint;

        public Test1()
        {
            InitializeComponent();
            //①起動②モード？

<<<<<<< HEAD
=======
            DBadd dBadd = new DBadd();
            dBadd.DataBaseRepository();

>>>>>>> 99b8510... DB

            //起動時にどうせ使う第壱テーブルを読み込む
            DbInsertLint = new PresetLoadClass().PresetLoad(DbInsertLint);

            //選択ボタン押された後使う第弐テーブルを読み込む用



            // DBにする配列達
            string[] FlowTable = new string[3];
            string[] PrintTable = new string[4];
            string[] KindTable = new string[3];

            // 変数を格納したDBからDictionaryにぶち込む
            Dictionary<string, int> VarManegement = new Dictionary<string, int>();
            VarManegement["i"] = 3;
            VarManegement["j"] = 5;
            string Shiki;

            /*
             * □*/
             Shiki = "1＋i＋3×j＋i→i";
            
             VarManegement = new CalculateClass().SquareCalculate(VarManegement, Shiki);
             System.Diagnostics.Debug.WriteLine("ここ一番で決める:"+VarManegement["i"].ToString());

            /*
             * ♢*/
            Shiki = "1＋i＋3×j＋i≧3＋4";
            VarManegement["i"] = 3;

            //Symbolは0がNo、1がYes、：が判定
            (string Symbol,int b,int c) Kekka = new CalculateClass().DiamondCalculat(VarManegement, Shiki);


            //台形Symbolは0がNo、1がYes、：が判定
            bool Kekka2 = new CalculateClass().TrapezoidCalculat(VarManegement, Shiki);


        }
    }
}
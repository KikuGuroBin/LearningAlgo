
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningAlgo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test1 : ContentPage
    {
        public Test1()
        {
            InitializeComponent();

            // プログラムでのレイアウト追加方法
            Label TestNo1Label = new Label
            {
                Text = "3＋12×4－6÷2→i"
            };
            Label TestNo2Label = new Label
            {
                Text = "i＋1→i"
            };
            Label TestNo3Label = new Label
            {
                Text = "i出力"
            };

            MainLayout.Children.Add(TestNo1Label);
            MainLayout.Children.Add(TestNo2Label);
            MainLayout.Children.Add(TestNo3Label);


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
             * □
             Shiki = "1＋i＋3×j＋i→i";

            SquareCalculatClass squareCalculat =new SquareCalculatClass();
            VarManegement = squareCalculat.SquareCalculate(VarManegement,Shiki);
            System.Diagnostics.Debug.WriteLine("ここ一番で決める:"+VarManegement["i"].ToString());
            */


            /*
             * ♢
            Shiki = "1＋i＋3×j＋i≧3＋4";

            //Symbolは0がNo、1がYes、：が判定
            DiamondCalculatClass diamondCalculat = new DiamondCalculatClass();
            (string Symbol,int b,int c) Kekka = diamondCalculat.DiamondCalculat(VarManegement, Shiki);
            */

            /*
             * ♢
            Shiki = "1＋i＋3×j＋i≧3＋4";

            //Symbolは0がNo、1がYes、：が判定
            DiamondCalculatClass diamondCalculat = new DiamondCalculatClass();
            bool Kekka = diamondCalculat.DiamondCalculat(VarManegement, Shiki);
            */


        }
    }
}
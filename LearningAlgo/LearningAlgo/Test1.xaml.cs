
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;



namespace LearningAlgo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test1 : ContentPage
    {
        /* OnSizeAllocated制御用 */
        private bool FirstOrder = true;

        /* 右からのショートカットメニュー用 */
        public StackLayout ShortCutPane;
        public StackLayout SubKeyPane;
        public ListView ShortCutList;
        private double PanelWidth = -1;
        private bool _PanelShowing = false;
        double SidePanelHeight;
        private bool PanelShowing


        {
            get
            {
                return _PanelShowing;
            }
            set
            {
                _PanelShowing = value;
            }
        }

        double LabelWidth;



        public Test1()
        {
            InitializeComponent();

            ShortCutPane = SidePane;

            /* iOSだけ、上部に余白をとる */
            /* Padding = new Thickness(0, Device.RuntimePlatform == Device.iOS ? 20 : 0, 0, 0);

            アイテムをImagesourceFormPageで参照できるようにメンバ変数に格納 */




           
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
        /* 画面サイズが変更されたときのイベント */
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            System.Diagnostics.Debug.WriteLine("aaaaaaaaaa");
            /* 初回だけ処理を行う */
            if (FirstOrder)
            {
                /* メインのレイアウトの幅、高さを設定 */
                MainLayout.WidthRequest = width;
                MainLayout.HeightRequest = height - 70;

                /* ラベルなどに設定する幅、高さを求める */
                LabelWidth = width / 5;
                double labelHeight = LabelWidth / 3 * 2;

                /* シュートカットメニュー用パネルの設定 */
                CreatePanel();

                UnderMenu.LayoutTo(new Rectangle(0, height / 10 * 9, width, height / 10), 0, Easing.CubicOut);


                /* 次回以降呼ばれないようにする */
                FirstOrder = false;
            }
        }





        /* ショートカットメニュー用パネル組み込み用 */
        private void CreatePanel()
        {
            /* 生成したパネルをメインのレイアウトに組み込む */
            MainLayout.Children.Add(ShortCutPane,
                Constraint.RelativeToParent((p) =>
                {
                    return -PanelWidth;
                }),
                Constraint.RelativeToParent((p) =>
                {
                    return 0;
                }),
                Constraint.RelativeToParent((p) =>
                {
                    if (PanelWidth == -1)
                    {
                        PanelWidth = p.Width / 3;
                    }

                    return PanelWidth;
                }),
                Constraint.RelativeToParent((p) =>
                {
                    return p.Height;
                })
            );
            SidePanelHeight = ShortCutPane.Height / 3 * 2;
        }
        private async void SideAnimatePanel()
        {
            // swap the state
            this.PanelShowing = !PanelShowing;

            // show or hide the panel
            if (this.PanelShowing)
            {
                // layout the panel to slide out
                var rect = new Rectangle(0, 0, ShortCutPane.Width, SidePanelHeight);

                await ShortCutPane.LayoutTo(rect, 100, Easing.CubicIn);
            }
            else
            {
                // layout the panel to slide in
                var rect = new Rectangle(0 - ShortCutPane.Width, 0, ShortCutPane.Width, SidePanelHeight);
                await ShortCutPane.LayoutTo(rect, 50, Easing.CubicOut);
            }
        }
        private async void KeybordAnimatePanel()
        {
            // swap the state
            this.PanelShowing = !PanelShowing;

            // show or hide the panel
            if (this.PanelShowing)
            {
                // layout the panel to slide out
                var rect = new Rectangle(0, 0, ShortCutPane.Width, SidePanelHeight);

                await ShortCutPane.LayoutTo(rect, 100, Easing.CubicIn);
            }
            else
            {
                // layout the panel to slide in
                var rect = new Rectangle(0 - ShortCutPane.Width, 0, ShortCutPane.Width, SidePanelHeight);
                await ShortCutPane.LayoutTo(rect, 50, Easing.CubicOut);
            }
        }
        /* サイドラベルタップ用のイベント */
        void SidePanel(object sender, EventArgs args)
        {
            SideAnimatePanel();
        }
        /* キーボードラベルタップ用のイベント */
        void KeyPanel(object sender, EventArgs args)
        {
            KeybordAnimatePanel();

        }


    }
}
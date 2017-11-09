using Java.Util;
using System;
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

        // DBにする配列達
        string[] FlowTable = new string[3];
        string[] PrintTable = new string[4];
        string[] KindTable = new string[3];

        // 今後i,jとか数値が変化するやつをハッシュマップで管理したい
        Dictionary<string, int> VarManagement = new Dictionary<string, int>();

        ArrayDeque NumberStack = new ArrayDeque();
        ArrayDeque SymbolStack = new ArrayDeque();



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

            // 必要な工程   形種類の判定


            // 判定後”□”の場合
            char[] StackText = TestNo1Label.Text.ToString().ToCharArray();

            // 最終的な変数　→i　の i的な
            string FinalizdKey;
            FinalizdKey = (StackText[(StackText.Length - 1)]).ToString();

            System.Diagnostics.Debug.WriteLine(TestNo1Label.Text.ToString());



            System.Diagnostics.Debug.WriteLine(StackText.Length);
            //与えられた文字列を一文字ずつ分解したから初めから数字と記号でスタックしてく(×÷は計算する)　→　が来たらブレイク
            for (int Tenmade = 0, length = 0, Calculat = 0, Popcount = 0; length < StackText.Length; length++)
            {

                System.Diagnostics.Debug.WriteLine("何週目ですか:" + length);

                if (StackText[length].ToString().Equals("→"))
                {
                    for (Popcount++; Popcount >= 0; Popcount--)
                    {
                        CalculationMethod();
                    }
                    break;
                }
                else
                {
                    if (StackText[length].ToString().Equals("×") || StackText[length].ToString().Equals("÷"))
                    {
                        if (Calculat == 1)
                        {
                            Popcount++;
                        }

                        if (Calculat >= 2)
                        {
                            CalculationMethod();

                        }

                        SymbolStack.Push(StackText[length]);
                        System.Diagnostics.Debug.WriteLine("中身：" + SymbolStack.ToString());
                        System.Diagnostics.Debug.WriteLine("数値中身：" + NumberStack.ToString());
                        Calculat = 2;
                        Tenmade = 0;
                    }
                    else if (StackText[length].ToString().Equals("＋") || StackText[length].ToString().Equals("－"))
                    {
                        if (Calculat >= 1)
                        {

                            for (; Popcount >= 0; Popcount--)
                            {
                                CalculationMethod();
                            }

                        }
                        Calculat = 1;
                        SymbolStack.Push(StackText[length]);
                        System.Diagnostics.Debug.WriteLine("中身：" + SymbolStack.ToString());
                        System.Diagnostics.Debug.WriteLine("数値中身：" + NumberStack.ToString());
                        Tenmade = 0;
                    }
                    else if (StackText[length].ToString().Equals("i") || StackText[length].ToString().Equals("j"))
                    {
                        if (!VarManagement.ContainsKey(StackText[length].ToString()))
                        {
                            VarManagement.Add(StackText[length].ToString(), 0);
                        }
                        else
                        {
                            NumberStack.Push(StackText[length]);
                        }
                    }
                    else
                    {
                        if (Tenmade == 1)
                        {

                            System.Diagnostics.Debug.WriteLine("a");

                            NumberStack.Push(int.Parse(NumberStack.Pop().ToString()) * 10 + int.Parse(StackText[length].ToString()));
                        }
                        else
                        {
                            NumberStack.Push(StackText[length]);
                        }
                        Tenmade = 1;

                        System.Diagnostics.Debug.WriteLine("中身：" + SymbolStack.ToString());
                        System.Diagnostics.Debug.WriteLine("数値中身：" + NumberStack.ToString());
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine("最終結果：" + NumberStack.Peek());
        }
        public void CalculationMethod()
        {
            if (SymbolStack.Peek().ToString().Equals("×"))
            {
                SymbolStack.Pop();
                string Before = NumberStack.Pop().ToString();
                NumberStack.Push(int.Parse(NumberStack.Pop().ToString()) * int.Parse(Before));
            }
            else if (SymbolStack.Peek().ToString().Equals("÷"))
            {
                SymbolStack.Pop();
                string Before = NumberStack.Pop().ToString();
                NumberStack.Push(int.Parse(NumberStack.Pop().ToString()) / int.Parse(Before));

            }
            else if (SymbolStack.Peek().ToString().Equals("＋"))
            {
                SymbolStack.Pop();
                string Before = NumberStack.Pop().ToString();
                NumberStack.Push(int.Parse(NumberStack.Pop().ToString()) + int.Parse(Before));
            }
            else if (SymbolStack.Peek().ToString().Equals("－"))
            {
                SymbolStack.Pop();
                string Before = NumberStack.Pop().ToString();
                NumberStack.Push(int.Parse(NumberStack.Pop().ToString()) - int.Parse(Before));

            }
        }
    }
}
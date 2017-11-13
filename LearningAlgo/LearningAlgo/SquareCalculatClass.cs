using Java.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningAlgo
{
    class SquareCalculatClass
    {

        // DBにする配列達
        string[] FlowTable = new string[3];
        string[] PrintTable = new string[4];
        string[] KindTable = new string[3];



        ArrayDeque NumberStack = new ArrayDeque();
        ArrayDeque SymbolStack = new ArrayDeque();
        public SquareCalculatClass() { }

        // 今後i,jとか数値が変化するやつをハッシュマップで管理したい
        public Dictionary<string, int> SquareCalculate(Dictionary<string, int> VarManagement, string ArithExpression)
        {


            // 必要な工程   形種類の判定


            // 判定後”□”の場合
            char[] StackText = ArithExpression.ToCharArray();

            // 最終的な変数　→i　の i的な
            string FinalizdKey;
            FinalizdKey = (StackText[(StackText.Length - 1)]).ToString();

            System.Diagnostics.Debug.WriteLine(ArithExpression);



            System.Diagnostics.Debug.WriteLine(StackText.Length);
            //与えられた文字列を一文字ずつ分解したから初めから数字と記号でスタックしてく(×÷は計算する)　→　が来たらブレイク
            for (int Tenmade = 0, length = 0, Calculat = 0, Popcount = 0; length < StackText.Length; length++)
            {

                System.Diagnostics.Debug.WriteLine("何週目ですか:" + length);
                System.Diagnostics.Debug.WriteLine("見るのは:" + StackText[length]);

                if (StackText[length].ToString().Equals("→"))
                {
                    
                    for (int a= NumberStack.Size()-1; a > 0; a--)
                    {
                        System.Diagnostics.Debug.WriteLine("残りはこれ:" + NumberStack.ToString()+a);
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
                            NumberStack.Push(VarManagement[(StackText[length].ToString())]);
                        }
                    }
                    else
                    {
                        if (Tenmade == 1)
                        {

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
            System.Diagnostics.Debug.WriteLine("最終結果：" + NumberStack.ToString());
            VarManagement[FinalizdKey.ToString()] = int.Parse(NumberStack.Pop().ToString());

            return VarManagement;

        }

        public void CalculationMethod()
        {

            int Before;
            int After;
            try
            {
                Before = int.Parse(NumberStack.Pop().ToString());


            }
            catch (Exception e)
            {
                Before = int.Parse(NumberStack.Pop().ToString());
            }

            try
            {
                After = int.Parse(NumberStack.Pop().ToString());


            }
            catch (Exception e)
            {

                After = int.Parse(NumberStack.Pop().ToString());
            }



            if (SymbolStack.Peek().ToString().Equals("×"))
            {
                SymbolStack.Pop();

                NumberStack.Push(After * Before);
            }
            else if (SymbolStack.Peek().ToString().Equals("÷"))
            {
                SymbolStack.Pop();
                NumberStack.Push(After / Before);

            }
            else if (SymbolStack.Peek().ToString().Equals("＋"))
            {
                SymbolStack.Pop();
                NumberStack.Push(After + Before);
            }
            else if (SymbolStack.Peek().ToString().Equals("－"))
            {
                SymbolStack.Pop();
                NumberStack.Push(After - Before);

            }
        }
    }
}

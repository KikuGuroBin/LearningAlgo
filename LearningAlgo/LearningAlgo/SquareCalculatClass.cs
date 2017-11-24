
using System;
using System.Collections.Generic;

namespace LearningAlgo
{
    class SquareCalculatClass
    {

        Stack<int> NumberStack = new Stack<int>();
        Stack<string> SymbolStack = new Stack<string>();
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
                    
                    for (int a= NumberStack.Count-1; a > 0; a--)
                    {
                        System.Diagnostics.Debug.WriteLine("残りはこれ:" + a);
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

                        SymbolStack.Push(StackText[length].ToString());
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
                        SymbolStack.Push(StackText[length].ToString());
                        System.Diagnostics.Debug.WriteLine("中身：" + SymbolStack.Peek().ToString());
                        System.Diagnostics.Debug.WriteLine("数値中身：" + NumberStack.Peek().ToString());
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
                            NumberStack.Push(int.Parse(StackText[length].ToString()));
                        }
                        Tenmade = 1;

                        try
                        {
                            System.Diagnostics.Debug.WriteLine("中身：" + SymbolStack.Peek().ToString());

                        }
                        catch (Exception e)
                        {

                            System.Diagnostics.Debug.WriteLine("数値中身：" + NumberStack.Peek().ToString());
                        }
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine("最終結果：" + NumberStack.Peek().ToString());
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

using System;
using System.Collections.Generic;
using System.Text;

namespace LearningAlgo
{
    class CalculateClass
    {
        public CalculateClass() { }

        Stack<int> NumberStack = new Stack<int>();
        Stack<string> SymbolStack = new Stack<string>();
        string RightArithExpression;
        string LeftArithExpression;
        string judgeSymbol;


        public (string, int, int) DiamondCalculat(Dictionary<string, int> VarManagement, string ArithExpression)
        {

            char[] stackText = ArithExpression.ToCharArray();

            for (int lengthcount = 0, rorl = 0; lengthcount < stackText.Length; lengthcount++)
            {
                if (rorl == 0)
                {

                    if (stackText[lengthcount].ToString() == "：" ||
                        stackText[lengthcount].ToString() == "＞" ||
                        stackText[lengthcount].ToString() == "＜" ||
                        stackText[lengthcount].ToString() == "≧" ||
                        stackText[lengthcount].ToString() == "≦" ||
                        stackText[lengthcount].ToString() == "＝" ||
                        stackText[lengthcount].ToString() == "≠")
                    {
                        judgeSymbol = stackText[lengthcount].ToString();
                        rorl = 1;
                    }
                    else
                    {
                        LeftArithExpression = LeftArithExpression + stackText[lengthcount].ToString();
                        System.Diagnostics.Debug.WriteLine("左の中身:       " + LeftArithExpression);
                    }
                }
                else
                {
                    RightArithExpression = RightArithExpression + stackText[lengthcount].ToString();
                    System.Diagnostics.Debug.WriteLine("右の中身:       " + RightArithExpression);
                }
            }
            System.Diagnostics.Debug.WriteLine("前半: " + LeftArithExpression);
            System.Diagnostics.Debug.WriteLine("後半：" + RightArithExpression);

            string before = DiamondSeparateCalculate(VarManagement, LeftArithExpression + "→");
            string after = DiamondSeparateCalculate(VarManagement, RightArithExpression + "→");
            System.Diagnostics.Debug.WriteLine("前半: " + before);
            System.Diagnostics.Debug.WriteLine("後半：" + after);




            if (judgeSymbol == "：")
            {
                return (judgeSymbol, int.Parse(before), int.Parse(after));
            }
            else
            {
                return (JudgeTorF(int.Parse(before), int.Parse(after), judgeSymbol));
            }
            return ("", 0, 0);
        }

        private (string, int, int) JudgeTorF(int before, int after, string judgeSymbol)
        {
            if (judgeSymbol == "＞")
            {
                if (before > after)
                {
                    return ("1", before, after);
                }
            }
            else if (judgeSymbol == "＜")
            {
                if (before < after)
                {

                    return ("1", before, after);
                }

            }
            else if (judgeSymbol == "≧")
            {
                if (before >= after)
                {
                    return ("1", before, after);
                }
            }
            else if (judgeSymbol == "≦")
            {
                if (before <= after)
                {
                    return ("1", before, after);
                }
            }
            else if (judgeSymbol == "＝")
            {
                if (before == after)
                {
                    return ("1", before, after);
                }
            }
            else if (judgeSymbol == "≠")
            {
                if (before != after)
                {
                    return ("1", before, after);
                }
            }
            else
            {
                return ("0", before, after);
            }


            return ("0", before, after);

        }

        public string DiamondSeparateCalculate(Dictionary<string, int> VarManagement, string ArithExpression)
        {

            // 必要な工程   形種類の判定


            // 判定後”□”の場合
            char[] StackText = ArithExpression.ToCharArray();

            System.Diagnostics.Debug.WriteLine(ArithExpression);



            System.Diagnostics.Debug.WriteLine(StackText.Length);
            //与えられた文字列を一文字ずつ分解したから初めから数字と記号でスタックしてく(×÷は計算する)　→　が来たらブレイク
            for (int Tenmade = 0, length = 0, Calculat = 0, Popcount = 0; length < StackText.Length; length++)
            {

                System.Diagnostics.Debug.WriteLine("何週目ですか:" + length);
                System.Diagnostics.Debug.WriteLine("見るのは:" + StackText[length]);

                if (StackText[length].ToString().Equals("→"))
                {

                    for (int a = NumberStack.Count - 1; a > 0; a--)
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

            return NumberStack.Pop().ToString();

        }



        public bool TrapezoidCalculat(Dictionary<string, int> VarManagement, string ArithExpression)
        {

            char[] stackText = ArithExpression.ToCharArray();

            for (int lengthcount = 0, rorl = 0; lengthcount < stackText.Length; lengthcount++)
            {
                if (rorl == 0)
                {

                    if (stackText[lengthcount].ToString() == "：" ||
                        stackText[lengthcount].ToString() == "＞" ||
                        stackText[lengthcount].ToString() == "＜" ||
                        stackText[lengthcount].ToString() == "≧" ||
                        stackText[lengthcount].ToString() == "≦" ||
                        stackText[lengthcount].ToString() == "＝" ||
                        stackText[lengthcount].ToString() == "≠")
                    {
                        judgeSymbol = stackText[lengthcount].ToString();
                        rorl = 1;
                    }
                    else
                    {
                        LeftArithExpression = LeftArithExpression + stackText[lengthcount].ToString();
                        System.Diagnostics.Debug.WriteLine("左の中身:       " + LeftArithExpression);
                    }
                }
                else
                {
                    RightArithExpression = RightArithExpression + stackText[lengthcount].ToString();
                    System.Diagnostics.Debug.WriteLine("右の中身:       " + RightArithExpression);
                }
            }
            System.Diagnostics.Debug.WriteLine("前半: " + LeftArithExpression);
            System.Diagnostics.Debug.WriteLine("後半：" + RightArithExpression);

            string before = DiamondSeparateCalculate(VarManagement, LeftArithExpression + "→");
            string after = DiamondSeparateCalculate(VarManagement, RightArithExpression + "→");
            System.Diagnostics.Debug.WriteLine("前半: " + before);
            System.Diagnostics.Debug.WriteLine("後半：" + after);


            return (JudgeTorF2(int.Parse(before), int.Parse(after), judgeSymbol));

        }

        private bool JudgeTorF2(int before, int after, string judgeSymbol)
        {
            if (judgeSymbol == "＞")
            {
                if (before > after)
                {
                    return true;
                }
            }
            else if (judgeSymbol == "＜")
            {
                if (before < after)
                {

                    return true;
                }

            }
            else if (judgeSymbol == "≧")
            {
                if (before >= after)
                {
                    return true;
                }
            }
            else if (judgeSymbol == "≦")
            {
                if (before <= after)
                {
                    return true;
                }
            }
            else if (judgeSymbol == "＝")
            {
                if (before == after)
                {
                    return true;
                }
            }
            else if (judgeSymbol == "≠")
            {
                if (before != after)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }


            return false;

        }






        // ”□”の場合
        public Dictionary<string, int> SquareCalculate(Dictionary<string, int> VarManagement, string ArithExpression)
        {


            // 必要な工程   形種類の判定


            
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

                    for (int a = NumberStack.Count - 1; a > 0; a--)
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

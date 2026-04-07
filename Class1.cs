using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace sekigae
{
    class Class1
    {
        static void Main()
        {

            string[] students =
            {
                "","ああ","いい","うう","ええ","おお","かか","きき","くく","けけ","ここ","ささ","しし","すす","せせ","そそ","たた","ちち","つつ","てて","とと","なな","にに","ぬぬ","ねね","のの","はは","ひひ","ふふ","へへ","ほほ","まま","みみ","むむ","めめ","もも"
            };

            //データ読み取り
            Console.Write("１列目≫");
            string[] A_str = Console.ReadLine().Split(',');
            Console.Write("２列目≫");
            string[] B_str = Console.ReadLine().Split(',');
            Console.Write("３列目≫");
            string[] C_str = Console.ReadLine().Split(',');
            Console.Write("４列目≫");
            string[] D_str = Console.ReadLine().Split(',');
            /*Console.Write("５列目≫");
            string[] E_str = Console.ReadLine().Split(',');*/
            string[][] strs = { A_str, B_str, C_str, D_str,/*E_str*/};

            int[] A = new int[A_str.Length];
            int[] B = new int[B_str.Length];
            int[] C = new int[C_str.Length];
            int[] D = new int[D_str.Length];
            //int[] E = new int[E_str.Length];
            int[][] ints = { A, B, C, D /*,E*/};
            int j = 0;
            for (int i = 0; i < ints.Length; i++)
            {
                foreach (string str in strs[i])
                {
                    ints[i][j] = int.Parse(str);
                    j++;
                }
                j = 0;
            }

            //前列希望者の席を抽選
            int[] seats = new int[students.Length - 1];
            Random rand = new Random();
            int r = 0;
            for (int row = 0; row < ints.Length; row++)
            {
                for (int num = 0; num < ints[row].Length; num++)
                {
                    while (!seats.Contains(ints[row][num]))
                    {
                        r = rand.Next(0, row * 6 + 6);
                        if (seats[r] == 0)
                        {
                            seats[r] = ints[row][num];
                        }
                    }
                }
            }

            //seats[]の空いている総要素数
            int intsnum = students.Length - 1;
            for (int i = 0; i < ints.Length; i++)
            {
                intsnum -= ints[i].Length;
            }
            List<int> intsAll = new List<int>();//intsをぜんぶひとまとめにしたやつ

            for (int i = 0; i < ints.Length; i++)
            {
                for (int k = 0; k < ints[i].Length; k++)
                {
                    intsAll.Add(ints[i][k]);
                }
            }
            List<int> freeStu = new List<int>();
            for (int i = 1; i < students.Length; i++)
            {
                if (!intsAll.Contains(i))
                {
                    freeStu.Add(i);
                }
            }
            freeStu = freeStu.OrderBy(a => Guid.NewGuid()).ToList();//シャッフル

            int l = 0;
            for (int i = 0; i < freeStu.Count; i++)
            {
                while (seats[l] != 0)
                {
                    l++;
                }
                seats[l] = freeStu[i];
                /*if (nums[i] == 0 & !intsAll.Contains(freeStu[i]))
                {
                  while(!nums.Contains(freeStu[i]))
                  {
                    nums[i] = freeStu[i];
                  }
                }*/
                //前席希望しない生徒を埋めていく工程。
                //複雑な機構なので注意。
            }

            //出力
            int count = 0;
            int columnNum = 6;
            Console.WriteLine("　　　        ［ホワイトボード］");
            foreach (int i in seats)
            {
                if (count % columnNum == 0 && count != 0)
                { //席の端っこまで埋まったら改行
                    Console.WriteLine();
                }
                if (count == 30)//席の左下は空白
                {
                    Console.Write("[　　]　");
                }
                Console.Write("[" + students[i] + "]　");
                count++;

            }
        }
        /*static void Explain()
        {
            Console.WriteLine("～");
            Console.WriteLine("席替えシステムへようこそ！\nこのアプリでは座席をランダムで抽選し、座席表を作成することができます。\n");
            Console.WriteLine("【前座席希望者の設定について】\n視力などの関係で前の座席を希望する人がいます。\n\"ｎ列目≫\"にその方の出席番号を半角数字で入力すると、その列より後ろの席に配置されないよう設定されます。");
            Console.Write("例えば、\n\n２列目≫1\n\nと入力すると");
            Console.WriteLine(@"
　　　        ［ホワイトボード］
[候補]　[候補]　[候補]　[候補]　[候補]　[候補]
[候補]　[候補]　[候補]　[候補]　[候補]　[候補]
[　　]　[　　]　[　　]　[　　]　[　　]　[　　]　
[　　]　[　　]　[　　]　[　　]　[　　]　[　　]　
[　　]　[　　]　[　　]　[　　]　[　　]　[　　]　
[　　]　[　　]　[　　]　[　　]　[　　]　[　　]");
            Console.WriteLine("出席番号１番は、[候補]の中から抽選されます。\n");
            Console.WriteLine("なお、希望者が複数いる場合は半角コンマ\",\"で区切り、");
            Console.WriteLine("列に希望者がいない場合は半角で\"0\"と入力してください。");
            Console.WriteLine("～\n");
        }*/
    }
}

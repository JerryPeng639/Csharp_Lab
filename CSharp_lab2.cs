using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

class Program
{
    static void Main()
    {
        Console.Write("請輸入人數 N：");
        if (!int.TryParse(Console.ReadLine(), out int N) || N <= 0)
        {
            Console.WriteLine("輸入無效，請輸入一個正整數。");
            return;
        }
        int[] A=new int[N];
        int[] B = new int[N];
        Console.Write("       ID:");
        for (int i = 0; i < N; i++)
        {
            A[i] = i;
            B[i] = i;   
            Console.Write("{0,3}", A[i]);
        }
        Console.WriteLine();

        
        //Random RNG = new Random();
        
        /*for (int i = 0; i < N; i++)
        { 
            B[i] = RNG.Next(N);
            Console.Write("{0,3}", B[i]);
        }*/
        Random rng = new Random();
        for (int i = N - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);  // 取得 [0, i] 之間的亂數
                                      // 交換 i 和 j
            int temp = B[i];
            B[i] = B[j];
            B[j] = temp;
        }

        Console.Write("Contactee:");
        for (int i = 0; i < N; i++)
        {
            Console.Write("{0,3}", B[i]);
        }
        Console.WriteLine();

        Console.WriteLine("Enter id of infected citizen:");
        int input;
        // 嘗試讀取並驗證輸入是否在範圍內
        if (int.TryParse(Console.ReadLine(), out input))
        {
            if (input >= 0 && input < N)
            {
                Console.WriteLine("你輸入的ID：{0,3}",input);
                // 在這裡你可以繼續使用這個 input 作為起始感染者
            }
            else
            {
                Console.WriteLine($"錯誤：輸入的數字不在 0 到 {N - 1} 的範圍內。");
            }
        }
        else
        {
            Console.WriteLine("錯誤：請輸入一個有效的整數。");
        }

        int k = input;
        int b;
       
        b = B[k];
       
        while (true)
        {
            Console.Write("{0,3 }",A[k]);
            k=B[k];
            if (k == input)
            {
                break;
            }
        }

        
       
    }
}

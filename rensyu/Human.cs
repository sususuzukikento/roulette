using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public class Human
{
    public int life {  get; set; }
    public string name { get; set; }
    public bool usedShowCard { get; set; }
    public bool usedPassCard { get; set; }

    string[] actionList = new string[] { "1:引き金を引く", "2:パスする", "3:実弾の数を見る" };

    public Human(string name)
    {
        life = 3;
        this.name=name;
        this.usedShowCard = false;
        this.usedPassCard = false;
    }
    public Human():this("Player") { }
    public void trigger(bool tf)
    {
        if (tf == true)
        {
            life--;
            Console.WriteLine("実弾が入っていました");
            Console.WriteLine($"{name}の残りHPは{life}です");
        }
        else
        {
            Console.WriteLine("空弾が入っていました");
            Console.WriteLine($"{name}の残りHPは {life}です");
        }
    }
    public void showCard(bool tf)
    {
        usedShowCard = true;
        if (tf == true)
        {
            Console.WriteLine("実弾が入っています");
        }
        else
        {
            Console.WriteLine("空弾が入っています");
        }
    }
    public void passCard()
    {
        usedPassCard = true;
        Console.WriteLine("パスしました");
    }
    public virtual int selectAction()
    {
        int num;
        while (true)
        {
            Console.WriteLine("行動を選択してください");
            Console.Write(actionList[0]);
            if (usedPassCard == false)
            {
                Console.Write("," + actionList[1]);
            }
            if (usedShowCard == false)
            {
                Console.Write("," + actionList[2]);
            }
            bool b = int.TryParse(Console.ReadLine(), out num);
            if (b == true)
            {
                break;
            }
            else
            {
                Console.WriteLine("数字を入力してください\n");
            }
        }
        return num;
    }
    public void doAction(bool tf)
    {
        int n = selectAction();
        Thread.Sleep(1000);
        if (n == 1)
        {
            trigger(tf);
        }
        else if(n == 2)
        {
            passCard();
        }
        else if(n==3)
        {
            showCard(tf);
        }
    }
}
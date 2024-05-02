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
    public bool showcard { get; set; }
    public bool passcard { get; set; }

    string[] actionList = new string[] { "1:引き金を引く", "2:パスする", "3:実弾の数を見る" };

    public Human(string name)
    {
        life = 3;
        this.name=name;
        this.showcard = true;
        this.passcard = true;
        
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
    public void useshowcard()
    {
        showcard = false;
    }
    public void usepasscard()
    {
        passcard = false;
    }
    public int selectaction()
    {
        int num;
        while (true)
        {
            Console.WriteLine("行動を選択してください");
            Console.Write(actionList[0]);
            if (passcard == true)
            {
                Console.Write("," + actionList[1]);
            }
            else if (showcard == true)
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
    public void useaction(bool bl)
    {
        int n = int.Parse(Console.ReadLine());
        if (n == 1)
        {
            trigger(bl);
        }
        else if(n == 2)
        {
            usepasscard();
        }
        else if(n==3)
        {
            useshowcard();
        }
    }
}
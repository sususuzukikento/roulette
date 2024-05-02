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
    public bool cheatcard { get; set; }
    public bool passcard { get; set; }

    string[] actionList = new string[] { "1:引き金を引く", "2:パスする", "3:実弾の数を見る" };

    public Human(string name)
    {
        life = 3;
        this.name=name;
        this.cheatcard = true;
        this.passcard = true;
        
    }
    public Human():this("Player") { }
    public void trigger(Gun gun)
    {
        if (gun.Bullet[gun.Count] == true)
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
    public void usecheatcard()
    {
        cheatcard = false;
    }
    public void usepasscard()
    {
        passcard = false;
    }
    public void selectAction(Gun gun,out int select)
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
            else if (cheatcard == true)
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
        select = num;
        if (num == 1)
        {
            trigger(gun);
        }
        else if (num == 2)
        {
            usepasscard();
        }
        else if (num == 3)
        {
            usecheatcard();
        }
    }
}
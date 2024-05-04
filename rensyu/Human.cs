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
    public bool pointtriggercard {  get; set; }

    string[] actionList = new string[] { "1:引き金を引く", "2:パスする", "3:実弾の数を見る","相手を撃つ" };

    public Human(string name)
    {
        life = 3;
        this.name=name;
        this.cheatcard = true;
        this.passcard = true;
        this.pointtriggercard = true;
    }
    public Human():this("Player") { }
    public void trigger(Gun gun)
    {
        if (gun.Bullet[gun.Count] == true)
        {
            Console.WriteLine($"{name}は引き金を引きました");
            life--;
            Console.WriteLine("実弾が入っていました");
            Console.WriteLine($"{name}の残りHPは{life}です");
        }
        else
        {
            Console.WriteLine($"{name}は引き金を引きました");
            Console.WriteLine("空弾が入っていました");
            Console.WriteLine($"{name}の残りHPは {life}です");
        }
        gun.Count++;
    }
    public void pointtrigger(Gun gun,Human human)
    {
        usepointtriggercard();
        if (gun.Bullet[gun.Count] == true)
        {
            Console.WriteLine($"{name}は{human.name}に向かって引き金を引きました");
            human.life--;
            Console.WriteLine("実弾が入っていました");
            Console.WriteLine($"{name}の残りHPは{life}です");
        }
        else
        {
            Console.WriteLine($"{name}は{human.name}に向かって引き金を引きました");
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
    public void usepointtriggercard()
    {
        pointtriggercard = false;
    }
    public void selectAction(Gun gun,Human human,out int select)
    {
        int num;
        while (true)
        {
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
                if (passcard)
                {
                    usepasscard();
                    break;
                }
                else
                {
                    Console.WriteLine("使用できません");
                }
            }
            else if (num == 3)
            {
                if (cheatcard)
                {
                    usecheatcard();
                    gun.Bulletcount();
                    break;
                }
                else
                {
                    Console.WriteLine("使用できません");
                }
            }
            else if (num == 4)
            {
                if (pointtriggercard)
                {
                    pointtrigger(gun,human);
                    break;
                }
                else
                {
                    Console.WriteLine("使用できません");
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public class Action
{
    Gun gun = new Gun();
    Human human;

    string[] actionlist = new string[] { "1:引き金を引く", "2:パスする", "3:実弾の数を見る" };
    public Action(string name)
    {
        Human human = new Human(name);
    }
    public Action():this("player")
    { }
    public static int selectaction()
    {
        int n = int.Parse(Console.ReadLine());
        return n;
    }
    public bool Gunshot()
    {
        return gun.Bullet[gun.Count] == true;
        gun.Count++;
    }
    public void Show()
    {
        if (gun.Bullet[gun.Count] == true)
        {
            Console.WriteLine("実弾が入っています");
        }
        else
        {
            Console.WriteLine("空弾が入っています");
        }
    }
    public void Bulletcount()
    {
        int num = 0;
        foreach (bool tf in gun.Bullet)
        {
            if (tf)
            {
                num++;
            }
        }
        Console.WriteLine($"実弾は{num}発入っています");
    }
    public void trigger(bool tf)
    {
        if (tf == true)
        {
            human.life--;
            Console.WriteLine("実弾が入っていました");
            Console.WriteLine($"{human.name}の残りHPは{human.life}です");
        }
        else
        {
            Console.WriteLine("空弾が入っていました");
            Console.WriteLine($"{human.name} の残りHPは {human.life}です");
        }
    }
    public void useshowcard()
    {
        human.showcard = false;
    }
    public void usepasscard()
    {
        human.passcard = false;
    }
    public void showaction()
    {
        Console.WriteLine("行動を選択してください");
        Console.WriteLine(actionlist[0]);
        if (human.passcard == true)
        {
            Console.WriteLine("," + actionlist[1]);
        }
        else if (human.showcard == true)
        {
            Console.Write("," + actionlist[2]);
        }
    }
}
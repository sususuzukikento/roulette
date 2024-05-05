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

    string[] actionList = new string[] { "1:引き金を引く", "2:パスする", "3:次の弾を見る","4:相手を撃つ","5:ルールを表示する" };

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
            Console.WriteLine($"{name}の残りHPは{life}です\n");
        }
        else
        {
            Console.WriteLine($"{name}は引き金を引きました");
            Console.WriteLine("実弾は入っていませんでした");
            Console.WriteLine($"{name}の残りHPは {life}です\n");
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
            Console.WriteLine($"{human.name}の残りHPは{human.life}です\n");
        }
        else
        {
            Console.WriteLine($"{name}は{human.name}に向かって引き金を引きました");
            Console.WriteLine("実弾は入っていませんでした");
            Console.WriteLine($"{human.name}の残りHPは {human.life}です\n");
        }
        gun.Count++;
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
    public void selectAction(Gun gun,Human human)
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
                if (cheatcard == true)
                {
                    Console.Write("," + actionList[2]);
                }
                if(pointtriggercard == true)
                {
                    Console.Write("," + actionList[3]);
                }
                Console.Write(","+actionList[4]);
                Console.WriteLine();
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
            if (num == 1)
            {
                trigger(gun);
                break;
            }
            else if (num == 2)
            {
                if (passcard)
                {
                    usepasscard();
                    Console.WriteLine("パスを使用しました\n");
                    break;
                }
                else
                {
                    Console.WriteLine("使用できません\n");
                }
            }
            else if (num == 3)
            {
                if (cheatcard)
                {
                    usecheatcard();
                    Console.WriteLine("次の弾を確認しました\n");
                    gun.Show();
                    continue;
                }
                else
                {
                    Console.WriteLine("使用できません\n");
                }
            }
            else if (num == 4)
            {
                if (pointtriggercard)
                {
                    pointtrigger(gun,human);
                    if (life == 0 || human.life == 0)
                    {
                        break;
                    }
                    if (gun.Bullet.Length == gun.Count)
                    {
                        Thread.Sleep(1500);
                        gun.resetBullet();
                        Console.WriteLine($"マガジンの弾数は{gun.Bullet.Length}です\n");
                        Thread.Sleep(1500);
                    }
                    continue;
                }
                else
                {
                    Console.WriteLine("使用できません\n");
                }
            }
            else if(num == 5) 
            {
                Console.WriteLine("このゲームは1対1のロシアンルーレットをするゲームです。");
                Console.WriteLine("マガジンには3～5発の弾が自動的に装填され、最低でも1発以上の実弾と空弾が装填されます。");
                Console.WriteLine("プレイヤーはHPが3の状態でゲームを開始して先にHPが0になったほうの負けです。");
                Console.WriteLine("自分に向かって引き金を引く以外の特殊行動はゲーム中にそれぞれ1度まで使用できます。");
                Console.WriteLine();
            }
        }
    }
}
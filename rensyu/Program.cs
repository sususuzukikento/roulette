using System;
using System.Threading;
class rennsyu
{
    static void Main()
    {
        Console.WriteLine("名前を入力してください");
        string? inputname = Console.ReadLine();
        Human player = new Human(inputname);
        Dealer dealer = new Dealer();
        bool order = RandomBoolGenerator.GetRandomBool();
            Thread.Sleep(500);
        if (order)
        {
            Console.WriteLine($"\n{player.name}の先行です\n");
            Thread.Sleep(500);
            Gun gun = new Gun();
            Thread.Sleep(500);
            while (true)
            {
                player.selectAction(gun,dealer);
                Thread.Sleep(1500);
                if(player.life==0||dealer.life==0)
                {
                    break;
                }    
                if (gun.Bullet.Length==gun.Count)
                {
                    Thread.Sleep(1500);
                    gun.resetBullet();
                    Console.WriteLine($"マガジンの弾数は{gun.Bullet.Length}です\n");
                    Thread.Sleep(1500);
                }
                dealer.dealerAction(gun,player);
                Thread.Sleep(1500);
                if (player.life == 0 || dealer.life == 0)
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
            }
            if(dealer.life == 0)
            {
                Console.WriteLine("\nあなたの勝利です\n");
            }
            else if(player.life == 0) 
            {
                Console.WriteLine("\nあなたの負けです\n");
            }
        }
        else 
        {
            Console.WriteLine($"\n{dealer.name}の先行です\n");
            Thread.Sleep(500);
            Gun gun = new Gun();
            Thread.Sleep(500);
            while (true)
            {
                dealer.dealerAction(gun, player);
                Thread.Sleep(1500);
                if (player.life == 0 || dealer.life == 0)
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
                player.selectAction(gun, dealer);
                Thread.Sleep(1500);
                if (player.life == 0 || dealer.life == 0)
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
            }
            if (dealer.life == 0)
            {
                Console.WriteLine("\nあなたの勝利です");
            }
            else if (player.life == 0)
            {
                Console.WriteLine("\nあなたの負けです");
            }
        }
    }
    
}
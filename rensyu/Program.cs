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
        if (order)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"\n{player.name}の先行です\n");
            Gun gun = new Gun();
            while (true)
            {
                player.selectAction(gun,dealer);
                Thread.Sleep(1000);
                if (gun.Bullet.Length==gun.Count)
                {
                    gun.resetBullet();
                    Thread.Sleep(1000);
                }
                if(player.life==0||dealer.life==0)
                {
                    break;
                }    
                dealer.dealerAction(gun,player);
                Thread.Sleep(1000);
                if (gun.Bullet.Length == gun.Count)
                {
                    gun.resetBullet();
                    Thread.Sleep(1000);
                }
                if (player.life == 0 || dealer.life == 0)
                {
                    break;
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
            Gun gun = new Gun();
            while (true)
            {
                dealer.dealerAction(gun, player);
                if (gun.Bullet.Length == gun.Count)
                {
                    gun.resetBullet();
                }
                if (player.life == 0 || dealer.life == 0)
                {
                    break;
                }
                player.selectAction(gun, dealer);
                if (gun.Bullet.Length == gun.Count)
                {
                    gun.resetBullet();
                }
                if (player.life == 0 || dealer.life == 0)
                {
                    break;
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
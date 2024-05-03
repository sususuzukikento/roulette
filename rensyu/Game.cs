using System;
using System.Threading;

public class Game
{
    Human firstPlayer;
    Human secondPlayer;
    Gun gun;
    bool isGameFinished = false;
    public Game(Human player, Human dealer, Gun gun)
    {
        this.gun = gun;
        bool order = RandomBoolGenerator.GetRandomBool();
        if (order)
        {
            Console.WriteLine($"{player.name}の先行です");
            Console.WriteLine("--------------------");
            firstPlayer = player;
            secondPlayer = dealer;
        }
        else
        {
            Console.WriteLine($"{dealer.name}の先行です");
            Console.WriteLine("--------------------");
            firstPlayer = dealer;
            secondPlayer = player;
        }
        Thread.Sleep(1000);
        
    }
    public void battle()
    {
        int turn = 0;
        while (true)
        {
            turn++;
            Thread.Sleep(1000);
            Console.WriteLine($"{turn}ターン目");
            Console.WriteLine();

            Thread.Sleep(1000);
            Console.WriteLine($"{firstPlayer.name}のターンです");
            Thread.Sleep(1000);
            firstPlayer.doAction(gun.shot());
            Console.WriteLine();
            if (judge())
            {
                break;
            }
            
            Console.WriteLine($"{secondPlayer.name}のターンです");
            Thread.Sleep(1000);
            secondPlayer.doAction(gun.shot());
            Console.WriteLine();
            if (judge())
            {
                break;
            }
            Console.WriteLine("--------------------");
        }
    }

    public bool judge()
    {
        if (firstPlayer.life <= 0)
        {
            Console.WriteLine($"{secondPlayer.name}の勝ちです");
            isGameFinished = true;
        }
        else if (secondPlayer.life <= 0)
        {
            Console.WriteLine($"{firstPlayer.name}の勝ちです");
            isGameFinished = true;
        }
        else if (gun.Count == gun.Bullet.Length)
        {
            Console.WriteLine("すべての弾が出ました");
            Console.WriteLine("引き分けです");
            isGameFinished = true;
        }
        return isGameFinished;
    }
}


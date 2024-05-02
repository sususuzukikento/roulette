using System;
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
            Console.WriteLine($"{player.name}の先行です");
            Gun gun = new Gun();
            while (true)
            {
                player.selectAction(gun, out int select);
                if(select==3)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
        }
        else 
        {
            Console.WriteLine($"{dealer.name}の先行です");
        }
    }
    
}
using System;
class rennsyu
{
    static void Main()
    {
        Console.WriteLine("名前を入力してください");
        string inputname = Console.ReadLine();
        Human player = new Human(inputname);
        Human dealer = new Human("ディーラー");
        bool order = RandomBoolGenerator.GetRandomBool();
        if (order)
        {
            Console.WriteLine($"{player.name}の先行です");
            Gun gun = new Gun();
            player.showaction();
            int selectnum = Game.selectaction();

        }
        else 
        {
            Console.WriteLine($"{player.name}の先行です");
        }
    }
    
}
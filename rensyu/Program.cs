using System;
class Rensyu
{
    static void Main()
    {
        Console.WriteLine("名前を入力してください");
        string inputname = Console.ReadLine();
        Gun gun = new Gun();
        Human player = new Human(inputname);
        Dealer dealer = new Dealer("ディーラー");
        Game game = new Game(player, dealer, gun);
        game.battle();
        
    }
}


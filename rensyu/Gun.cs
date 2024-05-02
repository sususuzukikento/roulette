using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Gun
{
    public bool[] Bullet { get; set; }
    public int Count {  get; set; }
    public Gun()
    {
        Random random = new Random();
        int n = random.Next(3, 6);
        Bullet = new bool[n];
        Count = 0;
        for (int i = 0; i < n; i++)
        {
            Bullet[i] = RandomBoolGenerator.GetRandomBool();
        }
        Console.WriteLine($"弾数は{n}です");
    }
}
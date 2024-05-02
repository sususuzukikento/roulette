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
    public bool Gunshot()
    {
        return Bullet[Count] == true;
        Count++;
    }
    public void Show()
    {
        if (Bullet[Count] == true)
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
        foreach (bool tf in Bullet)
        {
            if (tf)
            {
                num++;
            }
        }
        Console.WriteLine($"実弾は{num}発入っています");
    }
}
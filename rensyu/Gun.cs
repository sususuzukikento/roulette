using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Gun
{
    public bool[] Bullet { get; set; }
    public int Count {  get; set; }
    public int allBullet//マガジン内の実弾の数
    {
        get
        {
            int count = 0;
            for (int i = 0; i < Bullet.Length; i++)
            {
                if (Bullet[i])
                {
                    count++;
                }
            }
            return count;
        }
        set{ allBullet = value; }
    }
    public int cartridge//いままで撃った弾の中に何発実弾が含まれているかを数えてる。ディーラー用
    {
        get
        {
            int count = 0;
            for (int i = 0; i < Count; i++)
            {
                if (Bullet[i])
                {
                    count++;
                }
            }
            return count;
        }
        set { cartridge = value; }
    }
    public Gun()
    {
        Random random = new Random();
        int n = random.Next(3, 6);
        Bullet = new bool[n];
        Count = 0;
        for (int i = 0; i < n; i++)
        {
            Bullet[i] = RandomBoolGenerator.GetRandomBoollow();
        }
        Console.WriteLine($"弾数は{n}です");
    }
    public bool Gunshot()
    {
        Count++;
        return Bullet[Count] == true;
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
        Console.WriteLine($"実弾は{allBullet-cartridge}発入っています");
    }
    
}
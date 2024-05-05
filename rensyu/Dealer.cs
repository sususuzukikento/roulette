using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class Dealer : Human
{ 
    public Dealer()
    {
        name = "ディーラー";
    }

    public void dealerAction(Gun gun, Human human)
    {
        while (true)
        {
            if (gun.probability < (double)1 /(double) 2)
            {
                trigger(gun);
                break;
            }
            else
            {
                if (cheatcard)
                {
                    usecheatcard();
                    Console.WriteLine("ディーラーは次の弾を確認した\n");
                    Thread.Sleep(1500);
                    if (gun.Bullet[gun.Count] == true)
                    {
                        if (pointtriggercard)
                        {
                            pointtrigger(gun, human);
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
                        }
                        else if (passcard)
                        {
                            usepasscard();
                            Console.WriteLine("ディーラーはパスをしました\n");
                            break;
                        }
                        else
                        {
                            trigger(gun);
                            break;
                        }
                    }
                    else
                    {
                        trigger(gun);
                        break;
                    }
                }
                else
                {
                    if (pointtriggercard && RandomBoolGenerator.GetRandomBool())
                    {
                        pointtrigger(gun, human);
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
                    }
                    else if (passcard && RandomBoolGenerator.GetRandomBool())
                    {
                        usepasscard();
                        Console.WriteLine("ディーラーはパスをしました\n");
                        break;
                    }
                    else
                    {
                        trigger(gun);
                        break;
                    }
                }
            }
        }
    }
}

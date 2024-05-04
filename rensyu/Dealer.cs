using System;
using System.Collections.Generic;
using System.Linq;
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
            if (gun.probability < (1 / 2))
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
                    if (gun.Bullet[gun.Count] == true)
                    {
                        if (pointtriggercard)
                        {
                            pointtrigger(gun, human);
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

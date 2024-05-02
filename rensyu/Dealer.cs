using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Dealer : Human
{
    public bool actionmemory { get; set; }

    public Dealer()
    {
        name = "ディーラー";
        actionmemory = false;
    }
    public void dealerAction(Gun gun, int select)
    {
        if (actionmemory)
        {
            if (!cheatcard)
            {
                if (select == 2)
                {
                    if (gun.Bullet.Length - gun.Count == 1)
                    {
                        if (passcard)
                        {
                            usepasscard();
                        }
                        else
                        {
                            trigger(gun);
                        }
                    }
                    else if (gun.Bullet[gun.Count-1])
                    {
                        trigger(gun);
                    }
                    else if (gun.Count==0)
                    {
                        
                    }
                    else
                    {
                        if (RandomBoolGenerator.GetRandomBool())//1/2の確率でチートカードを使う
                        {
                            usecheatcard();
                            if (gun.allBullet - gun.cartridge == 0)
                            {
                                trigger(gun);
                            }
                            else if ((gun.allBullet - gun.cartridge) / (gun.Bullet.Length) < 1 / 3)
                            {
                                trigger(gun);
                            }
                            else
                            {
                                if (passcard)
                                {
                                    usepasscard();
                                }
                                else
                                {
                                    trigger(gun);
                                }
                            }
                        }
                    }
                }

            }
        }
    }
}

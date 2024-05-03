using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Dealer : Human
{
    public Dealer(string name) : base(name)
    {
    }

    public override int selectAction()
    {
        List<int> actionNumber = new List<int> { 1, 2, 3 };
        if (usedPassCard==true)
        {
            actionNumber.Remove(2);
        }
        if (usedShowCard==true)
        {
            actionNumber.Remove(3);
        }
        Random rnd = new Random();
        int num = rnd.Next(0, actionNumber.Count);
        return actionNumber[num];
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Human
{
    public int life {  get; set; }
    public string name { get; set; }
    public bool showcard { get; set; }
    public bool passcard { get; set; }
    
    public Human(string name)
    {
        life = 3;
        this.name=name;
        this.showcard = true;
        this.passcard = true;
        
    }
    public void showaction()
    {
        Console.WriteLine("行動を選択してください");
        Console.WriteLine(action[0]);
        if(passcard == true)
        {
            Console.WriteLine("," +action[1]);
        }
        else if(showcard == true)
        {
            Console.Write(","+action[2]);
        }
    }
}
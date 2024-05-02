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
}
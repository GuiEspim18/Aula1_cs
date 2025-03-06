using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaCS
{
    public class Player
    {

        public string name;
        public List<int> statistic = new();

        public Player(string name) 
        {
            this.name = name;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace so2
{
    internal class Legszennyezes
    {
        public List<int> Ora = new();

        public Legszennyezes(string sorok) 
        {
            var sor = sorok.Split(";");
            Ora = new List<int>();
            for (int i = 0; i < sor.Length; i++)
            {
                Ora.Add(int.Parse(sor[i]));
            }
        }

        public override string ToString() 
        {
            return $"{string.Join(" ", Ora)}";        
        }
    }
}

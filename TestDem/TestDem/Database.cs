using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDem
{
    internal class Database
    {
        public static Entities Instance { get; set; } = new Entities();

        public static void save()
        {
            Instance.SaveChanges();
        }
    }
}

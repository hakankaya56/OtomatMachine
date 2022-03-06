using OtomatMachine.Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtomatMachine.Domain.Entites
{
    public class Food:EntityBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    
    }
}

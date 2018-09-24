using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micromania.Console
{
    public class Purchase : Entity
    {
        public virtual double Cost { get; protected set; }
        public virtual DateTime PurchaseDate { get; protected set; }

        public Purchase()
        {
        }

        public Purchase(double cost)
        {
            Cost = cost;
            PurchaseDate = DateTime.Now;
        }

        public static Purchase Create(double cost)
        {
            return new Purchase(cost);
        }        
    }
}

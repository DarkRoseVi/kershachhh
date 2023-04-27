using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5.Componens
{
  public  partial class Order
    {
        public int? Quanity
        {
            get
            {
                return this.OrderDish.Sum(x => x.Quantity);
            }
        }
        public decimal? TotalSum
        {
            get
            {
          return  this.OrderDish.Sum(x=> x.Dish.Cost * x.Quantity);
            }
        }
        public string ColorStatyd 
        {
            get 
            {
                if (StatysId == 3)
                    return "#90EE90";
                else if (StatysId == 4)
                    return "#FA8072";
                else
                    return "#FFFFFF";
            }
        }
    } 
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaiterWpf.Components
{
    partial class Order
    {
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
                return this.OrderDish.Sum(x => x.Dish.Cost * x.Quantity);
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5.Componens
{
   partial  class Employees
    {
      public  string FUO 
        {
            get 
            {
                return LastName + " " + Name + " " + Patronymic;
            }
        }
    }
}
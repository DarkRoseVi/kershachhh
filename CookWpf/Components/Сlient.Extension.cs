﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookWpf.Components
{
    partial class Сlient
    {
        public string FUO
        {
            get
            {
                return LastName + " " + Name + " " + Patronymic;
            }
        }
    }
}

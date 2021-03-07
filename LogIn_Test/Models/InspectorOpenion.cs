using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogIn_Test.Models
{
    public class InspectorOpenion
    {
        [Requierd]
        public bool Openion { get; set; }
        public bool Desc { get; set; }
        [Requierd]
        public int[] PM_Machine_IDs { get; set; }

    }
}
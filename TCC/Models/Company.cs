using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC.Models
{
    public class Company
    {

        public int Id {get; set;}
        public string Name { get; set; }

        public string Cnpj { get; set; }

        public Adress Adress { get; set; }

        public Contact Contact { get; set; }

        public Category Category { get; set; }

    }
}
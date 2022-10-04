using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_CRUD.Entidades
{
    public class Person : Base
    {
        public string Name { get; set; }
        public Sex sex { get; set; }

        public DateTimeOffset Birthday { get; set; }

    }
}

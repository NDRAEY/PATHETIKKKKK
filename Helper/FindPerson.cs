using PATHETIKKKKK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PATHETIKKKKK.Helper
{
    internal class FindPerson
    {
        int id;
        public FindPerson(int id)
        {
            this.id = id;
        }
        public bool PersonPredicate(Person role)
        {
            return role.Id == id;
        }
    }
}

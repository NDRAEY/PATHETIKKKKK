using PATHETIKKKKK.Helper;
using PATHETIKKKKK.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PATHETIKKKKK.Model
{
    public class Person
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }


        public Person() { }
        public Person(int id, int roleId, string firstName, string lastName, DateTime birthday)
        {
            this.Id = id;
            this.RoleId = roleId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday = birthday;
        }

        public static PersonDPO CopyFromPerson(Person person)
        {
            PersonDPO perDPO = new PersonDPO();
            RoleViewModel vmRole = new RoleViewModel();
            string role = string.Empty;
            foreach (var r in vmRole.ListRole)
            {
                if (r.Id == person.RoleId)
                {
                    role = r.NameRole;
                    break;
                }
            }
            if (role != string.Empty)
            {
                perDPO.Id = person.Id;
                perDPO.RoleName = role;
                perDPO.FirstName = person.FirstName;
                perDPO.LastName = person.LastName;
                perDPO.Birthday = person.Birthday;
            }
            return perDPO;
        }


        public Person CopyFromPersonDPO(PersonDPO p)
        {
            RoleViewModel vmRole = new RoleViewModel();
            int roleId = 0;
            foreach (var r in vmRole.ListRole)
            {
                if (r.NameRole == p.RoleName)
                {
                    roleId = r.Id;
                    break;
                }
            }
            if (roleId != 0)
            {
                this.Id = p.Id;
                this.RoleId = roleId;
                this.FirstName = p.FirstName;
                this.LastName = p.LastName;
                this.Birthday = p.Birthday;
            }
            return this;
        }
    }
}

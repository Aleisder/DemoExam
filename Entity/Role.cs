using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam.Entity
{
    class Role
    {
        public int Id { get; set; }
        [Column("role")]
        public string RoleName { get; set; }

        public Role(int id, string roleName)
        {
            Id = id;
            RoleName = roleName;
        }
    }
}

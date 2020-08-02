using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SA.Models
{
    public class EditClassforUsers
    {
        public EditClassforUsers()
        {
            Users = new List<string>();
        }
        //aspnetroles id
        public string Id { get; set; }
        [Required(ErrorMessage = "Role Name is required")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}

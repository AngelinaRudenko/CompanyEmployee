using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace ConsoleApp14.Models
{
    [Table("Admins")]
    public class Admin : User
    {
        public bool HasSpecialPermissions { get; set; }
    }
}

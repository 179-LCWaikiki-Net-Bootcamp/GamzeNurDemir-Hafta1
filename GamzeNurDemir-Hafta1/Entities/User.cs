using System;
using System.Collections.Generic;

#nullable disable

namespace GamzeNurDemir_Hafta1.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

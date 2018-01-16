using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Selfgram.Model.Objects
{
    public class User
    {
        public User()
        {
            this.Publications = new HashSet<Publication>();
        }

        [Column("id")]
        public Guid Id { get; set; }
        [Column("username")]
        [MaxLength(40)]
        public string UserName { get; set; }
        [Column("password")]
        [MaxLength(40)]
        public string Password { get; set; }
        [Column("email")]
        public string Email { get; set; }

        public virtual ICollection<Publication> Publications { get; set; }
    }
}
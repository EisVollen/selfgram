using System;
using System.ComponentModel.DataAnnotations.Schema;
using Selfgram.Objects.Objects.Account;


namespace Selfgram.Objects.Objects.Core
{
    public class Likes
    {
        [Column("id")]
        public Guid Id { get; set; }
        [Column("user_id")]
        public Guid UserId { get; set; }
        [Column("publication_id")]
        public Guid PublicationId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Publication Publication { get; set; }

    }
}
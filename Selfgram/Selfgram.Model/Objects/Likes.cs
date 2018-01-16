using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Selfgram.Model.Objects
{
    public class Likes
    {
        [Column("id")]
        public Guid Id { get; set; }
        [Column("user_id")]
        public Guid UserId { get; set; }
        [Column("publication_id")]
        public Guid PublicationId { get; set; }
      
    }
}
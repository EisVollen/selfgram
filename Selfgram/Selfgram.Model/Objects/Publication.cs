using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Selfgram.Model.Objects
{
    /// <summary>
    /// Публикации
    /// </summary>
    public class Publication
    {
        
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        [Column("header")]
        [MaxLength(40)]
        public string Header { get; set; }

        /// <summary>
        /// Путь к файлу
        /// </summary>
        [Column("image_path")]
        [MaxLength(256)]
        public string ImagePath { get; set; }

        /// <summary>
        /// Тэги
        /// </summary>
        [Column("tags")]
        [MaxLength(1024)]
        public string Tags { get; set; }

        /// <summary>
        /// Автор Id
        /// </summary>
        [Column("author_id")]
        public Guid AuthorId { get; set; }

        /// <summary>
        /// Дата публикации
        /// </summary>
        [Column("public_date")]
        public DateTime PublicDate { get; set; }

        /// <summary>
        /// Автор
        /// </summary>
        public virtual User Author { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Selfgram.Objects.Objects.Account;
using Selfgram.Objects.Objects.Core;

namespace Selfgram.Models.CoreModels
{
    public class PublicationModel
    {
        [Required]
        [StringLength(40)]
        [Display(Name = "Заголовок")]
        public string Header { get; set; }

        [Required]
        [StringLength(256)]
        [Display(Name = "Фото")]
        public string ImagePath { get; set; }

        [Display(Name = "Тэги")]
        [MaxLength(1024)]
        public string Tags { get; set; }

        [Display(Name = "Дата публикации")]
        public DateTime PublicDate { get; set; }

        [Display(Name = "Автор")]
        public ApplicationUser Author { get; set; }

        [Display(Name = "Лайки")]
        public ICollection<Likes> Likes { get; set; }

    }
}


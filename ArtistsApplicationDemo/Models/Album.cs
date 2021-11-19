﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ArtistsApplicationDemo.Models
{
    public class Album
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Album Tille")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Album Description")]
        public string Description { get; set; }

        public ICollection<Song> Songs { get; set; }

        [ForeignKey("Artist")]
        public int ArtistId { get; set; }

        public Artist Artist { get; set; }
    }
}
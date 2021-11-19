using ArtistsApplicationDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtistsApplicationDemo.ViewModels
{
    public class SongFormViewModel
    {
        public Song Song { get; set; }
        public List<Album> Albums { get; set; }
    }
}
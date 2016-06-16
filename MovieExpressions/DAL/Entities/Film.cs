using DAL.IMDBScrapper;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace DAL.Entities
{
    public class Film
    {
        public Film()
        {
            this.Comments = new HashSet<Comment>();
        }
        public Film(IMDB imdb)
            : this()
        {
            this.Title = imdb.Title;
            this.Year = imdb.Year;
            this.Rating = imdb.Rating;
            this.Poster = this.UrlToByteArray(imdb.PosterFull);
            this.Plot = imdb.Plot;
            this.IMDbUrl = imdb.ImdbURL;
        }
        public Film(string query)
            : this(new IMDB(query)) { }


        public int ID { get; set; }

        [DisplayName("Название")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [DisplayName("Год")]
        [DataType(DataType.Date)]
        public string Year { get; set; }

        [DisplayName("Рейтинг")]
        public string Rating { get; set; }

        [DisplayName("Описание")]
        [DataType(DataType.MultilineText)]
        public string Plot { get; set; }

        [DataType(DataType.Url)]
        public string IMDbUrl { get; set; }

        public byte[] Poster { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public byte[] UrlToByteArray(string url)
        {
            using (WebClient client = new WebClient())
            {
               return client.DownloadData(url);
            }

        }

    }
}

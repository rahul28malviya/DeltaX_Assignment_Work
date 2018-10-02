using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies_IMDb.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public char Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Bio { get; set; }
    }
    public class Producer
    {
        public int ProducerId { get; set; }
        public string ProducerName { get; set; }
        public char Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Bio { get; set; }
    }
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Plot { get; set; }
        public DateTime DateOfRelease { get; set; }
        public int YearOfRelease { get; set; }
        public string Poster { get; set; }
        public int ProducerId { get; set; }
        public int[] ActorId { get; set; }

    }
}
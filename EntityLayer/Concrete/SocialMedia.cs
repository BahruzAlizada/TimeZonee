using CoreLayer.Entity;
using System;

namespace EntityLayer.Concrete
{
    public class SocialMedia : IEntity
    {
        public int Id { get; set; }
        public string InstagramLink { get; set; }
        public string TviterLink { get; set; }
        public string YoutubeLink { get; set; }
    }
}

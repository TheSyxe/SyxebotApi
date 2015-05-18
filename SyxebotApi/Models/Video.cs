namespace SyxebotApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Video
    {
        [Key]
        public int BroadcastId { get; set; }

        public int ChannelId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime RecordedAt { get; set; }

        public string VideoUrl { get; set; }

        public string PreviewUrl { get; set; }

        public int LengthInSeconds { get; set; }

        public int Views { get; set; }

        public virtual ChannelDetail ChannelDetail { get; set; }

        public virtual Channel Channel { get; set; }
    }
}

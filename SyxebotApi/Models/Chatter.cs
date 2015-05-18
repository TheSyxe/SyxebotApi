namespace SyxebotApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Chatter
    {
        public int ChatterId { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public int ChannelId { get; set; }

        public int Currency { get; set; }

        public int HoursWatched { get; set; }

        public virtual Channel Channel { get; set; }

        public virtual ChatterDetail ChatterDetail { get; set; }
    }
}

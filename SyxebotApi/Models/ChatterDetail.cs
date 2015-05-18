namespace SyxebotApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChatterDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ChatterId { get; set; }

        public string ChatColor { get; set; }

        public int TwitchId { get; set; }

        public string TwitchBio { get; set; }

        public DateTime TwitchUpdatedAt { get; set; }

        public string TwitchLogoUrl { get; set; }

        public virtual Chatter Chatter { get; set; }
    }
}

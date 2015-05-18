namespace SyxebotApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Follow
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ChannelId { get; set; }

        public DateTime CreatedAt { get; set; }

        public int TwitchUserId { get; set; }

        public string TwitchDisplayName { get; set; }

        public int? ChannelDetails_ChannelId { get; set; }

        public virtual ChannelDetail ChannelDetail { get; set; }

        public virtual Channel Channel { get; set; }
    }
}

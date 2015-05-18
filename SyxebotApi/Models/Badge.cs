namespace SyxebotApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Badge
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ChannelId { get; set; }

        public string Name { get; set; }

        public string BadgeUrl { get; set; }

        public int? ChannelDetails_ChannelId { get; set; }

        public virtual ChannelDetail ChannelDetail { get; set; }

        public virtual Channel Channel { get; set; }
    }
}

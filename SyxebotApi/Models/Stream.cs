namespace SyxebotApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Stream
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stream()
        {
            ChannelDetails = new HashSet<ChannelDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ChannelId { get; set; }

        public int StreamId { get; set; }

        public DateTime StartedAt { get; set; }

        public string TwitchStreamTitle { get; set; }

        public string TwitchStreamGame { get; set; }

        public int TwitchStreamDelay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChannelDetail> ChannelDetails { get; set; }

        public virtual Channel Channel { get; set; }
    }
}

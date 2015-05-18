namespace SyxebotApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChannelDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChannelDetail()
        {
            Badges = new HashSet<Badge>();
            Emoticons = new HashSet<Emoticon>();
            Follows = new HashSet<Follow>();
            Videos = new HashSet<Video>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ChannelId { get; set; }

        public string RaidMessage { get; set; }

        public int TimeZoneOffsetFromCST { get; set; }

        public int StreamId { get; set; }

        public bool IsTwitchMature { get; set; }

        public string TwitchStreamTitle { get; set; }

        public string TwitchStreamGame { get; set; }

        public int TwitchStreamDelay { get; set; }

        public int TwitchId { get; set; }

        public DateTime TwitchUpdatedAt { get; set; }

        public string TwitchLogo { get; set; }

        public string TwitchBanner { get; set; }

        public string TwitchVideoBanner { get; set; }

        public string TwitchBackgroundUrl { get; set; }

        public string TwitchProfileBannerUrl { get; set; }

        public string TwitchChatUrl { get; set; }

        public string TwitchProfileBannerBackgroundColor { get; set; }

        public bool IsPartnered { get; set; }

        public int TwitchViews { get; set; }

        public int TwitchFollows { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Badge> Badges { get; set; }

        public virtual Channel Channel { get; set; }

        public virtual Stream Stream { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emoticon> Emoticons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Follow> Follows { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Video> Videos { get; set; }
    }
}

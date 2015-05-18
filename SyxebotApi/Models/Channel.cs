namespace SyxebotApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Channel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Channel()
        {
            Chatters = new HashSet<Chatter>();
            Commands = new HashSet<Command>();
            Giveaways = new HashSet<Giveaway>();
            Giveaways1 = new HashSet<Giveaway>();
            Videos = new HashSet<Video>();
        }

        public int ChannelId { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public int BotId { get; set; }

        public int? GiveawaySettings_GiveawayId { get; set; }

        public virtual Badge Badge { get; set; }

        public virtual Bot Bot { get; set; }

        public virtual ChannelDetail ChannelDetail { get; set; }

        public virtual Giveaway Giveaway { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chatter> Chatters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Command> Commands { get; set; }

        public virtual Emoticon Emoticon { get; set; }

        public virtual Follow Follow { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Giveaway> Giveaways { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Giveaway> Giveaways1 { get; set; }

        public virtual Setting Setting { get; set; }

        public virtual Stream Stream { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Video> Videos { get; set; }
    }
}

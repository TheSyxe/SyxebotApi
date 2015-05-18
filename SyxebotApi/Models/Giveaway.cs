namespace SyxebotApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Giveaway
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Giveaway()
        {
            Channels = new HashSet<Channel>();
            Giveaways1 = new HashSet<Giveaway>();
        }

        public int GiveawayId { get; set; }

        public int ChannelId { get; set; }

        public string GameName { get; set; }

        public bool IsRegionalGiveaway { get; set; }

        public bool IsCheckCurrencyEnabled { get; set; }

        public int CurrencyRequirement { get; set; }

        public bool IsCurrencyRemovedOnEntry { get; set; }

        public bool IsCurrencyRemovedOnSelectWinner { get; set; }

        public bool IsTimeCheckEnabled { get; set; }

        public int HoursNeeded { get; set; }

        public bool IsClaimCheckEnabled { get; set; }

        public int ClaimTimeout { get; set; }

        public int ClaimRate { get; set; }

        public bool IsPurgingFalseWinners { get; set; }

        public bool IsFollowerOnly { get; set; }

        public bool IsSubscriberOnly { get; set; }

        public bool IsSubscriberBiasEnabled { get; set; }

        public double SubscriberBiasFactor { get; set; }

        public bool IsFollowerBiasEnabled { get; set; }

        public double FollowerBiasFactor { get; set; }

        public bool IsMultipleWinsAllowed { get; set; }

        public int GiveawaysBeforeWinAgain { get; set; }

        public bool IsLinearBias { get; set; }

        public bool IsCascadingBias { get; set; }

        public int? Messages { get; set; }

        public int? MessageIntervalInSeconds { get; set; }

        [Required]
        [StringLength(128)]
        public string Discriminator { get; set; }

        public int? channel_ChannelId { get; set; }

        public int? Region_GiveawayId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Channel> Channels { get; set; }

        public virtual Channel Channel { get; set; }

        public virtual Channel Channel1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Giveaway> Giveaways1 { get; set; }

        public virtual Giveaway Giveaway1 { get; set; }
    }
}

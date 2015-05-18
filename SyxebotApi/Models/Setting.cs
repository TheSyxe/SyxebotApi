namespace SyxebotApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Setting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ChannelID { get; set; }

        public bool IsCurrencyGenerationEnabled { get; set; }

        [Required]
        [StringLength(25)]
        public string CurrencyName { get; set; }

        public int OnlineCurrencyGenerationInterval { get; set; }

        public int OfflineCurrencyGenerationInterval { get; set; }

        public int HostCurrencyGenerationInterval { get; set; }

        public double FollowerGenerationModifier { get; set; }

        public double SubscriberGenerationModifier { get; set; }

        public virtual Channel Channel { get; set; }
    }
}

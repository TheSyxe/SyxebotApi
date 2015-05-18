namespace SyxebotApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Command
    {
        public int CommandId { get; set; }

        public string Trigger { get; set; }

        public string Response { get; set; }

        public int CooldownLengthInSeconds { get; set; }

        public int ChannelId { get; set; }

        public virtual Channel Channel { get; set; }
    }
}

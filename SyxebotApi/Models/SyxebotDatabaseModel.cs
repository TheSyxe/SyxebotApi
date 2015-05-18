namespace SyxebotApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SyxebotDatabaseModel : DbContext
    {
        public SyxebotDatabaseModel()
            : base("name=SyxebotDbModel")
        {
        }

        public virtual DbSet<Badge> Badges { get; set; }
        public virtual DbSet<Bot> Bots { get; set; }
        public virtual DbSet<ChannelDetail> ChannelDetails { get; set; }
        public virtual DbSet<Channel> Channels { get; set; }
        public virtual DbSet<ChatterDetail> ChatterDetails { get; set; }
        public virtual DbSet<Chatter> Chatters { get; set; }
        public virtual DbSet<Command> Commands { get; set; }
        public virtual DbSet<Emoticon> Emoticons { get; set; }
        public virtual DbSet<Follow> Follows { get; set; }
        public virtual DbSet<Giveaway> Giveaways { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Stream> Streams { get; set; }
        public virtual DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChannelDetail>()
                .HasMany(e => e.Badges)
                .WithOptional(e => e.ChannelDetail)
                .HasForeignKey(e => e.ChannelDetails_ChannelId);

            modelBuilder.Entity<ChannelDetail>()
                .HasMany(e => e.Emoticons)
                .WithOptional(e => e.ChannelDetail)
                .HasForeignKey(e => e.ChannelDetails_ChannelId);

            modelBuilder.Entity<ChannelDetail>()
                .HasMany(e => e.Follows)
                .WithOptional(e => e.ChannelDetail)
                .HasForeignKey(e => e.ChannelDetails_ChannelId);

            modelBuilder.Entity<Channel>()
                .HasOptional(e => e.Badge)
                .WithRequired(e => e.Channel);

            modelBuilder.Entity<Channel>()
                .HasOptional(e => e.ChannelDetail)
                .WithRequired(e => e.Channel);

            modelBuilder.Entity<Channel>()
                .HasOptional(e => e.Emoticon)
                .WithRequired(e => e.Channel);

            modelBuilder.Entity<Channel>()
                .HasOptional(e => e.Follow)
                .WithRequired(e => e.Channel);

            modelBuilder.Entity<Channel>()
                .HasMany(e => e.Giveaways)
                .WithOptional(e => e.Channel)
                .HasForeignKey(e => e.channel_ChannelId);

            modelBuilder.Entity<Channel>()
                .HasMany(e => e.Giveaways1)
                .WithRequired(e => e.Channel1)
                .HasForeignKey(e => e.ChannelId);

            modelBuilder.Entity<Channel>()
                .HasOptional(e => e.Setting)
                .WithRequired(e => e.Channel);

            modelBuilder.Entity<Channel>()
                .HasOptional(e => e.Stream)
                .WithRequired(e => e.Channel);

            modelBuilder.Entity<Chatter>()
                .HasOptional(e => e.ChatterDetail)
                .WithRequired(e => e.Chatter);

            modelBuilder.Entity<Giveaway>()
                .HasMany(e => e.Channels)
                .WithOptional(e => e.Giveaway)
                .HasForeignKey(e => e.GiveawaySettings_GiveawayId);

            modelBuilder.Entity<Giveaway>()
                .HasMany(e => e.Giveaways1)
                .WithOptional(e => e.Giveaway1)
                .HasForeignKey(e => e.Region_GiveawayId);

            modelBuilder.Entity<Stream>()
                .HasMany(e => e.ChannelDetails)
                .WithRequired(e => e.Stream)
                .HasForeignKey(e => e.StreamId);
        }
    }
}

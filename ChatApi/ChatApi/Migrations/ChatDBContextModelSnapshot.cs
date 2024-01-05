﻿// <auto-generated />
using System;
using ChatApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChatApi.Migrations
{
    [DbContext(typeof(ChatDBContext))]
    partial class ChatDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChatApi.Data.Chat", b =>
                {
                    b.Property<Guid>("chatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("chatName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("chatId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("ChatApi.Data.Message", b =>
                {
                    b.Property<Guid>("messageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("chatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("receivedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("sentDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("messageId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ChatApi.Data.User", b =>
                {
                    b.Property<Guid>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ChatApi.Data.UserChat", b =>
                {
                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<Guid>("chatId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.HasKey("userId", "chatId");

                    b.HasIndex("chatId");

                    b.ToTable("UsersChats");
                });

            modelBuilder.Entity("ChatApi.Data.UserChat", b =>
                {
                    b.HasOne("ChatApi.Data.Chat", "chat")
                        .WithMany()
                        .HasForeignKey("chatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChatApi.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("chat");
                });
#pragma warning restore 612, 618
        }
    }
}

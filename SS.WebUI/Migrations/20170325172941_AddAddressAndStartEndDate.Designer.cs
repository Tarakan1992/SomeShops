using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SS.Data;

namespace SS.WebUI.Migrations
{
    [DbContext(typeof(SomeShopsContext))]
    [Migration("20170325172941_AddAddressAndStartEndDate")]
    partial class AddAddressAndStartEndDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SS.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("ShopId");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SS.Entities.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("SS.Entities.Product", b =>
                {
                    b.HasOne("SS.Entities.Shop", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}

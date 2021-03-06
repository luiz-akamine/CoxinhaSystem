using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using CoxinhaSystem.Infra.Data.Context;

namespace CoxinhaSystem.Infra.Migrations
{
    [DbContext(typeof(CoxinhaContext))]
    [Migration("20160907001408_NOTNULL_Address.CEP")]
    partial class NOTNULL_AddressCEP
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoxinhaSystem.Domain.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressName")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnType", "VARCHAR(300)");

                    b.Property<int?>("CEP");

                    b.Property<string>("City")
                        .HasAnnotation("Relational:ColumnType", "VARCHAR(100)");

                    b.Property<string>("Complement")
                        .HasAnnotation("Relational:ColumnType", "VARCHAR(100)");

                    b.Property<int>("CustomerId");

                    b.Property<string>("District")
                        .HasAnnotation("Relational:ColumnType", "VARCHAR(100)");

                    b.Property<bool>("MainAddress");

                    b.Property<int>("Number");

                    b.Property<string>("State")
                        .HasAnnotation("Relational:ColumnType", "VARCHAR(5)");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("CoxinhaSystem.Domain.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("Relational:ColumnType", "VARCHAR(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnType", "VARCHAR(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();
                });

            modelBuilder.Entity("CoxinhaSystem.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("DeliveryDate");

                    b.Property<string>("Description")
                        .HasAnnotation("Relational:ColumnType", "VARCHAR(200)");

                    b.Property<double>("Discount");

                    b.Property<DateTime>("DtCreation")
                        .HasAnnotation("Relational:ColumnType", "DATETIME");

                    b.Property<bool>("Paid");

                    b.Property<bool?>("RetrieveInLocal");

                    b.Property<int>("Status");

                    b.Property<double>("Total");

                    b.Property<double>("TotalWithDiscount");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("CoxinhaSystem.Domain.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OrderId");

                    b.Property<double>("Price");

                    b.Property<int>("ProductId");

                    b.Property<double>("Qty");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("CoxinhaSystem.Domain.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<string>("Description")
                        .HasAnnotation("Relational:ColumnType", "VARCHAR(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnType", "VARCHAR(50)");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("CoxinhaSystem.Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("Relational:ColumnType", "VARCHAR(200)");

                    b.Property<double>("IncQty");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnType", "VARCHAR(100)");

                    b.Property<double>("Price");

                    b.Property<int>("ProductType");

                    b.Property<int>("Unit");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();
                });

            modelBuilder.Entity("CoxinhaSystem.Domain.Models.Address", b =>
                {
                    b.HasOne("CoxinhaSystem.Domain.Models.Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("CoxinhaSystem.Domain.Models.Order", b =>
                {
                    b.HasOne("CoxinhaSystem.Domain.Models.Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("CoxinhaSystem.Domain.Models.OrderItem", b =>
                {
                    b.HasOne("CoxinhaSystem.Domain.Models.Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("CoxinhaSystem.Domain.Models.Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("CoxinhaSystem.Domain.Models.Phone", b =>
                {
                    b.HasOne("CoxinhaSystem.Domain.Models.Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });
        }
    }
}

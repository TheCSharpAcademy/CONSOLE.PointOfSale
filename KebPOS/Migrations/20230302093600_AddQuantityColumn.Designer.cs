﻿// <auto-generated />
using System;
using KebPOS.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KebPOS.Migrations
{
    [DbContext(typeof(KebabContext))]
    [Migration("20230302093600_AddQuantityColumn")]
    partial class AddQuantityColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("KebPOS.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("KebPOS.Models.OrderProduct", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("KebPOS.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "    The other name of this yummy Kebab is “good for you Kebab” the Kebab is made up of paneer, raisins, oats and creamy yogurt. \n    This Kebab is a total combination of health and taste. The addition of extraordinary paneer simply enhances the taste of the Kebab. \n    You can add other veggies also.",
                            Name = "Yogurt Kebab",
                            Price = 3.49m
                        },
                        new
                        {
                            Id = 2,
                            Description = "    This Kebab is one among all the most popular and delicious Kebabs. \n    The special part of this Kebab is that they are grilled on the skewer. \n    Here the word shish means skewer. And the word Kebab stands for meat. \n    This dish comes under the category of side dish. \n    This dish is very famous in Turkey. \n    Just imagine the taste of Turkish dish with an Indian tadka. \n    These are most popular of all Kebabs. \n    Steamed vegetables and salads are served along with these Kebabs.",
                            Name = "Shish Kebab",
                            Price = 4.19m
                        },
                        new
                        {
                            Id = 3,
                            Description = "Another name of this Kebab is rotating Kebab. \nAnd this wonderful name is given to this Kebab because it is made on a vertical rotating spit. \nThis comes under the category of popular fast food loved by all. \nThe Kebab is made of lamb’s meat. \nThe special taste of Kebab is due to its cooking style. \nThe Kebabs are cooked slowly so that the meat juice could spread its flavor.",
                            Name = "Doner Kebab",
                            Price = 3.39m
                        },
                        new
                        {
                            Id = 4,
                            Description = "    Kathi Kebabs are very famous as they are made using tandoor. \n    This is the most popular Indian dish made using tandoor. \n    We all know the taste of tandoori chicken and the reason behind its scrumptious taste is tandoor. \n    This Kebab is a very wonderful snack to have. \n    The best way of having these yummy Kathi Kebabs is by rolling them in Kathi roll. \n    You can add lots and lots of chutney on the roll so that the taste of Kebabs enhances your mood also.",
                            Name = "Kathi Kebab",
                            Price = 3.37m
                        },
                        new
                        {
                            Id = 5,
                            Description = "    Chapli Kebabs are a very famous dish of Pakistani cuisine. \n    This minced meat has a special taste. \n    The Kebab is made using beef. \n    This Pakistani dish with an Indian special tadka is all you need to have.",
                            Name = "Chapli Kebab",
                            Price = 4.33m
                        },
                        new
                        {
                            Id = 6,
                            Description = "    Burrah Kebabs are also known as barrah Kebab. \n    The Kebab is made up of beef and lots and lots of spices. \n    This Kebab is very famous Kebab of Mughlai cuisine. \n    This dish comes under the heavy meal category. \n    It majorly includes larger pieces of meat. \n    If you are also among the Mughlai cuisine lovers, then you can’t afford to miss such an amazing dish.",
                            Name = "Burrah Kebab",
                            Price = 4.36m
                        },
                        new
                        {
                            Id = 7,
                            Description = "    This is an Irani dish with an Indian tadka. \n    This is, in fact, national food of Iran. \n    The dish is basic but yummy in taste. \n    They are always served with buttered rice. \n    Most of the people prefer doogh which is a yogurt drink with this Kebab. \n    The dish comes under the category of the side dish, but the taste of the dish is very special.",
                            Name = "Chelow Kebab",
                            Price = 4.29m
                        },
                        new
                        {
                            Id = 8,
                            Description = "    The name of the Kebab is testi Kebab, and here the word testi means jug. \n    Yes, the Kebab is served in a pot. \n    You can use dough or foil to cover the pot. \n    The pot is broken while eating. \n    We all know how special the taste of “matke ka pani” is. \n    Similarly, the taste of matka Kebab is very special.",
                            Name = "Testi Kebab",
                            Price = 3.69m
                        },
                        new
                        {
                            Id = 9,
                            Description = "    Dill salmon Kebab is very special Kebab for all seafood lovers and especially for fish lovers. \n    The dish is very yummy.",
                            Name = "Dill Salmon Kebab",
                            Price = 3.99m
                        },
                        new
                        {
                            Id = 10,
                            Description = "    Lamb Kebabs are very easy to make. \n    What all you need to do is marinate the mince meat with all the spices. \n    You can add egg also just to enhance the taste of Kebab.",
                            Name = "Lamb Kebab",
                            Price = 3.79m
                        },
                        new
                        {
                            Id = 11,
                            Description = "A freshly pulled shot of espresso layered with steamed whole milk and thick rich foam to offer a luxurious velvety texture and complex aroma.",
                            Name = "Cappuccino",
                            Price = 1.49m
                        },
                        new
                        {
                            Id = 12,
                            Description = "Red Bull is a utility drink to be taken against mental or physical weariness or exhaustion.",
                            Name = "Red Bull",
                            Price = 1.87m
                        },
                        new
                        {
                            Id = 13,
                            Description = "Coca-Cola is a carbonated, sweetened soft drink and is the world's best-selling drink. A popular nickname for Coca-Cola is Coke.",
                            Name = "Coca Cola",
                            Price = 0.93m
                        },
                        new
                        {
                            Id = 14,
                            Description = "Crisp, refreshing and clean-tasting, Sprite is a lemon and lime-flavoured soft drink.",
                            Name = "Sprite",
                            Price = 1.99m
                        },
                        new
                        {
                            Id = 15,
                            Description = "BonAqua is a high-quality drinking water.",
                            Name = "Bonaqua Sparkling",
                            Price = 1.24m
                        });
                });

            modelBuilder.Entity("KebPOS.Models.OrderProduct", b =>
                {
                    b.HasOne("KebPOS.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KebPOS.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("KebPOS.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("KebPOS.Models.Product", b =>
                {
                    b.Navigation("OrderProducts");
                });
#pragma warning restore 612, 618
        }
    }
}

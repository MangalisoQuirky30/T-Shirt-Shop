
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
/*
using ContosoPets.Api.Models; */
using TShirtAppAPI.Models;

namespace ContosoPets.Api.Data
{
    public static class SeedData
    {
        public static void Initialize(ContosoPetsContext context)
        {
            if (!context.TShirtOrders.Any())
            {
                context.TShirtOrders.AddRange(
                    new TShirtOrder
                    {
                        Name = "Squeaky Bone",
                        Gender = "Male",
                        Color = "red",
                        Size = "M",
                        ImgSrc = "red.png",
                    },
                    new TShirtOrder
                    {
                        Name = "Knotted Rope",
                        Gender = "Female",
                        Color = "green",
                        Size = "S",
                        ImgSrc = "green.png",
                    
                    }
                );

                context.SaveChanges();
            }
        }
    }
}

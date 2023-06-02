using System;
using System.Linq;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new BlogDataContext();

            // context.Users.Add(new User {
            //     Bio = "Backend Developer",
            //     Email = "lucas@lopes.io",
            //     Image = "https://lopes.io",
            //     Name = "Lucas Lopes",
            //     PasswordHash = "1234",
            //     Slug = "lucas-lopes"
            // });
            // context.SaveChanges();

            var user = context.Users.FirstOrDefault();

            var post = new Post {
                Author = user,
                Body = "Meu Artigo",
                Category = new Category{
                    Name = "Backend",
                    Slug = "backend"
                },
                CreateDate = DateTime.Now,
                Slug = "meu-artigo",
                Summary = "Neste artigo vamos conferir...",
                Title = "Meu Artigo"
            };
            context.Posts.Add(post);
            context.SaveChanges();
        }
    }
}
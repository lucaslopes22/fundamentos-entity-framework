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
            var post = context
                .Posts
                //.AsNoTracking()
                .Include(p => p.Author)
                .Include(p => p.Category)
                .OrderByDescending(x => x.LastUpdateDate)
                .FirstOrDefault();
            
            post.Author.Name = "Teste";
            context.Posts.Update(post);
            context.SaveChanges();

            /*
            var posts = context
                .Posts
                .AsNoTracking()
                .Include(p => p.Author)
                .Include(p => p.Category)
                    //.ThenInclude(p => p.) // SUBSELECT
                .OrderByDescending(x => x.LastUpdateDate)
                .ToList();

            foreach(var post in posts)
                Console.WriteLine($"{post.Title} escrito por {post.Author?.Name} em {post.Category?.Name}");

            var user = new User{
                Name = "Lucas Lopes",
                Slug = "lucaslopes",
                Email = "lucas@lopes.io",
                Bio = "Fullstack",
                Image = "https://lucas.io",
                PasswordHash = "123098457"
            };

            var category = new Category {
                Name = "Backend", Slug = "backend"
            };

            var post = new Post{
                Author = user,
                Category = category,
                Body = "<p>Hello World</post>",
                Slug = "comecando-com-ef-core",
                Summary = "Neste artigo vamos aprender EF Core",
                Title = "Começando com EF Core",
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };

            context.Posts.Add(post);
            context.SaveChanges();
            */

            //using(var context = new BlogDataContext()){
                // INSERT
                //var tag = new Tag{Name = "ASP.NET", Slug = "aspnet"};
                //context.Tags.Add(tag);
                //context.SaveChanges();

                // UPDATE
                //var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
                //tag.Name = ".NET";
                //tag.Slug = "dotnet";
                //context.Update(tag);
                //context.SaveChanges();

                // DELETE
                //var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
                //context.Remove(tag);
                //context.SaveChanges();

                //SELECT
                // Não executou no banco => var tags = context.Tags;
                // Executou no banco quando adicionado .ToList()
                //var tags = context
                //    .Tags
                //    .AsNoTracking()
                //    .ToList();

                //foreach(var tag in tags){
                //    System.Console.WriteLine(tag.Name);
                //}


                //var tag = context
                //    .Tags
                //    .AsNoTracking()
                //    .FirstOrDefault(x => x.Id == 5);
                //Console.WriteLine(tag?.Name);

                
            //}
        }
    }
}

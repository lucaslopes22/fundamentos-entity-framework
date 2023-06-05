using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var posts = context.PostWithTagsCounts.ToList();

            foreach(var item in posts){
                
            }

            Console.WriteLine("Teste");
        }
    }
}
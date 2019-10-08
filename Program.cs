using System;
using System.Linq;

namespace EFGetStarted
{
    class Program
    {
        static void Main()
        {
            using (var db = new BloggingContext())
            {
                // Create
                Console.WriteLine("Inserting a new blog");
                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");
                var blog = db.Blogs
                    .OrderBy(b => b.BlogId)
                    .First();

                // Update
                Console.WriteLine("Updating the blog and adding a post");
                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(
                    new Post
                    {
                        Title = "Hello World",
                        Content = "I wrote an app using EF Core!"
                    });
                db.SaveChanges();

                Console.WriteLine("Updating the blog and adding a post");
                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(
                    new Post
                    {
                        Title = "Nowy Wpis",
                        Content = "Taki mały wpis blogowy aby sprawdzić bazę danych."
                    });
                db.SaveChanges();
                Console.WriteLine("Wprowadź nowy tytuł wpisu:");
                string a = Console.ReadLine();
                Console.WriteLine("Wprowadź nowy wpis");
                string b = Console.ReadLine();
                blog.Posts.Add(
                new Post
                {
                    PostId=3,
                    Title = a,
                    Content = b
                });
                db.SaveChanges();

                var body = db.Posts
                    .Single(b => b.PostId == 3).Content;
                string body_string = Convert.ToString(body);
                Console.WriteLine(body_string);

                // Delete
                // Console.WriteLine("Delete the blog");
                //  db.Remove(blog);
                //  db.SaveChanges();
            }
        }
    }
}

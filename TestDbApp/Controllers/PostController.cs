using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TestDbApp.Conext;
using TestDbApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestDbApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        readonly MyDbContext myDbContext;
        public PostController(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }

        // GET: api/<PostController>
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            Random random = new Random();
            /*for (int i = 0; i < 4; i++)
            {
                Post post = new Post();
                post.Name = (myDbContext.Posts.ToList().Count+1).ToString();
                post.Description = i + "abc";
                myDbContext.Posts.Add(post);
                myDbContext.SaveChanges();
            }*/
            return myDbContext.Posts.ToList();
        }

        // GET api/<PostController>/5
        [HttpGet()]
        [Route("{id}")]
        public Post Get(int id)
        {
            Post post = myDbContext.Posts.FirstOrDefault(t => t.Id == id);
            return post;
        }

        // POST api/<PostController>
        [HttpGet]
        [Route("clear")]
        public void Post()
        {
           
            myDbContext.SaveChanges();
        }

        // PUT api/<PostController>/5
        [HttpGet()]
        [Route("update/{id}")]
        public Post Put(int id)
        {
            Post post=myDbContext.Posts.FirstOrDefault(t => t.Id == id);
            post.Description = "dsfsd";
            myDbContext.Posts.Update(post);
            myDbContext.SaveChanges();
            return post;
        }

        // DELETE api/<PostController>/5
        [HttpGet()]
        [Route("delete/{id}")]
        public string Delete(int id)
        {
           Post post = myDbContext.Posts.FirstOrDefault(t => t.Id == id);
           myDbContext.Posts.Remove(post);
           myDbContext.SaveChangesAsync();
           return "Xóa thành công";
        }
    }
}

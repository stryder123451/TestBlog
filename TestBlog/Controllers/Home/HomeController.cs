﻿using TestBlog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBlog.Data;
using TestBlog.Data.Repository;

namespace TestBlog.Controllers.Home
{
    public class HomeController : Controller
    {
        private IRepository _repository;
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var posts = _repository.GetAllPosts();
            return View(posts);
        }
        public IActionResult Post(int id)
        {
            var post = _repository.GetPost(id);
            return View(post);
        }
        [HttpGet]
        public IActionResult Edit(int ?id)
        {
            if (id == null)
            {
                return View(new Post());
            }
            else
            {
                var post = _repository.GetPost((int)id);
                return View(post);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            if (post.Id > 0)
            {
                _repository.UpdatePost(post);
            }
            else
            {
                _repository.AddPost(post);
            }


           
            if (await _repository.SaveChangesAsync())
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(post);
            }
            
        }

        public async Task<IActionResult> Remove(int id)
        {
            _repository.RemovePost(id);
            await _repository.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

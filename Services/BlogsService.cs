using System;
using System.Collections.Generic;
using bloggr_CS.Models;
using bloggr_CS.Repositories;

namespace bloggr_CS.Services
{
    public class BlogsService
    {
        public readonly BlogsRepository _repo;

        public BlogsService(BlogsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Blog> GetAll()
        {
            return _repo.GetAll();
        }

        internal Blog GetById(int id)
        {
            Blog data = _repo.GetById(id);
            if (data == null)
            {
                throw new Exception("Invalid Id");
            }
            return data;
        }

        internal Blog Create(Blog newBlog)
        {
            return _repo.Create(newBlog);
        }

        internal Blog Edit(Blog updated)
        {

            Blog data = GetById(updated.Id);

            data.Title = updated.Title != null ? updated.Title : data.Title;
            data.Body = updated.Body != null ? updated.Body : data.Body;
            data.ImgUrl = updated.ImgUrl != null ? updated.ImgUrl : data.ImgUrl;
            data.Published = updated.Published != null ? updated.Published : data.Published;




            return _repo.Edit(data);
        }
        internal string Delete(int id, string userId)
        {
            GetById(id);
            _repo.Delete(id, userId);
            return "delorted";
        }

        internal IEnumerable<Blog> GetAdmissionsByProfileId(string id)
        {
            return _repo.GetByProfileId(id);
        }
    }
}
using System.Collections.Generic;
using System.Data;
using bloggr_CS.Models;
using Dapper;

namespace bloggr_CS.Repositories
{
    public class BlogsRepository
    {
        public readonly IDbConnection _db;

        public BlogsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Blog> GetAll()
        {
            string sql = "SELECT * FROM blogs;";
            return _db.Query<Blog>(sql);
        }

        internal Blog GetById(int Id)
        {
            string sql = "SELECT * FROM blogs WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Blog>(sql, new { Id });
        }

        internal Blog Create(Blog newBlog)
        {
            string sql = @"
            INSERT INTO blogs
            (title, body, imgurl, published, creatorId)
            VALUES
            (@Title, @Body, @ImgUrl, @Published, @CreatorId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newBlog);
            newBlog.Id = id;
            return newBlog;
        }

        internal Blog Edit(Blog updatedBlog)
        {
            string sql = @"
            UPDATE blogs
            SET
                title = @Title,
                body = @Body,
                imgUrl = @ImgUrl,
                published = @Published,
                creatorId = @CreatorId
            WHERE id = @Id;
            SELECT * FROM blogs WHERE id = @Id;";
            Blog returnBlog = _db.QueryFirstOrDefault<Blog>(sql, updatedBlog);
            return returnBlog;
        }

        internal void Delete(int id, string creatorId)
        {
            string sql = "DELETE FROM blogs WHERE id = @Id AND creatorId = @creatorId;";
            _db.Execute(sql, new { id, creatorId });
        }

        internal IEnumerable<Blog> GetByProfileId(string id)
        {
            string sql = @"SELECT * FROM blogs WHERE creatorId = @id";
            return _db.Query<Blog>(sql, new { id });
        }
    }
}
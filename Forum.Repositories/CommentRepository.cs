using Forum.Contracts;
using Forum.Data;
using Forum.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddCommentAsync(Comment entity)
        {
            if (entity != null)
            {
                await _context.Comments.AddAsync(entity);
            }
        }

        public void DeleteComment(Comment entity)
        {
            if (entity != null)
            {
                _context.Comments.Remove(entity);
            }
        }

        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<List<Comment>> GetAllCommentsAsync(Expression<Func<Comment, bool>> filter)
        {
            return await _context.Comments.Where(filter).ToListAsync();
        }

        public async Task<Comment> GetSingleCommentAsync(Expression<Func<Comment, bool>> filter)
        {
            return await _context.Comments.FirstOrDefaultAsync(filter);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCommentAsync(Comment entity)
        {
            if (entity != null)
            {
                var commentToUpdate = await _context.Comments.FirstOrDefaultAsync(x => x.Id == entity.Id);

                if (commentToUpdate != null)
                {
                    commentToUpdate.Content = entity.Content;
                    commentToUpdate.CreationDate = entity.CreationDate;
                    //საჭიროა ეგ თუ არა?
                    commentToUpdate.TopicId = entity.TopicId;
                    commentToUpdate.UserId = entity.UserId;
                    _context.Comments.Update(commentToUpdate);
                }
            }
        }
    }
}

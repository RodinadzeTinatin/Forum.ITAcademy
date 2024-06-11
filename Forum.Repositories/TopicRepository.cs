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
    public class TopicRepository : ITopicRepository
    {
        private readonly ApplicationDbContext _context;

        public TopicRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddTopicAsync(Topic entity)
        {
            if (entity != null)
            {
                await _context.Topics.AddAsync(entity);
            }
        }

        public void DeleteTopic(Topic entity)
        {
            if (entity != null)
            {
                _context.Topics.Remove(entity);
            }
        }

        public async Task<List<Topic>> GetAllTopicsAsync()
        {
            return await _context.Topics.Include(topic => topic.Comments).ToListAsync();
        }

        public async Task<List<Topic>> GetAllTopicsAsync(Expression<Func<Topic, bool>> filter)
        {
            return await _context.Topics.Include(t => t.Comments).Where(filter).ToListAsync();
        }

        public async Task<Topic> GetSingleTopicAsync(Expression<Func<Topic, bool>> filter)
        {
            return await _context.Topics.Include(t => t.Comments).FirstOrDefaultAsync(filter);

        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTopicAsync(Topic entity)
        {
            if (entity != null)
            {
                var topicToUpdate = await _context.Topics.FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (topicToUpdate != null)
                {
                    topicToUpdate.Title = entity.Title;
                    topicToUpdate.State = entity.State;
                    topicToUpdate.Status = entity.Status;
                    topicToUpdate.CreationDate = entity.CreationDate;
                    topicToUpdate.UserId = entity.UserId;

                    _context.Topics.Update(topicToUpdate);
                }
            }
        }
    }
}

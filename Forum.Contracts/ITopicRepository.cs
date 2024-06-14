using Forum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Contracts
{
    public interface ITopicRepository : ISavable
    {
        Task<List<Topic>> GetAllTopicsAsync();
        Task<List<Topic>> GetAllTopicsAsync(Expression<Func<Topic, bool>> filter);

        Task<Topic> GetSingleTopicAsync(Expression<Func<Topic, bool>> filter);
        Task AddTopicAsync(Topic entity);
        Task UpdateTopicAsync(Topic entity);
        void DeleteTopic(Topic entity);

        Task<List<Topic>> GetTopicsToUpdateAsync();
    }
}

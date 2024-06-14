using Forum.Contracts;
using Forum.Entities;
using Forum.Service.Exceptions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Jobs
{
    public class TopicStatusService : BackgroundService
    {
        private readonly ITopicRepository _topicRepository;
        private readonly TimeSpan _checkInterval = TimeSpan.FromDays(1);

        public TopicStatusService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(_checkInterval, stoppingToken);

                try
                {
                    var topicsToUpdate = await _topicRepository.GetTopicsToUpdateAsync();

                    if (topicsToUpdate != null)
                    {
                        foreach (var topic in topicsToUpdate)
                        {
                            topic.Status = Status.Inactive;
                            await _topicRepository.Save();
                        }
                    }
                    else
                    {
                        throw new NoTopicsToUpdate();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}

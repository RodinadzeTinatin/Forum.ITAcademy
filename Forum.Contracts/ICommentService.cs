using Forum.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Contracts
{
    public interface ICommentService
    {
        Task<List<CommentForGettingDto>> GetCommentsOfUserAsync(string userId);
        Task<CommentForGettingDto> GetSingleCommentByUserId(int commentId, string userId);
        Task DeleteCommentAsync(int id);
        Task AddCommentAsync(CommentForCreatingDto commentForCreatingDto);
        Task UpdateCommentAsync(int commentcId, JsonPatchDocument<CommentForUpdatingDto> patchDocument);
    }
}

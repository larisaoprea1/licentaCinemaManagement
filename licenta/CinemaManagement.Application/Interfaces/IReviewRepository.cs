using CinemaManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagement.Application.Interfaces
{
    public interface IReviewRepository
    {
        Task<int> CountAsync(Movie movie);
        Task<int> CountAsyncUser(Guid userId);
        Task<Review> CreateAsync(Review review);
        Task DeleteAsync(Review review);
        Task<IEnumerable<Review>> ReturnAllAsync();
        Task<Review> ReturnByIdAsync(Guid id);
        Task<IEnumerable<Review>> ReturnMovieReviews(Movie movie, int? page, int pageSize);
        Task<IEnumerable<Review>> ReturnUserReviews(Guid userId, int? page, int pageSize);
        Task SaveAsync();
        Task UpdateAsync(Review review);
    }
}

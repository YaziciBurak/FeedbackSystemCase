using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IFeedbackRepository : IAsyncRepository<Feedback, int>, IRepository<Feedback,int>
{
}

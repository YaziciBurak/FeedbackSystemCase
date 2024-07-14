using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concretes;

namespace DataAccess.Repositories;

public class FeedbackRepository : EfRepositoryBase<Feedback, int, BaseDbContext>, IFeedbackRepository 
{
    public FeedbackRepository(BaseDbContext context) : base(context)
    {
    }
}

using Business.Profiles.Feedbacks;
using Business.Requests.Feedbacks;
using Business.Responses.Feedbacks;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IFeedbackService
{
    Task<IDataResult<List<GetAllFeedbackResponse>>> GetAllAsync();
    Task<IDataResult<GetByIdFeedbackResponse>> GetById(int id);
    Task<IDataResult<CreateFeedbackResponse>> AddAsync(CreateFeedbackRequest request);
    Task<IDataResult<UpdateFeedbackResponse>> UpdateAsync(UpdateFeedbackRequest request);
    Task<IResult> DeleteAsync(DeleteFeedbackRequest request);
}

using AutoMapper;
using Business.Abstracts;
using Business.Profiles.Feedbacks;
using Business.Requests.Feedbacks;
using Business.Responses.Feedbacks;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class FeedbackManager : IFeedbackService
{
    private readonly IFeedbackRepository _repository;
    private readonly IMapper _mapper;
    private readonly FeedbackBusinessRules _rules;

    public FeedbackManager(IFeedbackRepository repository, IMapper mapper, FeedbackBusinessRules rules)
    {
        _repository = repository;
        _mapper = mapper;
        _rules = rules;
    }

    public async Task<IDataResult<CreateFeedbackResponse>> AddAsync(CreateFeedbackRequest request)
    {
        await _rules.CheckIfUserIdExists(request.UserId);
        Feedback feedback = _mapper.Map<Feedback>(request);
        await _repository.AddAsync(feedback);
        CreateFeedbackResponse response = _mapper.Map<CreateFeedbackResponse>(feedback);
        return new SuccessDataResult<CreateFeedbackResponse>(response);
    }

    public async Task<IResult> DeleteAsync(DeleteFeedbackRequest request)
    {
        Feedback feedback = await _repository.GetAsync(x => x.Id == request.Id);
        await _repository.DeleteAsync(feedback);
        return new SuccessDataResult<DeleteFeedbackResponse>();
    }

    public async Task<IDataResult<List<GetAllFeedbackResponse>>> GetAllAsync()
    {
        List<Feedback> feedbacks = await _repository.GetAllAsync();
        List<GetAllFeedbackResponse> responses = _mapper.Map<List<GetAllFeedbackResponse>>(feedbacks);
        return new SuccessDataResult<List<GetAllFeedbackResponse>>(responses);
    }

    public async Task<IDataResult<GetByIdFeedbackResponse>> GetById(int id)
    {
        Feedback feedback = await _repository.GetAsync(x => x.Id == id);
        GetByIdFeedbackResponse response = _mapper.Map<GetByIdFeedbackResponse>(feedback);
        return new SuccessDataResult<GetByIdFeedbackResponse>(response);
    }

    public async Task<IDataResult<UpdateFeedbackResponse>> UpdateAsync(UpdateFeedbackRequest request)
    {
        Feedback feedback = await _repository.GetAsync(x => x.Id == request.Id);
        _mapper.Map(request, feedback);
        await _repository.UpdateAsync(feedback);
        UpdateFeedbackResponse response = _mapper.Map<UpdateFeedbackResponse>(feedback);
        return new SuccessDataResult<UpdateFeedbackResponse>(response);
    }
}

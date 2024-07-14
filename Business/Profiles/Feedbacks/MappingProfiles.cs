using AutoMapper;
using Business.Requests.Feedbacks;
using Business.Responses.Feedbacks;
using Entities.Concretes;

namespace Business.Profiles.Feedbacks;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Feedback, CreateFeedbackRequest>().ReverseMap();
        CreateMap<Feedback, UpdateFeedbackRequest>().ReverseMap();
        CreateMap<Feedback, DeleteFeedbackRequest>().ReverseMap();

        CreateMap<Feedback, CreateFeedbackResponse>().ReverseMap();
        CreateMap<Feedback, DeleteFeedbackResponse>().ReverseMap();
        CreateMap<Feedback, UpdateFeedbackResponse>().ReverseMap();
        CreateMap<Feedback, GetAllFeedbackResponse>().ReverseMap();
        CreateMap<Feedback, GetByIdFeedbackResponse>().ReverseMap();
       
    }
}

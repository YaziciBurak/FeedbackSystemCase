using Business.Abstracts;
using Business.Profiles.Feedbacks;
using Business.Requests.Feedbacks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : BaseController
    {
        private readonly IFeedbackService _service;

        public FeedbackController(IFeedbackService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleDataResult(await _service.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return HandleDataResult(await _service.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateFeedbackRequest request)
        {
            return HandleDataResult(await _service.AddAsync(request));
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteFeedbackRequest request)
        {
            return HandleResult(await _service.DeleteAsync(request));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateFeedbackRequest request)
        {
            return HandleDataResult(await _service.UpdateAsync(request));
        }
    }
}

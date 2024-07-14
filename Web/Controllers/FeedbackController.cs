using AutoMapper;
using Business.Abstracts;
using Business.Models;
using Business.Requests.Feedbacks;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication.ViewModels;

namespace Web.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IMapper _mapper;

        public FeedbackController(IFeedbackService feedbackService, IMapper mapper)
        {
            _feedbackService = feedbackService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _feedbackService.GetAllAsync();
            var viewModel = _mapper.Map<List<FeedbackViewModel>>(result.Data);
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeedbackRequest request)
        {
            if (ModelState.IsValid)
            {
                await _feedbackService.AddAsync(request);
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _feedbackService.GetById(id);
            if (result.Success)
            {
                var viewModel = _mapper.Map<FeedbackViewModel>(result.Data);
                return View(viewModel);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FeedbackViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var request = _mapper.Map<UpdateFeedbackRequest>(viewModel);
                await _feedbackService.UpdateAsync(request);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _feedbackService.GetById(id);
            if (result.Success)
            {
                var viewModel = _mapper.Map<FeedbackViewModel>(result.Data);
                return View(viewModel);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(DeleteFeedbackRequest request)
        {
            await _feedbackService.DeleteAsync(request);
            return RedirectToAction(nameof(Index));
        }
    }
}

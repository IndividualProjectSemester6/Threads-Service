using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThreadsService.API.Models;
using ThreadsService.Application.Queries.GetAllThreads;
using ThreadsService.Application.Queries.GetThread;

namespace ThreadsService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreadsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ThreadsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = new GetAllThreadsQuery();
            var result = await _mediator.Send(query);
            List<ThreadViewModel> threads = new List<ThreadViewModel>();
            foreach (var thread in result)
            {
                threads.Add(new ThreadViewModel(thread.Id, thread.TopicName, thread.Content, thread.Author, thread.CreatedAt, thread.LastEdited));
            }

            return Ok(threads);    
        }

        [HttpGet("{threadId}")]
        public async Task<ActionResult> Get(Guid threadId)
        {
            var query = new GetThreadQuery(threadId);
            var result = await _mediator.Send(query);
            if (result != null)
            {
                var thread = new ThreadViewModel(result.Id, result.TopicName, result.Content, result.Author, result.CreatedAt, result.LastEdited);
                return Ok(result);
            }

            return NotFound();
        }
    }
}

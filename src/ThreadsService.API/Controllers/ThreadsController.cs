using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThreadsService.API.Models;
using ThreadsService.Application.Commands.CreateThread;
using ThreadsService.Application.Commands.DeleteThread;
using ThreadsService.Application.Commands.UpdateThread;
using ThreadsService.Application.Notifications.PostCreated;
using ThreadsService.Application.Notifications.ThreadCreated;
using ThreadsService.Application.Queries.GetAllThreads;
using ThreadsService.Application.Queries.GetThread;
using ThreadsService.Domain.Entities;

namespace ThreadsService.API.Controllers;

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
            return Ok(thread);
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateThreadViewModel createThreadViewModel)
    {
        var query = new CreateThreadCommand(createThreadViewModel.Author, createThreadViewModel.TopicName, createThreadViewModel.Content);
        var result = await _mediator.Send(query);

        if (result == null) return BadRequest();

        await _mediator.Publish(new ThreadCreatedNotification()
        {
            Id = result.Id,
            ForumId = Guid.Empty,
            TopicName = result.TopicName,
            Content = result.Content,
            Author = result.Author,
            CreatedAt = result.CreatedAt,
            LastEdited = result.LastEdited
        });

        return Ok(result);
    }

    [HttpPut("{threadId}")]
    public async Task<ActionResult> Update(Guid threadId, UpdateThreadViewModel updateThread)
    {
        var thread = new ThreadDto() {TopicName = updateThread.TopicName, Content = updateThread.Content};
        var query = new UpdateThreadCommand(threadId, thread);
        var result = await _mediator.Send(query);
        if (result == null) return NotFound();

        return Ok(result);
    }

    [HttpDelete("{threadId}")]
    public async Task<ActionResult> Delete(Guid threadId)
    {
        var query = new DeleteThreadCommand(threadId);
        var result = await _mediator.Send(query);
        if (result == null) return BadRequest();

        return Ok();
    }
}
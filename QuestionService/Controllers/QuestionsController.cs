
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionService.Data;
using QuestionService.DTOs;
using QuestionService.Models;


namespace QuestionService.Controllers;


[ApiController]
[Route("questions")] // 👈 Maps this controller to http://localhost:7001/questions
public class QuestionsController(QuestionDbContext db) : ControllerBase
{
    // GET /questions
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Questions controller is working");
    }
    
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Question>> CreateQuestion(CreateQuestionDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var name = User.FindFirstValue("name");

        if (userId is null || name is null)
            return BadRequest("Cannot get user details");

        var question = new Question
        {
            Title = dto.Title,
            Content = dto.Content,
            TagSlugs = dto.Tags,
            AskerId = userId
            //AskerDisplayName = name
        };
        
        db.Questions.Add(question);
        await db.SaveChangesAsync();

        return Created($"/questions/{question.Id}", question);
    }
}



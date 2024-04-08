using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz_project.Server.Data;
using Quiz_project.Server.Models;
using Quiz_project.Shared.ViewModels;
using System.Diagnostics.Eventing.Reader;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace Quiz_project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuizController(ApplicationDbContext context)
        {
            _context = context;
        }

        public string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        [HttpPost("AddNewQuiz")]
        public IActionResult CreateQuiz(QuizViewModel model)
        {
            var newQuiz = new Quiz
            {
                Title = model.Title,
                UserId = GetUserId()
            };
            _context.Quizzes.Add(newQuiz);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("MyQuizList")]
        public IActionResult GetUserQuizList()
        {
            var output = (from q in _context.Quizzes
                          where q.UserId == GetUserId()
                          select new QuizViewModel
                          {
                              Id = q.Id,
                              Title = q.Title

                          }).ToList();
            return Ok(output);
        }

        [HttpPost("AddNewQuestion")]
        public IActionResult CreateQuestion(QuestionViewModel model)
        {
            
            var newQuestion = new Question
            {
                QuestionName = model.QuestionName,
                Option1 = model.Option1,
                Option2 = model.Option2,
                Option3 = model.Option3,
                Option4 = model.Option4,
                ImageUrl = model.ImageUrl,
                VideoUrl = model.VideoUrl,
                CorrectAnswer = model.CorrectAnswer,
                QuizId = model.QuizId
            };
            _context.Questions.Add(newQuestion);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("QuizList")]
        public IActionResult GetAllQuizzes()
        {
            var output = (from q in _context.Quizzes
                          select new QuizViewModel
                          {
                              Id = q.Id,
                              Title = q.Title

                          }).ToList();
            return Ok(output);
        }

        [HttpGet("GetQuestions/{Id}")]
        public IActionResult GetQuestionsById(int Id)
        {
            var output = (from q in _context.Questions
                          where q.QuizId == Id
                          select new QuestionViewModel
                          {
                              Id = q.Id,
                              QuestionName = q.QuestionName,
                              Option1 = q.Option1,
                              Option2 = q.Option2,
                              Option3 = q.Option3,
                              Option4 = q.Option4,
                              ImageUrl = q.ImageUrl,
                              VideoUrl = q.VideoUrl,
                              CorrectAnswer = q.CorrectAnswer,
                              QuizId = Id
                          }).ToList();
            return Ok(output);

        }

        [HttpPost("PlayQuiz/{Id}")]
        public IActionResult Play(int Id, QuizGameViewModel model)
        {
            var quizId = _context.QuizGames.FirstOrDefault(x => x.QuizId == Id && x.UserId== GetUserId());

            if (quizId == null)
            {
                var quizGame = new QuizGame
                {
                    Point = model.Point,
                    QuizId = Id,
                    UserId = GetUserId()
                };
                _context.QuizGames.Add(quizGame);
                _context.SaveChanges();
            }

            if (quizId != null)
            {
                quizId.Point += model.Point;
                _context.SaveChanges();
            }
            return Ok();
        }

        [HttpGet("UserScore")]
        public IActionResult GetUserScore()
        {
            var output = (from _user in _context.Users
                          join _quizgame in _context.QuizGames
                          on _user.Id equals _quizgame.UserId
                          join _quiz in _context.Quizzes
                          on _quizgame.QuizId equals _quiz.Id
                          where _quiz.UserId == GetUserId()
                          select new ScoreViewModel
                          {
                              Quiz = _quiz.Title,
                              User = _user.UserName,
                              Point = _quizgame.Point
                          }).ToList();
            return Ok(output);
        }



    }
}

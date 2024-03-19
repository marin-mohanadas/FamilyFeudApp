using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FamilyFeudApp.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase {

        [HttpGet]
        public IEnumerable<QuestionsAndAnswers> Get() {

            List<Questions> questionList = new List<Questions>() {
                new Questions() { Id = 1, Question = "Question 1" },
                new Questions() { Id = 2, Question = "Question 2" }
            };

            List<Answers> answerList = new List<Answers>() {
                new Answers() { Id = 1, Answer = "Answer 1", QuestionId = 1, Rank = 1, Points = 5},
                new Answers() { Id = 2, Answer = "Answer 2", QuestionId = 1, Rank = 2, Points = 3},
                new Answers() { Id = 3, Answer = "Answer 3", QuestionId = 2, Rank = 1, Points = 4},
                new Answers() { Id = 4, Answer = "Answer 4", QuestionId = 2, Rank = 2, Points = 4}
            };

            var joinedData = (from q in questionList
                              join a in answerList on q.Id equals a.QuestionId
                              select new {
                                  QuestionId = q.Id,
                                  QuestionText = q.Question,
                                  AnswerId = a.Id,
                                  AnswerText = a.Answer,
                                  a.Rank,
                                  a.Points
                              }).ToList();

            return Enumerable.Range(0, joinedData.Count).Select(index => new QuestionsAndAnswers {
                QuestionNumber = joinedData[index].QuestionId,
                Questions = joinedData[index].QuestionText,
                AnswerNumber = joinedData[index].AnswerId,
                Answer = joinedData[index].AnswerText,
                Rank = joinedData[index].Rank,
                Points = joinedData[index].Points

            })
            .ToArray();
        }

    }

    public class QuestionsAndAnswers {
        public int QuestionNumber { get; set; }
        public string Questions { get; set; }
        public int AnswerNumber { get; set; }
        public string Answer { get; set; }
        public int Rank { get; set; }
        public int Points { get; set; }
        //public int TotalPoints { get; set; }


    }

    public class Questions {
        public int Id { get; set; }
        public string Question { get; set; }
    }

    public class Answers {
        public int Id { get; set; }
        public string Answer { get; set; }
        public int QuestionId { get; set; }
        public int Rank { get; set; }
        public int Points { get; set; }
        //public int TotalPoints { get; set; }
    }
}
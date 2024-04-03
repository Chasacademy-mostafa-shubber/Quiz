using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz_project.Server.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public string QuestionName { get; set; }

        public string ?  Option1 { get; set; }

        public string ?  Option2 { get; set; }

        public string ?  Option3 { get; set; }

        public string ?  Option4 { get; set; }

        public string ?  ImageUrl { get; set; }

        public string ?  VideoUrl { get; set; }

        public string CorrectAnswer { get; set; }

        public int QuizId { get; set; }

        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_project.Shared.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        public string QuestionName { get; set; }

        public string? Option1 { get; set; }

        public string? Option2 { get; set; }

        public string? Option3 { get; set; }

        public string? Option4 { get; set; }

        public string? ImageUrl { get; set; }

        public string? VideoUrl { get; set; }

        public string CorrectAnswer { get; set; }


        public int QuizId { get; set; }


    }
}

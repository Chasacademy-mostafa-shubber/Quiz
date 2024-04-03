using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_project.Shared.ViewModels
{
    public class ScoreViewModel
    {
        public int QuizId { get; set; }

        public string Quiz { get; set; }

        public int Point { get; set; }

        public string UserId { get; set; }

        public string User{ get; set; }
    }
}

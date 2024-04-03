using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_project.Shared.ViewModels
{
    public class QuizGameViewModel
    {       
        public int ?Id { get; set; }

        public int Point { get; set; }

        public int? QuizId { get; set; }

        public string? UserId { get; set; }
       
    }
}

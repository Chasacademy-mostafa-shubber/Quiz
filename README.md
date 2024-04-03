# Quiz project with .NET 6 core Blazor Webassembly

## Models
* Question
* Quiz
* QuizGame

## Controllers

|Method|Outout|
|:-----|:-----|
|  [HttpPost("AddNewQuiz")]| Add quiz|
|  [HttpGet("MyQuizList")]| Get quizzes for the user|
|  [HttpPost("AddNewQuestion")]| Add question to quiz|
|  [HttpGet("QuizList")]| Get quizzes from all users|
|  [HttpGet("GetQuestions/{Id}")]| Get all questions for one quiz|
|  [HttpPost("PlayQuiz/{Id}")]| Answer the question|
|  [HttpGet("UserScore")]| Get score |

## Pages
* MyPage: Link for adding quiz and question. Show list of quizzes and scores.
* Game: Get list of all questions for the quiz. 
* AddQuestion: Add new question to quiz.
* AddQuiz: Add new quiz
* AllQuzzes: Get list of quizzes

## SQL Server

![Skärmklipp](https://github.com/Chasacademy-mostafa-shubber/Quiz/assets/113859196/672f6e2c-107a-4a69-ba68-c339391f64e3)

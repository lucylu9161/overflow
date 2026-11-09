// using System.ComponentModel.DataAnnotations;
// using QuestionService.Validators;

namespace QuestionService.DTOs;

public record CreateQuestionDto(
    string Title, 
    string Content, 
    List<string> Tags);



// using System.ComponentModel.DataAnnotations;
// using QuestionService.Validators;
//
// namespace QuestionService.DTOs;
//
// public record CreateQuestionDto(
//     [Required]string Title, 
//     [Required]string Content, 
//     [Required][TagListValidator(1, 5)]List<string> Tags);
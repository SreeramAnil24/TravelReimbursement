using System.ComponentModel.DataAnnotations;

namespace EmpManage.Models;

public class Feedback
{
    
    [Required]
    public string? emailid{get; set;}
    [Required]
    public int rating{get; set;}
    [Required]
    public string? feedback{get; set;}

}
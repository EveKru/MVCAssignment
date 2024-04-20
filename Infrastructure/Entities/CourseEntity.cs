using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class CourseEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Title { get; set; } = null!;
    public string Image { get; set; } = null!;
    public string Author { get; set; } = null!;

    public int Hours { get; set; } 
    public bool IsBestseller { get; set; }
    public bool IsDigital { get; set; }
    public string Originalprice { get; set; } = null!;
    public string? Discountprice { get; set; }
    public string? LikesInNumbers { get; set; }
    public string? LikesInProcent { get; set; }

    public DateTime Created { get; set; }
    public DateTime LastUpdated { get; set; }

    public int? CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }

}

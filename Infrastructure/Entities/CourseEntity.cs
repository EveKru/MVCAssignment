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
    public decimal Originalprice { get; set; }
    public decimal Discountprice { get; set; }
    public decimal LikesInNumbers { get; set; }
    public decimal LikesInProcent { get; set; }

}

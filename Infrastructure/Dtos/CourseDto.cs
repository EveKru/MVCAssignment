namespace Infrastructure.Dtos;

public class CourseDto
{
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

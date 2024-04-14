namespace WebApp.ViewModels.Courses
{
    public class CourseModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int Hours { get; set; }
        public bool IsBestseller { get; set; }
        public string? Originalprice { get; set; }
        public string? Discountprice { get; set; }
        public string? LikesInNumbers { get; set; }
        public string? LikesInProcent { get; set; }
    }
}

namespace WebApp.ViewModels.Courses
{
    public class CourseIndexViewModel
    {
        public IEnumerable<CategoryModel>? Categories { get; set; }
        public IEnumerable<CourseModel>? Courses { get; set; }
    }
}

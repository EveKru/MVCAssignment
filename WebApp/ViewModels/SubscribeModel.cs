using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class SubscribeModel
    {
        [Required]
        [Display(Prompt = "Your Email")]
        public string Email { get; set; } = null!;

        [Display(Name = "Daily Newsletter")]
        public bool DailyNewsLetter { get; set; }

        [Display(Name = "AdvertisingUpdates")]
        public bool AdvertisingUpdates { get; set; }

        [Display(Name = "Week in review")]
        public bool Weekinreview { get; set; }

        [Display(Name = "Event Updates")]
        public bool EventUpdates { get; set; }

        [Display(Name = "Startups Weekly")]
        public bool StartupsWeekly { get; set; }

        [Display(Name = "Podcasts")]
        public bool Podcasts { get; set; }

    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos;

public class SubscriberDto
{
    [Required]
    public string Email { get; set; } = null!;

    //public bool DailyNewsLetter { get; set; }

    //public bool AdvertisingUpdates { get; set; }

    //public bool Weekinreview { get; set; }

    //public bool EventUpdates { get; set; }

    //public bool StartupsWeekly { get; set; }

    //public bool Podcasts { get; set; }
}
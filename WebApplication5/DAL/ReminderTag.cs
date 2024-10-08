﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.DAL
{
    public class ReminderTag
    {
        public int ReminderId { get; set; }

        [ForeignKey("ReminderId")]
        public Reminder Reminder { get; set; }

        public int TagId { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }


    }
}
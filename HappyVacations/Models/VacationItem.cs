﻿namespace HappyVacations.Models
{
    public class VacationItem
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime Date { get; set; }
        public VacationItemType ItemType { get; set; } = VacationItemType.Regular;

        public bool Cancelled { get; set; }

        public override int GetHashCode()
        {
            return Date.GetHashCode();
        }
        public override string ToString()
        {
            if (Cancelled)
            {
                return "Х";
            }

            return ItemType switch
            {
                VacationItemType.Regular => "О",
                VacationItemType.DonorDay => "Д",
                VacationItemType.NonPayed => "С",
                VacationItemType.Sick => "Б",
                _ => "O"
            };
        }
    }

    public enum VacationItemType
    {
        Regular = 0,
        NonPayed = 1,
        DonorDay = 2,
        Sick = 3,
    }
}

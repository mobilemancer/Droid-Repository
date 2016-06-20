﻿using System;
using System.Collections.Generic;

namespace DroidRepository
{
    public class Droid
    {
        public int Id { get; set; }
        public Guid ImperialId { get; set; }
        public DateTime EntryDate { get; } = DateTime.UtcNow;
        public string Name { get; set; }
        public string ProductSeries { get; set; }
        public decimal Height { get; set; }
        public IEnumerable<string> Armaments { get; set; }
        public static Droid DeepClone(Droid oldDroid)
        {
            var newDroid = new Droid();
            newDroid.Id = oldDroid.Id;
            newDroid.Name = oldDroid.Name;
            newDroid.ProductSeries = oldDroid.ProductSeries;
            newDroid.Armaments = new List<string>(oldDroid.Armaments);
            return newDroid;

        }

    }
}

using System;
using System.Collections.Generic;

namespace DroidRepository
{
    public class Droid
    {
        public int Id { get; set; }
        public Guid ImperialContractId { get; set; }
        public DateTime EntryDate { get; } = DateTime.UtcNow;
        public string Name { get; set; }
        public long CreditBalance { get; set; }
        public string ProductSeries { get; set; }
        public decimal Height { get; set; }
        public IEnumerable<string> Armaments { get; set; }
        public IEnumerable<string> Equipment { get; set; }
        public static Droid DeepClone(Droid oldDroid)
        {
            var newDroid = new Droid();
            newDroid.Id = oldDroid.Id;
            newDroid.ImperialContractId = oldDroid.ImperialContractId;
            newDroid.Name = oldDroid.Name;
            newDroid.CreditBalance = oldDroid.CreditBalance;
            newDroid.ProductSeries = oldDroid.ProductSeries;
            newDroid.Height = oldDroid.Height;
            newDroid.Armaments = new List<string>(oldDroid.Armaments);
            newDroid.Equipment = new List<string>(oldDroid.Equipment);
            return newDroid;

        }

    }
}

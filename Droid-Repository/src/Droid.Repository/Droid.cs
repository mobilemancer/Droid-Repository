using System;
using System.Collections.Generic;
using System.Linq;

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
            if (oldDroid.Armaments != null)
            {
                newDroid.Armaments = new List<string>(oldDroid.Armaments);
            }
            else
            {
                newDroid.Armaments = new List<string>();
            }
            if (oldDroid.Equipment != null)
            {
                newDroid.Equipment = new List<string>(oldDroid.Equipment);
            }
            else
            {
                newDroid.Equipment = new List<string>();
            }
            return newDroid;
        }

        public void Update(Droid droid)
        {
            if (droid.ImperialContractId != Guid.Empty)
            {
                ImperialContractId = droid.ImperialContractId;
            }

            if (droid.CreditBalance != 0)
            {
                CreditBalance = droid.CreditBalance;
            }

            if (droid.ProductSeries != null)
            {
                ProductSeries = droid.ProductSeries;
            }

            if (droid.Height != 0)
            {
                Height = droid.Height;
            }

            if (droid.Armaments != null)
            {
                foreach (var armament in droid.Armaments)
                {
                    if (!Armaments.Contains(armament))
                    {
                        ((List<string>)Armaments).Add(armament);
                    }
                }
            }

            if (droid.Equipment != null)
            {
                foreach (var equipment in droid.Equipment)
                {
                    if (!Equipment.Contains(equipment))
                    {
                        ((List<string>)Equipment).Add(equipment);
                    }
                }
            }
        }
    }
}

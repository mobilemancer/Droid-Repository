using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace DroidRepository
{
    public class DroidRepository : IDroidRepository
    {
        private static ConcurrentDictionary<string, Droid> repo { get; set; }
        private static int id;
        public DroidRepository()
        {
            repo = new ConcurrentDictionary<string, Droid>();
            Seed();
        }


        public IEnumerable<Droid> GetAll()
        {
            var droids = new List<Droid>();
            foreach (var droid in repo.Values)
            {
                var newDroid = Droid.DeepClone(droid);
                droids.Add(newDroid);
            }
            return droids.OrderBy(d => d.Id);
        }

        public Droid Delete(string name)
        {
            Droid droid;
            repo.TryRemove(name, out droid);
            return droid;
        }

        public Droid Get(string name)
        {
            Droid droid = null;
            if (repo.ContainsKey(name))
            {
                repo.TryGetValue(name, out droid);
            }
            return droid;
        }

        public Droid Get(int id)
        {
            return repo.Values.FirstOrDefault(d => d.Id == id);
        }


        public bool Put(Droid newDroid)
        {
            Droid droid = null;
            repo.TryGetValue(newDroid.Name, out droid);
            if (droid != null)
            {
                return false;
            }

            newDroid.Id = id++;
            repo.TryAdd(newDroid.Name, newDroid);

            return true;
        }

        public Droid Update(Droid droid)
        {
            if (repo.ContainsKey(droid.Name))
            {
                droid.Id = repo[droid.Name].Id;
                repo[droid.Name] = droid;
                return droid;
            }
            return null;
        }

        public Droid UpdatePartial(string name, Droid droid)
        {
            if (repo.ContainsKey(name))
            {
                repo[name].Update(droid);
                return repo[name];
            }
            return null;
        }

        public IEnumerable<Droid> GetAllFromEntryDate(DateTime entryDate)
        {
            return repo.Values.Where(d => d.EntryDate.CompareTo(entryDate) > 0);
        }

        public IEnumerable<Droid> GetAllTallerThan(decimal height)
        {
            return repo.Values.Where(d => d.Height > height);
        }

        public Droid GetByImperialId(Guid imperialId)
        {
            return repo.Values.FirstOrDefault(d => d.ImperialContractId.Equals(imperialId));
        }

        public IEnumerable<Droid> GetByCreditBalance(long creditBalance)
        {
            return repo.Values.Where(d => d.CreditBalance > creditBalance);
        }



        /// <summary>
        /// Seed the database with a few initial droids
        /// </summary>
        private static void Seed()
        {
            var ig88 = new Droid
            {
                Id = id++,
                ImperialContractId = Guid.Parse("0B450FDD-F484-423B-8685-4193E9FA583D"),
                Name = "IG-88",
                CreditBalance = 4611686018427387903,
                ProductSeries = "IG-86",
                Height = 1.96M,
                Armaments = new List<string> {
                    "DAS-430 Neural Inhibitor", "Heavy pulse cannon", "Poison darts",
                    "Toxic gas dispensers", "Vibroblades"
                },
                Equipment = new List<string>()
            };
            repo.TryAdd(ig88.Name, ig88);

            var c3po = new Droid
            {
                Id = id++,
                Name = "C-3PO",
                ProductSeries = "3PO-series Protocol Droid",
                Height = 1.71M,
                Armaments = new List<string>(),
                Equipment = new List<string>
                {
                    "TranLang III communication module"
                }
            };
            repo.TryAdd(c3po.Name, c3po);

            var r2d2 = new Droid
            {
                Id = id++,
                Name = "R2-D2",
                ProductSeries = "R-Series",
                Height = 0.96M,
                Armaments = new List<string> {
                    "Buzz saw", "Electric pike"
                },
                Equipment = new List<string>
                {
                    "Drinks tray (only on sail barge)", "Fusion welder",
                    "Com link", "Power recharge coupler",
                    "Rocket boosters", "Holographic projector/recorder",
                    "Motorized, all-terrain treads", "Retractable third leg",
                    "Periscope", "Fire extinguisher", "Hidden lightsaber compartment with ejector",
                    "Data probe", "Life-form scanner", "Utility arm"
                }
            };
            repo.TryAdd(r2d2.Name, r2d2);

        }
    }

}


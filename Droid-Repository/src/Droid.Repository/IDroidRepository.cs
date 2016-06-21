using System;
using System.Collections.Generic;

namespace DroidRepository
{
    public interface IDroidRepository
    {
        Droid Delete(string name);
        IEnumerable<Droid> GetAll();
        Droid Get(string name);
        Droid Get(int id);
        bool Put(Droid newDroid);
        Droid Update(Droid droid);
        IEnumerable<Droid> GetAllFromEntryDate(DateTime entryDate);
        IEnumerable<Droid> GetAllTallerThan(decimal height);
        Droid GetByImperialId(Guid imperialId);
        IEnumerable<Droid> GetByCreditBalance(long creditBalance);
    }
}

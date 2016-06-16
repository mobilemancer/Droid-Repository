﻿using System.Collections.Generic;

namespace DroidRepository
{
    public interface IDroidRepository
    {
        bool Delete(string name);
        IEnumerable<Droid> GetAll();
        Droid Get(string name);
        Droid Get(int id);
        bool Put(Droid newDroid);
        Droid Update(Droid droid);

    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public interface IRentalRepository
    {
        Rental Create();
        Rental GetById(int id);
        void Update(Rental order);
    }
}
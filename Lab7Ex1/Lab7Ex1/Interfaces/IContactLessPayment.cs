using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7Ex1.Interfaces
{
    //    Plata contactless implica urmatoarele operatiuni:
    //           Apropie
    //           EfectueazaPlata
    public interface IContactLessPayment:IPayment
    {
        void PutCardCloseToPayStation();
    }
}

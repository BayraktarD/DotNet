using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7Ex1.Interfaces
{
    //    Plata contact-full implica urmatoarele operatiuni:
    //           Introduce
    //           EfectueazaPlata
    //           Extrage

    public interface IContactFullPayment:IPayment
    {
        void InsertCard();
        void ExtractCard();
    }
}

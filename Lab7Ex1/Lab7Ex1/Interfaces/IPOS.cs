using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7Ex1.Interfaces
{
    //    Un POSl va accepta atat plata contactless cat si plata contact-full.Cele doua modalitati de plata vor fi modelate prin intermediul a doua metode, ce vor primi cate doi parametri:
    //                  1. Suma de plata
    //                  2. dispozitivul prin care se va efectua plata „ascuns” sub o interfata specifica fiecarui mod de plata.

//    Pentru plata prin intermediul POS-ului, clientul va putea folosi atat
//                       carduri clasice – suporta doar plati contactfull
//                       carduri contactless - suporta atat plati contact-full cat si plati contactless
//                       telefoane mobile contactless - suporta doar plati contactless

    public interface IPOS
    {
        void PayUsingContactLessPaymentMethod(decimal paymentValue, IContactLessPayment contactLessPayment);
        void PayUsingContactFullPaymentMethod(decimal paymentValue, IContactFullPayment contactFullPayment);
    }
}

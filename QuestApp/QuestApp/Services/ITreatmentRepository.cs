using QuestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestApp.Services
{
    public interface ITreatmentRepository
    {
       
        Booking Get(int id);

       
    }
}

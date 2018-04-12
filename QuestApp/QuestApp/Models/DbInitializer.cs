using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using QuestApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestApp.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                AppDbContext context = serviceScope.ServiceProvider.GetService<AppDbContext>();

               

                if (!context.Treatments.Any())
                {
                    context.AddRange
                    (
                        new LU_Treatment { TreatmentTitle = "Pian",TreatmentDescription="Any treatment"},
                        new LU_Treatment { TreatmentTitle = "Sik", TreatmentDescription = "new Available treatment" }
                        
                    );
                }

                context.SaveChanges();
                if (!context.TimeSlots.Any())
                {
                    context.AddRange
                    (
                        new LU_TimeSlot { TimeSlotTitle = 9},
                        new LU_TimeSlot { TimeSlotTitle = 10 }

                    );
                }

                context.SaveChanges();
            }
        }
        
    }
}


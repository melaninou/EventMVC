using System;
using System.Linq;
using Data;

namespace Infra
{
    public static class EventDbTableInitializer
    {
        public static void Initialize(EventProjectDbContext c)
        {
            c.Database.EnsureCreated(); //kas andmebaas on olemas
            if (c.Events.Any()) return; //kui aadresside tabelis midagi, lõpetab tegevuse
            initEvents(c);
            c.SaveChanges();
        }
        private static void initEvents(EventProjectDbContext c)
        {
            add(c, new EventDbRecord
            {

                
                Name = "Parklapidu",
                Location = "Tallinn",
                Time = "28.09.2018",
                Type = "concert",
                Organiser = "TTU",
                Description = "bla bla bla"
            });
        }
        private static string add(EventProjectDbContext c, EventDbRecord events) //unikaalse ID genereerimine
        {
            events.ID = Guid.NewGuid().ToString();
            c.Events.Add(events); //lisab andmebaasi
            return events.ID;
        }
    }
}

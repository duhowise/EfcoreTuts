using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SumariCoreApp.Data;
using SumariCoreApp.Domain;

namespace SumariApp
{
    class Program
    {
       private static readonly SamuraiContext Context = new SamuraiContext();

        static void Main(string[] args)
        {
            //InsertSamurai();
            //InsertMUltipleSamurai();
            //InsertMUltipleDifferentObjects();

            //SimpleSamuraiQuery();
            //MoreQueries();
            //RetreiveAndUpdateSamurai();
            //RetreiveAndUpdateMultipleSamurai();


            RetreiveAndUpdateSamurai_DIsconnected();
            //DeleteWhileTracked();

        }

        private static void DeleteWhileTracked()
        {
            using (var context = new SamuraiContext())
            {
                var samurai = context.Sumarais.FirstOrDefault(o => o.Name == "Duhp");
                if (samurai != null) context.Sumarais.Remove(samurai);
            }

        }

        private static void RetreiveAndUpdateSamurai_DIsconnected()
        {
            var battle = Context.Battles.FirstOrDefault();

            using (var c1 = new SamuraiContext())
            {
                if (battle != null) battle.EndDate=new DateTime(1569,06,03);

                if (battle != null) c1.Battles.Update(battle);
                c1.SaveChanges();

            }
        }

        private static void RetreiveAndUpdateMultipleSamurai()
        {
            using (var context = new SamuraiContext())
            {
                var samurais = context.Sumarais.ToList();
              samurais.ForEach(s=>s.Name+="BAtch");
                context.SaveChanges();

            }
        }

        private static void RetreiveAndUpdateSamurai()
        {
            using (var context = new SamuraiContext())
            {
                var samurai = context.Sumarais.FirstOrDefault();
                if (samurai != null) samurai.Name += "er";
                context.SaveChanges();

            }
        }

        private static void MoreQueries()
        {
            using (var context = new SamuraiContext())
            {
                var name= "%Duh%";
                //var samurais = context.Sumarais.Where(o => o.Name.Contains(name));
                var samurais = context.Sumarais.Where(o =>EF.Functions.Like(o.Name,name));
                foreach (var samurai in samurais)
                {
                    Console.WriteLine(samurai?.Name);

                }

            }
        }

        private static void SimpleSamuraiQuery()
        {
            using (var context = new SamuraiContext())
            {
              var samurais= context.Sumarais.ToList();
            }
        }

        private static void InsertMUltipleDifferentObjects()
        {
            var samurai = new Samurai { Name = "Oda Nobunaga" };
            var battle = new Battle { Name = "Battle of Nagashino",
                StartDate = new DateTime(1575,06,16),
                EndDate = new DateTime(1575,06,28)};
            using (var context = new SamuraiContext())
            {
                context.AddRange(samurai, battle);
                context.SaveChanges();
            }
        }

        private static void InsertMUltipleSamurai()
        {
            var samurai = new Samurai { Name = "Duhper" };
            var samura2 = new Samurai { Name = "Dance" };
            using (var context = new SamuraiContext())
            {
                context.Sumarais.AddRange(samurai,samura2);
                context.SaveChanges();
            }
        }

        private static void InsertSamurai()
        {
            var samurai = new Samurai {Name = "Duhp"};
            using (var context=new SamuraiContext())
            {
                context.Sumarais.Add(samurai);
                context.SaveChanges();
            }
        }
    }
}

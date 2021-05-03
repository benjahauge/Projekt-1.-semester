using Projekt.Helpers;
using Projekt.Interfaces;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Services
{
    public class JsonKursusRepository : IRepository
    {
        string JsonFileName = @"Data\JsonKursus.Json";


        //Får alle kurser fra JsonKursus filen
        public List<Kursus> GetAllKursus()
        {
            return JsonFileReader.ReadJson(JsonFileName);
        }

        //Tilføjer et kursus, hvor den automatisk giver det næste ID i rækkefølgen
        //Så man ikke selv skal skrive det ind manuelt
        public void AddKursus(Kursus k)
        {
            List<Kursus> @kursuses = GetAllKursus().ToList();
            List<int> kursusIds = new List<int>();
            foreach (var ku in kursuses)
            {
                kursusIds.Add(ku.ID);
            }
			if (kursusIds.Count != 0)
			{
				int start = kursusIds.Max();
				k.ID = start + 1;
			}
			else
            {
                k.ID = 1;
            }   
            kursuses.Add(k);
            JsonFileWritter.WriteToJson(@kursuses, JsonFileName);
        }
       

        //Her kan man søge efter et bestemt kursus
        public List<Kursus> FilterKursus(string criteria)
        {
            List<Kursus> kursuses = GetAllKursus();
            List<Kursus> filteredKursuses = new List<Kursus>();
            foreach (var kus in kursuses)
            {
                if (kus.Navn.StartsWith(criteria))
                {
                    filteredKursuses.Add(kus);
                }
            }
            return filteredKursuses;

        }

        //Her kan man hente et bestemt kursus fra Json filen, så man kan bruge
        //andre metoder til at gøre noget bestemt ved det enkelte kursus
        public Kursus GetKursus(int id)
        {
            foreach (var v in GetAllKursus())
            {
                if (v.ID == id)
                    return v;
            }
            return new Kursus();
        }

        
        //Her kan man fjerne et kursus fra listen
        public void RemoveKursus(int id)
        {
            List<Kursus> @kursus = GetAllKursus().ToList();

            foreach (var e in @kursus)
            {
                if (e.ID == id)
                {
                    @kursus.Remove(e);
                    break;
                }
            }
            JsonFileWritter.WriteToJson(@kursus, JsonFileName);
        }
        
        //Her kan man opdatere et kursus fra listen
        public void UpdateKursus(Kursus @kurs)
        {
            List<Kursus> @kursus = GetAllKursus().ToList();

            if (@kursus != null)
            {
                foreach (var k in @kursus)
                {
                    if (k.ID == @kurs.ID)
                    {
                        k.ID = kurs.ID;
                        k.Beskrivelse = kurs.Beskrivelse;
                        k.DateTime = kurs.DateTime;
                        k.Lokale = kurs.Lokale;
                        k.Navn = kurs.Navn;
                        k.Underviser = kurs.Underviser;

                    }
                }
            }
            JsonFileWritter.WriteToJson(@kursus, JsonFileName);

        }
    }
}

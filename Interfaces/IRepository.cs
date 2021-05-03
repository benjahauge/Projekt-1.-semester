using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Projekt.Interfaces
{
    public interface IRepository
    {
        List<Kursus> FilterKursus(string criteria);
        List<Kursus> GetAllKursus();
        Kursus GetKursus(int id);
        void AddKursus(Kursus k);
        void UpdateKursus(Kursus k);
        void RemoveKursus(int id);

    }
}

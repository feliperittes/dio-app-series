using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SeriesRepository : IRepository<Serie>
    {
        private List<Serie> listSerie = new List<Serie>();
        public void Update(int id, Serie serieObject)
        {
            listSerie[id] = serieObject;
        }

        public void Delete(int id)
        {
            listSerie[id].Delete();
        }

        public void Insert(Serie serieObject)
        {
            listSerie.Add(serieObject);
        }

        public List<Serie> List()
        {
            return listSerie;
        }

        public int NextId()
        {
            return listSerie.Count;
        }

        public Serie ReturnById(int id)
        {
            return listSerie[id];
        }
    }
}
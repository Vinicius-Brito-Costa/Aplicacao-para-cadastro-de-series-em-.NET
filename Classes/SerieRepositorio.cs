using System;
using System.Collections.Generic;
using AplicativoSeries.Interfaces;
namespace AplicativoSeries.Classes
{
    public class SerieRepositorio : IRepositorio<Series>
    {
        private List<Series> listaSerie = new List<Series>();
        public void Atualiza(int id, Series entidade)
        {
            listaSerie[id] = entidade;
            Console.WriteLine("Serie atualizada.");
        }

        public void Excluir(int id)
        {
            listaSerie[id].Excluir();
            Console.WriteLine("Serie excluida.");
        }

        public void Insere(Series entidade)
        {
            listaSerie.Add(entidade);
            Console.WriteLine("Serie inserida.");
        }

        public List<Series> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Series RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}
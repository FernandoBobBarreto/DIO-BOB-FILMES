using System;
using System.Collections.Generic;
using Bob.filmes.interfaces;

namespace Bob.filmes
{
    public class FilmesRepositorio : iRepositorio<Filme>
    {
       private List<Filme> listaFilmes = new List<Filme>();
       public void Atualiza(int id, Filme objeto)
       {
           listaFilmes[id] = objeto;
       } 

       public void Exclui (int id)
       {
           listaFilmes[id].Excluir();
       }

       public void Insere(Filme objeto)
       {
           listaFilmes.Add(objeto);
       }

       public List<Filme> Lista()
       {
           return listaFilmes;
       }

       public int ProximoId()
       {
           return listaFilmes.Count;
       }

       public Filme RetornaPorId(int id)
       {
           return listaFilmes[id];
       }
    }
}
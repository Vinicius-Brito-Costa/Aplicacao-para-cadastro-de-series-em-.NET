using System;
namespace AplicativoSeries.Classes
{
    public class Series : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Series(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.ID = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }
        public string Informacoes()
        {
            string retorno = "";
            retorno += $"Titulo: {this.Titulo }" + Environment.NewLine;
            retorno += $"Gênero: {this.Genero }" + Environment.NewLine;
            retorno += $"Descrição: {this.Descricao }" + Environment.NewLine;
            retorno += $"Ano: {this.Ano }" + Environment.NewLine;
            retorno += $"Excluido: {(this.Excluido ? "Sim" : "Não")}";
            return retorno;
        }
        public string RetornaTitulo(){
            return this.Titulo;
        }
        public int RetornaId(){
            return this.ID;
        }
        public bool RetornaExcluido(){
            return this.Excluido;
        }
        public void Excluir(){
            this.Excluido = true;
        }
    }
}
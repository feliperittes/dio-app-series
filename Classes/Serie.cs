using System;

namespace DIO.Series
{
    public class Serie : BaseEntity
    {
        // Atributos
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Excluded { get; set; }

        // Métodos
        public Serie(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Excluded = false;
        }

        public override string ToString()
        {
            string returnThis = "";
            returnThis += "Gênero: " + this.Genre + Environment.NewLine;
            returnThis += "Titulo: " + this.Title + Environment.NewLine;
            returnThis += "Descrição: " + this.Description + Environment.NewLine;
            returnThis += "Ano de Início: " + this.Year + Environment.NewLine;
            returnThis += "Excluido: " + this.Excluded;
            return returnThis;
        }

        public string returnTitle()//retorna Titulo
        {
            return this.Title;
        }

        public int returnId()//retorna Id
        {
            return this.Id;
        }
        public bool returnDeleted()//return excluido
        {
            return this.Excluded;
        }
        public void Delete()
        {
            this.Excluded = true;
        }
    }
}
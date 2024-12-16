﻿using BusinessObjects.App;

namespace BusinessObjects.Entity
{
    public class Library : IEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Address {  get; private set; }

        public IEnumerable<Book> Books { get; set; }

        public Library(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
            Books = new List<Book>();
        }

        public override string ToString() => $"{Name} Matricule n°{Id} | Location : {Address} | Nombre de livres : {Books.Count()}";
    }
}

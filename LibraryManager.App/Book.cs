using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.App
{
    public class Book
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Book(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public override string ToString()
        {
            return $"Titre: {Name}, Genre: {Type}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.App
{
    public class Book
    {
        public string? name;
        public string? type;

        public Book(string name, string type)
        {
            this.name = name;
            this.type = type;
        }

        public string DisplayBook()
        {
            return "Nom du Livre: " + this.name + " | " + this.type;
        }
    }
}

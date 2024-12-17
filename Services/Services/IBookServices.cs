using BusinessObjects.App;
using BusinessObjects.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IBookServices : IServices
    {
        List<Book> GetBookByType(TypeBook type);
    }
}

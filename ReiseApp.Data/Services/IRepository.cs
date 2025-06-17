using ReiseApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReiseApp.Data.Services
{
    public interface IRepository
    {
        List<Reise> All();

        bool Insert(Reise reise);

        bool AddDemoData();

        bool Delete(Reise reise);
        bool DeleteAll();
    }
}

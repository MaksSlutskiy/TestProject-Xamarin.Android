using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Services
{
    public interface IDataService
    {
        Task<IEnumerable<Kitten>> GetAll();
        void Insert(Kitten kitten);
        void Update(Kitten kitten);
        void Delete(Kitten kitten);
    }
}

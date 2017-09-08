using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public interface IRepository<T>
    {
        IEnumerable<T> All { get; }
        T GetByID(int id, string s);
        void AddData(T model);
    }
}

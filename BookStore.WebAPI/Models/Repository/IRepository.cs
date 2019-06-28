using System;
using System.Collections.Generic;

namespace PetStoreMvc.Models.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> List();
        Product Find(Guid id);        
        Product Create(T item);
        T Update(T item);
        void Delete(Guid id);
    }
}
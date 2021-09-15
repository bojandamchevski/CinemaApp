using System;
using System.Collections.Generic;

namespace BojanDamchevski.CinemaApp.DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        int Insert(T entity);
        void Update(T entity);
        void DeleteById(int id);
    }
}


using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //generic constraint:generic kısık demek !
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        T Get(Expression<Func<T,bool>> filter);//filtre zorunludur
        List<T> GetAll(Expression<Func<T,bool>> filter=null);//filtre vermeye bilirsin 
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

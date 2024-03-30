using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace GlobalBackEndAPI.Global
{
    /// <summary>
    /// A base class which all repository classes can extend from. Implements basic create/delete/update and get by id methods. <br></br>
    /// Requires two generic types. D is the database context, T is the model class. <br></br>
    /// For the get to work, the model class primary key must be named as follows: TableName + Id.
    /// </summary>
    public class BaseRepository<D, T> : IBaseEntityRepository<T> where D : DbContext
    {
        protected readonly D _context;
        public BaseRepository(D rtDataContext)
        {
            _context = rtDataContext;
        }

        public T Get(Guid id)
        {
            Type type = typeof(D);
            PropertyInfo? propertyInfo = type.GetProperties().FirstOrDefault(p => p.PropertyType.IsGenericType &&
                p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                p.PropertyType.GetGenericArguments()[0] == typeof(T));

            if (propertyInfo is null) throw new Exception("Property not found.");

            IQueryable<T>? dbSet = propertyInfo.GetValue(_context) as IQueryable<T>;

            if (dbSet is null) throw new Exception("DbSet failed be cast.");

            ParameterExpression parameter = Expression.Parameter(typeof(T), "entity");
            MemberExpression property = Expression.Property(parameter, propertyInfo.Name + "Id");
            Expression idExpression = Expression.Constant(id);
            BinaryExpression equality = Expression.Equal(property, idExpression);
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(equality, parameter);

            return dbSet.Where(lambda).FirstOrDefault();
        }

        public bool Create(T t)
        {
            if (t is null) return false;
            _context.Add(t);
            return Save();
        }

        public bool Update(T t)
        {
            if (t is null) return false;
            _context.Update(t);
            return Save();
        }

        public bool Delete(T t)
        {
            if (t is null) return false;
            _context.Remove(t);
            return Save();
        }

        public bool Save()
        {
            int saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}

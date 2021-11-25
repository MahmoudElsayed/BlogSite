using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using System;
using System.Threading.Tasks;

namespace Blog.DAL
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : DbContext
    {
        #region Fields

        bool _IsDisposed = false;

        public UnitOfWork(T BlogContext) => this.BlogContext = BlogContext;

        #endregion

        #region Props

        public T BlogContext { get; }
        public IDbContextTransaction DbContextTransaction { get; set; }

        public bool IsDisposed { get => _IsDisposed; }

        #endregion

        #region Methods

        public virtual void Commit() => BlogContext.Database.CurrentTransaction.Commit();

        public bool SaveChanges()
        {
            try
            {
                return BlogContext.SaveChanges() >= 0;
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return false;
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return (await BlogContext.SaveChangesAsync()) > 0;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            BlogContext.Dispose();
            _IsDisposed = true;
        }
        #endregion
    }

}

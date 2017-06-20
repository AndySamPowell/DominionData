using System;

namespace DominionData.Base
{
    public interface IUow : IDisposable
    {
        void Commit();
        IRepository<T> GetRepo<T>() where T : class;

        /// <summary>
        /// Cleaning attached items to the context to improve processing speed in looping code
        /// </summary>
        void CleanCache();
    }
}

using CRMGuru.TestTaskWpf.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CRMGuru.TestTaskWpf.Services.Interrfaces
{
    public interface IDbService
    {
        /// <summary>
        /// Добавление страны в базу данных
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task Add(Country item, CancellationToken cancel = default);

        /// <summary>
        /// Загружает список стран с базы данных
        /// </summary>
        /// <returns></returns>
        IEnumerable<Country> GetAll();
    }
}

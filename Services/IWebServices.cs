using CRMGuru.TestTask.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CRMGuru.TestTaskWpf.Services
{
    public interface IWebServices
    {
        /// <summary>
        /// Возвращает страну от HttpClient 
        /// </summary>
        /// <param name="name">Название страны</param>
        /// <param name="cancel">токен отмены</param>
        /// <returns></returns>
        Task<Restcountries> GetAsync(string name, CancellationToken cancel = default);

        /// <summary>
        /// Возвращает массив стран от HttpClient 
        /// </summary>
        /// <param name="name">Название страны</param>
        /// <param name="cancel">токен отмены</param>
        /// <returns></returns>
        Task<IEnumerable<Restcountries>> GetArrayAsync(string name, CancellationToken cancel = default);
    }
}

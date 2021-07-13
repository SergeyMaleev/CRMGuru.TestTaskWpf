using CRMGuru.TestTaskWpf.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CRMGuru.TestTaskWpf.Services.Interrfaces
{
    public interface IWebService
    {
        /// <summary>
        /// Возвращает страну от HttpClient 
        /// </summary>
        /// <param name="name">Название страны</param>
        /// <param name="cancel">токен отмены</param>
        /// <returns></returns>
        Task<RestСountry> GetAsync(string name, CancellationToken cancel = default);

        /// <summary>
        /// Возвращает массив стран от HttpClient 
        /// </summary>
        /// <param name="name">Название страны</param>
        /// <param name="cancel">токен отмены</param>
        /// <returns></returns>
        Task<IEnumerable<RestСountry>> GetArrayAsync(string name, CancellationToken cancel = default);
    }
}

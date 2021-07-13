using CRMGuru.TestTaskWpf.Context;
using CRMGuru.TestTaskWpf.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using CRMGuru.TestTaskWpf.Services.Interrfaces;
using System.Threading;

namespace CRMGuru.TestTaskWpf.Services
{
    public class DbServices : IDbService
    {
        private readonly EfDataContext _context;
       
        public DbServices(EfDataContext context)
        {
            _context = context;
        }

        public async Task Add(Country item, CancellationToken cancel = default)
        {
            try
            {              
                var city = _context.Cities.FirstOrDefault(x => x.Name == item.Сapital.Name);
                var region = _context.Regions.FirstOrDefault(x => x.Name == item.Region.Name);
                var country = _context.Countries.FirstOrDefault(x => x.CountryCode == item.CountryCode);

                //_context.Countries.Remove(country);
                //await _context.SaveChangesAsync();
                if (city is null)
                {
                    await _context.Cities.AddAsync(item.Сapital);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    item.Сapital = city;               
                }
                    
                if (region is null)
                {
                    await _context.Regions.AddAsync(item.Region);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    item.Region = region;
                }
              
                if (country is null)
                {                   
                    await _context.Countries.AddAsync(item);
                }
                else
                {
                    country.Сapital = item.Сapital;
                    country.Region = item.Region;
                    _context.Countries.Update(country);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Country> GetAll()
        {
            try
            {
                var countries = _context.Countries.AsQueryable().Select(x => new Country
                {
                    Id = x.Id,
                    Name = x.Name,
                    Population = x.Population,
                    Area = x.Area,
                    CountryCode = x.CountryCode,
                    Region = new Region { Id = x.Region.Id, Name = x.Region.Name },
                    Сapital = new City { Id = x.Сapital.Id, Name = x.Сapital.Name }
                }).ToList();

                return countries;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

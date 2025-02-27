using HomeBookApp.Application.Common.Interfaces;
using HomeBookApp.Domain.Entities;
using HomeBookApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeBookApp.Infrastructure.Repository
{
    public class AmenityRepository : Repository<Amenity>, IAmenityRepository
    {
        private readonly ApplicationDbContext _db;

        public AmenityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void Update(Amenity entity)
        {
            _db.VillaNumbers.Update(entity);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFC4RESTAPI.Models.Super;
using EFC4RESTAPI.Services;

namespace EFC4RESTAPI.Repositories
{
    public class EFCRepository : IDBContext
    {
        private readonly AppDBContext _db;
        public EFCRepository(AppDBContext db) => _db = db;
        // POST IEnumerable<T>
        public async Task<Tuple<bool, string>> AddManyAsync<T>(IEnumerable<T> entities) where T : ISuper
        => await _db.AddManyAsync<T>(_db.Sets<T>(), entities);
        // POST T
        public async Task<Tuple<bool, string>> AddOneAsync<T>(T entity) where T : ISuper
        => await _db.AddOneAsync<T>(_db.Sets<T>(), entity);
        // GET
        public async Task<IEnumerable<T>> GetListAsync<T>() where T : ISuper
        => await _db.Sets<T>().GetListAsync();
        // GET {id}
        public async Task<T> GetOneAsync<T>(Guid id) where T : ISuper
        => await _db.Sets<T>().GetOneAsync(id);
        // PUT IEnumerable<Tuple<Guid, T>>
        public async Task<Tuple<bool, string>> ModifyManyAsync<T>(IEnumerable<Tuple<Guid, T>> ids_entities) where T : ISuper
        => await _db.ModifyManyAsync<T>(_db.Sets<T>(), ids_entities);
        // PUT {id}
        public async Task<Tuple<bool, string>> ModifyOneAsync<T>(Guid id, T entity) where T : ISuper
        => await _db.ModifyOneAsync<T>(_db.Sets<T>(), id, entity);
        // DELETE IEnumerable<Guid>
        public async Task<Tuple<bool, string>> RemoveManyAsync<T>(IEnumerable<Guid> ids) where T : ISuper
        => await _db.RemoveManyAsync<T>(_db.Sets<T>(), ids);
        // DELETE {id}
        public async Task<Tuple<bool, string>> RemoveOneAsync<T>(Guid id) where T : ISuper
        => await _db.RemoveOneAsync<T>(_db.Sets<T>(), id);
    }
}
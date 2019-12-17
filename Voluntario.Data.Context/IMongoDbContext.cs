using MongoDB.Driver;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Data.Context
{
    public interface IMongoDbContext
    {
        IMongoClient MongoClient { get; set; }
        IMongoDatabase MongoDataBase { get; set; }
        IMongoCollection<IVoluntario> VoluntarioCollection { get; set; }
        string ConnStr { get; set; }
        string DataBase { get; set; }
        string CollectionName { get; set; }
    }
}

using MongoDB.Bson.Serialization.Attributes;

namespace CatalogService.Api.Repositories
{
    public class BaseEntity
    {
        
        [BsonElement("_id")]
        public Guid Id { get; set; }
        
    }
}

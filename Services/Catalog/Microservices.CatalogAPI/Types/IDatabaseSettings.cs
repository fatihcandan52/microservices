namespace Microservices.CatalogAPI.Types
{
    public interface IDatabaseSettings
    {
        string CourseCollectionName { get; set; }
        string CategoryCollectionName { get; set; }
        string DatabaseName { get; set; }
        string MongoConnection { get; set; }
    }
}

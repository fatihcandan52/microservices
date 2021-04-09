namespace Microservices.CatalogAPI.Types
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CourseCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string DatabaseName { get; set; }
        public string MongoConnection { get; set; }
    }
}

﻿using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using WorkflowService.Domain;
using WorkflowService.WebApi.Config;

namespace WorkflowService.WebApi.Database
{
    public class DbContext
    {
        public DbContext(MongoConfig config)
        {
            RegisterClassMaps();

            MongoClient client = new MongoClient(config.ConnectionString);
            IMongoDatabase database = client.GetDatabase(config.Database);

            Projects = database.GetCollection<Project>("Projects");
            WorkItems = database.GetCollection<WorkItem>("WorkItems");
        }

        public IMongoCollection<Project> Projects { get; }

        public IMongoCollection<WorkItem> WorkItems { get; }

        private void RegisterClassMaps()
        {
            // cm.MapIdMember(x => x.Value);
            BsonClassMap.RegisterClassMap<Project>(cm =>
            {
                cm.AutoMap();
                cm.MapCreator(x => new Project(x.Title));
            });

            BsonClassMap.RegisterClassMap<WorkItem>(cm =>
            {
                cm.AutoMap();
                cm.MapCreator(x => new WorkItem(x.Title, x.Status));
            });
        }
    }
}
﻿using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Taskly.Workflow.Domain;
using Taskly.Workflow.WebApi.Config;

namespace Taskly.Workflow.WebApi.Database
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
            BsonClassMap.RegisterClassMap<WorkItemStatus>(cm => { cm.AutoMap(); });

            BsonClassMap.RegisterClassMap<Project>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id);
                cm.MapMember(x => x.AvailableStatuses);
                cm.MapCreator(x => new Project(x.Title, x.Description, x.AvailableStatuses));
            });

            BsonClassMap.RegisterClassMap<WorkItem>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id);
                cm.MapMember(x => x.ProjectId);
                cm.MapCreator(x => new WorkItem(x.ProjectId, x.Title, x.Description, x.Status));
            });
        }
    }
}

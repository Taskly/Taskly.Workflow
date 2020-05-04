using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Taskly.Workflow.Domain;

namespace Taskly.Workflow.WebApi.Database
{
    public class ProjectsRepository : IProjectsRepository
    {
        public ProjectsRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Project>> GetProjects()
        {
            var filter = new BsonDocument();
            List<Project> projects = await _dbContext.Projects.Find(filter).ToListAsync();
            return projects;
        }

        public async Task<Project> GetProject(string id)
        {
            Project project = await _dbContext.Projects.Find(x => x.Id == id).FirstOrDefaultAsync();
            return project;
        }

        public async Task<Project> SaveProject(Project project)
        {
            var replaceOptions = new ReplaceOptions
            {
                IsUpsert = true
            };

            await _dbContext.Projects.ReplaceOneAsync(x => x.Id == project.Id, project,
                replaceOptions);
            return project;
        }

        private readonly DbContext _dbContext;
    }
}

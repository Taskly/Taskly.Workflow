using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Taskly.Workflow.Domain;

namespace Taskly.Workflow.Application
{
    public class ProjectsRepository : IProjectsRepository
    {
        public ProjectsRepository(AppDbContext dbContext)
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
            if (project.Id is null)
            {
                await _dbContext.Projects.InsertOneAsync(project);
            }
            else
            {
                await _dbContext.Projects.ReplaceOneAsync(x => x.Id == project.Id, project);
            }

            return project;
        }

        private readonly AppDbContext _dbContext;
    }
}

using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taskly.Workflow.Domain;
using Taskly.Workflow.WebApi;
using Taskly.Workflow.WebApi.Dto.Projects;
using Taskly.Workflow.WebApi.Dto.WorkItems;

namespace Taskly.Workflow.Tests
{
    [TestClass]
    public class DtoMappingProfileTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            _configuration = new MapperConfiguration(cfg => { cfg.AddMaps(typeof(DtoMappingProfile)); });
            _mapper = _configuration.CreateMapper();
        }

        [TestMethod]
        public void ConfigurationIsValid()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void MapProjectToProjectDtoIsCorrect()
        {
            Project project = new Project("Some Title", "Short Description",
                new[] { new WorkItemStatus("first_status"), new WorkItemStatus("second_status") });

            ProjectDto projectDto = _mapper.Map<ProjectDto>(project);

            Assert.AreEqual("Some Title", projectDto.Title);
            Assert.AreEqual("Short Description", projectDto.Description);
            Assert.IsNotNull(projectDto.AvailableStatuses);
            Assert.AreEqual(project.Created, projectDto.Created);
            Assert.AreEqual(2, projectDto.AvailableStatuses.Count);
            Assert.AreEqual("first_status", projectDto.AvailableStatuses[0]);
            Assert.AreEqual("second_status", projectDto.AvailableStatuses[1]);
        }

        [TestMethod]
        public void MapWorkItemToWorkItemDtoIsCorrect()
        {
            WorkItem workItem = new WorkItem("42asd", "Task Title", "Task Description", new WorkItemStatus("one"));

            WorkItemDto workItemDto = _mapper.Map<WorkItemDto>(workItem);

            Assert.AreEqual("42asd", workItemDto.ProjectId);
            Assert.AreEqual("Task Title", workItemDto.Title);
            Assert.AreEqual("Task Description", workItemDto.Description);
            Assert.AreEqual(workItem.Created, workItemDto.Created);
            Assert.AreEqual("one", workItemDto.Status);
        }

        private MapperConfiguration _configuration;
        private IMapper _mapper;
    }
}

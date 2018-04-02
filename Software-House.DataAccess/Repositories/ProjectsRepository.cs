using Software_House.Contract.DataContracts;
using Software_House.Contract.Repositories;
using Software_House.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Software_House.DataAccess.Repositories
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProjectsRepository(ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public void Add(AddProjectDto project)
        {
            _dbContext.Projects.Add(new Project
            {
                Name = project.Name,
                Description = project.Description,
                IsDeleted = false,
                CreationDate = DateTime.Now
            });

            _dbContext.SaveChanges();
        }

        public List<ProjectsDto> GetAll()
        {
            return _dbContext.Projects.Where(x => !x.IsDeleted)
                .Select(x => new ProjectsDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    IsDeleted = x.IsDeleted,
                    CreationDate = x.CreationDate
                }).ToList();
        }

        public ProjectsDto GetById(int id)
        {
            var project = _dbContext.Projects.First(x => x.Id == id);
            return new ProjectsDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                CreationDate = project.CreationDate,
                IsDeleted = project.IsDeleted
            };
        }
        public ProjectsDto GetByName(string projectName)
        {
            var existingProject = _dbContext.Projects.FirstOrDefault(x => x.Name.ToLower() == projectName.ToLower());

            if (existingProject != null)
            {
                return new ProjectsDto
                {
                    Id = existingProject.Id,
                    Name = existingProject.Name,
                    Description = existingProject.Description,
                    IsDeleted = existingProject.IsDeleted,
                    CreationDate = existingProject.CreationDate
                };
            }

            return null;
        }
    }
}

using Software_House.Contract.Common;
using Software_House.Contract.DataContracts;
using Software_House.Contract.Repositories;
using Software_House.Contract.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Software_House.Services.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IProjectsRepository _projectsRepository;

        public ProjectsService(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public CommonResult Add(AddProjectDto project)
        {
            if(String.IsNullOrWhiteSpace(project.Name))
            {
                return CommonResult.Failure("Project name is empty.");
            }
            if (String.IsNullOrWhiteSpace(project.Description))
            {
                return CommonResult.Failure("Project description is empty.");
            }
            var existingProject = _projectsRepository.GetByName(project.Name);

            if (existingProject != null && !existingProject.IsDeleted && existingProject.Name == project.Name)
            {
                return CommonResult.Failure("Project name already exists.");
            }

            _projectsRepository.Add(project);

            return CommonResult.Success();
        }

		public void Delete(int id)
		{
			_projectsRepository.Delete(id);
		}

		public List<ProjectsDto> GetAll()
        {
            return _projectsRepository.GetAll();
        }

        public CommonResult<ProjectsDto> GetById(int id)
        {
            var project = _projectsRepository.GetById(id);

            if (project == null || project.IsDeleted)
            {
                return CommonResult<ProjectsDto>.Failure<ProjectsDto>("Problem occured during fetching project with given id.");
            }
            else
            {
                return CommonResult<ProjectsDto>.Success<ProjectsDto>(project);
            }
        }
    }
}

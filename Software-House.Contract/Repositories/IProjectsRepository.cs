using Software_House.Contract.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Software_House.Contract.Repositories
{
    public interface IProjectsRepository
    {
        List<ProjectsDto> GetAll();
        ProjectsDto GetById(int id);
        void Add(AddProjectDto project);
        ProjectsDto GetByName(string projectName);
    }
}

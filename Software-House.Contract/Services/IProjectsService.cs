using Software_House.Contract.Common;
using Software_House.Contract.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Software_House.Contract.Services
{
    public interface IProjectsService
    {
        List<ProjectsDto> GetAll();
        CommonResult<ProjectsDto> GetById(int id);
        CommonResult Add(AddProjectDto project);
    }
}

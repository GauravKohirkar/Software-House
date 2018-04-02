using System;
using System.Collections.Generic;
using System.Text;

namespace Software_House.Contract.DataContracts
{
    public class ProjectsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

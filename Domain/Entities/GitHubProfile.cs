using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GitHubProfile : Entity
    {
        public int UserId { get; set; }
        public string GitHubUrl { get; set; }
        public User User { get; set; }
    }
}

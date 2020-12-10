using IssueTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTracker.Domain.Entities
{
    public class Project : AuditableBaseEntity
    {
        public Project()
        {
            Issues = new HashSet<Issue>();
        }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public string OwnerId { get; set; }

        public ICollection<Issue> Issues { get; set; }
    }
}

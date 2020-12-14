using IssueTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Domain.Entities
{
    public class Issue : AuditableBaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReporterId { get; set; }
        public ApplicationUser Reporter { get; set; }
        public string AssigneeId { get; set; }
        public ApplicationUser Assignee { get; set; }
        public int Status { get; set; }
        public int IssueType { get; set; }
    }
}

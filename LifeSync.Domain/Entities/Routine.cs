using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSync.Domain.Entities
{
    public class Routine
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; } = string.Empty;
        
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}

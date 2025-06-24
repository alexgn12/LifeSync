using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSync.Application.DTOs
{
    public class CreateRoutineDto
    {
        public DateTime Date { get; set; }
        public string Title { get; set; } = null!;
        public List<CreateTaskItemDto> Tasks { get; set; } = new List<CreateTaskItemDto>();
    }
}

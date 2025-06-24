using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeSync.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public TimeSpan? PreferredWakeUpTime { get; set; }
        public TimeSpan? PreferredSleepTime { get; set; }
        public ICollection<UserSkill> Skills { get; set; } = new List<UserSkill>();
        public ICollection<UserAllergy> Allergies { get; set; } = new List<UserAllergy>();
        public ICollection<Routine> Routines { get; set; } = new List<Routine>();

    }
}

using System;
using System.Collections.Generic;

namespace ProjectMobile.Models
{
    public partial class Actor
    {
        public Actor()
        {
            SceneActor = new HashSet<SceneActor>();
        }

        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public string Image { get; set; }
        public string ActorDes { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public string AccountId { get; set; }
        public bool? IsDelete { get; set; }

        public Account Account { get; set; }
        public ICollection<SceneActor> SceneActor { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ProjectMobile.Models
{
    public partial class SceneActor
    {
        public int SceneId { get; set; }
        public int ActorId { get; set; }
        public string ActFrom { get; set; }
        public string ActTo { get; set; }

        public Actor Actor { get; set; }
        public Scene Scene { get; set; }
    }
}

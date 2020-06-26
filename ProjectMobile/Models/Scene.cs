using System;
using System.Collections.Generic;

namespace ProjectMobile.Models
{
    public partial class Scene
    {
        public Scene()
        {
            SceneActor = new HashSet<SceneActor>();
            SceneTool = new HashSet<SceneTool>();
        }

        public int SceneId { get; set; }
        public string SceneName { get; set; }
        public string SceneDes { get; set; }
        public string SceneLoc { get; set; }
        public DateTime? SceneTimeStart { get; set; }
        public DateTime? SceneTimeStop { get; set; }
        public int? SceneRec { get; set; }
        public string SceneActors { get; set; }
        public bool? IsDelete { get; set; }

        public ICollection<SceneActor> SceneActor { get; set; }
        public ICollection<SceneTool> SceneTool { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ProjectMobile.Models
{
    public partial class Scene
    {
        public int SceneId { get; set; }
        public string SceneName { get; set; }
        public string SceneDes { get; set; }
        public string SceneLoc { get; set; }
        public DateTime? SceneTimeStart { get; set; }
        public DateTime? SceneTimeStop { get; set; }
        public int? SceneRec { get; set; }
        public string SceneActors { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ProjectMobile.Models
{
    public partial class SceneTool
    {
        public int SceneId { get; set; }
        public int ToolId { get; set; }
        public string Quantity { get; set; }
        public string ToolFrom { get; set; }
        public string ToolTo { get; set; }

        public Scene Scene { get; set; }
        public Tool Tool { get; set; }
    }
}

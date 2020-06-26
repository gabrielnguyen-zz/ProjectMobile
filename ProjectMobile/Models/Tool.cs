using System;
using System.Collections.Generic;

namespace ProjectMobile.Models
{
    public partial class Tool
    {
        public Tool()
        {
            SceneTool = new HashSet<SceneTool>();
        }

        public int ToolId { get; set; }
        public string ToolName { get; set; }
        public string ToolDes { get; set; }
        public string Image { get; set; }
        public int? Quantity { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsDelete { get; set; }

        public ICollection<SceneTool> SceneTool { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandDto
    {
        public Guid PostGuid { get; set; }

        public string Title { get; set; }

        public string Abstract { get; set; }

        public string Description { get; set; }

        public bool IsShow { get; set; }

        public string DocumentGuid { get; set; }

        public Guid[] Categories { get; set; }

        public string[] Tags { get; set; }
    }
}

using System;

namespace GitHubApp
{
    public class CommitDto
    {
        public string CommitHash { get; set; }

        public string Comment { get; set; }

        public string Author { get; set; }

        public DateTime DateCommited { get; set; }
    }
}

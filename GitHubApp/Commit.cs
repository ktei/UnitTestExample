using System;

namespace GitHubApp
{
    public class Commit
    {
        public string CommitHash { get; set; }

        public string RepositoryId { get; set; }

        public string Comment { get; set; }

        public string Author { get; set; }

        public DateTime DateCommitted { get; set; }
    }
}

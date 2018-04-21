using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubApp
{
    public class GitHubClient : IGitHubClient
    {
        public Task<IEnumerable<Commit>> FetchCommits(string repositoryId)
        {
            throw new NotImplementedException();
        }
    }
}

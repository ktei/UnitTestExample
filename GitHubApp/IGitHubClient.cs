using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubApp
{
    public interface IGitHubClient
    {
        Task<IEnumerable<Commit>> FetchCommits(string repositoryId);
    }
}

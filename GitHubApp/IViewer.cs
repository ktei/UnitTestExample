using System.Collections.Generic;

namespace GitHubApp
{
    public interface IViewer
    {
        void ViewCommits(IEnumerable<CommitDto> commits);
    }
}

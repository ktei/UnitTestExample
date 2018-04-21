using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubApp
{
    public class App
    {
        private readonly IGitHubClient _gitHubClient;
        private readonly IViewer _viewer;
        private readonly IMapper _mapper;
        
        public App(
            IGitHubClient gitHubClient,
            IViewer viewer,
            IMapper mapper
        )
        {
            _gitHubClient = gitHubClient;
            _viewer = viewer;
            _mapper = mapper;
        }

        public async Task<List<CommitDto>> ViewCommits(string repositoryId)
        {
            var commits = await _gitHubClient.FetchCommits(repositoryId);
            var commitDtos = _mapper.Map<IEnumerable<CommitDto>>(commits);

            _viewer.ViewCommits(commitDtos);

            return commitDtos.ToList();
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
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

        public async Task ViewCommits(string repositoryId)
        {
            var commits = await _gitHubClient.FetchCommits(repositoryId);
            var commitDtos = _mapper.Map<IEnumerable<CommitDto>>(commits);

            _viewer.ViewCommits(commitDtos);
        }
    }
}

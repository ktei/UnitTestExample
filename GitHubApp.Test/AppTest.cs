using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubApp.Test
{
    [TestFixture]
    class AppTest
    {
        private Mock<IViewer> _viewerMock;
        private Mock<IGitHubClient> _gitHubClientMock;
        private App _app;

        [SetUp]
        public void Setup()
        {
            _viewerMock = new Mock<IViewer>();
            _gitHubClientMock = new Mock<IGitHubClient>();
            var mapper = new MapperConfiguration(opts =>
            {
                opts.CreateMap<Commit, CommitDto>();
            }).CreateMapper();

            _app = new App(_gitHubClientMock.Object, _viewerMock.Object, mapper);
        }

        [Test]
        public async Task ViewCommits_ShouldOutputCommits()
        {
            // assign
            var repositoryId = Guid.NewGuid().ToString();
            var commits = new[]
            {
                new Commit
                {
                    RepositoryId = repositoryId,
                    DateCommitted = new DateTime(2018, 9, 15, 10, 0, 0),
                    CommitHash = "1234567",
                    Author = "Eddie",
                    Comment = "Fixed bug 1"
                }
            };
            _gitHubClientMock.Setup(x => x.FetchCommits(It.IsAny<string>())).ReturnsAsync(commits);

            // act
            var viewedCommits = await _app.ViewCommits(repositoryId);

            // assert
            viewedCommits.Should().HaveCount(1);
            viewedCommits[0].CommitHash.Should().Be("1234567");

            _gitHubClientMock.Verify(x => x.FetchCommits(repositoryId), Times.Once());
            _viewerMock.Verify(x => x.ViewCommits(It.Is<IEnumerable<CommitDto>>(y => y.First().CommitHash == commits[0].CommitHash)), Times.Once());
        }
    }
}

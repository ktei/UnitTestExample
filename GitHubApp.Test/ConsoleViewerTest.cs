using Moq;
using NUnit.Framework;
using System;

namespace GitHubApp.Test
{
    [TestFixture]
    class ConsoleViewerTest
    {
        private Mock<Action<string>> _writeActionMock;
        private ConsoleViewer _consoleViewer;

        [SetUp]
        public void Setup()
        {
            _writeActionMock = new Mock<Action<string>>();
            _consoleViewer = new ConsoleViewer(_writeActionMock.Object);
        }

        [Test]
        public void ViewCommits_ShouldOutputCommitsToConsoleWithProperFormat()
        {
            // assign
            var commits = new[]
            {
                new CommitDto
                {
                    DateCommited = new DateTime(2018, 9, 15, 10, 30, 0),
                    Comment = "Fixed bug 1",
                    CommitHash = "1234567",
                    Author = "Eddie"
                }
            };

            // act
            _consoleViewer.ViewCommits(commits);

            // assert
            _writeActionMock.Verify(x => x($"{Environment.NewLine}[15/09/2018 10:30]: [1234567] - Fixed bug 1 - Eddie"), Times.Once());
        }
    }
}

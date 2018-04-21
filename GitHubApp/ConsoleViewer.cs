using System;
using System.Collections.Generic;

namespace GitHubApp
{
    public class ConsoleViewer : IViewer
    {
        public delegate void WriteAction(string line);

        private readonly WriteAction _writeAction;

        public ConsoleViewer(WriteAction writeAction)
        {
            _writeAction = writeAction ?? throw new ArgumentNullException(nameof(writeAction));
        }

        public void ViewCommits(IEnumerable<CommitDto> commits)
        {
            foreach (var commit in commits)
            {
                var line = string.Format("{0}[{1}]: [{2}] - {3} - {4}",
                    Environment.NewLine,
                    commit.DateCommited.ToString("dd/MM/yyyy HH:mm"),
                    commit.CommitHash,
                    commit.Comment,
                    commit.Author);
                _writeAction(line);
            }
        }
    }
}

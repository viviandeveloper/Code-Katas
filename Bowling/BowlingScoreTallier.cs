using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDDKata1;

namespace Bowling
{
    public class BowlingScoreTallier
    {
        private readonly string _frames;

        private int _currentFrame;
        private string[] _frameScores;
        private int _total;
        private readonly IDictionary<int, int> _doubleFrameScoreForFrames;

        private BowlingScoreTallier(string frames)
        {
            _frames = frames;
            _doubleFrameScoreForFrames = new Dictionary<int, int>();
        }

        public static int TallyScore(string frames)
        {
            return new BowlingScoreTallier(frames).TallyScore();
        }

        private int TallyScore()
        {
            if (string.IsNullOrEmpty(_frames))
            {
                return 0;
            }

            SetFrameScores();

            TallyFrameScores();

            return _total;
        }

        private void SetFrameScores()
        {
            _frameScores = new string[_frames.Length];
            for (int i = 0; i < _frames.Length; i++)
            {
                _frameScores[i] = _frames[i].ToString();
            }
        }

        private void TallyFrameScores()
        {
            for (_currentFrame = 0; _currentFrame < _frameScores.Length; _currentFrame++)
            {
                AggregateTotal(_frameScores[_currentFrame]);
            }
        }

        private void AggregateTotal(string frameScore)
        {
            var currentFrameScore = GetFrameScore(frameScore);

            _total += CheckMultipliersAndGetTotalFrameScore(currentFrameScore);
        }

        private int GetFrameScore(string frameScore)
        {
            int result;
            if (int.TryParse(frameScore, out result))
            {
                if (result >= 0 ||
                    result <= 9)
                {
                    return result;
                }
            }
            if (FrameIsStrike(frameScore) ||
                FrameIsSpare(frameScore))
            {
                SetFrameDoubler(frameScore);
                return 10;
            }
            throw new ArgumentException();
        }

        private int CheckMultipliersAndGetTotalFrameScore(int result)
        {
            int multiplier = 1;
            if (_doubleFrameScoreForFrames.ContainsKey(_currentFrame))
            {
                multiplier += _doubleFrameScoreForFrames[_currentFrame];
            }
            return result*multiplier;
        }

        private void SetFrameDoubler(string frameScore)
        {
            if (!_doubleFrameScoreForFrames.ContainsKey(_currentFrame + 1))
            {
                _doubleFrameScoreForFrames.Add(_currentFrame + 1, 0);
            }
            _doubleFrameScoreForFrames[_currentFrame + 1]++;

            if (FrameIsStrike(frameScore))
            {
                if (!_doubleFrameScoreForFrames.ContainsKey(_currentFrame + 2))
                {
                    _doubleFrameScoreForFrames.Add(_currentFrame + 2, 0);
                }
                _doubleFrameScoreForFrames[_currentFrame + 2]++;
            }
        }

        private bool FrameIsStrike(string frameScore)
        {
            return StringComparer.InvariantCultureIgnoreCase.Compare("x", frameScore) == 0;
        }

        private bool FrameIsSpare(string frameScore)
        {
            return StringComparer.InvariantCultureIgnoreCase.Compare("/", frameScore) == 0;
        }
    }
}

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Diagnostics;

namespace Models
{
    public class Statistics : INotifyPropertyChanged
    {
        private readonly Stopwatch _stopwatch;
        public Stopwatch Stopwatch
        {
            get => _stopwatch;
        }
        
        private double _averageTweetsPerHour;
        public double AverageTweetsPerHour
        {
            get => _averageTweetsPerHour;
        }

        private double _averageTweetsPerMinute;
        public double AverageTweetsPerMinute
        {
            get => _averageTweetsPerMinute;
            set => _averageTweetsPerMinute = value;
        }

        private double _averageTweetsPerSecond;
        public double AverageTweetsPerSecond
        {
            get => _averageTweetsPerSecond;
            set => _averageTweetsPerSecond = value;
        }


        private readonly IDictionary<string, ulong> _emojis;
        public IDictionary<string, ulong> Emojis
        {
            get => _emojis;
        }
        
        private readonly IDictionary<string, ulong> _hashTags;
        public IDictionary<string, ulong> HashTags
        {
            get => _hashTags;
        }
        
        private readonly IDictionary<string, ulong> _urls;
        public IDictionary<string, ulong> Urls
        {
            get => _urls;
        }

        public ulong _numberOfTweetsThatContainEmojis;
        public ulong NumberOfTweetsThatContainEmojis
        {
            get => _numberOfTweetsThatContainEmojis;
            set => _numberOfTweetsThatContainEmojis = value;
        }

        private double _percentOfTweetsThatContainEmojis;
        public double PercentOfTweetsThatContainEmojis
        {
            get => _percentOfTweetsThatContainEmojis;
            set => _percentOfTweetsThatContainEmojis = value;
        }

        private ulong _numberOfTweetsThatContainUrl;
        public ulong NumberOfTweetsThatContainUrl
        {
            get => _numberOfTweetsThatContainUrl;
            set => _numberOfTweetsThatContainUrl = value;
        }

        private double _percentOfTweetsThatContainUrl;
        public double PercentOfTweetsThatContainUrl
        {
            get => _percentOfTweetsThatContainUrl;
            set => _percentOfTweetsThatContainUrl = value;
        }

        private ulong _numberOfTweetsThatContainPhotoUrl;
        public ulong NumberOfTweetsThatContainPhotoUrl
        {
            get => _numberOfTweetsThatContainPhotoUrl;
            set => _numberOfTweetsThatContainPhotoUrl = value;
        }

        private double _percentOfTweetsThatContainPhotoUrl;
        public double PercentOfTweetsThatContainPhotoUrl
        {
            get => _percentOfTweetsThatContainPhotoUrl;
            set => _percentOfTweetsThatContainPhotoUrl = value;
        }

        private ulong totalNumberOfTweetsReceived;
        public ulong TotalNumberOfTweetsReceived
        {
            get => totalNumberOfTweetsReceived;
            set
            {
                if (value != totalNumberOfTweetsReceived)
                {
                    totalNumberOfTweetsReceived = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public Statistics()
        {
            _stopwatch = Stopwatch.StartNew();
            _emojis = new Dictionary<string, ulong>();
            _hashTags = new Dictionary<string, ulong>();
            _urls = new Dictionary<string, ulong>();
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new(propertyName));

            if (nameof(TotalNumberOfTweetsReceived) == propertyName)
            {
                _averageTweetsPerHour = (double)TotalNumberOfTweetsReceived / (double)Stopwatch.Elapsed.TotalHours;
                _averageTweetsPerMinute = (double)TotalNumberOfTweetsReceived / (double)Stopwatch.Elapsed.TotalMinutes;
                _averageTweetsPerSecond = (double)TotalNumberOfTweetsReceived / (double)Stopwatch.Elapsed.TotalSeconds;
                _percentOfTweetsThatContainEmojis = ((double)NumberOfTweetsThatContainEmojis / (double)TotalNumberOfTweetsReceived) * 100;
                _percentOfTweetsThatContainUrl = ((double)NumberOfTweetsThatContainUrl / (double)TotalNumberOfTweetsReceived) * 100;
                _percentOfTweetsThatContainPhotoUrl = ((double)NumberOfTweetsThatContainPhotoUrl / (double)TotalNumberOfTweetsReceived) * 100;
            }
        }
    }
}

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Diagnostics;

namespace Models
{
    public class Statistics : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            if (nameof(TotalNumberOfTweetsReceived) == propertyName)
            {
                AverageTweetsPerHour = (double)TotalNumberOfTweetsReceived / (double)Stopwatch.Elapsed.TotalHours;
                AverageTweetsPerMinute = (double)TotalNumberOfTweetsReceived / (double)Stopwatch.Elapsed.TotalMinutes;
                AverageTweetsPerSecond = (double)TotalNumberOfTweetsReceived / (double)Stopwatch.Elapsed.TotalSeconds;
                PercentOfTweetsThatContainUrl = ((double)NumberOfTweetsThatContainUrl / (double)TotalNumberOfTweetsReceived) * 100;
                PercentOfTweetsThatContainPhotoUrl = ((double)NumberOfTweetsThatContainPhotoUrl / (double)TotalNumberOfTweetsReceived) * 100;
            }
        }

        public Stopwatch Stopwatch { get; set; }

        public double AverageTweetsPerHour { get; set; }

        public double AverageTweetsPerMinute { get; set; }

        public double AverageTweetsPerSecond { get; set; }

        public Dictionary<string, ulong> HashTags { get; }

        public Dictionary<string, ulong> Urls { get; }

        public ulong NumberOfTweetsThatContainUrl { get; set; }

        public double PercentOfTweetsThatContainUrl { get; set; }

        public ulong NumberOfTweetsThatContainPhotoUrl { get; set; }

        public double PercentOfTweetsThatContainPhotoUrl { get; set; }

        private ulong totalNumberOfTweetsReceived;
        public ulong TotalNumberOfTweetsReceived
        {
            get
            {
                return totalNumberOfTweetsReceived;
            }

            set
            {
                if (value != totalNumberOfTweetsReceived)
                {
                    totalNumberOfTweetsReceived = value;
                    NotifyPropertyChanged();
                }
            }
        }        

        public Statistics()
        {
            Stopwatch = Stopwatch.StartNew();
            HashTags = new Dictionary<string, ulong>();
            Urls = new Dictionary<string, ulong>();
        }
    }
}

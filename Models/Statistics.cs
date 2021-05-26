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
                PercentOfTweetsThatContainUrl = ((double)NumberOfTweetsThatContainUrl / (double)TotalNumberOfTweetsReceived) * 100;
            }
        }

        public Stopwatch Stopwatch { get; set; }

        public Dictionary<string, ulong> HashTags { get; }

        public Dictionary<string, ulong> Urls { get; }

        public ulong NumberOfTweetsThatContainUrl { get; set; }

        public double PercentOfTweetsThatContainUrl { get; set; }

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

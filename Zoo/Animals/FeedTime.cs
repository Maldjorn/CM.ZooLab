using System;

namespace Zoos.Animals
{
    public class FeedTime
    {
        public DateTime feedTime { get; private set; }
        public ZooKeeper feedByZooKeper { get; set; }

        public FeedTime(DateTime dateTime, ZooKeeper zooKeeper)
        {
            feedTime = dateTime;
            feedByZooKeper = zooKeeper;
        }
    }
}
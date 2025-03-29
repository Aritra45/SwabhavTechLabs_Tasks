using ObserverMethodDesignPattern.Channels;
using ObserverMethodDesignPattern.Subcriber;

internal class Program
{
    private static void Main(string[] args)
    {
        YoutubeChannel youtubeChannel = new YoutubeChannel();
        Subscribers subscribers1 = new Subscribers("Aritra");
        youtubeChannel.Subscribe(subscribers1);
        Subscribers subscribers2 = new Subscribers("Avishek");
        youtubeChannel.Subscribe(subscribers2);
        youtubeChannel.Notify();
    }
}
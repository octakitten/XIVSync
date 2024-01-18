
using System.Threading.Tasks;
using YoutubeExplode;
using System;
using System.IO;
using Dalamud.Utility;
using YoutubeExplode.Videos.Streams;
using Dalamud.Plugin;

namespace XIVSync.Video;

/*
 * This class handles downloading a video from a youtube url
 * and 
 */
public class Stream : IDisposable
{
    public DalamudPluginInterface pluginInterface;

    public Stream()
    {
        
    }
    
    public Stream(DalamudPluginInterface pluginInterface)
    {
        this.pluginInterface = pluginInterface;
    }
    
    public async Task Download(string url)
    {
        var youtube = new YoutubeClient();
        var video = await youtube.Videos.GetAsync(url);
        var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);
        var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
        if (streamInfo != null)
        {
            var stream = await youtube.Videos.Streams.GetAsync(streamInfo);
            
        }
    }
    public void Dispose()
    {
        
    }
}

public class AudioStream : Stream
{
    public AudioStream(DalamudPluginInterface pluginInterface)
    {
        this.pluginInterface = pluginInterface;
    }
}

public class VideoStream : Stream
{
    public VideoStream(DalamudPluginInterface pluginInterface)
    {
        this.pluginInterface = pluginInterface;
    }
}


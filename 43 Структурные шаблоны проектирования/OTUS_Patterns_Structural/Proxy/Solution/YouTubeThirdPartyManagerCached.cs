using System.Collections.Generic;
using YouTubeLibrary;

namespace Proxy.Solution
{
    public class YouTubeThirdPartyManagerCached : IYouTubeThirdPartyManager
    {
        private IYouTubeThirdPartyManager _youTubeThirdPartyManager;

        private Dictionary<int, VideoInfo> cache = new Dictionary<int, VideoInfo>();

        public YouTubeThirdPartyManagerCached(IYouTubeThirdPartyManager youTubeThirdPartyManager)
        {
            _youTubeThirdPartyManager = youTubeThirdPartyManager;
        }
        
        public VideoInfo GetVideoInfo(int id)
        {
            if (cache.ContainsKey(id))
            {
                return cache[id];
            }
            else
            {
                var videoInfo = _youTubeThirdPartyManager.GetVideoInfo(id);
                cache.Add(id, videoInfo);
                return videoInfo;
            }
        }
    }
}
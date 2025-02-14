using YouTubeLibrary;

namespace Proxy.Solution
{
    public class YouTubeManager 
    {
        private IYouTubeThirdPartyManager _youTubeThirdPartyManager;
        
        public YouTubeManager(IYouTubeThirdPartyManager youTubeThirdPartyManager)
        {
            _youTubeThirdPartyManager = youTubeThirdPartyManager;
        }
        
        public VideoInfo GetVideoInfo(int id)
        {
            return _youTubeThirdPartyManager.GetVideoInfo(id);
        }

        public void RenderVideoPage(int id)
        {
            var videoInfo = GetVideoInfo(id);
            Render(videoInfo);
        }

        public void Render(VideoInfo videoInfo)
        {
            //
        }
    }
}
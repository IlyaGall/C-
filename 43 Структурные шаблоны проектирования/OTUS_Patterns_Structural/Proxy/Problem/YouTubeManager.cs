using YouTubeLibrary;

namespace Proxy.Problem
{
    public class YouTubeManager
    {
        private YouTubeThirdPartyManager _youTubeThirdPartyManager;
        
        public YouTubeManager()
        {
            _youTubeThirdPartyManager = new YouTubeThirdPartyManager();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using  AMSServices.Models;


namespace AMSServices.Controllers
{
    public class VideosController : ApiController
    {

        Video[] videos= new Video[]
        {
            new Video{Id= 1, AssetName="ErikLive", Url= "http://erik.origin.mediaservices.windows.net/0406c135-3c65-45f9-a088-cce323cc55ee/617a9594-f351-4e23-9f1b-c133752cd182.ism/Manifest(format=m3u8-aapl)"},
            new Video {Id= 2, AssetName="Bugs", Url= "http://wams.edgesuite.net/media/MPTExpressionData02/BigBuckBunny_1080p24_IYUV_2ch.ism/manifest(format=m3u8-aapl)"}
        };


         public IEnumerable<Video> GetAllVideos()
        {
            return videos ;
        }

        public IHttpActionResult GetVideo(int id)
        {
            var video = videos.FirstOrDefault((p) => p.Id == id);
            if (video == null)
            {
                return NotFound();
            }
            return Ok(video);
        }


    }
}

using System;
using System.Threading.Tasks;
using CoreFoundation;
using Foundation;
using UIKit;
using XamarinChallenge.iOS.DownloadService;
using XamarinChallenge.Services;

[assembly: Xamarin.Forms.Dependency(typeof(DownloadService))]
namespace XamarinChallenge.iOS.DownloadService
{
    public class DownloadService: IDownloader
    {
        public DownloadService()   
        {

        }

        public Task<bool> DownloadImage(string url)
        {
            var tcs = new TaskCompletionSource<bool>();

            NSUrlSession session = NSUrlSession.SharedSession;
            var dataTask = session.CreateDataTask(new NSUrlRequest(new NSUrl(url)), (data, response, error) =>
            {
                // Do something with the downloaded image
                tcs.SetResult(response != null);
            });

            dataTask.Resume();

            return tcs.Task;
        }
    }
}

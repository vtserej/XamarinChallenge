using System.Threading.Tasks;

namespace XamarinChallenge.Services
{
    public interface IDownloader
    {
        Task<bool> DownloadImage(string url);

    }
}

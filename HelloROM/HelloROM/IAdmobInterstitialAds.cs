using System;
using System.Threading.Tasks;

namespace HelloROM
{
    public interface IAdmobInterstitialAds
    {
        Task Display(string adId);
    }
}

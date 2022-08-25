using LuckyDraw.Models;
using System.Threading.Tasks;

namespace LuckyDraw.Interfaces
{
    public interface IGift
    {
        Task<int> AddGift(GiftModel giftModel);
    }
}

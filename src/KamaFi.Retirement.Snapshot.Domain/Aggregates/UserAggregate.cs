using KamaFi.Retirement.Snapshot.Domain.Entities.Asset;
using KamaFi.Retirement.Snapshot.Domain.Entities.Liability;
using KamaFi.Retirement.Snapshot.Domain.Entities.User;

namespace KamaFi.Retirement.Snapshot.Domain.Aggregates
{
    public class UserAggregate
    {
        public UserEntity User { get; set; }

        public UserAggregate(UserEntity user)
        {
            User = user;
        }

        public void CreateAsset(AssetEntity asset)
        {
            User.CreateAsset(asset);
        }

        public void CreateLiability(LiabilityEntity liability)
        {
            User.CreateLiability(liability);
        }
    }
}

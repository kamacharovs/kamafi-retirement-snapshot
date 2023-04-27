using KamaFi.Retirement.Snapshot.Domain.Entities.Asset;
using KamaFi.Retirement.Snapshot.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamaFi.Retirement.Snapshot.Domain.Aggregates
{
    public class UserAggregate
    {
        public UserEntity User { get; set; }

        public void AddAsset(AssetEntity asset)
        {
            User.AddAsset(asset);
        }
    }
}

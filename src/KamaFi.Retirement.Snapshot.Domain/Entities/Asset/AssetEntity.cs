﻿using KamaFi.Retirement.Snapshot.Common.Entities;

namespace KamaFi.Retirement.Snapshot.Domain.Entities.Asset
{
    public class AssetEntity : EntityBase
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public decimal Value { get; set; }
        public string? UserId { get; set; }
    }
}
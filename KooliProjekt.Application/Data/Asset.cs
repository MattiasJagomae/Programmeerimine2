using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Data
{
    internal class Asset
    {
        public int Id { get; set; }

        public string Name { get; set; } = null;

        public string Description { get; set; }

        public string Symbol { get; set; } = null;

        public string Currency { get; set; } = null;

        public int AssetClassId { get; set; }

        public bool IsActive { get; set; } = true;

        public AssetClass AssetClass { get; set; } = null;

        public ICollection<Transaction> Transactions { get; set; }
            = new List<Transaction>();

        public ICollection<AssetMonthly> AssetMonthlies { get; set; }
            = new List<AssetMonthly>();
    }
}

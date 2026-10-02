using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Data
{
    internal class AssetMonthly
    {
        public int Id { get; set; }

        public int PortfolioId { get; set; }

        public int AssetId { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public decimal Quantity { get; set; }

        public decimal Value { get; set; }

        public decimal UnitValue { get; set; }

        public Portfolio Portfolio { get; set; } = null;

        public Asset Asset { get; set; } = null!;
    }
}

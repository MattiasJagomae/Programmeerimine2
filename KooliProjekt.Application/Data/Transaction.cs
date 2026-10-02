using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Data
{
    internal class Transaction
    {
        public int Id { get; set; }

        public int PortfolioId { get; set; }

        public int AssetId { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; } = null;

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Total { get; set; }

        public decimal Fees { get; set; }

        public Portfolio Portfolio { get; set; } = null;

        public Asset Asset { get; set; } = null;
    }
}

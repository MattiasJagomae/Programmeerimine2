using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Data
{
    internal class CashFlow
    {
        public int Id { get; set; }

        public int PortfolioId { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public string Type { get; set; } = null;

        public string Description { get; set; }

        public Portfolio Portfolio { get; set; } = null;
    }
}

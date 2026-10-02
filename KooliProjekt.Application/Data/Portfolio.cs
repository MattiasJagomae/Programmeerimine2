using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Data
{
    internal class Portfolio
    {
        public int Id { get; set; }

        public string Name { get; set; } = null;

        public DateTime StartDate { get; set; }

        public decimal InitialValue { get; set; }

        public decimal CurrentValue { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
            = new List<Transaction>();

        public ICollection<CashFlow> CashFlows { get; set; }
            = new List<CashFlow>();

        public ICollection<AssetMonthly> AssetMonthlies { get; set; }
            = new List<AssetMonthly>();
    }
}

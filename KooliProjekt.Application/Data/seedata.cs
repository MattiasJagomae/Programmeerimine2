using System;
using System.Collections.Generic;
using System.Linq;

namespace KooliProjekt.Application.Data
{
    public static class SeedData
    {
        public static void Generate(ApplicationDbContext context)
        {
            // Kontrollime andmete olemasolu EF Core Set<T>() abil, 
            // et me ei vajaks ApplicationDbContext-is eraldi DbSet omadusi.
            if (context.Set<Portfolio>().Any() ||
                context.Set<Asset>().Any() ||
                context.Set<AssetClass>().Any() ||
                context.Set<Transaction>().Any() ||
                context.Set<CashFlow>().Any() ||
                context.Set<AssetMonthly>().Any())
            {
                return;
            }

            SeedAssetClasses(context);
            SeedAssets(context);
            SeedPortfolios(context);
            SeedTransactions(context);
            SeedCashFlows(context);
            SeedAssetMonthlies(context);
        }

        private static void SeedAssetClasses(ApplicationDbContext context)
        {
            var names = new[]
            {
                "Stocks", "Bonds", "ETFs", "Cryptocurrency",
                "Commodities", "Real Estate", "Mutual Funds"
            };

            var classes = names.Select(name => new AssetClass
            {
                Name = name,
                Description = $"Investment category: {name}"
            }).ToList();

            for (int i = 8; i <= 35; i++)
            {
                classes.Add(new AssetClass
                {
                    Name = $"Investment Class {i}",
                    Description = $"Additional investment category {i}"
                });
            }

            context.Set<AssetClass>().AddRange(classes);
            context.SaveChanges();
        }

        private static void SeedAssets(ApplicationDbContext context)
        {
            var assetClasses = context.Set<AssetClass>().ToList();
            var stocksId = assetClasses.FirstOrDefault(c => c.Name == "Stocks")?.Id ?? assetClasses[0].Id;
            var bondsId = assetClasses.FirstOrDefault(c => c.Name == "Bonds")?.Id ?? assetClasses[0].Id;
            var etfsId = assetClasses.FirstOrDefault(c => c.Name == "ETFs")?.Id ?? assetClasses[0].Id;
            var cryptoId = assetClasses.FirstOrDefault(c => c.Name == "Cryptocurrency")?.Id ?? assetClasses[0].Id;
            var commoditiesId = assetClasses.FirstOrDefault(c => c.Name == "Commodities")?.Id ?? assetClasses[0].Id;
            var realEstateId = assetClasses.FirstOrDefault(c => c.Name == "Real Estate")?.Id ?? assetClasses[0].Id;
            var mutualFundsId = assetClasses.FirstOrDefault(c => c.Name == "Mutual Funds")?.Id ?? assetClasses[0].Id;

            var assetsData = new[]
            {
                ("Apple Inc.", "AAPL", "USD", stocksId),
                ("Microsoft Corporation", "MSFT", "USD", stocksId),
                ("NVIDIA Corporation", "NVDA", "USD", stocksId),
                ("Amazon.com Inc.", "AMZN", "USD", stocksId),
                ("Alphabet Inc.", "GOOGL", "USD", stocksId),
                ("Tesla Inc.", "TSLA", "USD", stocksId),
                ("Berkshire Hathaway", "BRK.B", "USD", stocksId),
                ("Coca-Cola Company", "KO", "USD", stocksId),
                ("Johnson & Johnson", "JNJ", "USD", stocksId),
                ("Visa Inc.", "V", "USD", stocksId),
                ("Mastercard Inc.", "MA", "USD", stocksId),
                ("PepsiCo Inc.", "PEP", "USD", stocksId),
                ("Procter & Gamble", "PG", "USD", stocksId),
                ("ASML Holding", "ASML", "EUR", stocksId),
                ("SAP SE", "SAP", "EUR", stocksId),
                ("Siemens AG", "SIE", "EUR", stocksId),
                ("Toyota Motor", "TM", "USD", stocksId),
                ("Novo Nordisk", "NVO", "USD", stocksId),
                ("Vanguard S&P 500 ETF", "VOO", "USD", etfsId),
                ("Vanguard Total Stock Market ETF", "VTI", "USD", etfsId),
                ("iShares Core MSCI World ETF", "IWDA", "USD", etfsId),
                ("Vanguard FTSE All-World ETF", "VWRA", "USD", etfsId),
                ("US Treasury Bonds", "UST", "USD", bondsId),
                ("German Government Bonds", "DEB", "EUR", bondsId),
                ("Estonian Government Bonds", "EEB", "EUR", bondsId),
                ("Bitcoin", "BTC", "USD", cryptoId),
                ("Ethereum", "ETH", "USD", cryptoId),
                ("Gold", "XAU", "USD", commoditiesId),
                ("Silver", "XAG", "USD", commoditiesId),
                ("Brent Crude Oil", "BRN", "USD", commoditiesId),
                ("Real Estate Fund", "REF", "EUR", realEstateId),
                ("European Property Fund", "EPF", "EUR", realEstateId),
                ("Global Equity Fund", "GEF", "USD", mutualFundsId),
                ("European Bond Fund", "EBF", "EUR", mutualFundsId),
                ("Emerging Markets Fund", "EMF", "USD", mutualFundsId)
            };

            var assets = assetsData.Select(item => new Asset
            {
                Name = item.Item1,
                Symbol = item.Item2,
                Currency = item.Item3,
                AssetClassId = item.Item4,
                Description = $"{item.Item1} investment asset",
                IsActive = true
            }).ToList();

            context.Set<Asset>().AddRange(assets);
            context.SaveChanges();
        }

        private static void SeedPortfolios(ApplicationDbContext context)
        {
            var portfolios = Enumerable.Range(1, 35)
                .Select(i => new Portfolio
                {
                    Name = $"Investment Portfolio {i}",
                    StartDate = new DateTime(2020, 1, 1).AddMonths(i - 1),
                    InitialValue = 10000m + i * 1500m,
                    CurrentValue = (10000m + i * 1500m) * (1m + i * 0.005m)
                })
                .ToList();

            context.Set<Portfolio>().AddRange(portfolios);
            context.SaveChanges();
        }

        private static void SeedTransactions(ApplicationDbContext context)
        {
            var portfolios = context.Set<Portfolio>().OrderBy(p => p.Id).ToList();
            var assets = context.Set<Asset>().OrderBy(a => a.Id).ToList();

            var transactions = new List<Transaction>();

            for (int i = 0; i < 70; i++)
            {
                var portfolio = portfolios[i % portfolios.Count];
                var asset = assets[i % assets.Count];

                decimal quantity = 5m + (i % 20);
                decimal unitPrice = 50m + (i % 100) * 3m;
                decimal fees = 2.50m;

                transactions.Add(new Transaction
                {
                    PortfolioId = portfolio.Id,
                    AssetId = asset.Id,
                    Date = new DateTime(2024, 1, 1).AddDays(i * 5),
                    Type = i % 2 == 0 ? "Buy" : "Sell",
                    Quantity = quantity,
                    UnitPrice = unitPrice,
                    Total = quantity * unitPrice,
                    Fees = fees
                });
            }

            context.Set<Transaction>().AddRange(transactions);
            context.SaveChanges();
        }

        private static void SeedCashFlows(ApplicationDbContext context)
        {
            var portfolios = context.Set<Portfolio>().OrderBy(p => p.Id).ToList();
            var cashFlows = new List<CashFlow>();

            for (int i = 0; i < 70; i++)
            {
                var portfolio = portfolios[i % portfolios.Count];
                decimal amount = 500m + (i % 10) * 250m;

                cashFlows.Add(new CashFlow
                {
                    PortfolioId = portfolio.Id,
                    Date = new DateTime(2024, 1, 1).AddDays(i * 4),
                    Amount = i % 2 == 0 ? amount : -amount,
                    Type = i % 2 == 0 ? "Deposit" : "Withdrawal",
                    Description = i % 2 == 0
                        ? "Monthly investment contribution"
                        : "Portfolio withdrawal"
                });
            }

            context.Set<CashFlow>().AddRange(cashFlows);
            context.SaveChanges();
        }

        private static void SeedAssetMonthlies(ApplicationDbContext context)
        {
            var portfolios = context.Set<Portfolio>().OrderBy(p => p.Id).ToList();
            var assets = context.Set<Asset>().OrderBy(a => a.Id).ToList();

            var monthlyRecords = new List<AssetMonthly>();

            foreach (var portfolio in portfolios)
            {
                for (int month = 1; month <= 12; month++)
                {
                    var asset = assets[(portfolio.Id + month - 2) % assets.Count];

                    decimal quantity = 10m + portfolio.Id * 0.5m;
                    decimal unitValue = 100m + month * 2m + portfolio.Id;

                    monthlyRecords.Add(new AssetMonthly
                    {
                        PortfolioId = portfolio.Id,
                        AssetId = asset.Id,
                        Year = 2025,
                        Month = month,
                        Quantity = quantity,
                        UnitValue = unitValue,
                        Value = quantity * unitValue
                    });
                }
            }

            context.Set<AssetMonthly>().AddRange(monthlyRecords);
            context.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Data
{
    internal class AssetClass
    {
        public int Id { get; set; }

        public string Name { get; set; } = null;

        public string Description { get; set; }

        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
    }
}

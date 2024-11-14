using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kassasystem.ProductFolder;

namespace Kassasystem.CampaignFolder
{
    public class Campaign
    {
        public string CampaignName { get; set; }
        public DateTime CampaignStartDate { get; set; }
        public DateTime CampaignEndDate { get; set; }
        public short CampaignDiscountPercent { get; set; }
        public List<Product> ProductsInCampaign { get; set; }

        public Campaign(string name, DateTime start, DateTime end, short discount, List<Product> productsInCampaign)
        {
            CampaignName = name;
            CampaignStartDate = start;
            CampaignEndDate = end;
            CampaignDiscountPercent = discount;
            ProductsInCampaign = productsInCampaign;
        }
    }
}

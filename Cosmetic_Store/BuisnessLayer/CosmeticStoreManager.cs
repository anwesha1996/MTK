using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;

namespace BuisnessLayer
{
    public class CosmeticStoreManager
    {
		private readonly CosmeticDetailsSave saveCosmeticDetails = new CosmeticDetailsSave();
		public void SaveCosDetail(CosmeticDetails cosmeticDetails)
		{

			saveCosmeticDetails.SaveCosDetails(cosmeticDetails);
		}

		public List<CosmeticDetails> GetDetails()
		{
			return saveCosmeticDetails.GetCosDetails();
		}
		public void UpdateDetails(CosmeticDetails cosmeticDetails)
		{
			saveCosmeticDetails.UpdateCosDetails(cosmeticDetails);
		}
		public void DeleteDetails(string id)
		{
			saveCosmeticDetails.DeleteDetails(id);
		}


	}
}

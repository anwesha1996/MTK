using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLayer
{
    public class CosmeticDetailsSave
    {
		private readonly DbContext.CosDetailsDBContext dbContext = new DbContext.CosDetailsDBContext();
		public List<CosmeticDetails> GetCosDetails()
		{
			List<CosmeticDetails> details = new List<CosmeticDetails>();
			try
			{
				details = dbContext.cosmeticDetails.ToList<CosmeticDetails>();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return details;
		}
		public void SaveCosDetails(CosmeticDetails cosmeticDetails)
		{
			try
			{
				dbContext.cosmeticDetails.Add(cosmeticDetails);

				this.dbContext.SaveChanges();
			}

			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		public void UpdateCosDetails(CosmeticDetails cosmeticDetails)
		{
			dbContext.Entry(cosmeticDetails).State = System.Data.Entity.EntityState.Modified;
			dbContext.SaveChanges();
		}

		public void DeleteDetails(string id)
		{
			CosmeticDetails cm = dbContext.cosmeticDetails.Find(id);
			dbContext.cosmeticDetails.Remove(cm);
			dbContext.SaveChanges();

		}



	}
}


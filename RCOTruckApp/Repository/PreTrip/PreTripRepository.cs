using RCOTruckApp.Models.DBContext;
using RCOTruckApp.Models.PreTrip;
using RCOTruckApp.ViewModels.PreTrip;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.Repository.PreTrip
{
    internal class PreTripRepository
    {
        RCOTruckDBContext rCOTruckDBContext = new RCOTruckDBContext();

        internal List<PreTripCheckListHistoryViewModel> GetAllPreTripCheckList(DateTime fromDate, DateTime toDate)
        {
            if (fromDate == null)
                fromDate = DateTime.Now;

            if (toDate == null)
                toDate = DateTime.Now;

            toDate = toDate.AddDays(1);
            string rmsUserID = StaticServices.UserService.LoggedInUserCredentials.rmsUserId;

            return rCOTruckDBContext.PreTripCheckLists.Where(x => x.CreatedDate >= fromDate && x.CreatedDate < toDate && x.rmsUserId == rmsUserID).Select(x => new PreTripCheckListHistoryViewModel
            {
                PreTripCheckListID = x.PreTripCheckListID,
                Date = x.CreatedDate,
                Trailer1Number = x.Trailer1Number,
                Trailer2Number = x.Trailer2Number,
                TruckNumber = x.TruckNumber,
                DriverName = x.DriverName
            }).ToList();
        }

        internal PreTripCheckList GetPreTripCheckListByID(int preTripCheckListID)
        {
            return rCOTruckDBContext.PreTripCheckLists.FirstOrDefault(x => x.PreTripCheckListID == preTripCheckListID);
        }

        internal bool AddPreTripCheckList(PreTripCheckList preTripCheckList)
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                rCOTruckDBContext.PreTripCheckLists.Add(preTripCheckList);
                rCOTruckDBContext.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                // handle the update exception
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                //StaticServices.LogService.LogException(methodName, ex.Message, StaticServices.UserService.LoggedInUser.UserID);
                return false;
            }
        }
    }
}

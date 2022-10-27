using RCOTruckApp.Models.PreTrip;
using RCOTruckApp.Repository.PreTrip;
using RCOTruckApp.ViewModels.PreTrip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.Services.PreTrip
{
    internal class PreTripService
    {
        PreTripRepository preTripRepository = new PreTripRepository();

        internal List<PreTripCheckListHistoryViewModel> GetAllPreTripCheckList(DateTime from, DateTime to)
        {
            return preTripRepository.GetAllPreTripCheckList(from, to);
        }

        internal PreTripCheckList GetPreTripCheckListByID(int preTripCheckListID)
        {
            return preTripRepository.GetPreTripCheckListByID(preTripCheckListID);
        }

        internal bool AddPreTripCheckList(AddPretripCheckListViewModel addPretripCheckListViewModel, List<string> lstPreTripCheckList)
        {
            //tblPreTripCheckList
            PreTripCheckList preTripCheckList = new PreTripCheckList();
            preTripCheckList.Remarks = addPretripCheckListViewModel.Remarks;
            preTripCheckList.OdoMeter = addPretripCheckListViewModel.OdoMeter;
            preTripCheckList.DriverName = addPretripCheckListViewModel.DriverName;
            preTripCheckList.Trailer1Number = addPretripCheckListViewModel.Trailer1Number;
            preTripCheckList.Trailer1ReeferHOS = addPretripCheckListViewModel.Trailer1ReeferHOS;
            preTripCheckList.Trailer2Number = addPretripCheckListViewModel.Trailer2Number;
            preTripCheckList.Trailer2ReeferHOS = addPretripCheckListViewModel.Trailer2ReeferHOS;
            preTripCheckList.TruckNumber = addPretripCheckListViewModel.TruckNumber;
            preTripCheckList.DriverSignature = addPretripCheckListViewModel.DriverSignature;
            preTripCheckList.MechanicSignature = addPretripCheckListViewModel.MechanicSignature;
            preTripCheckList.rmsUserId = StaticServices.UserService.LoggedInUserCredentials.rmsUserId;
            preTripCheckList.VersionRMSUserId = StaticServices.UserService.LoggedInUser.rmsUserId;
            preTripCheckList.Archived = false;
            preTripCheckList.CreatedDate = DateTime.Now;

            //get checkbox values from viewmodel and set into database object
            foreach (string chkListName in lstPreTripCheckList)
            {
                PropertyInfo propertyInfoPreTripCheckList = preTripCheckList.GetType().GetProperty(chkListName);
                PropertyInfo propertyInfoAddPretripCheckListViewModel = addPretripCheckListViewModel.GetType().GetProperty(chkListName);
                propertyInfoPreTripCheckList.SetValue(preTripCheckList, propertyInfoAddPretripCheckListViewModel.GetValue(addPretripCheckListViewModel));
            }

            return preTripRepository.AddPreTripCheckList(preTripCheckList);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOTruckApp.ViewModels.PreTrip
{
    internal class AddPretripCheckListViewModel 
    {
        /// <summary>
        ///     UserID
        /// </summary>
        public int UserID { get; set; }

        //Truck/tractor
        public string OdoMeter { get; set; }
        public string TruckNumber { get; set; }
        public bool AirCompressor { get; set; }
        public bool AirLines { get; set; }
        public bool Battery { get; set; }
        public bool BreakAccessories { get; set; }
        public bool Carburetor { get; set; }
        public bool Clutch { get; set; }
        public bool Defroster { get; set; }
        public bool DriveLine { get; set; }
        public bool FifthWheel { get; set; }
        public bool FrontAxie { get; set; }
        public bool FuelTanks { get; set; }
        public bool OilPressure { get; set; }
        public bool OnBoardRecorder { get; set; }
        public bool Radiator { get; set; }
        public bool RearEnd { get; set; }
        public bool Reflectors { get; set; }
        public bool SafetyEquipment { get; set; }
        public bool Springs { get; set; }
        public bool Starter { get; set; }
        public bool Tachograph { get; set; }
        public bool Transmission { get; set; }
        public bool Windows { get; set; }
        public bool WindShieldWipers { get; set; }
        public bool Others { get; set; }
        public bool Breaks { get; set; }
        public bool Heater { get; set; }
        public bool Horns { get; set; }
        public bool Mirros { get; set; }
        public bool Steering { get; set; }
        public bool Tires { get; set; }
        public bool Wheels { get; set; }


        #region Trailer 1

        public string Trailer1Number { get; set; }
        public string Trailer1ReeferHOS { get; set; }
        public bool Trailer1BreakConnections { get; set; }
        public bool Trailer1Breaks { get; set; }
        public bool Trailer1CouplingPin { get; set; }
        public bool Trailer1CouplingChains { get; set; }
        public bool Trailer1Doors { get; set; }
        public bool Trailer1Hitch { get; set; }
        public bool Trailer1LandingGear { get; set; }
        public bool Trailer1LightsAll { get; set; }
        public bool Trailer1Roof { get; set; }
        public bool Trailer1Springs { get; set; }
        public bool Trailer1Tarpaulin { get; set; }
        public bool Trailer1Tires { get; set; }
        public bool Trailer1Wheels { get; set; }
        public bool Trailer1Other { get; set; }

        #endregion


        #region Trailer 2

        public string Trailer2Number { get; set; }
        public string Trailer2ReeferHOS { get; set; }
        public bool Trailer2BreakConnections { get; set; }
        public bool Trailer2Breaks { get; set; }
        public bool Trailer2CouplingPin { get; set; }
        public bool Trailer2CouplingChains { get; set; }
        public bool Trailer2Doors { get; set; }
        public bool Trailer2Hitch { get; set; }
        public bool Trailer2LandingGear { get; set; }
        public bool Trailer2LightsAll { get; set; }
        public bool Trailer2Roof { get; set; }
        public bool Trailer2Springs { get; set; }
        public bool Trailer2Tarpaulin { get; set; }
        public bool Trailer2Tires { get; set; }
        public bool Trailer2Wheels { get; set; }
        public bool Trailer2Other { get; set; }

        #endregion

        //Remarks
        public string Remarks { get; set; }
        public bool ConditionSatisfactory { get; set; }
        public bool Registration { get; set; }
        public bool Insurance { get; set; }


        //Driver
        public string DriverName { get; set; }
        public bool DefecetsCorrected { get; set; }
        public bool DefecetsNoCorrectionNeed { get; set; }
        public byte[] DriverSignature { get; set; }


        //Mechanic signature
        public byte[] MechanicSignature { get; set; }
    }
}

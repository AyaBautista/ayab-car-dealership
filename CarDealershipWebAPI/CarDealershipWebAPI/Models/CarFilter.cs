namespace CarDealershipWebAPI.Models
{
    public class CarFilter
    {
        public string Color { get; set; }
        public bool HasSunroof { get; set; }
        public bool IsFourWheelDrive { get; set; }
        public bool HasLowMiles { get; set; }
        public bool HasPowerWindows { get; set; }
        public bool HasNavigation { get; set; }
        public bool HasHeatedSeats { get; set; }
        public bool ShowExactMatches { get; set; }
    }
}
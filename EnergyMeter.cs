using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome
{
    public class EnergyMeter
    {
        private int _limit;
        private int _used;

        public int Limit
        {
            get { return _limit; }
        }
        public int Used
        {
            get { return _used; }
        }

        public EnergyMeter(int limit)
        {
            _limit = limit;
            _used = 0;
        }

        public bool Run(Device device, int hours)
        {
            int consumption = device.Consumption(hours);
            if (_used + consumption > _limit)
            {
                device.TurnOff();
                return false;
               
            }
            _used += consumption;
            return true;
        }

        public int Remaining()
        { 
            return _limit - _used;
        }
    }
}

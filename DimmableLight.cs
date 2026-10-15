using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome
{
    public class DimmableLight : Device
    {
        private int _brightness;

        public int Brightness
        {
            get { return _brightness; }
            set
            {
                if (value < 0 || value > 100)
                {
                    _brightness = 0;
                }
                _brightness = value;
            }
        }

        public DimmableLight(string name, int brightness) : base(name)
        {
            Brightness = brightness;
        }

        public override int PowerUsage()
        {
            return Brightness / 10;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}, fényerő: {Brightness}%";
        }
    }
}

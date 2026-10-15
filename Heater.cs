using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome
{
    public class Heater : Device
    {

        private bool _isWindowOpen;
       
        private int _targetTemperature;
        public int TargetTemperature
        {
            get { return _targetTemperature; }
            set
            {
                if (value < 5 || value > 30)
                {
                    _targetTemperature = 20;
                }
                else
                {
                    _targetTemperature = value;
                }
            }
        }
        public bool IsWindowOpen
        {
            get { return _isWindowOpen; }
        }

        public Heater(string name, int targetTemperature) : base(name)
        {
            TargetTemperature = targetTemperature;
        }

        public override int PowerUsage()
        {
            return TargetTemperature * 100;
        }
        public override string GetDescription()
        {
            return $"{base.GetDescription()}, {TargetTemperature}°C";
        }

        public void OpenWindow()
        {
            _isWindowOpen = true;
            base.TurnOff();
        }
        public void CloseWindow()
        {
            _isWindowOpen = false;
        }
        public override bool TurnOn()
        {
            if (_isWindowOpen)
            {
                return false;
            }
            return base.TurnOn();
        }
    }
}

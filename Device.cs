using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SmartHome
{
    public abstract class Device
    {
        // prperties
        private string _name;
        private bool _isOn;
        private static int _count;

        public static int Count
        {
            get { return _count; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool IsOn
        {
            get { return _isOn; }
        }

        // constructor
        public Device(string name)
        {
            _name = name;
            _isOn = false;
            _count++;
        }

        //methods

        public virtual bool TurnOn()
        {
            if (!_isOn)
            {
                _isOn = true;
                return true;
            }
            return false;
        }

        public virtual bool TurnOff()
        {
            if (_isOn)
            {
                _isOn = false;
                return true;
            }
            return false;
        }
        public virtual string GetDescription()
        {
            return $"{_name} ({(_isOn ? "be" : "ki")})";
        }
        public abstract int PowerUsage();

        public int Consumption(int hours)
        {
            if (_isOn == false)
            {
                return 0;
            }
            else
            {
                return PowerUsage() * hours;
            }
        }



        public static Device MoreConsuming(Device first, Device second, int hours)
        {
            if (first.Consumption(hours) > second.Consumption(hours))
            {
                return first;
            }
            else if(first.Consumption(hours) == second.Consumption(hours))
            {
                return null;
            }
            else
            {
                return second;
            }
        }
    }
}

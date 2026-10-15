using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome
{
    public class Fridge : Device
    {
        private bool _isEcoMode;
        public bool IsEcoMode
        {
            get { return _isEcoMode; }
            set { _isEcoMode = value; }
        }

        public Fridge(string name, bool isEcoMode) : base(name)
        {
            IsEcoMode = isEcoMode;
            base.TurnOn();
        }

        public override int PowerUsage()
        {
            return IsEcoMode ? 100 : 150;
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}, {(IsEcoMode ? "Eco Mode" : "Normál mód")}";
        }

        public override bool TurnOff()
        {
            return false;
        }
    }
}

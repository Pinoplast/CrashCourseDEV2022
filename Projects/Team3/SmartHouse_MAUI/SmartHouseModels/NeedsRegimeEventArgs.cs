using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseModels
{
    public enum NeedsRegime { Normal, NeedWarm, NeedCool, NeedOutFire }

    public class NeedsRegimeEventArgs : EventArgs
    {
        public NeedsRegime NeedsRegime { get; set; }
    }
}

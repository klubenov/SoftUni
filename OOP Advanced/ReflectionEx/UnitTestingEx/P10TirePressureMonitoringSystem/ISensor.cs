using System;
using System.Collections.Generic;
using System.Text;

namespace P10TirePressureMonitoringSystem
{
    public interface ISensor
    {
        double PopNextPressurePsiValue();
    }
}

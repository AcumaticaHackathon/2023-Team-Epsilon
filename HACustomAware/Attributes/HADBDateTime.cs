using PX.Data;
using System;

namespace HA.Objects.Summit2023.Epsilon.CustomAware {

    [PXDBDate(UseSmallDateTime = false, PreserveTime = true, UseTimeZone = true)]
    [PXUIField(Enabled = false, IsReadOnly = true)]
    [Serializable]
    public class HADBDateTime : HAAggregateAttribute {
    }
}

using PX.Data;
using System;

namespace HA.Objects.Summit2023.Epsilon.CustomAware {

    [PXDBGuid(false)]
    [PXUIField(Enabled = false, IsReadOnly = true)]
    [Serializable]
    public class HADBByIDAttribute : HAAggregateAttribute {
    }
}

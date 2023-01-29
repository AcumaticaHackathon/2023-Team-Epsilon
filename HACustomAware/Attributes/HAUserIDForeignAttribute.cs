using PX.Data;
using PX.SM;

namespace HA.Objects.Summit2023.Epsilon.CustomAware {

    [PXDBGuid(false)]
    [PXUIField(DisplayName = "User", Visibility = PXUIVisibility.Visible)]
    [PXSelector(typeof(Search<Users.pKID>),
                DescriptionField = typeof(Users.username),
                SubstituteKey = typeof(Users.username), ValidateValue = false)]
    public class HAUserIDForeignAttribute : HAAggregateAttribute {
    }
}

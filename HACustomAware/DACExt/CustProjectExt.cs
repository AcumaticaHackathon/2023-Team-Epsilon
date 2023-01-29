using PX.Data;
using PX.SM;

namespace HA.Objects.Summit2023.Epsilon.CustomAware {
    public class CustProjectExt : PXCacheExtension<CustProject> {

        #region UsrAuthorEmail
        [PXDBString(255)]
        [PXUIField(DisplayName = "Author Email")]
        public virtual string UsrAuthorEmail { get; set; }
        public abstract class usrAuthorEmail : PX.Data.BQL.BqlString.Field<usrAuthorEmail> { }
        #endregion

        #region UsrAuthorName
        [PXDBString(255)]
        [PXUIField(DisplayName = "Author Name")]
        public virtual string UsrAuthorName { get; set; }
        public abstract class usrAuthorName : PX.Data.BQL.BqlString.Field<usrAuthorName> { }
        #endregion

        #region UsrAuthorComments
        [PXDBText]
        [PXUIField(DisplayName = "Author Comments")]
        public virtual string UsrAuthorComments { get; set; }
        public abstract class usrAuthorComments : PX.Data.BQL.BqlString.Field<usrAuthorComments> { }
        #endregion

        #region UsrAuthorPhone
        public abstract class usrAuthorPhone : PX.Data.BQL.BqlString.Field<usrAuthorPhone> { }
        [PXDBString(15, IsUnicode = true)]
        [PXUIField(DisplayName = "Author Phone")]
        public virtual string UsrAuthorPhone { get; set; }
        #endregion
    }
}

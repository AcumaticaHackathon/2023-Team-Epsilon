using PX.Data;
using PX.Objects;
using PX.SM;
using System;

// todo: can't reference PX.SM.CustProject using visual studio project
// all this is inline code on the package.


namespace HACustomAware.DACExt
{
   // public class CustProjectExt : PXCacheExtension<PX.SM.CustProject>
    public class CustProjectExt : PXCacheExtension<CustProject>
    {
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
        [PXDBString(512)]
        [PXUIField(DisplayName = "Author Comments")]

        public virtual string UsrAuthorComments { get; set; }
        public abstract class usrAuthorComments : PX.Data.BQL.BqlString.Field<usrAuthorComments> { }
        #endregion

        #region UsrAuthorPhone
        [PXDBString(4000)]
        [PXUIField(DisplayName = "Author Phone")]
        public virtual string UsrAuthorPhone { get; set; }
        public abstract class usrAuthorPhone : PX.Data.BQL.BqlString.Field<usrAuthorPhone> { }
        #endregion
    }
}


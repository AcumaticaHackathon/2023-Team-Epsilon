using PX.Data.BQL;
using PX.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data.ReferentialIntegrity.Attributes;
using System.Diagnostics;
using PX.SM;

namespace HA.Objects.Summit2023.Epsilon.CustomAware {

    [Serializable]
    [PXPrimaryGraph(typeof(HAPublishHistoryMaint))]
    [PXCacheName(HAMessages.HADACName.HAPublishHistory)]
    [DebuggerDisplay("Barcode: {Name} ({Description})")]
    public class HAPublishHistory : IBqlTable, INotable {

        #region Keys
        public class PK : PrimaryKeyOf<HAPublishHistory>.By<recordID> {
            public static HAPublishHistory Find(PXGraph graph, int? recordID) => FindBy(graph, recordID);
        }
        public static class FK {
            public class User : Users.PK.ForeignKeyOf<HAPublishHistory>.By<userID> { }
        }
        #endregion

        #region RecordID
        public abstract class recordID : BqlInt.Field<recordID> { }
        [PXDBIdentity(IsKey = true)]
        [PXUIField(DisplayName = "Record ID", Visibility = PXUIVisibility.SelectorVisible)]
        [PXSelector(typeof(Search<recordID, Where<True, Equal<True>>, OrderBy<Desc<recordID>>>))]
        public virtual int? RecordID { get; set; }
        #endregion

        #region UserID
        public abstract class userID : BqlGuid.Field<userID> { }
        [HAUserIDForeign]
        [PXForeignReference(typeof(FK.User))]
        public virtual Guid? UserID { get; set; }
        #endregion

        #region TenantId
        public abstract class tenantId : BqlString.Field<tenantId> { }
        [PXDBString(255)]
        [PXUIField(DisplayName = "Tenant", IsReadOnly = true)]
        public string TenantId { get; set; }
        #endregion

        #region NoteID
        public abstract class noteID : BqlGuid.Field<noteID> { }
        [PXNote]
        public virtual Guid? NoteID { get; set; }
        #endregion

        #region CreatedByID
        public abstract class createdByID : BqlGuid.Field<createdByID> { }
        [PXDBCreatedByID]
        public virtual Guid? CreatedByID { get; set; }
        #endregion

        #region CreatedByScreenID
        public abstract class createdByScreenID : BqlString.Field<createdByScreenID> { }
        [PXDBCreatedByScreenID]
        [PXUIField(DisplayName = "Screen ID", Enabled = false)]
        public virtual string CreatedByScreenID { get; set; }
        #endregion

        #region CreatedDateTime
        public abstract class createdDateTime : BqlDateTime.Field<createdDateTime> { }
        [PXDBCreatedDateTime()]
        [PXUIField(DisplayName = PXDBLastModifiedByIDAttribute.DisplayFieldNames.CreatedDateTime, Visibility = PXUIVisibility.SelectorVisible, Enabled = false)]
        public virtual DateTime? CreatedDateTime { get; set; }
        #endregion

        #region LastModifiedByID
        public abstract class lastModifiedByID : BqlGuid.Field<lastModifiedByID> { }
        [PXDBLastModifiedByID]
        public virtual Guid? LastModifiedByID { get; set; }
        #endregion

        #region LastModifiedByScreenID
        public abstract class lastModifiedByScreenID : BqlString.Field<lastModifiedByScreenID> { }
        [PXDBLastModifiedByScreenID]
        public virtual string LastModifiedByScreenID { get; set; }
        #endregion

        #region LastModifiedDateTime
        public abstract class lastModifiedDateTime : BqlDateTime.Field<lastModifiedDateTime> { }
        [PXDBLastModifiedDateTime]
        [PXUIField(DisplayName = PXDBLastModifiedByIDAttribute.DisplayFieldNames.LastModifiedDateTime, Enabled = false)]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        #endregion

        #region tstamp
        public abstract class Tstamp : BqlByteArray.Field<Tstamp> { }
        [PXDBTimestamp]
        public virtual byte[] tstamp { get; set; }
        #endregion
    }
}

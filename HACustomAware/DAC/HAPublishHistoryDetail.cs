using PX.Data;
using PX.Data.BQL;
using PX.Data.ReferentialIntegrity.Attributes;
using PX.SM;
using System;
using System.Diagnostics;

namespace HA.Objects.Summit2023.Epsilon.CustomAware {

    [Serializable]
    [PXCacheName(HAMessages.HADACName.HAPublishHistoryDetail)]
    [DebuggerDisplay("PublishHistoryDetail: {ProjID} ({Description})")]
    public class HAPublishHistoryDetail : IBqlTable, INotable, ISortOrder {

        #region Keys
        public class PK : PrimaryKeyOf<HAPublishHistoryDetail>.By<recordID, lineNbr> {
            public static HAPublishHistoryDetail Find(PXGraph graph, int? recordID, int? lineNbr) => FindBy(graph, recordID, lineNbr);
        }
        public static class FK {
            public class Parent : HAPublishHistory.PK.ForeignKeyOf<HAPublishHistoryDetail>.By<recordID> { }
            public class CustProj : CustProject.PK.ForeignKeyOf<HAPublishHistoryDetail>.By<projID> { }
        }
        #endregion

        #region RecordID
        public abstract class recordID : BqlInt.Field<recordID> { }
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Record ID", Visibility = PXUIVisibility.SelectorVisible)]
        [PXParent(typeof(FK.Parent))]
        [PXDefault(typeof(HAPublishHistory.recordID))]
        public virtual int? RecordID { get; set; }
        #endregion

        #region LineNbr
        public abstract class lineNbr : BqlInt.Field<lineNbr> { }
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Line Nbr.", Visible = false)]
        [PXLineNbr(typeof(HAPublishHistory))]
        public virtual int? LineNbr { get; set; }
        #endregion

        #region SortOrder
        public abstract class sortOrder : BqlInt.Field<sortOrder> { }
        [PXUIField(DisplayName = "Line Order", Visible = false, Enabled = false)]
        [PXDBInt]
        public virtual int? SortOrder { get; set; }
        #endregion

        #region ProjID
        public abstract class projID : BqlGuid.Field<projID> { }
        [PXDBGuid(false)]
        [PXDefault]
        [PXUIField(Visibility = PXUIVisibility.Visible)]
        [PXParent(typeof(FK.CustProj))]
        [PXSelector(typeof(Search<CustProject.projID>),
            DescriptionField = typeof(CustProject.description),
            CacheGlobal = true)]
        public virtual Guid? ProjID { get; set; }
        #endregion

        #region Description
        public abstract class description : BqlString.Field<description> { }
        [PXDBString(256)]
        [PXUIField(DisplayName = "Description", Visibility = PXUIVisibility.SelectorVisible)]
        [PX.Data.EP.PXFieldDescription]
        public virtual string Description { get; set; }
        #endregion

        #region DevelopedBy
        [PXDBString(60, IsUnicode = true)]
        public virtual string DevelopedBy { get; set; }
        #endregion

        #region IsPublished
        [PXDBBool]
        [PXUIField(DisplayName = "Published", Enabled = false)]
        public bool? IsPublished { get; set; }
        #endregion

        #region IsWorking
        [PXDBBool]
        [PXDefault(false)]
        [PXUIField(DisplayName = "Selected")]
        public virtual bool? IsWorking { get; set; }
        #endregion

        #region CustCreatedByID
        [HADBByID(DisplayName = "Cust. Imported By")]
        public virtual Guid? CustCreatedByID { get; set; }
        #endregion

        #region CustCreatedDateTime
        [HADBDateTime(DisplayName = "Cust. Imported On")]
        public virtual DateTime? CustCreatedDateTime { get; set; }
        #endregion

        #region CustLastModifiedByID
        [HADBByID(DisplayName = "Cust. Modified By")]
        public virtual Guid? CustLastModifiedByID { get; set; }
        #endregion

        #region CustLastModifiedDateTime
        [HADBDateTime(DisplayName = "Cust. Modified On")]
        public virtual DateTime? CustLastModifiedDateTime { get; set; }
        #endregion

        #region ScreenNames
        [PXDBText]
        [PXUIField(DisplayName = "Screen Names", Visibility = PXUIVisibility.SelectorVisible, Enabled = false)]
        public string ScreenNames { get; set; }
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
        [PXDBCreatedDateTime]
        [PXUIField(DisplayName = PXDBLastModifiedByIDAttribute.DisplayFieldNames.CreatedDateTime, Enabled = false)]
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

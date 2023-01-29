using PX.Data;
using PX.Data.SQLTree;
using System;
using System.Collections.Generic;

namespace HA.Objects.Summit2023.Epsilon.CustomAware {
    /// <summary>
    /// This is a Generic Attribute that Aggregates other attributes and exposes there public properties.
    /// The Attributes aggregated can be of the following types:
    /// - DBFieldAttribute such as PXBDInt, PXDBString, etc.
    /// - PXUIFieldAttribute
    /// - PXSelectorAttribute
    /// - PXDefaultAttribute
    /// </summary>
    public class HAAggregateAttribute : PXAggregateAttribute, IPXInterfaceField, IPXCommandPreparingSubscriber, IPXRowSelectingSubscriber {

        protected int _DBAttrIndex = -1;
        protected int _NonDBAttrIndex = -1;
        protected int _UIAttrIndex = -1;
        protected int _SelAttrIndex = -1;
        protected int _DefAttrIndex = -1;

        public HAAggregateAttribute() {
            Initialize();
            Filterable = true;
        }

        public Type BqlField {
            get {
                PXDBFieldAttribute dBAttribute = DBAttribute;
                if (dBAttribute != null) {
                    return dBAttribute.BqlField;
                }
                return null;
            }
            set {
                DBAttribute.BqlField = value;
                BqlTable = DBAttribute.BqlTable;
            }
        }

        public virtual bool CacheGlobal {
            get {
                PXSelectorAttribute selectorAttribute = SelectorAttribute;
                if (selectorAttribute != null) {
                    return selectorAttribute.CacheGlobal;
                }
                return false;
            }
            set {
                if (SelectorAttribute != null) {
                    SelectorAttribute.CacheGlobal = value;
                }
            }
        }

        protected PXDBFieldAttribute DBAttribute {
            get {
                if (_DBAttrIndex == -1) {
                    return null;
                }
                return (PXDBFieldAttribute)_Attributes[_DBAttrIndex];
            }
        }

        protected PXDefaultAttribute DefaultAttribute {
            get {
                if (_DefAttrIndex == -1) {
                    return null;
                }
                return (PXDefaultAttribute)_Attributes[_DefAttrIndex];
            }
        }

        public virtual Type DescriptionField {
            get {
                PXSelectorAttribute selectorAttribute = SelectorAttribute;
                if (selectorAttribute != null) {
                    return selectorAttribute.DescriptionField;
                }
                return null;
            }
            set {
                if (SelectorAttribute != null) {
                    SelectorAttribute.DescriptionField = value;
                }
            }
        }

        public virtual bool DirtyRead {
            get {
                PXSelectorAttribute selectorAttribute = SelectorAttribute;
                if (selectorAttribute != null) {
                    return selectorAttribute.DirtyRead;
                }
                return false;
            }
            set {
                if (SelectorAttribute != null) {
                    SelectorAttribute.DirtyRead = value;
                }
            }
        }

        public string DisplayName {
            get {
                PXUIFieldAttribute uIAttribute = UIAttribute;
                if (uIAttribute != null) {
                    return uIAttribute.DisplayName;
                }
                return null;
            }
            set {
                if (UIAttribute != null) {
                    UIAttribute.DisplayName = value;
                }
            }
        }

        public bool Enabled {
            get {
                PXUIFieldAttribute uIAttribute = UIAttribute;
                if (uIAttribute != null) {
                    return uIAttribute.Enabled;
                }
                return true;
            }
            set {
                if (UIAttribute != null) {
                    UIAttribute.Enabled = value;
                }
            }
        }

        public bool IsReadOnly {
            get {
                PXUIFieldAttribute uIAttribute = UIAttribute;
                if (uIAttribute != null) {
                    return uIAttribute.IsReadOnly;
                }
                return false;
            }
            set {
                if (UIAttribute != null) {
                    UIAttribute.IsReadOnly = value;
                }
            }
        }

        public virtual PXErrorHandling ErrorHandling {
            get {
                PXUIFieldAttribute uIAttribute = UIAttribute;
                if (uIAttribute != null) {
                    return uIAttribute.ErrorHandling;
                }
                return PXErrorHandling.WhenVisible;
            }
            set {
                if (UIAttribute != null) {
                    UIAttribute.ErrorHandling = value;
                }
            }
        }

        public PXErrorLevel ErrorLevel {
            get {
                IPXInterfaceField pXInterfaceField = PXInterfaceField;
                if (pXInterfaceField != null) {
                    return pXInterfaceField.ErrorLevel;
                }
                return PXErrorLevel.Undefined;
            }
            set {
                if (PXInterfaceField != null) {
                    PXInterfaceField.ErrorLevel = value;
                }
            }
        }

        public string ErrorText {
            get {
                IPXInterfaceField pXInterfaceField = PXInterfaceField;
                if (pXInterfaceField != null) {
                    return pXInterfaceField.ErrorText;
                }
                return null;
            }
            set {
                if (PXInterfaceField != null) {
                    PXInterfaceField.ErrorText = value;
                }
            }
        }

        public object ErrorValue {
            get {
                IPXInterfaceField pXInterfaceField = PXInterfaceField;
                if (pXInterfaceField != null) {
                    return pXInterfaceField.ErrorValue;
                }
                return null;
            }
            set {
                if (PXInterfaceField != null) {
                    PXInterfaceField.ErrorValue = value;
                }
            }
        }

        public string FieldClass {
            get {
                PXUIFieldAttribute uIAttribute = UIAttribute;
                if (uIAttribute != null) {
                    return uIAttribute.FieldClass;
                }
                return null;
            }
            set {
                if (UIAttribute != null) {
                    UIAttribute.FieldClass = value;
                }
            }
        }

        public new string FieldName {
            get {
                PXDBFieldAttribute dBAttribute = DBAttribute;
                if (dBAttribute != null) {
                    return dBAttribute.FieldName;
                }
                return null;
            }
            set {
                DBAttribute.FieldName = value;
            }
        }

        public virtual bool Filterable {
            get {
                PXSelectorAttribute selectorAttribute = SelectorAttribute;
                if (selectorAttribute != null) {
                    return selectorAttribute.Filterable;
                }
                return false;
            }
            set {
                if (SelectorAttribute != null) {
                    SelectorAttribute.Filterable = value;
                }
            }
        }

        public bool IsDBField { get; set; } = true;

        public bool IsFixed {
            get {
                PXDBStringAttribute dBAttribute = (PXDBStringAttribute)DBAttribute;
                if (dBAttribute != null) {
                    return dBAttribute.IsFixed;
                }
                return false;
            }
            set {
                ((PXDBStringAttribute)DBAttribute).IsFixed = value;
                if (NonDBAttribute != null) {
                    ((PXStringAttribute)NonDBAttribute).IsFixed = value;
                }
            }
        }

        public bool IsKey {
            get {
                PXDBFieldAttribute dBAttribute = DBAttribute;
                if (dBAttribute != null) {
                    return dBAttribute.IsKey;
                }
                return false;
            }
            set {
                DBAttribute.IsKey = value;
            }
        }

        public PXCacheRights MapEnableRights {
            get {
                IPXInterfaceField pXInterfaceField = PXInterfaceField;
                if (pXInterfaceField != null) {
                    return pXInterfaceField.MapEnableRights;
                }
                return PXCacheRights.Select;
            }
            set {
                if (PXInterfaceField != null) {
                    PXInterfaceField.MapEnableRights = value;
                }
            }
        }

        public PXCacheRights MapViewRights {
            get {
                IPXInterfaceField pXInterfaceField = PXInterfaceField;
                if (pXInterfaceField != null) {
                    return pXInterfaceField.MapViewRights;
                }
                return PXCacheRights.Select;
            }
            set {
                if (PXInterfaceField != null) {
                    PXInterfaceField.MapViewRights = value;
                }
            }
        }

        protected PXEventSubscriberAttribute NonDBAttribute {
            get {
                if (_NonDBAttrIndex == -1) {
                    return null;
                }
                return _Attributes[_NonDBAttrIndex];
            }
        }

        public virtual PXPersistingCheck PersistingCheck {
            get {
                PXDefaultAttribute defaultAttribute = DefaultAttribute;
                if (defaultAttribute != null) {
                    return defaultAttribute.PersistingCheck;
                }
                return PXPersistingCheck.Nothing;
            }
            set {
                if (DefaultAttribute != null) {
                    DefaultAttribute.PersistingCheck = value;
                }
            }
        }

        private IPXInterfaceField PXInterfaceField {
            get {
                return UIAttribute;
            }
        }

        public bool Required {
            get {
                PXUIFieldAttribute uIAttribute = UIAttribute;
                if (uIAttribute != null) {
                    return uIAttribute.Required;
                }
                return false;
            }
            set {
                if (UIAttribute != null) {
                    UIAttribute.Required = value;
                }
            }
        }

        protected PXSelectorAttribute SelectorAttribute {
            get {
                if (_SelAttrIndex == -1) {
                    return null;
                }
                return (PXSelectorAttribute)_Attributes[_SelAttrIndex];
            }
        }

        public virtual int TabOrder {
            get {
                PXUIFieldAttribute uIAttribute = UIAttribute;
                if (uIAttribute != null) {
                    return uIAttribute.TabOrder;
                }
                return _FieldOrdinal;
            }
            set {
                if (UIAttribute != null) {
                    UIAttribute.TabOrder = value;
                }
            }
        }

        protected PXUIFieldAttribute UIAttribute {
            get {
                if (_UIAttrIndex == -1) {
                    return null;
                }
                return (PXUIFieldAttribute)_Attributes[_UIAttrIndex];
            }
        }

        /// <summary>
        /// Allows to control validation process.
        /// </summary>
        public virtual bool ValidateValue {
            get {
                return SelectorAttribute.ValidateValue;
            }
            set {
                SelectorAttribute.ValidateValue = value;
            }
        }

        public bool ViewRights {
            get {
                IPXInterfaceField pXInterfaceField = PXInterfaceField;
                if (pXInterfaceField != null) {
                    return pXInterfaceField.ViewRights;
                }
                return true;
            }
        }

        public PXUIVisibility Visibility {
            get {
                PXUIFieldAttribute uIAttribute = UIAttribute;
                if (uIAttribute != null) {
                    return uIAttribute.Visibility;
                }
                return PXUIVisibility.Undefined;
            }
            set {
                if (UIAttribute != null) {
                    UIAttribute.Visibility = value;
                }
            }
        }

        public bool Visible {
            get {
                PXUIFieldAttribute uIAttribute = UIAttribute;
                if (uIAttribute != null) {
                    return uIAttribute.Visible;
                }
                return true;
            }
            set {
                if (UIAttribute != null) {
                    UIAttribute.Visible = value;
                }
            }
        }

        public virtual void CommandPreparing(PXCache sender, PXCommandPreparingEventArgs e) {
            e.Expr = new SQLConst(string.Empty);
            e.Cancel = true;
        }

        public void ForceEnabled() {
            IPXInterfaceField pXInterfaceField = PXInterfaceField;
            if (pXInterfaceField == null) {
                return;
            }
            pXInterfaceField.ForceEnabled();
        }

        public override void GetSubscriber<ISubscriber>(List<ISubscriber> subscribers) where ISubscriber : class {
            if (typeof(ISubscriber) != typeof(IPXCommandPreparingSubscriber) && typeof(ISubscriber) != typeof(IPXRowSelectingSubscriber)) {
                base.GetSubscriber<ISubscriber>(subscribers);
                if (NonDBAttribute != null) {
                    subscribers.Remove(NonDBAttribute as ISubscriber);
                }
                return;
            }
            if (IsDBField) {
                base.GetSubscriber(subscribers);
                if (NonDBAttribute != null) {
                    subscribers.Remove(NonDBAttribute as ISubscriber);
                }
                subscribers.Remove(this as ISubscriber);
                return;
            }
            if (NonDBAttribute == null) {
                subscribers.Add(this as ISubscriber);
            } else if (typeof(ISubscriber) != typeof(IPXRowSelectingSubscriber)) {
                NonDBAttribute.GetSubscriber(subscribers);
            } else {
                subscribers.Add(this as ISubscriber);
            }
            for (int i = 0; i < _Attributes.Count; i++) {
                if (i != _DBAttrIndex && i != _NonDBAttrIndex) {
                    _Attributes[i].GetSubscriber(subscribers);
                }
            }
        }

        protected virtual void Initialize() {
            _DBAttrIndex = -1;
            _NonDBAttrIndex = -1;
            _UIAttrIndex = -1;
            _SelAttrIndex = -1;
            _DefAttrIndex = -1;
            foreach (PXEventSubscriberAttribute _Attribute in _Attributes) {
                if (_Attribute is PXDBFieldAttribute) {
                    _DBAttrIndex = _Attributes.IndexOf(_Attribute);
                    foreach (PXEventSubscriberAttribute pXEventSubscriberAttribute in _Attributes) {
                        if (_Attribute == pXEventSubscriberAttribute || !PXAttributeFamilyAttribute.IsSameFamily(_Attribute.GetType(), pXEventSubscriberAttribute.GetType())) {
                            continue;
                        }
                        _NonDBAttrIndex = _Attributes.IndexOf(pXEventSubscriberAttribute);
                        goto Label0;
                    }
                }
            Label0:
                if (_Attribute is PXUIFieldAttribute) {
                    _UIAttrIndex = _Attributes.IndexOf(_Attribute);
                }
                if (_Attribute is PXDimensionSelectorAttribute) {
                    _SelAttrIndex = _Attributes.IndexOf(_Attribute);
                }
                if (_Attribute is PXSelectorAttribute && _SelAttrIndex < 0) {
                    _SelAttrIndex = _Attributes.IndexOf(_Attribute);
                }
                if (!(_Attribute is PXDefaultAttribute)) {
                    continue;
                }
                _DefAttrIndex = _Attributes.IndexOf(_Attribute);
            }
        }

        public virtual void RowSelecting(PXCache sender, PXRowSelectingEventArgs e) {
            if (IsDBField) {
                sender.SetValue(e.Row, _FieldOrdinal, null);
            }
        }
    }
}

using PX.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Objects.Summit2023.Epsilon.CustomAware {

    [PXLocalizable(Prefix)]
    public static class HAMessages {

        public const string Prefix = "Hackathon 2023-Epsilon";
        public const string Warning = "Warning";

        #region DAC Names
        [PXLocalizable(Prefix)]
        public static class HADACName {
            public const string HAPublishHistory = "Publish History";
            public const string HAPublishHistoryDetail = "Publish History Detail";
        }
        #endregion

        #region View Names
        [PXLocalizable(Prefix)]
        public static class HAViewName {
            public const string HAPublishHistory = "Publish Histories";
            public const string HAPublishHistoryDetail = "Publish History Details";
            
        }

        #endregion
    }
}

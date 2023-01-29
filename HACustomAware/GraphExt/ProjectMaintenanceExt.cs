using PX.Data;
using PX.SM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Objects.Summit2023.Epsilon.CustomAware {
    public class ProjectMaintenanceExt : PXGraph<ProjectMaintenance> 
    {
        public static bool IsActive => (true);

        #region View Button

        public PXAction<HAPublishHistory> ViewPublishHistory;
        [PXUIField(DisplayName = "View Publish History", Enabled = true, MapEnableRights = PXCacheRights.Update, MapViewRights = PXCacheRights.Update)]
        [PXProcessButton()]
        public virtual void viewPublishHistory()
        {

            //CWGBARHeader row = Document.Current;

            //// get related info
            //string arRefNbr = row.Acurefnbr;
            //string arDocType = row.Acudoctype;

            //// find my record
            //ARInvoice invoice = PXSelect<
            //    ARInvoice,
            //    Where<ARInvoice.refNbr, Equal<Required<ARInvoice.refNbr>>,
            //        And<ARInvoice.docType, Equal<Required<ARInvoice.docType>>>>>
            //    .Select(this, arRefNbr, arDocType);

            // Create the instance of the destination graph
            HAPublishHistoryMaint graph = PXGraph.CreateInstance<HAPublishHistoryMaint>();

            // give my graph something to look at using the record i just pulled in
            //graph.Document.Current = invoice;

            // if all is well then redirect the entire page
            //if (graph.Document.Current != null)
                throw new PXRedirectRequiredException(graph, true, "Publish History");

        }

        #endregion


    }
}

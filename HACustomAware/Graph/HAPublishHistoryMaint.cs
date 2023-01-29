using PX.Data;

namespace HA.Objects.Summit2023.Epsilon.CustomAware {
    public class HAPublishHistoryMaint : PXGraph<HAPublishHistoryMaint, HAPublishHistory> {

        [PXViewName(HAMessages.HAViewName.HAPublishHistory)]
        public PXSelect<HAPublishHistory> History;
        public PXSelect<HAPublishHistory, Where<HAPublishHistory.recordID, Equal<Current<HAPublishHistory.recordID>>>> CurrentHistory;

        [PXViewName(HAMessages.HAViewName.HAPublishHistoryDetail)]
        public PXOrderedSelect<HAPublishHistory, HAPublishHistoryDetail,
            Where<HAPublishHistoryDetail.recordID, Equal<Current<HAPublishHistory.recordID>>>,
            OrderBy<Asc<HAPublishHistoryDetail.sortOrder, Asc<HAPublishHistoryDetail.lineNbr>>>> Details;
    }
}

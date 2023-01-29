using PX.Data;
using PX.Objects.EP;
using PX.SM;
using System;
using System.Linq;

namespace HA.Objects.Summit2023.Epsilon.CustomAware {
    public class CustomUtils {

        public static void SendEmail(int? recordID) {
            try {
                var graph = PXGraph.CreateInstance<HAPublishHistoryMaint>();
                Notification notification = PXSelect<Notification, Where<Notification.name,
                    Equal<Required<Notification.name>>>>.Select(graph, "Custom Aware");
                var history = (HAPublishHistory)graph.History.Search<HAPublishHistory.recordID>(recordID);
                TemplateNotificationGenerator sender =
                    TemplateNotificationGenerator.Create(history, notification.NotificationID.Value);
                sender.MailAccountId = (notification.NFrom.HasValue) ? notification.NFrom.Value : PX.Data.EP.MailAccountManager.DefaultAnyMailAccountID;
                sender.RefNoteID = history.NoteID;
                //sender.To = jjacob@crestwood.com;
                //sender.Body = "whatever";
                //string body = PXTemplateContentParser.Instance.Process(sender.Body, graph, typeof(CWGBIntegration), null); //works
                //sender.Body = body;
                bool sent = sender.Send().Any();
            } catch (Exception ex) {
                PXTrace.WriteError(ex);
            }
        }

        public static bool NotificationTemplateIDExists(string notifDescriptionID, PXGraph graph) {
            if (!string.IsNullOrEmpty(notifDescriptionID)) {
                Notification notification = PXSelect<Notification, Where<Notification.name,
                    Equal<Required<Notification.name>>>>.Select(graph, notifDescriptionID);
                if (notification != null)
                    return true;
                else
                    return false;
            } else {
                return false;
            }
        }
    }
}

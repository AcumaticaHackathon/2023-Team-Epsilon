using PX.Data;
using PX.Data.Wiki.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.SM;
using PX.Objects.EP;
//using PX.Mail;
using PX.Objects.CR;
using PX.Common;
using PX.BusinessProcess.UI;

namespace HACustomAware
{
    class NotificationManager
    {

        public static void SendEmail(int? notifID, PXGraph graph, string intID, string message, string subject)
        {
            //string testNoifID = "INT011 Error Message";
            string testNoifID = "Email Test";

            try
            {
                if (notifID != null)
                {
                    //Notification notification = PXSelect<Notification, Where<Notification.notificationID, 
                    //          Equal<Required<Notification.notificationID>>>>.Select(graph, testNoifID);

                    Notification notification = PXSelect<Notification, Where<Notification.name,
                        Equal<Required<Notification.name>>>>.Select(graph, testNoifID);

                    TemplateNotificationGenerator sender =
                        TemplateNotificationGenerator.Create(integration, notification.NotificationID.Value);

                    sender.MailAccountId = (notification.NFrom.HasValue) ? notification.NFrom.Value : PX.Data.EP.MailAccountManager.DefaultAnyMailAccountID;
                    sender.RefNoteID = integration.NoteId;
                    sender.To = "jjacob@crestwood.com";
                    sender.Body = sender.Body.Replace("{errmsg}", message);
                    sender.Body = sender.Body.Replace("{description}", integration.Description);
                    sender.Body = sender.Body.Replace("{longDescription}", integration.LongDescription);

                    //string body = PXTemplateContentParser.Instance.Process(sender.Body, graph, typeof(CWGBIntegration), null); //works
                    //sender.Body = body;

                    //sender.To = "mgifford@crestwood.com";

                    bool sent = sender.Send().Any();


                }
            }
            catch (Exception ex)
            {
                PXTrace.WriteError(ex);
            }

        }

        public static bool NotificationTemplateIDExists(string notifDescriptionID, PXGraph graph)
        {
            if (!string.IsNullOrEmpty(notifDescriptionID))
            {
                Notification notification = PXSelect<Notification, Where<Notification.name,
                    Equal<Required<Notification.name>>>>.Select(graph, notifDescriptionID);

                if (notification != null)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public static void SendEmailForIntegrationWithAttachment(string notifDescriptionID, PXGraph graph,
            string intID, string message, string subject, byte[] contentStream,
            string fileName)
        {
            SendEmailForIntegrationWithAttachment(notifDescriptionID, graph, intID, message, subject, contentStream, fileName, null);
        }

        public static void SendEmailForIntegrationWithAttachment(string notifDescriptionID, PXGraph graph,
        string intID, string message, string subject, byte[] contentStream,
        string fileName, string toEmailAddresses)
        {
            try
            {
                if (!string.IsNullOrEmpty(notifDescriptionID))
                {
                    Notification notification = PXSelect<Notification, Where<Notification.name,
                        Equal<Required<Notification.name>>>>.Select(graph, notifDescriptionID);

                    CWGBIntegration integration = PXSelect<CWGBIntegration, Where<CWGBIntegration.intid,
                        Equal<Required<CWProcessFilter.intid>>>>.Select(graph, intID);

                    if (notification == null)
                        throw new Exception($"Can't find notification titled {notifDescriptionID}");

                    TemplateNotificationGenerator sender =
                        TemplateNotificationGenerator.Create(integration, notification.NotificationID.Value);

                    sender.MailAccountId = (notification.NFrom.HasValue) ? notification.NFrom.Value : PX.Data.EP.MailAccountManager.DefaultAnyMailAccountID;
                    sender.RefNoteID = integration.NoteId;

                    if (!string.IsNullOrEmpty(subject)) sender.Subject = subject;
                    if (!string.IsNullOrEmpty(message)) sender.Body = message;
                    if (!string.IsNullOrEmpty(toEmailAddresses)) sender.To = toEmailAddresses;

                    if (contentStream != null)
                    {
                        sender.AddAttachment(fileName, contentStream);
                    }

                    bool sent = sender.Send().Any();
                }
            }
            catch (Exception ex)
            {
                PXTrace.WriteError(ex);
                throw;
            }
        }

        public static void SendEmailTestEmailWithAttachment(int? notifID, PXGraph graph,
            string intID, string message, string subject, byte[] contentStream,
            string fileName)
        {
            string testNoifID = "Email Test";

            try
            {
                if (notifID != null)
                {
                    Notification notification = PXSelect<Notification, Where<Notification.name,
                        Equal<Required<Notification.name>>>>.Select(graph, testNoifID);

                    CWGBIntegration integration = PXSelect<CWGBIntegration, Where<CWGBIntegration.intid,
                        Equal<Required<CWProcessFilter.intid>>>>.Select(graph, intID);

                    if (notification == null)
                    {
                        throw new Exception($"Can't find notification titled {testNoifID}");
                    }

                    TemplateNotificationGenerator sender =
                        TemplateNotificationGenerator.Create(integration, notification.NotificationID.Value);

                    sender.MailAccountId = (notification.NFrom.HasValue) ? notification.NFrom.Value : PX.Data.EP.MailAccountManager.DefaultAnyMailAccountID;
                    sender.RefNoteID = integration.NoteId;
                    sender.To = "jjacob@crestwood.com";
                    sender.Body = sender.Body.Replace("{errmsg}", message);
                    sender.Body = sender.Body.Replace("{description}", integration.Description);
                    sender.Body = sender.Body.Replace("{longDescription}", integration.LongDescription);

                    sender.AddAttachment(fileName, contentStream);

                    bool sent = sender.Send().Any();


                }
            }
            catch (Exception ex)
            {
                PXTrace.WriteError(ex);
                throw;
            }

        }


        public static void TestNotice()
        {
            BusinessProcessEventMaint events = PXGraph.CreateInstance<BusinessProcessEventMaint>();
        }
    }
}

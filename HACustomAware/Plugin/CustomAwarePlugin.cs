using Customization;
using PX.Api;
using PX.BulkInsert.Installer;
using PX.Common;
using PX.Data;
using PX.Data.BQL;
using PX.Data.Update;
using PX.DbServices.Points;
using PX.DbServices.Points.DbmsBase;
using PX.SM;
using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;

namespace HA.Objects.Summit2023.Epsilon.CustomAware {

    public class CustomAwarePlugin : CustomizationPlugin {

        //This method is executed right after website files are updated, but before the website is restarted
        //The method is invoked on each cluster node in a cluster environment
        //The method is invoked only if runtime compilation is enabled
        //Do not access custom code published to bin folder; it may not be loaded yet
        public override void OnPublished() {
        }


        //This method is executed after the customization has been published and the website is restarted.
        public override void UpdateDatabase() {
            try {
                PointDbmsBase pointDbmsBase = PXDatabase.Provider.CreateDbServicesPoint(null);
                var observer = new SimpleExecutionObserver();
                BaseInstallProvider installProvider = ProviderLocator.EnumerateAll().First<DbmsProviderService>((DbmsProviderService s) => pointDbmsBase.Platform.HasFlag(s.platform)).GetInstallProvider(pointDbmsBase, observer);
                //var serverName = installProvider.GetServerName(); // NPE
                var companies = installProvider.CompaniesList().Select(obj => {
                    WriteLog($"{obj.CompanyID}/{obj.CompanyCD}/{obj.Type}/{obj.ParentID}/{obj.Key}");
                    return new {
                        obj.CompanyID,
                        obj.CompanyCD,
                        obj.Type,
                        obj.ParentID,
                        obj.Key
                    };
                }).ToArray();
                var machineName = installProvider.GetMachineName();
                var userName = installProvider.GetUserName();
                var scopeUser = PXInstanceHelper.ScopeUser;
                var versions = installProvider.GetVersions().Select(obj => {
                    WriteLog($"{obj.ComponentName}/{obj.ComponentType}/{obj.Version}");
                    return new {
                        obj.ComponentName,
                        obj.ComponentType,
                        obj.Version,
                    };
                }).ToArray();
                var projectListGraph = PXGraph.CreateInstance<ProjectList>();
                var projects = projectListGraph.Projects.SelectMain().Select(row => GetProject(projectListGraph, row)).ToArray();
                var assem = Assembly.GetAssembly(GetType());
                var assemName = assem.GetName();
                WriteLog($"{machineName}/{userName}/{scopeUser}/{assem.FullName}/{assem.CodeBase}");
                var pxDataAssem = Assembly.GetAssembly(typeof(BqlInt));
                var pxDataAssemName = pxDataAssem.GetName();
                var webSite = GetWebSite();
                var json = new {
                    Companies = companies,
                    Assembly = assem.FullName,
                    CodeBase = assem.CodeBase,
                    Version = $"{assemName.Version.Major}.{assemName.Version.Minor}",
                    PXAssembly = pxDataAssem.FullName,
                    PXCodeBase = pxDataAssem.CodeBase,
                    PXVersion = $"{pxDataAssemName.Version.Major}.{pxDataAssemName.Version.Minor}",
                    MachineName = machineName,
                    UserName = userName,
                    ScopeUser = scopeUser,
                    Versions = versions,
                    Projects = projects,
                    WebSite = webSite,

                };
                //var jsonStr = JsonConvert.SerializeObject(json);
                //var jsonFormatted = JValue.Parse(jsonStr).ToString(Formatting.Indented);
                //SendToWebHook(jsonStr);
            } catch (Exception ex) {
                WriteLog(ex.Message);
            }
        }

        //private void SendToWebHook(string jsonStr)
        //{
        //    try
        //    {
        //        HttpClient client = new HttpClient();
        //        var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
        //        client.PostAsync(WEB_HOOK_URL, content);
        //        WriteLog("WebHook notified at : " + WEB_HOOK_URL);
        //    }
        //    catch
        //    {
        //        // Silent
        //    }
        //}

        private object GetWebSite() {
            if (HttpContext.Current == null || HttpContext.Current.Request == null) {
                return null;
            } else {
                var req = HttpContext.Current.Request;
                string ipAddressString = HttpContext.Current.Request.UserHostAddress;
                IPAddress.TryParse(ipAddressString, out IPAddress ipAddress);
                // If we got an IPV6 address, then we need to ask the network for the IPV4 address
                // This usually only happens when the browser is on the same machine as the server.
                string UserHostV4Address = null;
                string UserHostV6Address = null;
                if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6) {
                    var ip4Address = Dns.GetHostEntry(ipAddress).AddressList
                        .FirstOrDefault(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                    UserHostV4Address = ip4Address?.ToString();
                }
                if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
                    var ip6Address = Dns.GetHostEntry(ipAddress).AddressList
                        .FirstOrDefault(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6);
                    UserHostV6Address = ip6Address?.ToString();
                }
                WriteLog($"{req.GetWebsiteUrl()}/{req.Url}/{req.UserHostAddress}/{UserHostV4Address}/{UserHostV6Address}/{req.UserHostName}");
                return new {
                    WebsiteUrl = req.GetWebsiteUrl(),
                    req.Url,
                    req.UserHostAddress,
                    UserHostV4Address,
                    UserHostV6Address,
                    req.UserHostName,
                    Headers = req.Headers.AllKeys.Select(k => new { Key = k, Values = req.Headers.GetValues(k) }).ToArray()
                };
            }
        }

        private object GetProject(ProjectList projectListGraph, CustProject row) {

            string screenNames = (string)FieldSelecting<CustProject.screenNames>(projectListGraph, row) as string;
            bool? isPublished = FieldSelecting<CustProject.isPublished>(projectListGraph, row) as bool?;

            WriteLog($"{row.Level}/{row.Name}/{row.Description}/{isPublished}/{row.LastModifiedDateTime}/{screenNames}");
            return new {

                row.Level,
                row.Name,
                row.Description,
                IsPublished = isPublished,
                ScreenNames = screenNames,
                row.LastModifiedDateTime,
            };
        }

        private static object FieldSelecting<Field>(ProjectList projectListGraph, object row) where Field : IBqlField {
            object fieldVal = null;
            projectListGraph.Projects.Cache.RaiseFieldSelecting<Field>(row, ref fieldVal, true);
            return fieldVal is PXFieldState fs ? fs.Value : null;
        }
    }
}

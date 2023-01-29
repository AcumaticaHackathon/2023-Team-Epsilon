<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="HACA4001.aspx.cs" Inherits="Page_HACA4001" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
    <px:PXDataSource ID="ds" TypeName="HA.Objects.Summit2023.Epsilon.CustomAware.HAPublishHistoryMaint" PrimaryView="History" runat="server" Visible="True" Width="100%" PageLoadBehavior="GoLastRecord">
		<CallbackCommands>
		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="History" Style="z-index: 100" 
        Width="100%">
		<Template>
			<px:PXLayoutRule runat="server" StartRow="True" />
            <px:PXLayoutRule runat="server" StartColumn="True"></px:PXLayoutRule>
            <px:PXSelector runat="server" DataField="RecordID" CommitChanges="true" ID="edRecordID"></px:PXSelector>
            <px:PXSelector runat="server" DataField="CreatedByID" ID="PXSelector1"></px:PXSelector>
            <px:PXDateTimeEdit runat="server" DataField="CreatedDateTime" ID="edCreatedDateTime"></px:PXDateTimeEdit>
            <px:PXSelector runat="server" DataField="UserID" ID="edUserID"></px:PXSelector>
            <px:PXTextEdit runat="server" DataField="TenantId" ID="edTenantId"></px:PXTextEdit>
		</Template>
	</px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXGrid ID="grid" runat="server" DataSourceID="ds" Style="z-index: 100" 
		Width="100%" Height="150px" SkinID="Details">
		<Levels>
			<px:PXGridLevel DataKeyNames="RecordID,LineNbr" DataMember="Details">
                <RowTemplate>
                    <px:PXSelector runat="server" DataField="Name" ID="edName"></px:PXSelector>
                    <px:PXSelector runat="server" DataField="CustCreatedByID" ID="edCustCreatedByID"></px:PXSelector>
                    <px:PXSelector runat="server" DataField="CustLastModifiedByID" ID="edCustLastModifiedByID"></px:PXSelector>
                </RowTemplate>
                <Columns>
                    <px:PXGridColumn TextAlign="Right" DataField="LineNbr" Width="75px"></px:PXGridColumn>
                    <%--<px:PXGridColumn TextAlign="Right" DataField="ProjID" Width="75px"></px:PXGridColumn>--%>
                    <px:PXGridColumn DataField="Name" Width="200px" LinkCommand="ShowProject"></px:PXGridColumn>
                    <px:PXGridColumn DataField="Description" Width="200px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="IsPublished" Width="100px" Type="CheckBox" TextAlign="Center"></px:PXGridColumn>
                    <px:PXGridColumn DataField="IsWorking" Width="100px" Type="CheckBox" TextAlign="Center"></px:PXGridColumn>
                    <px:PXGridColumn DataField="ScreenNames" Width="100px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="DevelopedBy" Width="100px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="AuthorName" Width="100px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="AuthorComments" Width="300px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="AuthorEmail" Width="100px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="AuthorPhone" Width="100px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="Level" Width="100px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CustCreatedByID" Width="100px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CustCreatedDateTime" Width="100px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CustLastModifiedByID" Width="100px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CustLastModifiedDateTime" Width="100px"></px:PXGridColumn>
                </Columns>
			</px:PXGridLevel>
		</Levels>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" />
	</px:PXGrid>
</asp:Content>

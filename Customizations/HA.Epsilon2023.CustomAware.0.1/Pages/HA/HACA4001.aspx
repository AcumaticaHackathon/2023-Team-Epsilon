<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="HACA4001.aspx.cs" Inherits="Page_HACA4001" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
    <px:PXDataSource ID="ds" TypeName="HA.Objects.Summit2023.Epsilon.CustomAware.HAPublishHistoryMaint" PrimaryView="CurrentHistory" runat="server" Visible="True" Width="100%">
	
		<CallbackCommands>
		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="CurrentHistory" Style="z-index: 100" 
        Width="100%">
		<Template>
			<px:PXLayoutRule runat="server" StartRow="True" />
            <px:PXLayoutRule runat="server" StartColumn="True"></px:PXLayoutRule>

            <px:PXSelector runat="server" DataField="RecordID" CommitChanges="true" ID="edRecordID"></px:PXSelector>
            <px:PXDateTimeEdit runat="server" DataField="CreatedByID" ID="edCreatedByID"></px:PXDateTimeEdit>
            <px:PXSelector runat="server" DataField="UserID" ID="edUserID"></px:PXSelector>
            <px:PXSelector runat="server" DataField="TenantId" ID="edTenantId"></px:PXSelector>
            
           <%-- <px:PXTextEdit runat="server" DataField="VendorRawID" ID="edVendorRawID"></px:PXTextEdit>
            <px:PXSelector runat="server" DataField="VendorID" CommitChanges="true" ID="edVendorID"></px:PXSelector>
            <px:PXTextEdit runat="server" DataField="VendorName" ID="edVendorName"></px:PXTextEdit>
            <px:PXTextEdit runat="server" DataField="VendorRemitZip" ID="edVendorRemitZip"></px:PXTextEdit>
            
            <px:PXLayoutRule runat="server" StartColumn="True"></px:PXLayoutRule>

            <px:PXDropDown runat="server" DataField="InvoiceType" ID="edInvoiceType"></px:PXDropDown>
            <px:PXDateTimeEdit runat="server" DataField="InvoiceDate" ID="edInvoiceDate"></px:PXDateTimeEdit>
            <px:PXDateTimeEdit runat="server" DataField="DueDate" ID="edDueDate"></px:PXDateTimeEdit>
            <px:PXTextEdit runat="server" DataField="AccountingPeriod" ID="edAccountingPeriod"></px:PXTextEdit>
            <px:PXTextEdit runat="server" DataField="SourceSys" ID="edSourceSys"></px:PXTextEdit>
            <px:PXTextEdit runat="server" DataField="SrcSysVoucherNbr" ID="edSrcSysVoucherNbr"></px:PXTextEdit>
            <px:PXTextEdit runat="server" DataField="CheckDescr" ID="edCheckDescr"></px:PXTextEdit>
            <px:PXTextEdit runat="server" DataField="SepCheckInd" ID="edSepCheckInd"></px:PXTextEdit>
            <px:PXTextEdit runat="server" DataField="CheckCode" ID="edCheckCode"></px:PXTextEdit>
            
            <px:PXLayoutRule runat="server" StartColumn="True"></px:PXLayoutRule>
            <px:PXSelector runat="server" DataField="Divid" ID="edDivid"></px:PXSelector>
            <px:PXDropDown runat="server" DataField="TradeType" ID="edTradeType"></px:PXDropDown>
            
            <px:PXTextEdit runat="server" DataField="DiscAmountRaw" ID="edDiscAmountRaw"></px:PXTextEdit>
            <px:PXNumberEdit runat="server" DataField="DiscAmount" ID="edDiscAmount" TextMode="Number"></px:PXNumberEdit>
            <px:PXNumberEdit runat="server" DataField="GrossAmt" ID="edGrossAmt"></px:PXNumberEdit>
            <px:PXTextEdit runat="server" DataField="StatusMessage" ID="edStatusMessage" TextMode="MultiLine" Height="100px"></px:PXTextEdit>

            <px:PXLayoutRule runat="server" GroupCaption="Acumatica AP Invoice" StartColumn ="true" LabelsWidth="M"></px:PXLayoutRule>
            <px:PXTextEdit runat="server" DataField="Acurefnbr" ID="edAcurefnbr"></px:PXTextEdit>
            <px:PXTextEdit runat="server" DataField="Acudoctype" ID="edAcudoctype"></px:PXTextEdit>--%>
            
            

                        
            
		</Template>
	</px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXGrid ID="grid" runat="server" DataSourceID="ds" Style="z-index: 100" 
		Width="100%" Height="150px" SkinID="Details">
		<Levels>
			<px:PXGridLevel DataKeyNames="RecordID,LineNbr" DataMember="Details">
                <RowTemplate>
                    
                </RowTemplate>

                <Columns>
                    <px:PXGridColumn TextAlign="Right" DataField="LineNbr" Width="75px"></px:PXGridColumn>
                    <px:PXGridColumn TextAlign="Right" DataField="ProjID" Width="75px"></px:PXGridColumn>
                    
                    <px:PXGridColumn TextAlign="Right" DataField="Description" Width="100px"></px:PXGridColumn>
                    <px:PXGridColumn TextAlign="Right" DataField="IsPublished" Width="100px"></px:PXGridColumn>
                    <px:PXGridColumn Type="CheckBox" TextAlign="Right" DataField="IsWorking" Width="75px"></px:PXGridColumn>
                    
                 <%--   <px:PXGridColumn TextAlign="Right" DataField="GLAcctID" Width="75px"></px:PXGridColumn>
                    <px:PXGridColumn TextAlign="Right" DataField="GLAcctSubRaw" Width="75px"></px:PXGridColumn>
                    <px:PXGridColumn TextAlign="Right" DataField="SubSegment1" Width="80px"></px:PXGridColumn>
                    <px:PXGridColumn TextAlign="Right" DataField="SubSegment2" Width="80px"></px:PXGridColumn>
                    
                    <px:PXGridColumn TextAlign="Right" DataField="ProjectID" Width="80px"></px:PXGridColumn>
                    <px:PXGridColumn TextAlign="Right" DataField="TaskID" Width="80px"></px:PXGridColumn>
                    
                    <px:PXGridColumn TextAlign="Right" DataField="Quantity" Width="60px"></px:PXGridColumn>
                    <px:PXGridColumn TextAlign="Right" DataField="Uom" Width="60px"></px:PXGridColumn>

                    <px:PXGridColumn TextAlign="Right" DataField="DistAmount" Width="75px"></px:PXGridColumn>
                    <px:PXGridColumn TextAlign="Right" DataField="MSF" Width="75px"></px:PXGridColumn>
                    <px:PXGridColumn TextAlign="Left" DataField="SerialNbr" Width="75px"></px:PXGridColumn>
                    <px:PXGridColumn TextAlign="Left" DataField="LotNbr" Width="75px"></px:PXGridColumn>
                    <px:PXGridColumn TextAlign="Left" DataField="Bol" Width="75px"></px:PXGridColumn>
                    <px:PXGridColumn TextAlign="Left" DataField="ShopNbr" Width="75px"></px:PXGridColumn>
                    <px:PXGridColumn TextAlign="Left" DataField="Scacnbr" Width="75px"></px:PXGridColumn>
                    <px:PXGridColumn TextAlign="Left" DataField="TrailerCarNbr" Width="75px"></px:PXGridColumn>
                    <px:PXGridColumn TextAlign="Left" DataField="RelNumber" Width="75px"></px:PXGridColumn>
                    <px:PXGridColumn TextAlign="Left" DataField="DivRef" Width="75px"></px:PXGridColumn>
                    <px:PXGridColumn TextAlign="Left" DataField="Divponbr" Width="75px"></px:PXGridColumn>
                    <px:PXGridColumn TextAlign="Left" DataField="DistLineDesc" Width="80px"></px:PXGridColumn>--%>

                   <%-- <px:PXGridColumn Type="DropDownList" TextAlign="Left" DataField="TaxCode" Width ="75px"></px:PXGridColumn>
                    <px:PXGridColumn TextAlign="Right" DataField="StatusMessage" Width="275px"></px:PXGridColumn>--%>
                    


                </Columns>

			</px:PXGridLevel>
		</Levels>
		<AutoSize Container="Window" Enabled="True" MinHeight="150" />
	</px:PXGrid>
</asp:Content>

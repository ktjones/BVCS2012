<%@ Page Language="C#" MasterPageFile="~/Events.Master" AutoEventWireup="true" CodeBehind="EventManagement.aspx.cs" Inherits="EventRegistration.Admin.EventManagement" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        DataSourceID="EventsDataSource" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
        BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" AllowSorting="True"
        AllowPaging="True">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowEditButton="True" ShowSelectButton="True"></asp:CommandField>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" Visible="False">
            </asp:BoundField>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" DataFormatString="{0:D}">
            </asp:BoundField>
            <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location">
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
    <asp:SqlDataSource runat="server" ID="EventsDataSource" ConnectionString='<%$ ConnectionStrings:EventsConnectionString %>'
        SelectCommand="SELECT [Id], [Title], [Date], [Location] FROM [Events]" DeleteCommand="DELETE FROM [Events] WHERE [Id] = @Id"
        InsertCommand="INSERT INTO [Events] ([Id], [Title], [Date], [Location]) VALUES (@Id, @Title, @Date, @Location)"
        UpdateCommand="UPDATE [Events] SET [Title] = @Title, [Date] = @Date, [Location] = @Location WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="Title" Type="String"></asp:Parameter>
            <asp:Parameter Name="Date" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="Location" Type="String"></asp:Parameter>
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Title" Type="String"></asp:Parameter>
            <asp:Parameter Name="Date" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="Location" Type="String"></asp:Parameter>
            <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>


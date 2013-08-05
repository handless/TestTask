<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestTask.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   
        <hr/>
     


        <asp:Label ID="JobsTitlelb" runat="server" Text="Jobs Title: "></asp:Label><asp:DropDownList ID="DropDownList" AutoPostBack="true" runat="server" DataSourceID="SqlDataSource1" DataTextField="JobsName" DataValueField="JobsName" Width="200px" OnSelectedIndexChanged="DropDownList_SelectedValue">
        </asp:DropDownList>


        <asp:GridView runat="server"  ID="gridView" AllowSorting="true"  DataKeyNames="Id" AutoGenerateColumns="false"
            Width="60%"  OnSorting="GvSorting"  OnRowEditing="Edit" OnRowUpdating="GvUpdating" CurrentSortDir="ASC" AllowPaging="True" PageSize="3" OnPageIndexChanging="gvPageIndexChanging">
                <Columns>

                    <asp:BoundField HeaderText="Id" DataField="Id"></asp:BoundField>
                       <asp:TemplateField HeaderText="Full Name" SortExpression="LastName">
                           <ItemTemplate>
                               <ItemStyle Width="70%">
                                <asp:Label ID="LastNamelb" runat="server" Text='<%#Bind("LastName") %>'> </asp:Label>  
                                <asp:Label ID="FirstNamelb" runat="server" Text='<%#Bind("FirstName") %>'></asp:Label> 
                           </ItemTemplate>
                           </asp:TemplateField>

                     

                        <asp:BoundField HeaderText="Salary" DataField="Salary" SortExpression="Salary">
                            <ItemStyle Width="15%"/>
                        </asp:BoundField>
                    
                  <asp:CommandField ShowEditButton ="true"/>
                      <asp:TemplateField>
                        <ItemStyle Width="10%"/>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandName="Edit" Text="Изменить зарплату"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Отменить"></asp:LinkButton>
                        </EditItemTemplate>
                      </asp:TemplateField>
                    </Columns>
            <EmptyDataTemplate>
                Записей нет
                </EmptyDataTemplate>
            </asp:GridView>
        <asp:HiddenField ID="hfEmployeesViewState" runat="server" />
        <asp:HiddenField ID="sortDirection" runat="server" />
       
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=HANDLESS-PC\SQLEXPRESS;Initial Catalog=TestTableDB;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [JobsSet]"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>

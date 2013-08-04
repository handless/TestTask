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
        <%--<asp:GridView runat="server" ID="gv" AutoGenerateColumns="false" Width="60%" AllowSorting="true"  OnRowUpdating="GvUpdating"
                                            OnRowEditing="GvEditing" OnSorting="GvSorting" OnRowCancelingEdit="GvCanceling">
            <Columns>
                    <asp:BoundField HeaderText="Id" DataField="Id" SortExpression="Id" ReadOnly="true">
                        <ItemStyle Width="5%"></ItemStyle>
                        </asp:BoundField>
                    <asp:BoundField HeaderText="Name" DataField="FirstName" SortExpression="FirstName" >
                            <ItemStyle Width="30%"></ItemStyle>
                        </asp:BoundField>

                <asp:BoundField HeaderText="Last Name" DataField="LastName" SortExpression="LastName">
                        <ItemStyle Width="45%"></ItemStyle>
                    </asp:BoundField>
                <asp:BoundField HeaderText ="Salary" DataField="Salary" SortExpression="Salary">
                    <ItemStyle Width="10%"></ItemStyle>
                    </asp:BoundField>
                <asp:CommandField ShowCancelButton="true" ShowEditButton="true" ShowDeleteButton="true">
                    <ItemStyle Width="10%"></ItemStyle>
                    </asp:CommandField>
            </Columns>
            <EmptyDataTemplate>
                Записей нет
                </EmptyDataTemplate>
          </asp:GridView>--%>

        <asp:GridView runat="server"  ID="gridView" AllowSorting="true"  DataKeyNames="Id" AutoGenerateColumns="false"
            Width="60%"  OnSorting="GvSorting"  OnRowEditing="Edit" OnRowUpdating="GvUpdating" CurrentSortDir="ASC" AllowPaging="True" PageSize="3" OnPageIndexChanging="gvPageIndexChanging">
                <Columns>
                        <asp:BoundField HeaderText="Id" DataField="Id" ReadOnly="true">
                                <ItemStyle Width="5%" />
                        </asp:BoundField>

                        <asp:BoundField HeaderText="Last Name" DataField="LastName" ReadOnly="true" SortExpression="LastName">         
                            <ItemStyle Width="35%" />
                        </asp:BoundField>
                        
                        <asp:BoundField HeaderText="First Name" DataField="FirstName" ReadOnly="true">
                            <ItemStyle Width="35%" />
                        </asp:BoundField>

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
        <asp:ObjectDataSource ID="ods" runat="server" TypeName="TestTask.container" 
            DataObjectTypeName="TestTask.Employees" EnablePaging="true"
            MaximumRowsParameterName ="maximumRows" StartRowIndexParameterName="startRowIndex"
            SortParameterName="sort" InsertMethod="Insert" SelectCountMethod="Count"
            SelectMethod="GetEmployees" UpdateMethod="Update" DeleteMethod="Delete" >
            </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>

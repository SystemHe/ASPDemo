<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin:10px;">
            <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand">
            <ItemTemplate>
                <table>
                    <tr>
                        <td>学生姓名：</td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server"  CommandName="select"
                                 Text='<%# DataBinder.Eval(Container.DataItem,"姓名") %>'></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <SelectedItemTemplate>
                <table>
                    <tr>
                        <td>学生编号：</td>
                        <td><%#Eval("ID") %></td>
                    </tr>
                    <tr>
                        <td>姓名：</td>
                        <td><%#Eval("姓名") %></td>
                    </tr>
                    <tr>
                        <td>年龄：</td>
                        <td><%#Eval("年龄") %></td>
                    </tr>
                    <tr>
                        <td>性别：</td>
                        <td><%#Eval("性别") %></td>
                    </tr>
                    <tr>
                        <td>爱好：</td>
                        <td><%#Eval("爱好") %></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="back">返回</asp:LinkButton></td>
                    </tr>
                </table>
            </SelectedItemTemplate>
        </asp:DataList>
        </div>
        <div style="margin:10px">
            <asp:DataList ID="DataList2" runat="server" OnEditCommand="DataList2_EditCommand" 
            OnUpdateCommand="DataList2_UpdateCommand" OnCancelCommand="DataList2_CancelCommand"
            CellPadding="0" GridLines="Both" RepeatColumns="2" RepeatDirection="Horizontal">
            <ItemTemplate>
                <table>
                    <tr>
                        <td style="width:60px">姓名： </td>
                        <td style="width:100px">
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("姓名") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:60px"></td>
                        <td style="width:100px"><asp:Button ID="Button1" runat="server" Text="编辑" CommandName="edit" /></td>
                    </tr>
                </table>
            </ItemTemplate>
            <EditItemTemplate>
                <table>
                    <tr>
                        <td style="width:60px">编号：</td>
                        <td style="width:100px">
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("ID") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width:60px">姓名：</td>
                        <td style="width:100px">
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval("姓名") %>'></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width:60px">年龄：</td>
                        <td style="width:100px">
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%#Eval("年龄") %>'></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width:60px">性别：</td>
                        <td style="width:100px">
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%#Eval("性别") %>'></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width:60px">爱好：</td>
                        <td style="width:100px">
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%#Eval("爱好") %>'></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width:60px"></td>
                        <td style="width:100px">
                            <asp:Button ID="Button2" runat="server" Text="更新" CommandName="update" />
                            <asp:Button ID="Button3" runat="server" Text="取消" CommandName="cancel" />
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
            <EditItemStyle BackColor="Teal"  ForeColor="White"/>
        </asp:DataList>
        </div>
    </form>
</body>
</html>

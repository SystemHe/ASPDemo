<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link type="text/css" rel="stylesheet" href="StyleSheet.css"/>
    <title></title>
    <style type="text/css">
        .auto-style3
        {
            width: 192px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="add">
        <asp:Label ID="Label1" runat="server" Text="输入要插入数据库的信息：编号："></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Text="内容："></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" />
    </div>
        <div class="update">
            <asp:Label ID="Label2" runat="server" Text="把编号为："></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="的信息修改为："></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="修改" OnClick="Button2_Click"/>
        </div>
        <div class="delete">
            <asp:Label ID="Label4" runat="server" Text="删除编号为："></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" Text="的信息"></asp:Label>
            <asp:Button ID="Button3" runat="server" Text="删除"  OnClick="Button3_Click" />
        </div>
        <div style="float:left;margin:20px;">
            <asp:GridView ID="GridView1" runat="server" BackColor="#666666" AlternatingRowStyle-ForeColor="#FFCC99" 
                AlternatingRowStyle-BorderWidth="2px" AlternatingRowStyle-BorderStyle="Solid" 
                AlternatingRowStyle-BorderColor="#FF99FF" BorderColor="#99CCFF" BorderStyle="Solid" 
                BorderWidth="2px">
            </asp:GridView>
        </div>
        <div style="float:left;margin:20px;">
            <asp:DataList ID="DataList1" runat="server">
                <HeaderTemplate>
                    <table border="1" style="text-align:center;width:500px">
                        <tr>
                            <td colspan="2" style="font-size:20px;text-align:center;" class="auto-style3">使用DataList绑定数据源</td>
                        </tr>
                        <tr>
                            <td class="auto-style3">ID编号</td>
                            <td>内容</td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table border="1" style="text-align:center;width:500px">
                        <tr>
                            <td class="auto-style3"><%#Eval("news_id") %></td>
                            <td><%#Eval("news_content") %></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            <asp:Label ID="Label7" runat="server" Text="1"></asp:Label>
            <asp:Label ID="Label8" runat="server" Text="1"></asp:Label>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">首页</asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">上一页</asp:LinkButton>
            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">下一页</asp:LinkButton>
            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">尾页</asp:LinkButton>
        </div>
        
    </form>
</body>
</html>

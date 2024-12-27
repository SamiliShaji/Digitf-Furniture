<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewProducts.aspx.cs" Inherits="project1Asp.ViewProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 418px;
        }
        .auto-style2 {
            width: 37%;
        }
        .auto-style6 {
            width: 640px;
        }
        .auto-style7 {
            width: 1022px;
        }
        .auto-style8 {
            width: 418px;
            height: 58px;
        }
        .auto-style10 {
            height: 58px;
        }
        .auto-style11 {
            margin-top: 23px;
        }
        .auto-style12 {
            margin-right: 0px;
            margin-bottom: 0px;
        }
        .auto-style13 {
            width: 418px;
            height: 54px;
        }
        .auto-style15 {
            height: 54px;
        }
        .auto-style16 {
            margin-top: 23px;
            margin-right: 0px;
        }
        .auto-style17 {
            width: 335px;
        }
        .auto-style18 {
            width: 335px;
            height: 54px;
        }
        .auto-style19 {
            width: 335px;
            height: 58px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Image ID="Image1" runat="server" Height="382px" Width="314px" />
            </td>
            <td class="auto-style17">
                <table class="auto-style2">
                    <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style6">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td class="auto-style6">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style6">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">
                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td class="auto-style6">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style6">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">
                            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td class="auto-style6">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style6">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">
                            <asp:Label ID="Label4" runat="server" Text="Quantity"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                <asp:ListItem>--Select--</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style6">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">
                            <asp:Label ID="Label5" runat="server" Text="Total Price"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:Label ID="Label6" runat="server" Text="₹"></asp:Label>
                            <asp:Label ID="Label7" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style13">
                </td>
            <td class="auto-style18">
                </td>
            <td class="auto-style15"></td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:ImageButton ID="ImageButton1" runat="server" CssClass="auto-style16" Height="53px" ImageUrl="~/add to cart.jpeg" OnClick="ImageButton1_Click" Width="365px" />
            </td>
            <td class="auto-style17">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton2" runat="server" CssClass="auto-style11" Height="67px" ImageUrl="~/continue shopping.jpeg" PostBackUrl="~/Userhome.aspx" Width="434px" />
                &nbsp;</td>
            <td>
                <asp:ImageButton ID="ImageButton3" runat="server" CssClass="auto-style12" Height="76px" ImageUrl="~/view cart.jpeg" Width="401px" PostBackUrl="~/ViewCart.aspx" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label8" runat="server" Text="Label" Visible="False" Font-Bold="True" Font-Size="Large" ForeColor="#009933"></asp:Label>
            </td>
            <td class="auto-style17">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style19"></td>
            <td class="auto-style10"></td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

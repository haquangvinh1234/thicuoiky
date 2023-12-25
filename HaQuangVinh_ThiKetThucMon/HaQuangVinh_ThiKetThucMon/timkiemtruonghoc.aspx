<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="timkiemtruonghoc.aspx.cs" Inherits="HaQuangVinh_ThiKetThucMon.timkiemtruonghoc" %>

<asp:Content ID="CThead" runat="server" ContentPlaceHolderID="CTHearder"></asp:Content>
<asp:Content ID="CTContent" runat="server" ContentPlaceHolderID="CTContent">
    <style>
        .left-title-1{
            font-size: 25px;
            padding: 10px 0 10px 0;
        }
        .btngroup{
            padding: 3px 3px 3px 3px;
            font-size: 16px;
            margin-top: 5px;
        }
        input[type="text"i]{
            padding: 3px 3px 3px 3px;
            font-size: 16px;
            margin-top: 5px;
        }
        .Erorr{
            margin-top: 10px;
        }
    </style>
    <div class="left-title-1">
        <asp:Label ID="Label1" runat="server" Text="TÌM KIẾM THÔNG TIN TRƯỜNG HỌC"></asp:Label>
    </div>
    <div class="table">
        <table>
            <tr>
                <td>Mã trường:</td>
                <td><asp:TextBox ID="txtMaTruong" runat="server"></asp:TextBox> </td>
                <td> <asp:Button ID="btnTimtheoma" CssClass="btngroup" runat="server" Text="Tìm theo mã" OnClick="btnTimtheoma_Click" /> </td>
            </tr>
              <tr>
                <td>Tên trường:</td>
                <td><asp:TextBox ID="txtTentruong" runat="server"></asp:TextBox> </td>
                <td><asp:Button ID="btnTimtheoten" CssClass="btngroup" runat="server" Text="Tìm theo tên" OnClick="btnTimtheoten_Click" /> </td>
            </tr>
        </table>
    </div>
    <div class="Erorr">
        <asp:Label ID="lblErorr" runat="server" Text=""></asp:Label>
    </div>
    <div class="gridView">
           <asp:GridView ID="grvDSTH" runat="server" Width="600px"  AutoGenerateColumns="False"  OnPageIndexChanging="grvDSTH_PageIndexChanging" CellPadding="4"  ForeColor="#333333" PageSize="8"  BackColor="White" AllowPaging="True" OnSelectedIndexChanged="grvDSTH_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="MaTruong" HeaderText="Mã trường" ReadOnly="True" />
                            <asp:BoundField DataField="TenTruong" HeaderText="Tên trường" />
                            <asp:CommandField SelectText="Chọn" ShowSelectButton="True" />
                        </Columns>
                 <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#0066CC" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
          </div>
</asp:Content>

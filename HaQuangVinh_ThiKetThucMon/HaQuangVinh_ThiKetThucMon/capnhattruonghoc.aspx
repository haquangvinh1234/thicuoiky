<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="capnhattruonghoc.aspx.cs" Inherits="HaQuangVinh_ThiKetThucMon.capnhattruonghoc" %>

<asp:Content ID="CThead" runat="server" ContentPlaceHolderID="CTHearder"></asp:Content>
<asp:Content ID="CTContent" runat="server" ContentPlaceHolderID="CTContent">
    <style>
        .left-title-1{
            font-size: 25px;
            padding: 10px 0 10px 0;
        }
        .btn{
            margin-top: 10px;
        }
        .groupBtn{
            padding: 3px 3px 3px 3px;
            font-size: 16px;
        }
        input[type="text"i]{
            padding: 3px 3px 3px 3px;
            font-size: 16px;
            margin-top: 5px;
        }
        .Erorr{
            margin: 10px 0 5px 0;
        }
    </style>
    <div class="left-title-1">
        <asp:Label ID="Label1" runat="server" Text="DANH SÁCH TRƯỜNG HỌC"></asp:Label>
    </div>
    <div class="table">
        <table>
            <tr>
                <td>Mã trường:</td>
                <td><asp:TextBox ID="txtMaTruong" runat="server"></asp:TextBox> </td>
                <td><asp:Label ID="lblErorrMatruong" runat="server" Text=""></asp:Label></td>
            </tr>
              <tr>
                <td>Tên trường:</td>
                <td><asp:TextBox ID="txtTentruong" runat="server"></asp:TextBox> </td>
            </tr>
        </table>
    </div>
    <div class="Erorr">
        <asp:Label ID="lblErorr" runat="server" Text=""></asp:Label>
    </div>
    <div class="gridView">
           <asp:GridView ID="grvDSTH" runat="server" Width="600px"  AutoGenerateColumns="False"  OnPageIndexChanging="grvDSTH_PageIndexChanging" CellPadding="4"  ForeColor="#333333" PageSize="4"  BackColor="White" AllowPaging="True" OnSelectedIndexChanged="grvDSTH_SelectedIndexChanged">
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
           <div class="btn">
                        <asp:Button ID="btnThem" CssClass="groupBtn" runat="server" Text="Thêm" OnClick="btnThem_Click"/>
                        <asp:Button ID="btnLuu" CssClass="groupBtn"  runat="server" Text="Lưu" OnClick="btnLuu_Click" />
                        <asp:Button ID="btnXoa" CssClass="groupBtn"  runat="server" Text="Xoá" OnClick="btnXoa_Click" />
                        <asp:Button ID="btnSua" CssClass="groupBtn"  runat="server" Text="Sửa" OnClick="btnSua_Click" />
           </div>
</asp:Content>
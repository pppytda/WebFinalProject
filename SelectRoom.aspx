<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectRoom.aspx.cs" Inherits="WebFinalProject.SelectRoom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <style type="text/css">
        body{
            background-image:url(img/Blur-4.png)
        }
        .auto-font {
            font-family: 'TH Sarabun New';
            font-size: larger;
        }
        .auto-imgColorStatus {
            width: 19px;
            height: 19px;
        }
        .auto-tableStyle{
            background-color: #666666;
            color: white;
            height: 30px;
            width: 82px;        
        }
        .auto-btRoomNormal {
            background-color: #cccccc;
            border-style: none;
        }
        .auto-btRoomRed {
            background-color: red;
            color: white;  
            border-style: none;   
            font-family: 'TH Sarabun New';       
        }
        .auto-fontRed {
            color: red;
            font-size: small; 
            font-size: large;           
        }
        .auto-Left {
            float: left;
        }
        .auto-Right {
            float: right;
        }
        .auto-MiddleVer {
            vertical-align: middle;
        }
        .auto-colorbtSelect {
            background-color: #223343;
        }
        .auto-colorbtOnSelect {
            background-color: #696969;
        }
    </style>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
        <br />
        <table width="1500" height="690" border="0" cellpadding="0" cellspacing="0" class="auto-font">
            <tr>
                <td bgcolor="#2DCB74" bordercolor="#2dcb74" class="auto-style5"></td>
                <td width="1201" bgcolor="#FFFFFF" bordercolor="#FFFFFF" align="center" valign="bottom" class="auto-style5">
                    <br />
                    <table border="0" class="auto-Left">
                        <td style="width:85px">
                            &nbsp;&nbsp;&nbsp;
                            <img src="img/profile.png" style="height: 29px; width: 28px"/></td>
                    </table>
                    <table border="0" class="auto-Right">
                        <td class="auto-MiddleVer">
                            <img src="img/search1.gif" style="height: 18px; width: 20px" class="auto-MiddleVer"/>&nbsp;
                            <asp:TextBox ID="tbSearchAll" runat="server" ForeColor="#cccccc" BorderStyle="Solid" BorderColor="#cccccc" Text=" Search" Height="24px" Width="170px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </table>
                    <br />
                    <img src="img/line.gif" width="1249" height="6" />
                </td>
            </tr>
            <tr>
                <td rowspan="2" bgcolor="#33495E" bordercolor="#33495E" valign="top">
                    <br />
                    <table border="0">
                        <td>
                            &nbsp;&nbsp;<asp:ImageButton ID="btMain" runat="server" ImageUrl="~/img/btMain.gif" Height="34px" Width="203px" />
                        </td>
                    </table>
                    <table border="0" class="auto-colorbtSelect">
                        <td width="300">
                            &nbsp;&nbsp;<asp:ImageButton ID="btBookRoom" runat="server" ImageUrl="~/img/btbookRoom.gif" Height="34px" Width="203px" />
                            <br />
                            <asp:ImageButton ID="btBookingRoom" runat="server" ImageUrl="~/img/btbooking.gif" Height="34px" Width="203px" />
                        </td>
                    </table>
                    <table border="0">
                        <td>
                            &nbsp;&nbsp;<asp:ImageButton ID="btChangeRoom" runat="server" ImageUrl="~/img/btChangeRoom.gif" Height="34px" Width="203px" />
                            <br />
                            &nbsp;&nbsp;<asp:ImageButton ID="btCancelRoom" runat="server" ImageUrl="~/img/btCancelRoom.gif" Height="34px" Width="203px" />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="btBookSche" runat="server" ImageUrl="~/img/btBookSchedule.gif" Height="34px" Width="210px" />
                            <br />
                            &nbsp;&nbsp;<asp:ImageButton ID="btAddBook" runat="server" ImageUrl="~/img/btAddBook.gif" Height="34px" Width="210px" />
                            <br />
                            &nbsp;&nbsp;<asp:ImageButton ID="btCheckRoom" runat="server" ImageUrl="~/img/btCheckRoom.gif" Height="34px" Width="210px" />
                            <br />
                            &nbsp;&nbsp;<asp:ImageButton ID="btCheckStatus" runat="server" ImageUrl="~/img/btCheckStatus.gif" Height="34px" Width="210px" />
                        </td>
                    </table>
                </td>    
                <td height="107" bgcolor="#FFFFFF" bordercolor="#FFFFFF">
                    <table align="Right" class="auto-MiddleVer">
                        <td>
                            <asp:ImageButton ID="btEditData" runat="server" ImageUrl="~/img/edit.png" Height="30px" Width="32px" CssClass="auto-MiddleVer" />
                            &nbsp;&nbsp;&nbsp;<asp:ImageButton ID="btLogOut" runat="server" ImageUrl="~/img/logout.png" Height="32px" Width="33px" CssClass="auto-MiddleVer" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </table>
                    <img src="img/linebook.gif" width="1249" height="34" />                    
                </td>
            </tr>
            <%-----------------------------------------------------------------------------------------------------------------------------%>
            <tr>
                <td height="402" bgcolor="#FFFFFF" bordercolor="#FFFFFF" valign="top" align="center" colspan="1">
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="เลือกวันที่ต้องการใช้ห้อง" CssClass="auto-font"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" CssClass="auto-font" Font-Size="Larger"></asp:DropDownList>
                    &nbsp;<asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" CssClass="auto-font" Font-Size="Larger"></asp:DropDownList>
                    &nbsp;<asp:DropDownList ID="ddlDay" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDay_SelectedIndexChanged" CssClass="auto-font" Font-Size="Larger"></asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                    <img alt="" class="auto-imgColorStatus" src="img/ห้องเรียนตามปกติ.jpg" />&nbsp;<asp:Label ID="lbRoomBlue" runat="server" Text="ห้องเรียนตามปกติ" Font-Bold="true" Font-Size="Large" CssClass="auto-font"></asp:Label>
                    &nbsp;&nbsp;<img alt="" class="auto-imgColorStatus" src="img/ไม่ว่าง.JPG" />&nbsp;<asp:Label ID="lbRoomRed" runat="server" Text="ห้องไม่ว่าง" Font-Bold="true" Font-Size="Large" CssClass="auto-font"></asp:Label>
                    &nbsp;&nbsp;<img alt="" class="auto-imgColorStatus" src="img/ไม่พร้อมใช้งาน.JPG" />&nbsp;<asp:Label ID="lbRoomYellow" runat="server" Text="ห้องไม่พร้อมใช้งาน" Font-Bold="true" Font-Size="Large" CssClass="auto-font"></asp:Label>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                    <br />
                    <br />
                    <table width="1212" border="1">
                        <tr>
                            <td class="auto-tableStyle"><center>Room/Text</center></td>
                            <td class="auto-tableStyle"><center>08:00-09:00</center></td>
                            <td class="auto-tableStyle"><center>09:00-10:00</center></td>
                            <td class="auto-tableStyle"><center>10:00-11:00</center></td>
                            <td class="auto-tableStyle"><center>11:00-12:00</center></td>
                            <td class="auto-tableStyle"><center>12:00-13:00</center></td>
                            <td class="auto-tableStyle"><center>13:00-14:00</center></td>
                            <td class="auto-tableStyle"><center>14:00-15:00</center></td>
                            <td class="auto-tableStyle"><center>15:00-16:00</center></td>
                            <td class="auto-tableStyle"><center>16:00-17:00</center></td>
                            <td class="auto-tableStyle"><center>17:00-18:00</center></td>
                            <td class="auto-tableStyle"><center>18:00-19:00</center></td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td class="auto-MiddleVer" style="background-color: #999999"><img src="img/bt981.gif" /></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98108" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98108_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98109" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98109_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98110" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98110_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98111" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98111_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98112" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98112_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98113" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98113_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98114" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98114_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98115" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98115_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98116" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98116_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98117" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98117_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98118" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98118_Click"/></center></td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td class="auto-MiddleVer" style="background-color: #999999"><img src="img/bt982.gif" /></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98208" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98208_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98209" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98209_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98210" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98210_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98211" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98211_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98212" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98212_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98213" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98213_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98214" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98214_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98215" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98215_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98216" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98216_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98217" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98217_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98218" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98218_Click"/></center></td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td class="auto-MiddleVer" style="background-color: #999999"><img src="img/bt983.gif" /></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98308" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98308_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98309" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98309_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98310" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98310_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98311" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98311_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98312" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98312_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98313" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98313_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98314" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98314_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98315" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98315_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98316" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98316_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98317" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98317_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98318" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt98318_Click"/></center></td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td class="auto-MiddleVer" style="background-color: #999999"><img src="img/bt971.gif" /></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97108" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97108_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97109" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97109_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97110" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97110_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97111" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97111_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97112" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97112_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97113" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97113_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97114" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97114_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97115" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97115_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97116" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97116_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97117" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97117_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97118" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97118_Click"/></center></td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td class="auto-MiddleVer" style="background-color: #999999"><img src="img/bt972.gif" /></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97208" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97208_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97209" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97209_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97210" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97210_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97211" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97211_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97212" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97212_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97213" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97213_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97214" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97214_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97215" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97215_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97216" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97216_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97217" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97217_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97218" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97218_Click"/></center></td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td class="auto-MiddleVer" style="background-color: #999999"><img src="img/bt973.gif" /></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97308" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97308_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97309" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97309_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97310" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97310_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97311" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97311_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97312" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97312_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97313" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97313_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97314" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97314_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97315" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97315_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97316" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97316_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97317" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97317_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97318" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt97318_Click"/></center></td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td class="auto-MiddleVer" style="background-color: #999999"><img src="img/bt962.gif" /></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96208" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96208_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96209" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96209_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96210" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96210_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96211" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96211_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96212" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96212_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96213" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96213_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96214" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96214_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96215" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96215_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96216" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96216_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96217" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96217_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96218" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96218_Click"/></center></td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td class="auto-MiddleVer" style="background-color: #999999"><img src="img/bt963.gif" /></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96308" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96308_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96309" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96309_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96310" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96310_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96311" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96311_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96312" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96312_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96313" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96313_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96314" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96314_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96315" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96315_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96316" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96316_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96317" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96317_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96318" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt96318_Click"/></center></td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td class="auto-MiddleVer" style="background-color: #999999"><img src="img/bt952.gif" /></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95208" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95208_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95209" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95209_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95210" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95210_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95211" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95211_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95212" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95212_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95213" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95213_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95214" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95214_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95215" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95215_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95216" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95216_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95217" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95217_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95218" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95218_Click"/></center></td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td class="auto-MiddleVer" style="background-color: #999999"><img src="img/bt953.gif" /></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95308" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95308_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95309" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95309_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95310" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95310_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95311" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95311_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95312" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95312_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95313" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95313_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95314" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95314_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95315" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95315_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95316" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95316_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95317" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95317_Click"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95318" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" OnClick="bt95318_Click"/></center></td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                </table>
                    <table style="width: 1207px" border="0">
                        <tr class="auto-Left"> 
                            <td class="auto-fontRed"><b>*ห้องที่มีสัญลักษณ์&nbsp;&nbsp;<img src="img/com.gif" style="height: 15px; width: 20px" />&nbsp;&nbsp;คือห้องปฏิบัติการคอมพิวเตอร์</b></td>                            
                        </tr>
                    </table>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>                    
                    <table style="width: 1207px" border="0">
                        <tr>
                            <td>
                                <asp:ImageButton ID="btBooking" runat="server" ImageUrl="~/img/btbook.gif" CssClass="auto-Right" OnClick="btBooking_Click" Height="36px" Width="101px" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <%-----------------------------------------------------------------------------------------------------------------------------%> 
                </td>
            </tr>                
        </table>
        </center>
    </div>
    </form>
</body>
</html>

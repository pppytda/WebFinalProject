<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testBT.aspx.cs" Inherits="WebFinalProject.Admin.testBT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <style type="text/css">
        body{            
            background-image:url(Blur-4.png);
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
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

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
                            <img src="../img/profile.png" style="height: 29px; width: 28px"/></td>
                    </table>
                    <table border="0" class="auto-Right">
                        <td class="auto-MiddleVer">
                            <img src="../img/search1.gif" style="height: 18px; width: 20px" class="auto-MiddleVer"/>&nbsp;
                            <asp:TextBox ID="tbSearchAll" runat="server" ForeColor="#cccccc" BorderStyle="Solid" BorderColor="#cccccc" Text=" Search" Height="24px" Width="170px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </table>
                    <br />
                    <img src="../img/line.gif" width="1249" height="6" />
                </td>
            </tr>
            <tr>
                <td rowspan="2" bgcolor="#33495E" bordercolor="#33495E" valign="top">
                <br />
                    <table border="0">
                        <td>
                            &nbsp;&nbsp;
                            <div class="btn-group-vertical">
                                <asp:ImageButton ID="btMain" runat="server" ImageUrl="~/img/btMain.gif" CssClass="btn btn-primary" Height="45px" Width="215px" BackColor="#33495e" BorderWidth="0"/>
                            </div>
                        </td>
                    </table>                    
                 &nbsp;&nbsp;  
                 <div class="btn-group">
                    <asp:ImageButton runat="server" ID="btBookRoom" ImageUrl="~/img/btMainbookRoom.gif" CssClass="btn btn-primary" Height="45px" Width="215px" BackColor="#33495e" BorderWidth="0"/>
                    <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" style="height:45px">
                    <span class="caret"></span>
                    </button>
                    <ul class="dropdown-menu" role="menu">
                        <li><a href="#" style="font-size:x-large">- เปลี่ยนห้องเรียน</a></li>
                        <li><a href="#" style="font-size:x-large">- ยกเลิกห้องเรียน</a></li>
                        <li><a href="#" style="font-size:x-large">- จองตามตารางเรียน</a></li>
                        <li><a href="#" style="font-size:x-large">- สรุปข้อมูลตารางเรียน</a></li>
                    </ul>
                 </div>
                 <br />
                 <table border="0" class="auto-colorbtSelect">
                    <td width="300">
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="btBookingRoom" runat="server" ImageUrl="~/img/btbooking.gif" Height="34px" Width="203px" />
                        <br />
                    </td>
                 </table>
                 <table border="0">
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <div class="btn-group-vertical">
                            <asp:ImageButton ID="btAddBook" runat="server" ImageUrl="~/img/btAddBook.gif" Height="33px" Width="208px" BackColor="#33495e" BorderWidth="0"/>
                        </div>
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <div class="btn-group-vertical">
                            <asp:ImageButton ID="btCheckRoom" runat="server" ImageUrl="~/img/btCheckRoom.gif" Height="33px" Width="208px" BackColor="#33495e" BorderWidth="0"/>
                        </div>
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <div class="btn-group-vertical">
                            <asp:ImageButton ID="btCheckStatus" runat="server" ImageUrl="~/img/btCheckProblem.gif" Height="33px" Width="208px" BackColor="#33495e" BorderWidth="0" />
                        </div>
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
                    <img src="../img/linebook.gif" width="1249" height="34" />                    
                </td>
            </tr>
            <%-----------------------------------------------------------------------------------------------------------------------------%>
            <tr>
                <td height="402" bgcolor="#FFFFFF" bordercolor="#FFFFFF" valign="top" align="center" colspan="1">
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="เลือกวันที่ต้องการใช้ห้อง" CssClass="auto-font"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" CssClass="auto-font" Font-Size="Larger"></asp:DropDownList>
                    &nbsp;<asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="true" CssClass="auto-font" Font-Size="Larger"></asp:DropDownList>
                    &nbsp;<asp:DropDownList ID="ddlDay" runat="server" AutoPostBack="true" CssClass="auto-font" Font-Size="Larger"></asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <img alt="" class="auto-imgColorStatus" src="../img/ห้องเรียนตามปกติ.jpg" />&nbsp;<asp:Label ID="lbRoomBlue" runat="server" Text="ห้องเรียนตามปกติ" Font-Bold="true" Font-Size="Large" CssClass="auto-font"></asp:Label>
                    &nbsp;&nbsp;<img alt="" class="auto-imgColorStatus" src="../img/ไม่ว่าง.JPG" />&nbsp;<asp:Label ID="lbRoomRed" runat="server" Text="ห้องเรียนชดเชย" Font-Bold="true" Font-Size="Large" CssClass="auto-font"></asp:Label>
                    &nbsp;&nbsp;&nbsp;<%-----------------------------------------------------------------------------------------------------------------------------%><br />
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
                            <td class="auto-MiddleVer" style="background-color: #999999"><img src="../img/bt981.gif" /></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98108" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal"/></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98109" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98110" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98111" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98112" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98113" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98114" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98115" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98116" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98117" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98118" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td class="auto-MiddleVer" style="background-color: #999999"><img src="../img/bt982.gif" /></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98208" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98209" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98210" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98211" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98212" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98213" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98214" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98215" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98216" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98217" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98218" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td class="auto-MiddleVer" style="background-color: #999999"><img src="../img/bt983.gif" /></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98308" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98309" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98310" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98311" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98312" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98313" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98314" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98315" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98316" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98317" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt98318" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td class="auto-MiddleVer" style="background-color: #999999"><img src="../img/bt971.gif" /></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97108" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97109" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97110" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97111" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97112" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97113" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97114" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97115" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97116" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97117" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97118" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td class="auto-MiddleVer" style="background-color: #999999"><img src="../img/bt972.gif" /></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97208" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97209" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97210" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97211" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97212" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97213" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97214" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97215" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97216" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97217" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97218" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td class="auto-MiddleVer" style="background-color: #999999"><img src="../img/bt973.gif" /></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97308" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97309" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97310" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97311" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97312" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97313" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97314" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97315" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97316" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97317" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt97318" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td class="auto-MiddleVer" style="background-color: #999999"><img src="../img/bt962.gif" /></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96208" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96209" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96210" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96211" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96212" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96213" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96214" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96215" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96216" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96217" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96218" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td class="auto-MiddleVer" style="background-color: #999999"><img src="../img/bt963.gif" /></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96308" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96309" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96310" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96311" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96312" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96313" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96314" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96315" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96316" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96317" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt96318" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td class="auto-MiddleVer" style="background-color: #999999"><img src="../img/bt952.gif" /></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95208" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95209" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95210" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95211" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95212" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95213" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95214" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95215" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95216" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95217" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95218" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td class="auto-MiddleVer" style="background-color: #999999"><img src="../img/bt953.gif" /></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95308" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95309" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95310" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95311" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95312" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95313" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95314" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95315" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95316" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95317" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                            <td class="auto-btRoomNormal"><center><asp:Button ID="bt95318" runat="server" BorderColor="#cccccc" Width="82px" Height="25px" CssClass="auto-btRoomNormal" /></center></td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                    <table style="width: 1207px" border="0">
                        <tr class="auto-Left"> 
                            <td class="auto-fontRed"><b>*ห้องที่มีสัญลักษณ์&nbsp;&nbsp;<img src="../img/com.gif" style="height: 15px; width: 20px" />&nbsp;&nbsp;คือห้องปฏิบัติการคอมพิวเตอร์</b></td>                            
                        </tr>
                    </table>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>                    
                    <table style="width: 1207px" border="0">
                        <tr>
                            <td>
                                <asp:ImageButton ID="btBooking" runat="server" ImageUrl="~/img/btbook.gif" CssClass="auto-Right" Height="36px" Width="101px" />
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

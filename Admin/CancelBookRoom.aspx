<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CancelBookRoom.aspx.cs" Inherits="WebFinalProject.Admin.CancelBookRoom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <style type="text/css">
        body{
            background-image:url(Blur-4.png)
        }
        .auto-font {            
            font-family: 'TH Sarabun New';
            font-size: x-large;
        }
        .auto-fontWhite {
            color: white;           
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
        .auto-style2 {
            height: 11px;
        }
        .auto-fontCCCCCC {
            color : #cccccc;
        }
        .auto-style3 {
            width: 190px;
        }
        .auto-style4 {
            width: 131px;
        }
        .auto-style5 {
            width: 164px;
        }
        .auto-style6 {
            width: 263px;
        }
        .auto-style7 {
            width: 191px;
        }
        </style>

    <title></title>
</head>
<body>    
    <form id="form1" runat="server">
    <div>
    <center>
        <asp:Panel ID="pnBookRoom" runat="server">
        <br />
            <table width="1500" height="690" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td bgcolor="#2DCB74" bordercolor="#2dcb74" class="auto-style2"></td>
                <td width="1201" bgcolor="#FFFFFF" bordercolor="#FFFFFF" align="center" valign="bottom" class="auto-style2">
                    <br />
                    <table border="0" class="auto-Left">
                        <tr>
                            <td style="width:85px" class="auto-MiddleVer">&nbsp;&nbsp;&nbsp;
                                <img src="../img/profile.png" style="height: 29px; width: 28px"/>
                            </td>
                        </tr>
                    </table>
                    <table border="0" class="auto-Right">
                        <tr class="auto-MiddleVer">
                            <td class="auto-MiddleVer">
                                <img src="../img/search1.gif" style="height: 18px; width: 20px" class="auto-MiddleVer"/>
                                &nbsp;
                                <asp:TextBox ID="tbSearchAll" runat="server" BorderColor="#cccccc" BorderStyle="Solid" ForeColor="#cccccc" Height="24px" Text=" Search" Width="170px"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp; 
                            </td>
                        </tr>
                    </table>
                    <br />
                    <img src="../img/line.gif" width="1249" height="6" />
                </td>
            </tr>
            <tr>
                <td rowspan="2" bgcolor="#33495E" bordercolor="#33495E" valign="top">
                    <br />
                    <table border="0">
                        <tr>
                            <td>&nbsp;&nbsp;<asp:ImageButton ID="btMain" runat="server" Height="34px" ImageUrl="~/img/btMain.gif" Width="203px" />
                            </td>
                        </tr>
                    </table>
                    <table border="0" class="auto-colorbtSelect">
                        <tr>
                            <td width="300">&nbsp;&nbsp;<asp:ImageButton ID="btBookRoom" runat="server" Height="34px" ImageUrl="~/img/btbookRoom.gif" Width="203px" />
                            </td>
                        </tr>
                    </table>
                    <table border="0">
                        <tr>
                            <td>&nbsp;&nbsp;<asp:ImageButton ID="btBookingRoom" runat="server" Height="34px" ImageUrl="~/img/btbooking2.gif" Width="203px" OnClick="btBookingRoom_Click" />
                                <br />
                                &nbsp;&nbsp;<asp:ImageButton ID="btChangeRoom" runat="server" Height="34px" ImageUrl="~/img/btChangeRoom.gif" Width="203px" />
                                <br />
                    </table>
                    <table border="0" class="auto-colorbtSelect">
                        <tr>
                            <td width="300">&nbsp;&nbsp;<asp:ImageButton ID="btCancelRoom" runat="server" Height="34px" ImageUrl="~/img/btCancelRoom2.gif" Width="203px" />
                            </td>
                        </tr>
                    </table>
                    <table border="0">
                                <tr>
                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="btBookSche" runat="server" Height="34px" ImageUrl="~/img/btBookSchedule.gif" Width="210px" OnClick="btBookSche_Click" />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/btDataSchedule.gif" Height="34px" Width="210px" />
                                        <br />
                                        &nbsp;&nbsp;<asp:ImageButton ID="btAddBook" runat="server" Height="34px" ImageUrl="~/img/btAddBook.gif" Width="210px" />
                                        <br />
                                        &nbsp;&nbsp;<asp:ImageButton ID="btCheckRoom" runat="server" Height="34px" ImageUrl="~/img/btCheckRoom.gif" Width="210px" />
                                        <br />
                                        &nbsp;&nbsp;<asp:ImageButton ID="btCheckStatus" runat="server" Height="34px" ImageUrl="~/img/btCheckProblem.gif" Width="210px" />
                                    </td>
                                </tr>
                    </table>
                </td>    
                <td height="107" bgcolor="#FFFFFF" bordercolor="#FFFFFF">
                    <table align="Right" class="auto-MiddleVer">
                        <tr>
                            <td>
                                <asp:ImageButton ID="btEditData" runat="server" CssClass="auto-MiddleVer" Height="30px" ImageUrl="~/img/edit.png" Width="32px" />
                                &nbsp;&nbsp;&nbsp;<asp:ImageButton ID="btLogOut" runat="server" CssClass="auto-MiddleVer" Height="32px" ImageUrl="~/img/logout.png" Width="33px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                        </tr>
                    </table>
                    <img src="../img/linecancel.gif" width="1249" height="26" />                    
                </td>
            </tr>
            <%-----------------------------------------------------------------------------------------------------------------------------%>
            <tr>
                <td height="402" bgcolor="#FFFFFF" bordercolor="#FFFFFF" valign="top" align="center" colspan="1">
                    <br />

                    <table border="0">
                        <tr>
                            <td valign="top" align="center">
                                <asp:Label ID="Label1" runat="server" Text="กรุณาเลือก วัน/เดือน/ปี ที่ต้องการ" CssClass="auto-font"></asp:Label>
                                &nbsp;<asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" CssClass="auto-font" Font-Size="X-Large" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"></asp:DropDownList>
                                &nbsp;<asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="true" CssClass="auto-font" Font-Size="X-Large" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"></asp:DropDownList>
                                &nbsp;<asp:DropDownList ID="ddlDay" runat="server" AutoPostBack="true" CssClass="auto-font" Font-Size="X-Large" OnSelectedIndexChanged="ddlDay_SelectedIndexChanged"></asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label2" runat="server" Text="ชื่อ-นามสกุล อาจารย์" CssClass="auto-font"></asp:Label>
                                &nbsp;<asp:TextBox ID="tbTeachName" runat="server" Height="24px"></asp:TextBox>                                
                            </td>
                            <td>
                                &nbsp;<asp:ImageButton ID="ImBtNext" runat="server" ImageUrl="~/img/next.png" Height="29px" Width="32px" OnClick="ImBtNext_Click" />
                            </td>
                        </tr>
                    </table>
                    <br />
                        <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <%-----------------------------------------------------------------------------------------------------------------------------%>
                    <table width="1000" style="background-color:#cccccc">
                        <tr  class="auto-fontWhite">
                            <td>
                                <center style="width: 75px">
                                    <b>วันที่</b>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <b>เวลาที่จอง</b>
                                </center>
                            </td>
                            <td class="auto-style3">
                                <center>
                                    <b>ห้องเรียนที่จอง</b>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <b>วิชาที่ทำการจอง</b>
                                </center>
                            </td>
                            <td class="auto-fontCCCCCC">
                                ยกเลิกห้องเรียน
                            </td>
                        </tr>
                    </table>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                    <table class="auto-font" width="1000" border="0">    
                        <tr>
                            <td class="auto-style4">
                                <center>
                                    <asp:Label ID="lbDate0" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td class="auto-style5">
                                <center>
                                    <asp:Label ID="lbTime0" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td class="auto-style7">
                                <center>
                                    <asp:Label ID="lbRoom0" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td class="auto-style6">
                                <center>
                                    <asp:Label ID="lbSubject0" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <asp:Button ID="btCancel0" runat="server" Text="ยกเลิกการจองห้อง" ForeColor="#3399ff" BorderStyle="None" BackColor="White" OnClick="btCancel0_Click" />
                            </td>
                        </tr>                        
                        <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td class="auto-style4">
                                <center>
                                    <asp:Label ID="lbDate1" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td class="auto-style5">
                                <center>
                                    <asp:Label ID="lbTime1" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td class="auto-style7">
                                <center>
                                    <asp:Label ID="lbRoom1" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td class="auto-style6">
                                <center>
                                    <asp:Label ID="lbSubject1" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Button ID="btCancel1" runat="server" Text="ยกเลิกการจองห้อง" ForeColor="#3399ff" BorderStyle="None" BackColor="White"></asp:Button>
                                </center>
                            </td>
                        </tr>
                        </table>

                    <asp:GridView ID="DataScheduleGridView" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="ScheduleID" HeaderText="วันที่" />
                            <asp:BoundField DataField="StartTime" HeaderText="เวลา" />
                            <asp:BoundField DataField="RoomNo" HeaderText="ห้องเรียน" />
                            <asp:BoundField DataField="SubjectNameTH" HeaderText="รายวิชาที่สอน" />
                            <asp:ButtonField Text="ยกเลิกการใช้ห้องเรียน" />
                        </Columns>
                    </asp:GridView>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                    </table>            
                    </td>
            </tr>                
        </table>
        </asp:Panel>
        </center>
    </div>
    </form>
</body>
</html>

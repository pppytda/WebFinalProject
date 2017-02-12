<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingScheduleRoom.aspx.cs" Inherits="WebFinalProject.Admin.BookingScheduleRoom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <style type="text/css">
        body{
            background-image:url(Blur-4.png)
        }
        .auto-fontRed {
            color: red;
            font-size: small;            
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
                                &nbsp;&nbsp;<asp:ImageButton ID="btCancelRoom" runat="server" Height="34px" ImageUrl="~/img/btCancelRoom.gif" Width="203px" />
                                <br />
                    </table>
                    <table border="0" class="auto-colorbtSelect">
                        <tr>
                            <td width="300">&nbsp;&nbsp;<asp:ImageButton ID="btBookSche" runat="server" Height="34px" ImageUrl="~/img/btBookSchedule2.gif" Width="210px" />
                            </td>
                        </tr>
                    </table>
                    <table border="0">
                                <tr>
                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/btDataSchedule.gif" Height="34px" Width="210px" />
                                        <br />
                                        &nbsp;&nbsp;<asp:ImageButton ID="btAddBook" runat="server" Height="34px" ImageUrl="~/img/btAddBook.gif" Width="210px" OnClick="btAddBook_Click" />
                                        <br />
                                        &nbsp;&nbsp;<asp:ImageButton ID="btCheckRoom" runat="server" Height="34px" ImageUrl="~/img/btCheckRoom.gif" Width="210px" OnClick="btCheckRoom_Click"/>
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
                    <img src="../img/line.gif" width="1249" height="6" />                    
                </td>
            </tr>
            <%-----------------------------------------------------------------------------------------------------------------------------%>
            <tr>
                <td height="402" bgcolor="#FFFFFF" bordercolor="#FFFFFF" valign="top" align="center" colspan="1">
                    <br />
                    <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="วัน"></asp:Label>
                    &nbsp;<asp:CheckBox ID="cbMon" runat="server" Text="จ."></asp:CheckBox>
                    &nbsp;<asp:CheckBox ID="cbTue" runat="server" Text="อ."></asp:CheckBox>
                    &nbsp;<asp:CheckBox ID="cbWed" runat="server" Text="พ."></asp:CheckBox>
                    &nbsp;<asp:CheckBox ID="cbThu" runat="server" Text="พฤ."></asp:CheckBox>
                    &nbsp;<asp:CheckBox ID="cbFri" runat="server" Text="ศ."></asp:CheckBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Font-Size="Large" Text="เวลา"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlStrTime" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStrTime_SelectedIndexChanged"></asp:DropDownList>
                    &nbsp;<asp:Label ID="Label3" runat="server" Font-Size="Large" Text="ถึง"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlEndTime" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEndTime_SelectedIndexChanged">
                    </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                    <br />              
                    <asp:Label ID="Label7" runat="server" Font-Size="Large" Text="เทอม"></asp:Label>
                    &nbsp;<asp:CheckBox ID="cbTerm1" runat="server" Text="เทอม 1"></asp:CheckBox>
                    &nbsp;<asp:CheckBox ID="cbTerm2" runat="server" Text="เทอม 2"></asp:CheckBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label8" runat="server" Font-Size="Large" Text="ภาคการศึกษา"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSemester_SelectedIndexChanged"></asp:DropDownList>
                    &nbsp;<asp:Button ID="btAddDate" runat="server" Text="เพิ่มการจองห้อง"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:Label ID="Label4" runat="server" Font-Size="Large" Text="ห้องเรียนที่ต้องการใช้"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="tbRoom" runat="server" Height="24px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:Label ID="Label5" runat="server" Font-Size="Large" Text="อาจารย์ที่ต้องการใช้ห้อง"></asp:Label>
                    &nbsp;<asp:TextBox ID="tbTeachName" runat="server" Height="24px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btSearchTech" runat="server" Text="ค้นหาอาจารย์" OnClick="btSearchTech_Click"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:Label ID="Label6" runat="server" Font-Size="Large" Text="รายวิชาที่สอน"></asp:Label>
                    &nbsp;<asp:TextBox ID="tbSubject" runat="server" Height="24px" Width="287px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btSearchSub" runat="server" Text="ค้นหารายวิชา" OnClick="btSearchSub_Click"/>
                    &nbsp;
                    <br />
                    <asp:Label ID="lbFaculty" runat="server" Font-Size="Large" Text="กลุ่มที่"></asp:Label>
                    &nbsp;<asp:TextBox ID="tbSec" runat="server" Height="24px" Width="168px"></asp:TextBox>
                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:Label ID="lbBranch" runat="server" Font-Size="Large" Text="ระดับชั้นปีการศึกษา"></asp:Label>
                    &nbsp;<asp:TextBox ID="tbBranch" runat="server" Height="24px" Width="168px"></asp:TextBox>
                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                      
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%-----------------------------------------------------------------------------------------------------------------------------%>
                    <center>
                        &nbsp;&nbsp;&nbsp;</center>
                    <table style="width: 927px" border="0">
                        <tr>
                            <td style="width: 870px">
                                <asp:ImageButton ID="ImBtSave" runat="server" ToolTip="บันทึกข้อมูล" Height="38px" ImageUrl="~/img/Devices (4).png" Width="38px" CssClass="auto-Right"/>
                                <asp:ImageButton ID="ImBtPrint" runat="server" ToolTip="สั่งพิมพ์" Height="38px" ImageUrl="~/img/printer.png" Width="38px" CssClass="auto-Left"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImBtCancel" runat="server" ToolTip="ยกเลิก" Height="35px" ImageUrl="~/img/cancel.gif" Width="35px" CssClass="auto-Right"/>
                           </td>
                        </tr>
                    <%-----------------------------------------------------------------------------------------------------------------------------%>
                    </table>
                </td>
            </tr>                
        </table>
        </asp:Panel>
        <%-----------------------------------------------------------------------------------------------------------------------------%>
        <asp:Panel ID="pnSearchTeach" runat="server" BackColor="#cccccc" BorderWidth="1px" BorderColor="#666666" Width="500px">
            <asp:Label ID="Label9" runat="server" Text="กรุณาเลือกอาจารย์ที่ต้องการใช้ห้อง" Font-Italic="true"></asp:Label>
            <br />
            <asp:CheckBoxList ID="cbListTeach" runat="server" OnSelectedIndexChanged="cbListTeach_SelectedIndexChanged"></asp:CheckBoxList>
            <asp:Button ID="btSelectTeach" runat="server" Text="เลือก" OnClick="btSelectTeach_Click"></asp:Button>
        </asp:Panel>
        <%-----------------------------------------------------------------------------------------------------------------------------%>
        <asp:Panel ID="pnSearchSub" runat="server" BackColor="#cccccc" BorderWidth="1px" BorderColor="#666666" Width="500px">
            <asp:Label ID="Label10" runat="server" Text="กรุณาเลือกรายวิชา" Font-Italic="true"></asp:Label>
            <br />
            <asp:CheckBoxList ID="cbListSub" runat="server" OnSelectedIndexChanged="cbListSub_SelectedIndexChanged"></asp:CheckBoxList>
            <asp:Button ID="btSelectSub" runat="server" Text="เลือก" OnClick="btSelectSub_Click"></asp:Button>
        </asp:Panel>
        <%-----------------------------------------------------------------------------------------------------------------------------%>
        </center>
    </div>
    </form>
</body>
</html>

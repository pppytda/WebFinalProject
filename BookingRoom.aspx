<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingRoom.aspx.cs" Inherits="WebFinalProject.BookingRoom" %>

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
                                <img src="img/profile.png" style="height: 29px; width: 28px"/>
                            </td>
                        </tr>
                    </table>
                    <table border="0" class="auto-Right">
                        <tr class="auto-MiddleVer">
                            <td class="auto-MiddleVer">
                                <img src="img/search1.gif" style="height: 18px; width: 20px" class="auto-MiddleVer"/>
                                &nbsp;
                                <asp:TextBox ID="tbSearchAll" runat="server" BorderColor="#cccccc" BorderStyle="Solid" ForeColor="#cccccc" Height="24px" Text=" Search" Width="170px"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp; 
                            </td>
                        </tr>
                    </table>
                    <br />
                    <img src="img/line.gif" width="1249" height="6" />
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
                    <table border="0">
                        <tr>
                            <td>&nbsp;&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" Height="34px" ImageUrl="~/img/btbookRoom2.gif" Width="203px" />
                                <br />
                                <asp:ImageButton ID="btBooking" runat="server" Height="34px" ImageUrl="~/img/btbooking2.gif" Width="203px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:ImageButton ID="btChangeRoom" runat="server" Height="34px" ImageUrl="~/img/btChangeRoom.gif" Width="203px" />
                                <br />
                                &nbsp;&nbsp;<asp:ImageButton ID="btCancelRoom" runat="server" Height="34px" ImageUrl="~/img/btCancelRoom.gif" Width="203px" />
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="btBookSche" runat="server" Height="34px" ImageUrl="~/img/btBookSchedule.gif" Width="210px" />
                                <br />
                                <table border="0" class="auto-colorbtSelect">
                                    <tr>
                                        <td width="300">&nbsp;&nbsp;<asp:ImageButton ID="btAddBook" runat="server" Height="34px" ImageUrl="~/img/btAddBook2.gif" Width="210px" />
                                        </td>
                                    </tr>
                                </table>
                                &nbsp;&nbsp;<asp:ImageButton ID="btCheckRoom" runat="server" Height="34px" ImageUrl="~/img/btCheckRoom.gif" Width="210px" />
                                <br />
                                &nbsp;&nbsp;<asp:ImageButton ID="btCheckStatus" runat="server" Height="34px" ImageUrl="~/img/btCheckStatus.gif" Width="210px" />
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
                    <img src="img/line.gif" width="1249" height="6" />                    
                </td>
            </tr>
            <%-----------------------------------------------------------------------------------------------------------------------------%>
            <tr>
                <td height="402" bgcolor="#FFFFFF" bordercolor="#FFFFFF" valign="top" align="center" colspan="1">
                    <br />
                    <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="วัน"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" CssClass="auto-font"></asp:DropDownList>
                    &nbsp;<asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" CssClass="auto-font"></asp:DropDownList>
                    &nbsp;<asp:DropDownList ID="ddlDay" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDay_SelectedIndexChanged" CssClass="auto-font"></asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Font-Size="Large" Text="เวลา"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlStrTime" runat="server" AutoPostBack="true" CssClass="auto-font" OnSelectedIndexChanged="ddlStrTime_SelectedIndexChanged"></asp:DropDownList>
                    &nbsp;<asp:Label ID="Label3" runat="server" Font-Size="Large" Text="ถึง"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlEndTime" runat="server" AutoPostBack="true" CssClass="auto-font"></asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btAddDayTime" runat="server" Text="เพิ่มวัน/เวลาการจองห้อง" OnClick="btAddDayTime_Click" />  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                  
                    <br />
                    <asp:Label ID="Label4" runat="server" Font-Size="Large" Text="ห้องเรียนที่ต้องการใช้"></asp:Label>
                    &nbsp;
                    <asp:Label ID="lbRoom" runat="server" BorderColor="#cccccc" Font-Bold="true"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:Label ID="Label5" runat="server" Font-Size="Large" Text="อาจารย์ที่ต้องการใช้ห้อง"></asp:Label>
                    &nbsp;<asp:TextBox ID="tbTeachName" runat="server" Height="24px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btSearchTech" runat="server" Text="ค้นหาอาจารย์"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:Label ID="Label6" runat="server" Font-Size="Large" Text="รายวิชาที่สอน"></asp:Label>
                    &nbsp;<asp:TextBox ID="tbSubject" runat="server" Height="24px" Width="287px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btSearchSub" runat="server" Text="ค้นหารายวิชา"/>
                    &nbsp;
                    <br />
                    <asp:Label ID="lbFaculty" runat="server" Font-Size="Large" Text="คณะ"></asp:Label>
                    &nbsp;<asp:TextBox ID="tbFaculty" runat="server" Height="24px" Width="232px"></asp:TextBox>
                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:Label ID="lbBranch" runat="server" Font-Size="Large" Text="สาขาวิชา"></asp:Label>
                    &nbsp;<asp:TextBox ID="tbBranch" runat="server" Height="24px" Width="198px"></asp:TextBox>
                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                       
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <%-----------------------------------------------------------------------------------------------------------------------------%> 
                    <center>                        
                        <asp:Label ID="tbTextAdd" Text="วันเวลาที่ต้องการจองห้องเรียน" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:TextBox ID="tbAddDate" runat="server"></asp:TextBox>
                    </center>
                    <asp:Panel ID="pnAddDate" runat="server" BackColor="#ffffff" BorderWidth="0">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;</asp:Panel>
                    <br />
                    <table style="width: 927px" border="0">
                        <tr>
                            <td style="width: 870px">
                                <asp:ImageButton ID="ImBtSave" runat="server" Height="38px" ImageUrl="~/img/Devices (4).png" Width="38px" CssClass="auto-Right" />
                            </td>
                            <td>
                                <asp:ImageButton ID="ImBtCancel" runat="server" Height="35px" ImageUrl="~/img/cancel.gif" Width="35px" CssClass="auto-Right" />
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
            <asp:Label ID="Label7" runat="server" Text="กรุณาเลือกอาจารย์ที่ต้องการใช้ห้อง" Font-Italic="true"></asp:Label>
            <br />
            <asp:CheckBoxList ID="cbListTeach" runat="server" ></asp:CheckBoxList>
            <asp:Button ID="btSelectTeach" runat="server" Text="เลือก" ></asp:Button>
        </asp:Panel>
        <%-----------------------------------------------------------------------------------------------------------------------------%>
        <asp:Panel ID="pnSearchSub" runat="server" BackColor="#cccccc" BorderWidth="1px" BorderColor="#666666" Width="500px">
            <asp:Label ID="Label8" runat="server" Text="กรุณาเลือกรายวิชา" Font-Italic="true"></asp:Label>
            <br />
            <asp:CheckBoxList ID="cbListSub" runat="server"></asp:CheckBoxList>
            <asp:Button ID="btSelectSub" runat="server" Text="เลือก" ></asp:Button>
        </asp:Panel>
        <%-----------------------------------------------------------------------------------------------------------------------------%>
        </center>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataSchedule.aspx.cs" Inherits="WebFinalProject.Admin.DataSchedule" %>

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
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="btBookSche" runat="server" Height="34px" ImageUrl="~/img/btBookSchedule.gif" Width="210px" OnClick="btBookSche_Click" />
                                <br />
                    </table>
                    <table border="0" class="auto-colorbtSelect">
                        <tr>
                            <td width="300">&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="btDataSchedule" runat="server" ImageUrl="~/img/btDataSchedule2.gif" Height="34px" Width="210px" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table border="0">
                        <tr>
                            <td>&nbsp;&nbsp;<asp:ImageButton ID="btAddBook" runat="server" Height="34px" ImageUrl="~/img/btAddBook.gif" Width="210px" OnClick="btAddBook_Click" />
                            <br />
                            &nbsp;&nbsp;<asp:ImageButton ID="btCheckRoom" runat="server" Height="34px" ImageUrl="~/img/btCheckRoom.gif" Width="210px" OnClick="btCheckRoom_Click" />
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
                    <asp:Label ID="Label1" runat="server" Text="ชื่ออาจารย์ :"></asp:Label>
                    &nbsp;&nbsp;<asp:TextBox ID="tbTeachName" runat="server"></asp:TextBox>
                    &nbsp;<asp:Button ID="btSearch" runat="server" Text="ค้นหา" OnClick="btSearch_Click" />
                    <br />
                    <br />
                    <asp:GridView ID="DataScheduleGridView" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="DayName" HeaderText="วัน" />
                            <asp:BoundField DataField="StartTime" HeaderText="เวลา" />
                            <asp:BoundField DataField="SubjectID" HeaderText="รหัสวิชา" />
                            <asp:BoundField DataField="TeachName" HeaderText="อาจารย์ผู้สอน" />
                            <asp:ButtonField ButtonType="Button" Text="แก้ไขข้อมูล" />
                            <asp:ButtonField ButtonType="Button" Text="ลบข้อมูล" />
                        </Columns>
                    </asp:GridView>
                    <br />                               
                </td>
            </tr>
            <%-----------------------------------------------------------------------------------------------------------------------------%>
            </table>   
        </asp:Panel>
        </center>
    </div>
    </form>
</body>
</html>

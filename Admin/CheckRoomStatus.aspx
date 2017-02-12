<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckRoomStatus.aspx.cs" Inherits="WebFinalProject.CheckRoomStatus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <style type="text/css">
        body{
            background-image:url(Blur-4.png)
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
        .auto-style3 {
            width: 321px;
        }
        .auto-style4 {
            width: 333px;
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
                    <table border="0">
                        <tr>
                            <td>&nbsp;&nbsp;<asp:ImageButton ID="btBookRoom" runat="server" Height="34px" ImageUrl="~/img/btbookRoom2.gif" Width="203px" />
                                <br />
                                <asp:ImageButton ID="btBooking" runat="server" Height="34px" ImageUrl="~/img/btbooking2.gif" Width="203px" OnClick="btBooking_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:ImageButton ID="btChangeRoom" runat="server" Height="34px" ImageUrl="~/img/btChangeRoom.gif" Width="203px" />
                                <br />
                                &nbsp;&nbsp;<asp:ImageButton ID="btCancelRoom" runat="server" Height="34px" ImageUrl="~/img/btCancelRoom.gif" Width="203px" OnClick="btCancelRoom_Click" />
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="btBookSche" runat="server" Height="34px" ImageUrl="~/img/btBookSchedule.gif" Width="210px" OnClick="btBookSche_Click" />
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="btDataSchedule" runat="server" ImageUrl="~/img/btDataSchedule.gif" Height="34px" Width="210px" OnClick="btDataSchedule_Click"/>
                                <br />                                
                                    <tr>
                                        <td width="300">&nbsp;&nbsp;<asp:ImageButton ID="btAddBook" runat="server" Height="34px" ImageUrl="~/img/btAddBook.gif" Width="210px" OnClick="btAddBook_Click" />
                                        </td>
                                    </tr>
                                <table border="0" class="auto-colorbtSelect">
                                    <tr>
                                        <td width="300">&nbsp;&nbsp;<asp:ImageButton ID="btCheckRoom" runat="server" Height="34px" ImageUrl="~/img/btCheckRoom2.gif" Width="210px" />
                                        </td>
                                    </tr>
                                </table>
                                <table border="0">
                                    <tr>
                                        <td>&nbsp;&nbsp;<asp:ImageButton ID="btCheckStatus" runat="server" Height="34px" ImageUrl="~/img/btCheckProblem.gif" Width="210px" />
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
                    <table class="auto-font" border="1" width="1000">
                        <tr>
                            <td class="auto-style3">
                                <center>
                                    <b>ห้อง</b></center>
                            </td>
                            <td class="auto-style4">
                                <center>
                                    <b>ผู้จองห้องเรียน</b></center>
                            </td>
                            <td>
                                <center>
                                    <b>สถานะห้องเรียน</b></center>
                            </td>
                        </tr>
                        </table>
                        <%-----------------------------------------------------------------------------------------------------------------------------%>
                    <table class="auto-font" width="1000" border="0">    
                        <tr>
                            <td>
                                <center>
                                    <asp:Label ID="lbRoom0" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbTeach0" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbStatus0" runat="server"></asp:Label>
                                </center>
                            </td>
                        </tr>
                        <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td>
                                <center>
                                    <asp:Label ID="lbRoom1" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbTeach1" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbStatus1" runat="server"></asp:Label>
                                </center>
                            </td>
                        </tr>
                        <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td>
                                <center>
                                    <asp:Label ID="lbRoom2" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbTeach2" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbStatus2" runat="server"></asp:Label>
                                </center>
                            </td>
                        </tr>
                        <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td>
                                <center>
                                    <asp:Label ID="lbRoom3" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbTeach3" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbStatus3" runat="server"></asp:Label>
                                </center>
                            </td>
                        </tr>
                        <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td>
                                <center>
                                    <asp:Label ID="lbRoom4" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbTeach4" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbStatus4" runat="server"></asp:Label>
                                </center>
                            </td>
                        </tr>
                        <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td>
                                <center>
                                    <asp:Label ID="lbRoom5" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbTeach5" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbStatus5" runat="server"></asp:Label>
                                </center>
                            </td>
                        </tr>
                        <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td>
                                <center>
                                    <asp:Label ID="lbRoom6" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbTeach6" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbStatus6" runat="server"></asp:Label>
                                </center>
                            </td>
                        </tr>
                        <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td>
                                <center>
                                    <asp:Label ID="lbRoom7" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbTeach7" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbStatus7" runat="server"></asp:Label>
                                </center>
                            </td>
                        </tr>
                        <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr>
                            <td>
                                <center>
                                    <asp:Label ID="lbRoom8" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbTeach8" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbStatus8" runat="server"></asp:Label>
                                </center>
                            </td>
                        </tr>
                        <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr border="1" style="border-color:black">
                            <td>
                                <center>
                                    <asp:Label ID="lbRoom9" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbTeach9" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbStatus9" runat="server"></asp:Label>
                                </center>
                            </td>
                        </tr>
                        <%-----------------------------------------------------------------------------------------------------------------------------%>
                        <tr border="1" style="border-color:black">
                            <td>
                                <center>
                                    <asp:Label ID="lbRoom10" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbTeach10" runat="server"></asp:Label>
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:Label ID="lbStatus10" runat="server"></asp:Label>
                                </center>
                            </td>
                        </tr>
                        </table>
                        <%-----------------------------------------------------------------------------------------------------------------------------%>
                    </table>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%-----------------------------------------------------------------------------------------------------------------------------%>
                </td>
            </tr>                
        </table>
        </asp:Panel>
        <%-----------------------------------------------------------------------------------------------------------------------------%>
        <%-----------------------------------------------------------------------------------------------------------------------------%>
        <%-----------------------------------------------------------------------------------------------------------------------------%>
        </center>
    </div>
    </form>
</body>
</html>

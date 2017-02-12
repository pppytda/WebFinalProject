using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFinalProject
{

    public partial class SelectRoom : System.Web.UI.Page
    {
        string DMY; //ประกาศไว้นอก Page_Load เพราะทุกครั้งที่มีการโหลดจะได้ไม่คืนค่าเดิม

        protected void Page_Load(object sender, EventArgs e)
        {
            btBookRoom.Enabled = false;
            btBookingRoom.Enabled = false;

            if (!IsPostBack)
            {
                ddlSelectYear();
                ddlSelectMonth();

                ddlMonth.Enabled = false;
                ddlDay.Enabled = false;

            }
            else if (IsPostBack)
            {
                ddlMonth.Enabled = true;
                ddlDay.Enabled = true;
            }
        }

        //แถบยกเลิกห้องเรียน
        protected void btCancelRoom_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/CancelBookRoom.aspx");
        }

        //แถบจองตามตารางเรียน
        protected void btBookSche_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/BookingScheduleRoom.aspx");
        }

        //แถบสรุปข้อมูลตามตารางเรียน
        protected void btDataSchedule_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/DataSchedule.aspx");
        }

        //แถบกรอกข้อมูลการใช้ห้องเรียน
        protected void btAddBook_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/BookingRoom.aspx");
        }

        //แถบเช็คสถานะห้องเรียน
        protected void btCheckRoom_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/CheckRoomStatus.aspx");
        }

        //dropdownlist ปี
        protected void ddlSelectYear()
        {
            string[] Years = { "กรุณาเลือกปี", "2017", "2016", "2015", "2014", "2013" };
            string[] valueYears = { "1", "2", "3", "4", "5", "6" };

            for (int i = 0; i < Years.Length; i++)
            {
                ddlYear.Items.Add(new ListItem(Years[i].ToString(), valueYears[i].ToString()));
            }
        }

        //dropdownlist ปี (กรณีมีการเลือก)
        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() != "กรุณาเลือกปี")
            {
                Session["DMY"] = ddlYear.SelectedItem.ToString();
            }
        }

        //dropdownlist เดือน
        protected void ddlSelectMonth()
        {
            string[] Month = { "กรุณาเลือกเดือน", "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม" };
            string[] valueMonth = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" };

            for (int i = 0; i < Month.Length; i++)
            {
                ddlMonth.Items.Add(new ListItem(Month[i].ToString(), valueMonth[i].ToString()));
            }
        }

        //dropdownlist เดือน (กรณีมีการเลือก)
        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMonth.SelectedItem.ToString() != "กรุณาเลือกเดือน")
            {
                Session.Add("Month", ddlMonth.SelectedIndex.ToString());
                ddlSelectDay();
            }
        }

        //dropdownlist วัน
        protected void ddlSelectDay()
        {
            string[] Days = { "กรุณาเลือกวันที่", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
            string[] valueDays = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32" };

            string NameMonth = ddlMonth.SelectedItem.ToString();
            string YearNum = ddlYear.SelectedItem.ToString();

            int year = Convert.ToInt32(YearNum);
            int years = year % 4; //สำหรับเอาปีมา mod ด้วย 4 หากเท่ากับ 0 เดือนกุมภาจะมี 29 วัน (4 ปีมีครั้ง)

            ddlDay.Items.Clear(); //เคลียร์ค่า ddl ทุกครั้งเพื่อจะไม่วนซ้ำ

            if (NameMonth == "มกราคม" || NameMonth == "มีนาคม" || NameMonth == "พฤษภาคม" || NameMonth == "กรกฎาคม" || NameMonth == "สิงหาคม" || NameMonth == "ตุลาคม" || NameMonth == "ธันวาคม")
            {
                for (int i = 0; i < Days.Length; i++)
                {
                    ddlDay.Items.Add(new ListItem(Days[i].ToString(), valueDays[i].ToString()));
                }
            }
            else if (NameMonth == "เมษายน" || NameMonth == "มิถุนายน" || NameMonth == "กันยายน" || NameMonth == "พฤศจิกายน")
            {
                for (int i = 0; i < 31; i++) //ถ้าหากเป็นวันที่ลงท้ายด้วย ยน จะโชว์แค่ 30 วัน (i < 31)
                {
                    ddlDay.Items.Add(new ListItem(Days[i].ToString(), valueDays[i].ToString()));
                }
            }
            else if (NameMonth == "กุมภาพันธ์" && (years.ToString()) != "0")
            {
                for (int i = 0; i < 29; i++)
                {
                    ddlDay.Items.Add(new ListItem(Days[i].ToString(), valueDays[i].ToString()));
                }
            }
            else if (NameMonth == "กุมภาพันธ์" && (years.ToString()) == "0") //เงื่อนไข mod ที่เท่ากับ 0 i จะน้อยกว่า 30 เพื่อให้เดือนกุมภาโชว์ 29 วัน
            {
                for (int i = 0; i < 30; i++)
                {
                    ddlDay.Items.Add(new ListItem(Days[i].ToString(), valueDays[i].ToString()));
                }
            }
        }

        //dropdownlist วัน (กรณีมีการเลือก)
        protected void ddlDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDay.SelectedItem.ToString() != "กรุณาเลือกวันที่")
            {
                Session.Add("Days", ddlDay.SelectedItem.ToString());

                if (ddlMonth.SelectedIndex.ToString().Length < 2)
                {
                    DMY = ddlYear.SelectedItem.ToString() + "-" + "0" + ddlMonth.SelectedIndex.ToString() + "-" + ddlDay.SelectedItem.ToString();
                }
                else if (ddlMonth.SelectedIndex.ToString().Length >= 2)
                {
                    DMY = ddlYear.SelectedItem.ToString() + "-" + ddlMonth.SelectedIndex.ToString() + "-" + ddlDay.SelectedItem.ToString();
                }

                displayRoomShow();
            }
        }
        
        //กำหนดค่า Index ให้กับเวลาเริ่มและสิ้นสุด 
        protected int getStartEndTime(String Time)
        {
            int timeIndex = 0;

            //กำหนดค่าให้เวลาเริ่มต้น
            if (Time == "09:00")
            {
                timeIndex = 1;
            }
            else if (Time == "10:00")
            {
                timeIndex = 2;
            }
            else if (Time == "11:00")
            {
                timeIndex = 3;
            }
            else if (Time == "12:00")
            {
                timeIndex = 4;
            }
            else if (Time == "13:00")
            {
                timeIndex = 5;
            }
            else if (Time == "14:00")
            {
                timeIndex = 6;
            }
            else if (Time == "15:00")
            {
                timeIndex = 7;
            }
            else if (Time == "16:00")
            {
                timeIndex = 8;
            }
            else if (Time == "17:00")
            {
                timeIndex = 9;
            }
            else if (Time == "18:00")
            {
                timeIndex = 10;
            }
            return timeIndex;
        }

        //การโชว์สีตามสถานะห้อง
        protected void displayRoomShow()
        {
            //กำหนด list ให้ปุ่มห้องตามชั่วโมงทุกปุ่ม เพื่อง่ายต่อการเช็คค่าใน for loop
            List<Button> room981 = new List<Button>();
            room981.Add(bt98108);
            room981.Add(bt98109);
            room981.Add(bt98110);
            room981.Add(bt98111);
            room981.Add(bt98112);
            room981.Add(bt98113);
            room981.Add(bt98114);
            room981.Add(bt98115);
            room981.Add(bt98116);
            room981.Add(bt98117);
            room981.Add(bt98118);

            List<Button> room982 = new List<Button>();
            room982.Add(bt98208);
            room982.Add(bt98209);
            room982.Add(bt98210);
            room982.Add(bt98211);
            room982.Add(bt98212);
            room982.Add(bt98213);
            room982.Add(bt98214);
            room982.Add(bt98215);
            room982.Add(bt98216);
            room982.Add(bt98217);
            room982.Add(bt98218);

            List<Button> room983 = new List<Button>();
            room983.Add(bt98308);
            room983.Add(bt98309);
            room983.Add(bt98310);
            room983.Add(bt98311);
            room983.Add(bt98312);
            room983.Add(bt98313);
            room983.Add(bt98314);
            room983.Add(bt98315);
            room983.Add(bt98316);
            room983.Add(bt98317);
            room983.Add(bt98318);

            List<Button> room971 = new List<Button>();
            room971.Add(bt97108);
            room971.Add(bt97109);
            room971.Add(bt97110);
            room971.Add(bt97111);
            room971.Add(bt97112);
            room971.Add(bt97113);
            room971.Add(bt97114);
            room971.Add(bt97115);
            room971.Add(bt97116);
            room971.Add(bt97117);
            room971.Add(bt97118);

            List<Button> room972 = new List<Button>();
            room972.Add(bt97208);
            room972.Add(bt97209);
            room972.Add(bt97210);
            room972.Add(bt97211);
            room972.Add(bt97212);
            room972.Add(bt97213);
            room972.Add(bt97214);
            room972.Add(bt97215);
            room972.Add(bt97216);
            room972.Add(bt97217);
            room972.Add(bt97218);

            List<Button> room973 = new List<Button>();
            room973.Add(bt97308);
            room973.Add(bt97309);
            room973.Add(bt97310);
            room973.Add(bt97311);
            room973.Add(bt97312);
            room973.Add(bt97313);
            room973.Add(bt97314);
            room973.Add(bt97315);
            room973.Add(bt97316);
            room973.Add(bt97317);
            room973.Add(bt97318);

            List<Button> room962 = new List<Button>();
            room962.Add(bt96208);
            room962.Add(bt96209);
            room962.Add(bt96210);
            room962.Add(bt96211);
            room962.Add(bt96212);
            room962.Add(bt96213);
            room962.Add(bt96214);
            room962.Add(bt96215);
            room962.Add(bt96216);
            room962.Add(bt96217);
            room962.Add(bt96218);

            List<Button> room963 = new List<Button>();
            room963.Add(bt96308);
            room963.Add(bt96309);
            room963.Add(bt96310);
            room963.Add(bt96311);
            room963.Add(bt96312);
            room963.Add(bt96313);
            room963.Add(bt96314);
            room963.Add(bt96315);
            room963.Add(bt96316);
            room963.Add(bt96317);
            room963.Add(bt96318);

            List<Button> room952 = new List<Button>();
            room952.Add(bt95208);
            room952.Add(bt95209);
            room952.Add(bt95210);
            room952.Add(bt95211);
            room952.Add(bt95212);
            room952.Add(bt95213);
            room952.Add(bt95214);
            room952.Add(bt95215);
            room952.Add(bt95216);
            room952.Add(bt95217);
            room952.Add(bt95218);

            List<Button> room953 = new List<Button>();
            room953.Add(bt95308);
            room953.Add(bt95309);
            room953.Add(bt95310);
            room953.Add(bt95311);
            room953.Add(bt95312);
            room953.Add(bt95313);
            room953.Add(bt95314);
            room953.Add(bt95315);
            room953.Add(bt95316);
            room953.Add(bt95317);
            room953.Add(bt95318);

            string conn = "Data Source=DESKTOP-BVC1DQ7;Initial Catalog=ClassroomManagementSystemBase;User ID=voondia;password=voondia";

            if (DMY != "")
            {
                SqlDataAdapter dtAdapterCount;
                DataTable dtCount = new DataTable();
                string QueryCount = "SELECT count(*) as no FROM timetable WHERE ScheduleID LIKE '%" + DMY + "%'";
                SqlConnection myCount = new SqlConnection(conn);
                dtAdapterCount = new SqlDataAdapter(QueryCount, conn);
                dtAdapterCount.Fill(dtCount);

                int qCount = (int)dtCount.Rows[0]["no"];

                //clear ปุ่มให้เป็นค่าปกติ 
                for (int i = 0; i < room981.Count; i++)
                {
                    room981.ElementAt(i).Enabled = true;
                    room981.ElementAt(i).CssClass = "auto-btRoomNormal";
                    room981.ElementAt(i).Text = "";
                }
                for (int i = 0; i < room982.Count; i++)
                {
                    room982.ElementAt(i).Enabled = true;
                    room982.ElementAt(i).CssClass = "auto-btRoomNormal";
                    room982.ElementAt(i).Text = "";
                }
                for (int i = 0; i < room983.Count; i++)
                {
                    room983.ElementAt(i).Enabled = true;
                    room983.ElementAt(i).CssClass = "auto-btRoomNormal";
                    room983.ElementAt(i).Text = "";
                }
                for (int i = 0; i < room971.Count; i++)
                {
                    room971.ElementAt(i).Enabled = true;
                    room971.ElementAt(i).CssClass = "auto-btRoomNormal";
                    room971.ElementAt(i).Text = "";
                }
                for (int i = 0; i < room972.Count; i++)
                {
                    room972.ElementAt(i).Enabled = true;
                    room972.ElementAt(i).CssClass = "auto-btRoomNormal";
                    room972.ElementAt(i).Text = "";
                }
                for (int i = 0; i < room973.Count; i++)
                {
                    room973.ElementAt(i).Enabled = true;
                    room973.ElementAt(i).CssClass = "auto-btRoomNormal";
                    room973.ElementAt(i).Text = "";
                }
                for (int i = 0; i < room962.Count; i++)
                {
                    room962.ElementAt(i).Enabled = true;
                    room962.ElementAt(i).CssClass = "auto-btRoomNormal";
                    room962.ElementAt(i).Text = "";
                }
                for (int i = 0; i < room963.Count; i++)
                {
                    room963.ElementAt(i).Enabled = true;
                    room963.ElementAt(i).CssClass = "auto-btRoomNormal";
                    room963.ElementAt(i).Text = "";
                }
                for (int i = 0; i < room952.Count; i++)
                {
                    room952.ElementAt(i).Enabled = true;
                    room952.ElementAt(i).CssClass = "auto-btRoomNormal";
                    room952.ElementAt(i).Text = "";
                }
                for (int i = 0; i < room953.Count; i++)
                {
                    room953.ElementAt(i).Enabled = true;
                    room953.ElementAt(i).CssClass = "auto-btRoomNormal";
                    room953.ElementAt(i).Text = "";
                }

                if (qCount > 0) //หากห้องไม่ว่างจะโชว์สีแดง
                {
                    SqlDataAdapter dtAdapter;
                    DataTable dt = new DataTable();
                    string QueryString = "SELECT SubjectID, StartTime, EndTime, RoomNo, TeachName FROM timetable WHERE ScheduleID LIKE '%" + DMY + "%'";
                    SqlConnection myConnection = new SqlConnection(conn);
                    dtAdapter = new SqlDataAdapter(QueryString, conn);
                    dtAdapter.Fill(dt);

                    //for สำหรับนับ row ของ dt เพื่อให้วน loop ให้ครบจำนวน
                    for (int cou = 0; cou < qCount; cou++)
                    {
                        string subID = (string)dt.Rows[cou]["SubjectID"];
                        DateTime strDT = (DateTime)dt.Rows[cou]["StartTime"];
                        DateTime endDT = (DateTime)dt.Rows[cou]["EndTime"];
                        string roomNo = (string)dt.Rows[cou]["RoomNo"];
                        string teachName = (string)dt.Rows[cou]["TeachName"];
                        string strDate = DateTime.Parse(strDT.ToString().Trim()).ToString("yyyy-MM-dd");
                        string strTime = DateTime.Parse(strDT.ToString().Trim()).ToString("HH:mm");
                        string endTime = DateTime.Parse(endDT.ToString().Trim()).ToString("HH:mm");

                        int str = getStartEndTime(strTime);
                        int sto = getStartEndTime(endTime); //ตำแหน่งที่ 1 คือ 09:00 (เวลาสิ้นสุด)

                        if (roomNo == "981" && strDate == DMY)
                        {
                            for (int i = str; i < sto; i++)
                            {
                                room981.ElementAt(i).Enabled = false;
                                room981.ElementAt(i).CssClass = "auto-btRoomRed";
                                room981.ElementAt(i).Text = subID + " " + teachName;
                            }
                        }
                        else if (roomNo == "982" && strDate == DMY)
                        {
                            for (int i = str; i < sto; i++)
                            {
                                room982.ElementAt(i).Enabled = false;
                                room982.ElementAt(i).CssClass = "auto-btRoomRed";
                                room982.ElementAt(i).Text = subID + " " + teachName;
                            }
                        }
                        else if (roomNo == "983" && strDate == DMY)
                        {
                            for (int i = str; i < sto; i++)
                            {
                                room983.ElementAt(i).Enabled = false;
                                room983.ElementAt(i).CssClass = "auto-btRoomRed";
                                room983.ElementAt(i).Text = subID + " " + teachName;
                            }
                        }
                        else if (roomNo == "971" && strDate == DMY)
                        {
                            for (int i = str; i < sto; i++)
                            {
                                room971.ElementAt(i).Enabled = false;
                                room971.ElementAt(i).CssClass = "auto-btRoomRed";
                                room971.ElementAt(i).Text = subID + " " + teachName;
                            }
                        }
                        else if (roomNo == "972" && strDate == DMY)
                        {
                            for (int i = str; i < sto; i++)
                            {
                                room972.ElementAt(i).Enabled = false;
                                room972.ElementAt(i).CssClass = "auto-btRoomRed";
                                room972.ElementAt(i).Text = subID + " " + teachName;
                            }
                        }
                        else if (roomNo == "973" && strDate == DMY)
                        {
                            for (int i = str; i < sto; i++)
                            {
                                room973.ElementAt(i).Enabled = false;
                                room973.ElementAt(i).CssClass = "auto-btRoomRed";
                                room973.ElementAt(i).Text = subID + " " + teachName;
                            }
                        }
                        else if (roomNo == "962" && strDate == DMY)
                        {
                            for (int i = str; i < sto; i++)
                            {
                                room962.ElementAt(i).Enabled = false;
                                room962.ElementAt(i).CssClass = "auto-btRoomRed";
                                room962.ElementAt(i).Text = subID + " " + teachName;
                            }
                        }
                        else if (roomNo == "963" && strDate == DMY)
                        {
                            for (int i = str; i < sto; i++)
                            {
                                room963.ElementAt(i).Enabled = false;
                                room963.ElementAt(i).CssClass = "auto-btRoomRed";
                                room963.ElementAt(i).Text = subID + " " + teachName;
                            }
                        }
                        else if (roomNo == "952" && strDate == DMY)
                        {
                            for (int i = str; i < sto; i++)
                            {
                                room952.ElementAt(i).Enabled = false;
                                room952.ElementAt(i).CssClass = "auto-btRoomRed";
                                room952.ElementAt(i).Text = subID + " " + teachName;
                            }
                        }
                        else if (roomNo == "953" && strDate == DMY)
                        {
                            for (int i = str; i < sto; i++)
                            {
                                room953.ElementAt(i).Enabled = false;
                                room953.ElementAt(i).CssClass = "auto-btRoomRed";
                                room953.ElementAt(i).Text = subID + " " + teachName;
                            }
                        }
                    }
                }
            }
        }

        //ปุ่มจองห้องเรียน
        protected void btBooking_Click(object sender, EventArgs e)
        {
            //ก่อนจะไปหน้ากรอกข้อมูล จะมีการเช็คว่าเลือก ป/ด/ว กับห้องและช่วงเวลาหรือยัง ถ้ายังจะแสดง error เตือน
            if (ddlYear.SelectedItem.ToString() != "กรุณาเลือกปี" && ddlMonth.SelectedItem.ToString() != "กรุณาเลือกเดือน" && ddlDay.SelectedItem.ToString() != "กรุณาเลือกวันที่" && Session["room"] != null)
            {
                Response.Redirect("~/Admin/BookingRoomFromTB.aspx");
            }
            else if (ddlYear.SelectedItem.ToString() != "กรุณาเลือกปี" && ddlMonth.SelectedItem.ToString() != "กรุณาเลือกเดือน" && ddlDay.SelectedItem.ToString() != "กรุณาเลือกวันที่" && Session["room"] == null)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือกห้องในช่วงเวลาที่ต้องการเข้าใช้')</script>");
            }
            else if (ddlYear.SelectedItem.ToString() != "กรุณาเลือกปี" && ddlMonth.SelectedItem.ToString() != "กรุณาเลือกเดือน" && ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน และห้องในช่วงเวลาที่ต้องการเข้าใช้')</script>");
            }
            else if (ddlYear.SelectedItem.ToString() != "กรุณาเลือกปี" && ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือน วัน และห้องในช่วงเวลาที่ต้องการเข้าใช้')</script>");
            }
            else if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน/เดือน/ปี และห้องในช่วงเวลาที่ต้องการเข้าใช้')</script>");
            }
        }

        //ในส่วน button จองห้องในตาราง จะมีการกำหนดค่าไว้ ว่า button ในเป็นห้องอะไร เวลาใด และใช้การเก็บ Session เพื่อส่งค่าไปอีกหน้า
        //981
        protected void bt98108_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98108.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "981";
                Session.Add("startTime", "08:00");
            }
        }

        protected void bt98109_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98109.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "981";
                Session.Add("startTime", "09:00");
            }
        }

        protected void bt98110_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98110.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "981";
                Session.Add("startTime", "10:00");
            }
        }

        protected void bt98111_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98111.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "981";
                Session.Add("startTime", "11:00");
            }
        }

        protected void bt98112_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98112.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "981";
                Session.Add("startTime", "12:00");
            }
        }

        protected void bt98113_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98113.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "981";
                Session.Add("startTime", "13:00");
            }
        }

        protected void bt98114_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98114.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "981";
                Session.Add("startTime", "14:00");
            }
        }

        protected void bt98115_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98115.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "981";
                Session.Add("startTime", "15:00");
            }
        }

        protected void bt98116_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98116.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "981";
                Session.Add("startTime", "16:00");
            }
        }

        protected void bt98117_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98117.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "981";
                Session.Add("startTime", "17:00");
            }
        }

        protected void bt98118_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98118.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "981";
                Session.Add("startTime", "18:00");
            }
        }

        //982
        protected void bt98208_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98208.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "982";
                Session.Add("startTime", "08:00");
            }
        }

        protected void bt98209_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98209.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "982";
                Session.Add("startTime", "09:00");
            }
        }

        protected void bt98210_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98210.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "982";
                Session.Add("startTime", "10:00");
            }
        }

        protected void bt98211_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98211.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "982";
                Session.Add("startTime", "11:00");
            }
        }

        protected void bt98212_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98212.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "982";
                Session.Add("startTime", "12:00");
            }
        }

        protected void bt98213_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98213.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "982";
                Session.Add("startTime", "13:00");
            }
        }

        protected void bt98214_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98214.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "982";
                Session.Add("startTime", "14:00");
            }
        }

        protected void bt98215_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98215.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "982";
                Session.Add("startTime", "15:00");
            }
        }

        protected void bt98216_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98216.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "982";
                Session.Add("startTime", "16:00");
            }
        }

        protected void bt98217_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98217.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "982";
                Session.Add("startTime", "17:00");
            }
        }

        protected void bt98218_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98218.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "982";
                Session.Add("startTime", "18:00");
            }
        }

        //983
        protected void bt98308_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98308.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "983";
                Session.Add("startTime", "08:00");
            }
        }

        protected void bt98309_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98309.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "983";
                Session.Add("startTime", "09:00");
            }
        }

        protected void bt98310_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98310.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "983";
                Session.Add("startTime", "10:00");
            }
        }

        protected void bt98311_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98311.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "983";
                Session.Add("startTime", "11:00");
            }
        }

        protected void bt98312_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98312.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "983";
                Session.Add("startTime", "12:00");
            }
        }

        protected void bt98313_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98313.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "983";
                Session.Add("startTime", "13:00");
            }
        }

        protected void bt98314_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98314.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "983";
                Session.Add("startTime", "14:00");
            }
        }

        protected void bt98315_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98315.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "983";
                Session.Add("startTime", "15:00");
            }
        }

        protected void bt98316_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98316.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "983";
                Session.Add("startTime", "16:00");
            }
        }

        protected void bt98317_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98317.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "983";
                Session.Add("startTime", "17:00");
            }
        }

        protected void bt98318_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt98318.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "983";
                Session.Add("startTime", "18:00");
            }
        }

        //971
        protected void bt97108_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97108.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "971";
                Session.Add("startTime", "08:00");
            }
        }

        protected void bt97109_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97109.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "971";
                Session.Add("startTime", "09:00");
            }
        }

        protected void bt97110_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97110.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "971";
                Session.Add("startTime", "10:00");
            }
        }

        protected void bt97111_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97111.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "971";
                Session.Add("startTime", "11:00");
            }
        }

        protected void bt97112_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97112.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "971";
                Session.Add("startTime", "12:00");
            }
        }

        protected void bt97113_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97113.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "971";
                Session.Add("startTime", "13:00");
            }
        }

        protected void bt97114_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97114.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "971";
                Session.Add("startTime", "14:00");
            }
        }

        protected void bt97115_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97115.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "971";
                Session.Add("startTime", "15:00");
            }
        }

        protected void bt97116_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97116.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "971";
                Session.Add("startTime", "16:00");
            }
        }

        protected void bt97117_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97117.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "971";
                Session.Add("startTime", "17:00");
            }
        }

        protected void bt97118_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97118.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "971";
                Session.Add("startTime", "18:00");
            }
        }

        //972
        protected void bt97208_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97208.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "972";
                Session.Add("startTime", "08:00");
            }
        }

        protected void bt97209_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97209.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "972";
                Session.Add("startTime", "09:00");
            }
        }

        protected void bt97210_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97210.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "972";
                Session.Add("startTime", "10:00");
            }
        }

        protected void bt97211_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97211.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "972";
                Session.Add("startTime", "11:00");
            }
        }

        protected void bt97212_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97212.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "972";
                Session.Add("startTime", "12:00");
            }
        }

        protected void bt97213_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97213.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "972";
                Session.Add("startTime", "13:00");
            }
        }

        protected void bt97214_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97214.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "972";
                Session.Add("startTime", "14:00");
            }
        }

        protected void bt97215_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97215.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "972";
                Session.Add("startTime", "15:00");
            }
        }

        protected void bt97216_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97216.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "972";
                Session.Add("startTime", "16:00");
            }
        }

        protected void bt97217_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97217.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "972";
                Session.Add("startTime", "17:00");
            }
        }

        protected void bt97218_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97218.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "972";
                Session.Add("startTime", "18:00");
            }
        }

        //973
        protected void bt97308_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97308.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "973";
                Session.Add("startTime", "08:00");
            }
        }

        protected void bt97309_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97309.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "973";
                Session.Add("startTime", "09:00");
            }
        }

        protected void bt97310_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97310.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "973";
                Session.Add("startTime", "10:00");
            }
        }

        protected void bt97311_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97311.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "973";
                Session.Add("startTime", "11:00");
            }
        }

        protected void bt97312_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97312.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "973";
                Session.Add("startTime", "12:00");
            }
        }

        protected void bt97313_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97313.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "973";
                Session.Add("startTime", "13:00");
            }
        }

        protected void bt97314_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97314.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "973";
                Session.Add("startTime", "14:00");
            }
        }

        protected void bt97315_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97315.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "973";
                Session.Add("startTime", "15:00");
            }
        }

        protected void bt97316_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97316.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "973";
                Session.Add("startTime", "16:00");
            }
        }

        protected void bt97317_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97317.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "973";
                Session.Add("startTime", "17:00");
            }
        }

        protected void bt97318_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt97318.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "973";
                Session.Add("startTime", "18:00");
            }
        }

        //962
        protected void bt96208_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96208.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "962";
                Session.Add("startTime", "08:00");
            }
        }

        protected void bt96209_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96209.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "962";
                Session.Add("startTime", "09:00");
            }
        }

        protected void bt96210_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96210.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "962";
                Session.Add("startTime", "10:00");
            }
        }

        protected void bt96211_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96211.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "962";
                Session.Add("startTime", "11:00");
            }
        }

        protected void bt96212_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96212.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "962";
                Session.Add("startTime", "12:00");
            }
        }

        protected void bt96213_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96213.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "962";
                Session.Add("startTime", "13:00");
            }
        }

        protected void bt96214_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96214.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "962";
                Session.Add("startTime", "14:00");
            }
        }

        protected void bt96215_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96215.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "962";
                Session.Add("startTime", "15:00");
            }
        }

        protected void bt96216_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96216.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "962";
                Session.Add("startTime", "16:00");
            }
        }

        protected void bt96217_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96217.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "962";
                Session.Add("startTime", "17:00");
            }
        }

        protected void bt96218_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96218.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "962";
                Session.Add("startTime", "18:00");
            }
        }

        //963
        protected void bt96308_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96308.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "963";
                Session.Add("startTime", "08:00");
            }
        }

        protected void bt96309_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96309.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "963";
                Session.Add("startTime", "09:00");
            }
        }

        protected void bt96310_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96310.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "963";
                Session.Add("startTime", "10:00");
            }
        }

        protected void bt96311_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96311.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "963";
                Session.Add("startTime", "11:00");
            }
        }

        protected void bt96312_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96312.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "963";
                Session.Add("startTime", "12:00");
            }
        }

        protected void bt96313_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96313.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "963";
                Session.Add("startTime", "13:00");
            }
        }

        protected void bt96314_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96314.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "963";
                Session.Add("startTime", "14:00");
            }
        }

        protected void bt96315_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96315.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "963";
                Session.Add("startTime", "15:00");
            }
        }

        protected void bt96316_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96316.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "963";
                Session.Add("startTime", "16:00");
            }
        }

        protected void bt96317_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96317.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "963";
                Session.Add("startTime", "17:00");
            }
        }

        protected void bt96318_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt96318.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "963";
                Session.Add("startTime", "18:00");
            }
        }

        //952
        protected void bt95208_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95208.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "952";
                Session.Add("startTime", "08:00");
            }
        }

        protected void bt95209_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95209.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "952";
                Session.Add("startTime", "09:00");
            }
        }

        protected void bt95210_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95210.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "952";
                Session.Add("startTime", "10:00");
            }
        }

        protected void bt95211_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95211.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "952";
                Session.Add("startTime", "11:00");
            }
        }

        protected void bt95212_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95212.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "952";
                Session.Add("startTime", "12:00");
            }
        }

        protected void bt95213_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95213.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "952";
                Session.Add("startTime", "13:00");
            }
        }

        protected void bt95214_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95214.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "952";
                Session.Add("startTime", "14:00");
            }
        }

        protected void bt95215_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95215.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "952";
                Session.Add("startTime", "15:00");
            }
        }

        protected void bt95216_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95216.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "952";
                Session.Add("startTime", "16:00");
            }
        }

        protected void bt95217_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95217.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "952";
                Session.Add("startTime", "17:00");
            }
        }

        protected void bt95218_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95218.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "952";
                Session.Add("startTime", "18:00");
            }
        }

        //953
        protected void bt95308_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95308.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "953";
                Session.Add("startTime", "08:00");
            }
        }

        protected void bt95309_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95309.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "953";
                Session.Add("startTime", "09:00");
            }
        }

        protected void bt95310_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95310.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "953";
                Session.Add("startTime", "10:00");
            }
        }

        protected void bt95311_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95311.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "953";
                Session.Add("startTime", "11:00");
            }
        }

        protected void bt95312_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95312.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "953";
                Session.Add("startTime", "12:00");
            }
        }

        protected void bt95313_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95313.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "953";
                Session.Add("startTime", "13:00");
            }
        }

        protected void bt95314_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95314.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "953";
                Session.Add("startTime", "14:00");
            }
        }

        protected void bt95315_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95315.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "953";
                Session.Add("startTime", "15:00");
            }
        }

        protected void bt95316_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95316.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "953";
                Session.Add("startTime", "16:00");
            }
        }

        protected void bt95317_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95317.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "953";
                Session.Add("startTime", "17:00");
            }
        }

        protected void bt95318_Click(object sender, EventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการเข้าใช้ก่อน')</script>");
            }
            else
            {
                //bt95318.CssClass = "auto-colorbtOnSelect";

                Session["room"] = "953";
                Session.Add("startTime", "18:00");
            }
        }
    }
}
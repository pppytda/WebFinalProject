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
    public partial class BookingRoom : System.Web.UI.Page
    {
        List<Label> ArrayLabel;
        int numOfAdd = 0;
        int checkList = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            btAddBook.Enabled = false;
            tbFaculty.Enabled = false;
            tbBranch.Enabled = false;
            lbRoom.Visible = false;
            tbTextAdd.Visible = false;
            tbAddDate.Visible = false;
            pnSearchTeach.Visible = false;
            pnSearchSub.Visible = false;

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

            if (Session["DayOne"] != null && Session["TimeStrEnd"] != null)
            {
                lbRoom.Visible = true;
                tbTextAdd.Visible = true;
                tbAddDate.Visible = true;

                tbRoom.Visible = false;

                lbRoom.Text = Session["room"].ToString();
                tbAddDate.Text = Session["DayOne"] + " " + ":" + " " + Session["TimeStrEnd"];
            }
        }

        //แถบการจองห้องเรียน
        protected void btBooking_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/SelectRoom.aspx");
        }

        //แถบเช็คสถานะห้องเรียน
        protected void btCheckRoom_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/CheckRoomStatus.aspx");
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
                ddlStart();

                if (ddlMonth.SelectedIndex.ToString().Length < 2)
                {
                    Session["DMY"] = ddlYear.SelectedItem.ToString() + "-" + "0" + ddlMonth.SelectedIndex.ToString() + "-" + ddlDay.SelectedItem.ToString();
                }
                else if (ddlMonth.SelectedIndex.ToString().Length >= 2)
                {
                    Session["DMY"] = ddlYear.SelectedItem.ToString() + "-" + ddlMonth.SelectedIndex.ToString() + "-" + ddlDay.SelectedItem.ToString();
                }
            }
        }

        //dropdownlist เวลาเริ่มต้นการใช้ห้อง
        protected void ddlStart()
        {
            string[] StrTime = { "กรุณาเลือกเวลา", "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00" };
            string[] valueStr = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };

            ddlStrTime.Items.Clear();

            for (int i = 0; i < StrTime.Length; i++)
            {
                ddlStrTime.Items.Add(new ListItem(StrTime[i].ToString(), valueStr[i].ToString()));
            }
        }

        //กรณีมีการเลือกเวลาเริ่มต้นแล้ว
        protected void ddlStrTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["str"] = ddlStrTime.SelectedItem.Text;
            ddlEnd();
        }

        //dropdownlist เวลาสิ้นสุดการใช้ห้อง
        protected void ddlEnd()
        {
            string[] EndTime = { "", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00" };
            string[] valueEnd = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };

            ddlEndTime.Items.Clear();

            //จะมีการเช็คเงื่อนไขเวลาเริ่มต้น เพื่อให้ DropDownList เวลาสิ้นสุดโชว์แค่เวลาถัดไปจากเวลาเริ่ม
            if (Session["str"].ToString().Equals("08:00"))
            {
                for (int i = 1; i < EndTime.Length; i++)
                {
                    ddlEndTime.Items.Add(new ListItem(EndTime[i].ToString(), valueEnd[i].ToString()));
                }

            }
            else if (Session["str"].ToString().Equals("09:00"))
            {
                for (int i = 2; i < EndTime.Length; i++)
                {
                    ddlEndTime.Items.Add(new ListItem(EndTime[i].ToString(), valueEnd[i].ToString()));
                }
            }
            else if (Session["str"].ToString().Equals("10:00"))
            {
                for (int i = 3; i < EndTime.Length; i++)
                {
                    ddlEndTime.Items.Add(new ListItem(EndTime[i].ToString(), valueEnd[i].ToString()));
                }
            }
            else if (Session["str"].ToString().Equals("11:00"))
            {
                for (int i = 4; i < EndTime.Length; i++)
                {
                    ddlEndTime.Items.Add(new ListItem(EndTime[i].ToString(), valueEnd[i].ToString()));
                }
            }
            else if (Session["str"].ToString().Equals("12:00"))
            {
                for (int i = 5; i < EndTime.Length; i++)
                {
                    ddlEndTime.Items.Add(new ListItem(EndTime[i].ToString(), valueEnd[i].ToString()));
                }
            }
            else if (Session["str"].ToString().Equals("13:00"))
            {
                for (int i = 6; i < EndTime.Length; i++)
                {
                    ddlEndTime.Items.Add(new ListItem(EndTime[i].ToString(), valueEnd[i].ToString()));
                }
            }
            else if (Session["str"].ToString().Equals("14:00"))
            {
                for (int i = 7; i < EndTime.Length; i++)
                {
                    ddlEndTime.Items.Add(new ListItem(EndTime[i].ToString(), valueEnd[i].ToString()));
                }
            }
            else if (Session["str"].ToString().Equals("15:00"))
            {
                for (int i = 8; i < EndTime.Length; i++)
                {
                    ddlEndTime.Items.Add(new ListItem(EndTime[i].ToString(), valueEnd[i].ToString()));
                }
            }
            else if (Session["str"].ToString().Equals("16:00"))
            {
                for (int i = 9; i < EndTime.Length; i++)
                {
                    ddlEndTime.Items.Add(new ListItem(EndTime[i].ToString(), valueEnd[i].ToString()));
                }
            }
            else if (Session["str"].ToString().Equals("17:00"))
            {
                for (int i = 10; i < EndTime.Length; i++)
                {
                    ddlEndTime.Items.Add(new ListItem(EndTime[i].ToString(), valueEnd[i].ToString()));
                }
            }
            else if (Session["str"].ToString().Equals("18:00"))
            {
                for (int i = 11; i < EndTime.Length; i++)
                {
                    ddlEndTime.Items.Add(new ListItem(EndTime[i].ToString(), valueEnd[i].ToString()));
                }
            }
        }

        //dropdownlist เวลาสิ้นสุดการใช้ห้อง กรณีมีการเลือก
        protected void ddlEndTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["TimeEnd"] = ddlEndTime.SelectedItem.ToString();
        }

        //ปุ่มค้นหาอาจารย์
        protected void btSearchTech_Click(object sender, EventArgs e)
        {
            //เก็บค่า text ของช่องที่ให้กรอกอาจารย์ แล้วมีการเช็คเงื่อนไข if else หากเป็นค่าว่างจะแสดง pop-up ให้กรอกข้อมูล หากมีการกรอก จะค้นหาแค่อาจารย์คนนั้น
            string teachname = tbTeachName.Text;

            string conn = "Data Source=DESKTOP-BVC1DQ7;Initial Catalog=ClassroomManagementSystemBase;User ID=voondia;password=voondia";

            if (teachname == "")
            {
                string QueryString = "SELECT TeachName FROM TeacherTable";
                SqlConnection myConnection = new SqlConnection(conn);
                SqlDataAdapter myCommand = new SqlDataAdapter(QueryString, myConnection);
                DataSet ds = new DataSet();
                myCommand.Fill(ds, "Teacher");

                pnBookRoom.Visible = false;
                pnSearchTeach.Visible = true;

                this.cbListTeach.DataSource = ds;
                this.cbListTeach.DataTextField = "TeachName";
                this.cbListTeach.DataValueField = "TeachName";
                this.cbListTeach.DataBind();
            }
            else if (teachname != "")
            {
                SqlDataAdapter dtAdapterCount;
                DataTable dtCount = new DataTable();
                string QueryCount = "SELECT count(*) as no FROM TeacherTable WHERE TeachName LIKE '%" + teachname + "%'";
                SqlConnection myCount = new SqlConnection(conn);
                dtAdapterCount = new SqlDataAdapter(QueryCount, conn);
                dtAdapterCount.Fill(dtCount);

                int qCount = (int)dtCount.Rows[0]["no"];

                if (qCount > 0)
                {
                    string QueryString = "SELECT * FROM TeacherTable WHERE TeachName LIKE '%" + teachname + "%'";

                    SqlConnection myConnection = new SqlConnection(conn);
                    SqlDataAdapter myCommand = new SqlDataAdapter(QueryString, myConnection);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Teacher");

                    pnBookRoom.Visible = false;
                    pnSearchTeach.Visible = true;

                    this.cbListTeach.DataSource = ds;
                    this.cbListTeach.DataTextField = "TeachName";
                    this.cbListTeach.DataValueField = "TeachName";
                    this.cbListTeach.DataBind();
                }
                else if (qCount <= 0)
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('ไม่พบข้อมูลอาจารย์ที่ทำการค้นหา กรุณากรอกข้อมูลอาจารย์ที่ต้องการใช้ห้องอีกครั้ง')</script>");
                }
            }
        }

        //checkboxlist แสดงชื่ออาจารย์ (กรณีมีการเลือก) 
        protected void cbListTeach_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkList++;

            Session["Teacher"] = cbListTeach.Text.ToString();
            Session.Add("TeachName", cbListTeach.Text.ToString());
        }

        //ปุ่มเลือกอาจารย์ในหน้าแสดงอาจารย์
        protected void btSelectTeach_Click(object sender, EventArgs e)
        {
            if (checkList > 0)
            {
                pnSearchTeach.Visible = false;
                pnBookRoom.Visible = true;

                tbTeachName.Text = Session["TeachName"].ToString();

                checkList = 0;
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือกอาจารย์ที่ต้องการใช้ห้อง')</script>");
                pnSearchTeach.Visible = true;
            }
        }

        //ปุ่มค้นหารายวิชา
        protected void btSearchSub_Click(object sender, EventArgs e)
        {
            //เก็บค่า text ของช่องที่ให้กรอกรายวิชา แล้วมีการเช็คเงื่อนไข if else หากเป็นค่าว่างจะแสดง pop-up ให้กรอกข้อมูล หากมีการกรอก จะค้นหาแค่รายวิชานั้น
            string subName = tbSubject.Text;

            string conn = "Data Source=DESKTOP-BVC1DQ7;Initial Catalog=ClassroomManagementSystemBase;User ID=voondia;password=voondia";

            if (subName == "")
            {
                string QueryString = "SELECT SubjectNameTH FROM SubjectTable";
                SqlConnection myConnection = new SqlConnection(conn);
                SqlDataAdapter myCommand = new SqlDataAdapter(QueryString, myConnection);
                DataSet ds = new DataSet();
                myCommand.Fill(ds, "Subject");

                pnBookRoom.Visible = false;
                pnSearchTeach.Visible = true;

                this.cbListTeach.DataSource = ds;
                this.cbListTeach.DataTextField = "SubjectNameTH";
                this.cbListTeach.DataValueField = "SubjectNameTH";
                this.cbListTeach.DataBind();
            }
            else if (subName != "")
            {
                SqlDataAdapter dtAdapterCount;
                DataTable dtCount = new DataTable();
                string QueryCount = "SELECT count(*) as no FROM SubjectTable WHERE SubjectNameTH LIKE '%" + subName + "%'";
                SqlConnection myCount = new SqlConnection(conn);
                dtAdapterCount = new SqlDataAdapter(QueryCount, conn);
                dtAdapterCount.Fill(dtCount);

                int qCount = (int)dtCount.Rows[0]["no"];

                if (qCount > 0)
                {
                    string QueryString = "SELECT * FROM SubjectTable WHERE SubjectNameTH LIKE '%" + subName + "%'";

                    SqlConnection myConnection = new SqlConnection(conn);
                    SqlDataAdapter myCommand = new SqlDataAdapter(QueryString, myConnection);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "Subject");

                    pnBookRoom.Visible = false;
                    pnSearchSub.Visible = true;

                    this.cbListSub.DataSource = ds;
                    this.cbListSub.DataTextField = "SubjectNameTH";
                    this.cbListSub.DataValueField = "SubjectNameTH";
                    this.cbListSub.DataBind();
                }
                else if (qCount <= 0)
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('ไม่พบข้อมูลรายวิชาที่ทำการค้นหา กรุณากรอกข้อมูลรายวิชาอีกครั้ง')</script>");
                }
            }
        }

        //checkboxlist แสดงชื่อรายวิชา(กรณีมีการเลือก)
        protected void cbListSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkList++;

            Session["Subject"] = cbListSub.Text.ToString();
            Session.Add("SubName", cbListSub.Text.ToString());
        }

        //ปุ่มเลือกรายวิชาในหน้าแสดงรายวิชา
        protected void btSelectSub_Click(object sender, EventArgs e)
        {
            if (checkList > 0)
            {
                pnSearchSub.Visible = false;
                pnBookRoom.Visible = true;
                lbFaculty.Visible = true;
                lbBranch.Visible = true;
                tbFaculty.Visible = true;
                tbFaculty.Enabled = false;
                tbBranch.Visible = true;
                tbBranch.Enabled = false;

                tbSubject.Text = Session["SubName"].ToString();
                string sub = Session["SubName"].ToString();

                //select คณะและสาขา ตามรายวิชาที่เลือก และนำมาแสดงใน textbox
                SqlDataAdapter dtAdapter;
                DataTable dt = new DataTable();
                string conn = "Data Source=DESKTOP-BVC1DQ7;Initial Catalog=ClassroomManagementSystemBase;User ID=voondia;password=voondia";
                string QueryString = "SELECT Faculty, Branch FROM SubjectTable WHERE SubjectNameTH LIKE '%" + sub + "%'";
                SqlConnection myConnection = new SqlConnection(conn);
                dtAdapter = new SqlDataAdapter(QueryString, conn);
                dtAdapter.Fill(dt);
                string test = (string)dt.Rows[0]["Faculty"];
                string testt = (string)dt.Rows[0]["Branch"];
                this.tbFaculty.Text = (string)dt.Rows[0]["Faculty"];
                this.tbBranch.Text = (string)dt.Rows[0]["Branch"];

                checkList = 0;
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือกรายวิชา')</script>");
                pnSearchSub.Visible = true;
            }
        }

        //กรณีต้องการเพิ่มวันเวลาการจอง
        protected void btAddDayTime_Click(object sender, EventArgs e)
        {
            numOfAdd++;
            ArrayLabel = new List<Label>();

            for (int i = 0; i < numOfAdd; i++)
            {
                TextBox new_textbox = new TextBox();
                new_textbox = new TextBox();

                new_textbox.ID = "tbAddDay" + numOfAdd.ToString();
                new_textbox.Text = Session["DMY"] + " " + ":" + " " + ddlStrTime.SelectedItem.Text + "-" + ddlEndTime.SelectedItem.Text;

                pnAddDate.Style.Add("overflow", "auto");
                pnAddDate.Controls.Add(new_textbox);
                pnAddDate.Controls.Add(new LiteralControl("<br>"));
            }
        }
    }
}
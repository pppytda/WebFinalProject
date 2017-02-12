using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFinalProject.Admin
{
    public partial class BookingScheduleRoom : System.Web.UI.Page
    {
        int checkList = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            btBookSche.Enabled = false;
            pnSearchTeach.Visible = false;
            pnSearchSub.Visible = false;

            if (!IsPostBack)
            {
                ddlStart();
                ddlSemes();
            }
        }

        //แถบจองห้องเรียน
        protected void btBookingRoom_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/SelectRoom.aspx");
        }

        //แถบกรอกข้อมูลการใช้ห้อง
        protected void btAddBook_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/BookingRoom.aspx");
        }

        //แถบตรวจสอบสถานะห้อง
        protected void btCheckRoom_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/CheckRoomStatus.aspx");
        }

        //dropdownlist เวลาเริ่มต้นการใช้ห้อง
        protected void ddlStart()
        {
            string[] StrTime = { "", "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00" };
            string[] valueStr = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };

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

        //dropdownlist ภาคการศึกษา
        protected void ddlSemes()
        {
            string[] Semes = { "2560", "2559", "2558", "2557" };
            string[] valueSem = { "1", "2", "3", "4" };

            for (int i = 0; i < Semes.Length; i++)
            {
                ddlSemester.Items.Add(new ListItem(Semes[i].ToString(), valueSem[i].ToString()));
            }
        }

        //dropdownlist ภาคการศึกษา กรณีมีการเลือก
        protected void ddlSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Semester"] = ddlSemester.SelectedItem.ToString();
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

                tbSubject.Text = Session["SubName"].ToString();
                string sub = Session["SubName"].ToString();

                checkList = 0;
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือกรายวิชา')</script>");
                pnSearchSub.Visible = true;
            }
        }
    }
}
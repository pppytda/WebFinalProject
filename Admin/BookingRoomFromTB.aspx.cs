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
    public partial class BookingRoomFromTB : System.Web.UI.Page
    {
        int checkList = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            btAddBook.Enabled = false;
            tbFaculty.Enabled = false;
            tbBranch.Enabled = false;
            pnSearchTeach.Visible = false;
            pnSearchSub.Visible = false;

            ddlEnd();

            if (Session["room"] != null && Session["DMY"] != null)
            {
                //มี if เพื่อเช็คเดือนว่าเป็นเลขตัวเดียวไหม ถ้าใช่ให้เติม 0 ไม่ข้างหน้า
                if (Session["Month"].ToString().Length < 2)
                {
                    lbStTime.Visible = true;
                    lbRoom.Visible = true;

                    lbDay.Text = Session["DMY"].ToString() + "-" + "0" + Session["Month"] + "-" + Session["Days"]; //เงื่อนไขการเติม 0 ไปด้านหน้าเลขเดือนที่เป็นตัวเดียว

                    lbStTime.Text = Session["startTime"].ToString();
                    lbRoom.Text = Session["room"].ToString();
                }
                else //สำหรับเดือนที่เป็นเลขคู่ lbDay จะไม่เติม 0 
                {
                    lbStTime.Visible = true;
                    lbRoom.Visible = true;

                    lbDay.Text = Session["DMY"].ToString() + "-" + Session["Month"] + "-" + Session["Days"];

                    lbStTime.Text = Session["startTime"].ToString();
                    lbRoom.Text = Session["room"].ToString();
                }
            }
        }

        //แถบจองห้องเรียน
        protected void btBooking_Click(object sender, ImageClickEventArgs e)
        {
            //ทำปุ่มย้อนหลังให้คืนค่าแบบเดิม
            Response.Redirect("~/Admin/SelectRoom.aspx");
        }

        //แถบเช็คสถานะห้องเรียน
        protected void btCheckRoom_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/CheckRoomStatus.aspx");
        }

        //dropdownlist เวลาสิ้นสุดการใช้ห้อง
        protected void ddlEnd()
        {
            string[] EndTime = { "กรุณาเลือกเวลาสิ้นสุด", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00" };
            string[] valueEnd = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };

            //ddlEndTime.Items.Clear(); //เคลียร์ค่า ddl ทุกครั้งเพื่อจะไม่วนซ้ำ

            //จะมีการเช็คเงื่อนไขเวลาเริ่มต้น เพื่อให้ DropDownList เวลาสิ้นสุดโชว์แค่เวลาถัดไปจากเวลาเริ่ม
            if (Session["startTime"].ToString().Equals("08:00"))
            {
                for (int i = 1; i < EndTime.Length; i++)
                {
                    ddlEndTime.Items.Add(new ListItem(EndTime[i].ToString(), valueEnd[i].ToString()));
                }
            }
            else if (Session["startTime"].ToString().Equals("09:00"))
            {
                for (int i = 2; i < EndTime.Length; i++)
                {
                    ddlEndTime.Items.Add(new ListItem(EndTime[i].ToString(), valueEnd[i].ToString()));
                }
            }
            else if (Session["startTime"].ToString().Equals("10:00"))
            {
                for (int i = 3; i < EndTime.Length; i++)
                {
                    ddlEndTime.Items.Add(new ListItem(EndTime[i].ToString(), valueEnd[i].ToString()));
                }
            }
            else if (Session["startTime"].ToString().Equals("11:00"))
            {
                for (int i = 4; i < EndTime.Length; i++)
                {
                    ddlEndTime.Items.Add(new ListItem(EndTime[i].ToString(), valueEnd[i].ToString()));
                }
            }
            else if (Session["startTime"].ToString().Equals("12:00"))
            {
                for (int i = 5; i < EndTime.Length; i++)
                {
                    ddlEndTime.Items.Add(new ListItem(EndTime[i].ToString(), valueEnd[i].ToString()));
                }
            }
            else if (Session["startTime"].ToString().Equals("13:00"))
            {
                for (int i = 6; i < EndTime.Length; i++)
                {
                    ddlEndTime.Items.Add(new ListItem(EndTime[i].ToString(), valueEnd[i].ToString()));
                }
            }
            else if (Session["startTime"].ToString().Equals("14:00"))
            {
                for (int i = 7; i < EndTime.Length; i++)
                {
                    ddlEndTime.Items.Add(new ListItem(EndTime[i].ToString(), valueEnd[i].ToString()));
                }
            }
            else if (Session["startTime"].ToString().Equals("15:00"))
            {
                for (int i = 8; i < EndTime.Length; i++)
                {
                    ddlEndTime.Items.Add(new ListItem(EndTime[i].ToString(), valueEnd[i].ToString()));
                }
            }
            else if (Session["startTime"].ToString().Equals("16:00"))
            {
                for (int i = 9; i < EndTime.Length; i++)
                {
                    ddlEndTime.Items.Add(new ListItem(EndTime[i].ToString(), valueEnd[i].ToString()));
                }
            }
            else if (Session["startTime"].ToString().Equals("17:00"))
            {
                for (int i = 10; i < EndTime.Length; i++)
                {
                    ddlEndTime.Items.Add(new ListItem(EndTime[i].ToString(), valueEnd[i].ToString()));
                }
            }
            else if (Session["startTime"].ToString().Equals("18:00"))
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

        //ปุ่มบันทึกข้อมูลการจองลง Base
        protected void ImBtSave_Click(object sender, ImageClickEventArgs e)
        {
            if (tbTeachName.Text != "" && tbSubject.Text != "")
            {
                //เพื่อกำหนดให้ค่าที่รับมาเป็น format ที่ถูกต้องของ Data Type ใน Base ที่เป็น DateTime
                string lbStrTime = lbStTime.Text = Session["startTime"].ToString();
                string strTime = lbDay.Text + " " + lbStrTime + ":00.000";
                string ddledTime = ddlEndTime.SelectedItem.Text;
                string endTime = lbDay.Text + " " + ddledTime + ":00.000";

                //แปลง string เป็น int เพื่อให้ค่าตรงกับ Data Type ใน Base
                string room = lbRoom.Text = Session["room"].ToString();
                int roomint = Convert.ToInt32(room);

                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-BVC1DQ7;Initial Catalog=ClassroomManagementSystemBase;User ID=voondia;password=voondia");
                conn.Open();

                //select ID รายวิชา จากรายวิชาที่ถูกเลือก เพื่อใช้บันทึกข้อมูลลง Base
                string sub = Session["SubName"].ToString();
                SqlDataAdapter dtAdapter;
                DataTable dt = new DataTable();
                string QueryString = "SELECT SubjectID FROM SubjectTable WHERE SubjectNameTH LIKE '%" + sub + "%'";
                dtAdapter = new SqlDataAdapter(QueryString, conn);
                dtAdapter.Fill(dt);
                string subID = tbSubject.Text = (string)dt.Rows[0]["SubjectID"];

                string sqlString = "INSERT INTO UseingClassroomTable(ScheduleID, StartTime, EndTime, RoomNo, TeachID, SubjectID, StatusName) (select @ScheduleID, @StartTime, @EndTime, @RoomNo, TeachID, @SubjectID, @StatusName from TeacherTable where TeachName = @TeachName)";
                SqlCommand comm = new SqlCommand(sqlString, conn);

                comm.Parameters.Add("@ScheduleID", SqlDbType.NVarChar).Value = lbDay.Text + " " + ":" + lbStTime.Text + " " + ":" + lbRoom.Text; //ตัวอย่าง UseingID "2016-07-18 :08:00 :982"
                comm.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = strTime;
                comm.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = endTime;
                comm.Parameters.Add("@RoomNo", SqlDbType.Int).Value = roomint;
                comm.Parameters.Add("@TeachName", SqlDbType.VarChar).Value = tbTeachName.Text;
                comm.Parameters.Add("@SubjectID", SqlDbType.VarChar).Value = subID;
                comm.Parameters.Add("@StatusName", SqlDbType.VarChar).Value = "จอง";
                comm.ExecuteNonQuery();
                //Response.Write("บันทึกข้อมูลการจองเรียบร้อย");

                conn.Close();

                Response.Redirect("~/Admin/SelectRoom.aspx");
            }
            else if (tbTeachName.Text == "" && tbSubject.Text == "")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณากรอกข้อมูลอาจารย์, และข้อมูลรายวิชา')</script>");
            }
            else if (tbTeachName.Text != "" && tbSubject.Text == "")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณากรอกข้อมูลรายวิชา')</script>");
            }
            else if (tbTeachName.Text == "" && tbSubject.Text != "")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณากรอกข้อมูลอาจารย์')</script>");
            }
        }

        //ปุ่มยกเลิกหน้าการกรอกข้อมูลการใช้ห้อง (กลับสู่หน้าแรก)
        protected void ImBtCancel_Click(object sender, ImageClickEventArgs e)
        {
            //ทำ pop-up เตือนว่าต้องการออกจากหน้านีใข่ไหม
            Response.Redirect("~/Admin/SelectRoom.aspx");
        }

        //ปุ่มเพิ่มวันเวลาการจองห้องเรียน
        protected void btAddDayTime_Click(object sender, EventArgs e)
        {
            //ทำ pop-up เตือนว่าต้องการเพิ่มใช่ไหม
            Session["DayOne"] = lbDay.Text;
            Session["TimeStrEnd"] = lbStTime.Text + "-" + ddlEndTime.SelectedItem.Text;

            Response.Redirect("~/Admin/BookingRoom.aspx");
        }

        protected void ImBtPrint_Click(object sender, ImageClickEventArgs e)
        {
            Session["TeachName"] = tbTeachName.Text;
            Session["DayOne"] = lbDay.Text;
            Session["TimeStr"] = lbStTime.Text;
            Session["TimeEnd"] = ddlEndTime.SelectedItem.Text;
            Session["Room"] = lbRoom.Text;

            Response.Redirect("~/Admin/PrintForm.aspx");
        }
    }
}
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
    public partial class CancelBookRoom : System.Web.UI.Page
    {
        string DMY; //ประกาศไว้นอก Page_Load เพราะทุกครั้งที่มีการโหลดจะได้ไม่คืนค่าเดิม

        protected void Page_Load(object sender, EventArgs e)
        {
            btBookRoom.Enabled = false;
            btCancelRoom.Enabled = false;
            btCancel0.Visible = false;
            btCancel1.Visible = false;

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

        //แถบจองห้องเรียน
        protected void btBookingRoom_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/SelectRoom.aspx");
        }

        //แถบจองห้องเรียนตามตารางเรียน
        protected void btBookSche_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/BookingScheduleRoom.aspx");
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
            }
        }

        //ปุ่ม Next
        protected void ImBtNext_Click(object sender, ImageClickEventArgs e)
        {
            if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี" && tbTeachName.Text != "")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการ')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน" && tbTeachName.Text != "")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการ')</script>");
            }
            else if (ddlYear.SelectedItem.ToString() == "กรุณาเลือกปี" && tbTeachName.Text == "")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก ปี/เดือน/วัน ที่ต้องการ และกรอกข้อมูลอาจารย์ก่อน')</script>");
            }
            else if (ddlMonth.SelectedItem.ToString() == "กรุณาเลือกเดือน" && tbTeachName.Text == "")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก เดือนและวัน ที่ต้องการ และกรอกข้อมูลอาจารย์ก่อน')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่" && tbTeachName.Text == "")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการ และกรอกข้อมูลอาจารย์ก่อน')</script>");
            }
            else if (tbTeachName.Text == "")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณากรอกข้อมูลอาจารย์')</script>");
            }
            else if (ddlDay.SelectedItem.ToString() == "กรุณาเลือกวันที่" && tbTeachName.Text != "")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('กรุณาเลือก วัน ที่ต้องการ')</script>");
            }
            else
            {
                string TName = tbTeachName.Text; //เอาค่าที่กรอกมาเก็บใส่ตัวแปรไว้สำหรับเช็คในเบส

                if (ddlMonth.SelectedIndex.ToString().Length < 2)
                {
                    DMY = ddlYear.SelectedItem.ToString() + "-" + "0" + ddlMonth.SelectedIndex.ToString() + "-" + ddlDay.SelectedItem.ToString();
                }
                else if (ddlMonth.SelectedIndex.ToString().Length >= 2)
                {
                    DMY = ddlYear.SelectedItem.ToString() + "-" + ddlMonth.SelectedIndex.ToString() + "-" + ddlDay.SelectedItem.ToString();
                }

                string conn = "Data Source=DESKTOP-BVC1DQ7;Initial Catalog=ClassroomManagementSystemBase;User ID=voondia;password=voondia";

                //เช็คว่าข้อมูลอาจารย์ที่กรอกตรงกับข้อมูลในเบสไหม
                SqlDataAdapter dtAdapterCount;
                DataTable dtCount = new DataTable();
                string QueryCount = "SELECT count(*) as no FROM UseingClassroomTable INNER JOIN TeacherTable ON UseingClassroomTable.TeachID=TeacherTable.TeachID WHERE ScheduleID LIKE '%" + DMY + "%' and TeachName LIKE '%" + TName + "%'";
                SqlConnection myCount = new SqlConnection(conn);
                dtAdapterCount = new SqlDataAdapter(QueryCount, conn);
                dtAdapterCount.Fill(dtCount);

                int qCount = (int)dtCount.Rows[0]["no"];

                if (qCount > 0) //ถ้าข้อมูลอาจารย์ที่กรอกตรงกับในเบส qCount จะมากกว่า 0
                {
                    SqlDataAdapter dtAdapter;
                    DataTable dt = new DataTable();
                    string QueryString = "SELECT SubjectTable.SubjectNameTH, UseingClassroomTable.ScheduleID, TeacherTable.TeachName, UseingClassroomTable.StartTime, UseingClassroomTable.EndTime, UseingClassroomTable.RoomNo FROM UseingClassroomTable INNER JOIN SubjectTable ON UseingClassroomTable.SubjectID=SubjectTable.SubjectID INNER JOIN TeacherTable ON UseingClassroomTable.TeachID=TeacherTable.TeachID WHERE ScheduleID LIKE '%" + DMY + "%' and TeachName LIKE '%" + TName + "%'";
                    SqlConnection myConnection = new SqlConnection(conn);
                    dtAdapter = new SqlDataAdapter(QueryString, conn);
                    dtAdapter.Fill(dt);

                    tbTeachName.Text = (string)dt.Rows[0]["TeachName"]; //ให้ช่องกรอกข้อมูลอาจารย์โชว์ข้อมูลเต็ม

                    DataScheduleGridView.DataSource = dt;
                    DataScheduleGridView.DataBind();

                    //for (int cou = 0; cou < qCount; cou++)
                    //{
                    //    Session["UseID"] = (string)dt.Rows[cou]["UseingID"]; //

                    //    string subName = (string)dt.Rows[cou]["SubjectNameTH"];
                    //    DateTime strDT = (DateTime)dt.Rows[cou]["StartTime"];
                    //    DateTime endDT = (DateTime)dt.Rows[cou]["EndTime"];
                    //    string roomNo = (string)dt.Rows[cou]["RoomNo"];
                    //    string strTime = DateTime.Parse(strDT.ToString().Trim()).ToString("HH:mm");
                    //    string endTime = DateTime.Parse(endDT.ToString().Trim()).ToString("HH:mm");

                    //    string lbCheck = "lbDate" + cou.ToString();

                    //    if (lbCheck == "lbDate0")
                    //    {
                    //        lbDate0.Text = DMY;
                    //        lbTime0.Text = strTime + "-" + endTime;
                    //        lbRoom0.Text = Convert.ToString(roomNo);
                    //        lbSubject0.Text = subName;
                    //        btCancel0.Visible = true;
                    //    }
                    //    else if (lbCheck == "lbDate1")
                    //    {
                    //        lbDate1.Text = DMY;
                    //        lbTime1.Text = strTime + "-" + endTime;
                    //        lbRoom1.Text = Convert.ToString(roomNo);
                    //        lbSubject1.Text = subName;
                    //        btCancel1.Visible = true;
                    //    }
                    //}
                }
                else if (qCount <= 0)
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('ไม่พบข้อมูลอาจารย์ที่ทำการค้นหา กรุณากรอกข้อมูลอาจารย์ใหม่อีกครั้ง')</script>");
                }
            }
        }

        //ปุ่ม ยกเลิก0
        protected void btCancel0_Click(object sender, EventArgs e)
        {
            btCancel0.Visible = true;
        }
    }
}
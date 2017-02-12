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
    public partial class DataSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btBookingRoom.Enabled = false;
            btDataSchedule.Enabled = false;
        }

        //แถบจองห้องเรียน
        protected void btBookingRoom_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/BookingRoomFromTB.aspx");
        }

        //แถบจองห้องเรียนตามตารางเรียน
        protected void btBookSche_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/BookingScheduleRoom.aspx");
        }

        //แถบกรอกข้อมูลการใช้ห้องเรียน
        protected void btAddBook_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/BookingRoom.aspx");
        }

        //แถบตรวจสอบสถานะห้องเรียน
        protected void btCheckRoom_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/CheckRoomStatus.aspx");
        }

        //ค้นหาข้อมูลตามชื่ออาจารย์
        protected void btSearch_Click(object sender, EventArgs e)
        {
            string TName = tbTeachName.Text.ToString();

            string conn = "Data Source=DESKTOP-BVC1DQ7;Initial Catalog=ClassroomManagementSystemBase;User ID=voondia;password=voondia";

            SqlDataAdapter dtAdapterCount;
            DataTable dtCount = new DataTable();
            string QueryCount = "SELECT DayOfScheduleTable.DayName, DayOfScheduleTable.StartTime, DayOfScheduleTable.SubjectID, TermOfSubjectTable.TeachName FROM DayOfScheduleTable INNER JOIN TermOfSubjectTable ON DayOfScheduleTable.SubjectID=TermOfSubjectTable.SubjectID and DayOfScheduleTable.Term=TermOfSubjectTable.Term and DayOfScheduleTable.Sec=TermOfSubjectTable.Sec  WHERE TermOfSubjectTable.TeachName LIKE '%" + TName + "%'";
            SqlConnection myCount = new SqlConnection(conn);
            dtAdapterCount = new SqlDataAdapter(QueryCount, conn);
            dtAdapterCount.Fill(dtCount);

            DataScheduleGridView.DataSource = dtCount;
            DataScheduleGridView.DataBind();
        }
    }
}
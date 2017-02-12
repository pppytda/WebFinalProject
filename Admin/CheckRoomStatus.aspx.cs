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
    public partial class CheckRoomStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btBookRoom.Enabled = false;
            btCheckRoom.Enabled = false;

            displayRoomStatus();
        }

        //แถบจองห้องเรียน
        protected void btBooking_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/SelectRoom.aspx");
        }

        //แถบยกเลิกห้องเรียน
        protected void btCancelRoom_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/CancelBookRoom.aspx");
        }

        //แถบจองห้องเรียนตามตารางเรียน
        protected void btBookSche_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/BookingScheduleRoom.aspx");
        }

        //แถบสรุปข้อมูลตามตารางเรียน
        protected void btDataSchedule_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/DataSchedule.aspx");
        }

        //แถบกรอกข้อมูลการใช้ห้อง
        protected void btAddBook_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Admin/BookingRoom.aspx");
        }

        //การโชว์สถานะห้อง
        protected void displayRoomStatus()
        {
            string conn = "Data Source=DESKTOP-BVC1DQ7;Initial Catalog=ClassroomManagementSystemBase;User ID=voondia;password=voondia";

            SqlDataAdapter dtAdapterCount;
            DataTable dtCount = new DataTable();
            string QueryCount = "SELECT count(*) as no FROM timetable WHERE SYSDATETIME() between StartTime and EndTime";
            SqlConnection myCount = new SqlConnection(conn);
            dtAdapterCount = new SqlDataAdapter(QueryCount, conn);
            dtAdapterCount.Fill(dtCount);

            int qCount = (int)dtCount.Rows[0]["no"];

            if (qCount > 0)
            {
                SqlDataAdapter dtAdapter;
                DataTable dt = new DataTable();
                string QueryString = "SELECT timetable.RoomNo, timetable.TeachName, timetable.StatusName FROM timetable WHERE SYSDATETIME() between timetable.StartTime and timetable.EndTime;";
                SqlConnection myConnection = new SqlConnection(conn);
                dtAdapterCount = new SqlDataAdapter(QueryString, conn);
                dtAdapterCount.Fill(dt);

                for (int cou = 0; cou < qCount; cou++)
                {
                    string roomID = (string)dt.Rows[cou]["RoomNo"];
                    string TeachName = (string)dt.Rows[cou]["TeachName"];
                    string Status = (string)dt.Rows[cou]["StatusName"];

                    string lbCheck = "lbRoom" + cou.ToString();

                    if (lbCheck == "lbRoom0")
                    {
                        lbRoom0.Text = Convert.ToString(roomID);
                        lbTeach0.Text = TeachName;
                        lbStatus0.Text = Status;
                    }
                    else if (lbCheck == "lbRoom1")
                    {
                        lbRoom1.Text = Convert.ToString(roomID);
                        lbTeach1.Text = TeachName;
                        lbStatus1.Text = Status;
                    }
                    else if (lbCheck == "lbRoom2")
                    {
                        lbRoom2.Text = Convert.ToString(roomID);
                        lbTeach2.Text = TeachName;
                        lbStatus2.Text = Status;
                    }
                    else if (lbCheck == "lbRoom3")
                    {
                        lbRoom3.Text = Convert.ToString(roomID);
                        lbTeach3.Text = TeachName;
                        lbStatus3.Text = Status;
                    }
                    else if (lbCheck == "lbRoom4")
                    {
                        lbRoom4.Text = Convert.ToString(roomID);
                        lbTeach4.Text = TeachName;
                        lbStatus4.Text = Status;
                    }
                    else if (lbCheck == "lbRoom5")
                    {
                        lbRoom5.Text = Convert.ToString(roomID);
                        lbTeach5.Text = TeachName;
                        lbStatus5.Text = Status;
                    }
                    else if (lbCheck == "lbRoom6")
                    {
                        lbRoom6.Text = Convert.ToString(roomID);
                        lbTeach6.Text = TeachName;
                        lbStatus6.Text = Status;
                    }
                    else if (lbCheck == "lbRoom7")
                    {
                        lbRoom7.Text = Convert.ToString(roomID);
                        lbTeach7.Text = TeachName;
                        lbStatus7.Text = Status;
                    }
                    else if (lbCheck == "lbRoom8")
                    {
                        lbRoom8.Text = Convert.ToString(roomID);
                        lbTeach8.Text = TeachName;
                        lbStatus8.Text = Status;
                    }
                    else if (lbCheck == "lbRoom9")
                    {
                        lbRoom9.Text = Convert.ToString(roomID);
                        lbTeach9.Text = TeachName;
                        lbStatus9.Text = Status;
                    }
                    else if (lbCheck == "lbRoom10")
                    {
                        lbRoom10.Text = Convert.ToString(roomID);
                        lbTeach10.Text = TeachName;
                        lbStatus10.Text = Status;
                    }
                }
            }
            else if (qCount <= 0)
            {
                lbTeach0.Text = "ไม่มีการใช้ห้องในวัน/เวลานี้";
            }
        }
    }
}

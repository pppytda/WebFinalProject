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

        protected void Page_Load(object sender, EventArgs e)
        {
            btAddBook.Enabled = false;
            tbFaculty.Enabled = false;
            tbBranch.Enabled = false;
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

            tbAddDate.Text = Session["DayOne"] + " " + ":" + " " + Session["TimeStrEnd"];
            lbRoom.Text = Session["room"].ToString(); 
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
            string[] StrTime = { "", "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00" };
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
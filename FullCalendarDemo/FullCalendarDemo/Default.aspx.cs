using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FullCalendarDemo.DTO;
using System.Web.Services;

namespace FullCalendarDemo
{
    public partial class _Default : System.Web.UI.Page
    {
        [WebMethod]
        public static string UpdateEventOwner(int id, int userId, string userName, bool isLocked){
            EventManager em = new EventManager();
            em.UpdateEventOwner(id, userId, userName, isLocked);
            return string.Empty;
        }
        [WebMethod]
        public static string CheckIfLocked(int id)
        {
            return new EventManager().CheckIfLocked(id);
        }
        [WebMethod]
        public static string UpdateEvent(string startDate)
        {
          // TimeZone.CurrentTimeZone
           
            var dateStr = DateTime.SpecifyKind(DateTime.Parse(startDate),DateTimeKind.Utc);
            
            var dateLocal= TimeZoneInfo.ConvertTimeFromUtc(dateStr, TimeZoneInfo.Local);
          
            return dateLocal.ToString(); ;
        }
        [WebMethod]
        public static List<Event> GetAllEvents()
        {
            return new EventManager().GetAllEvents();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                hfUserID.Value = "1";
                hfUserName.Value = "dannyso";
            }
        }
    }
}

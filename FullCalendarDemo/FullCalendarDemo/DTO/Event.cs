using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullCalendarDemo.DTO
{
    public class Event
    {
        public int EventID { get; set; }
        public string Title { get; set; }
        public bool IsAllDay { get; set; }
       
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ClassName  { get; set; }
        public bool IsEditable { get; set; }
        public string Agenda { get; set; }
        public bool Active { get; set; }
        public int SlotsLeft { get; set; }
        public bool isLocked { get; set; }
        public string LockedBy { get; set; }
        public string Slots
        {
            get
            {
                return SlotsLeft.ToString();
            }
        }
        public string Start
        {
            get
            {
                return StartDate.ToUniversalTime().ToString();
            }

        }
        public string End {
            get
            {
                return EndDate.ToUniversalTime().ToString();
            }
        
        }

    }
}
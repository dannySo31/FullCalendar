using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FullCalendarDemo.Data;

namespace FullCalendarDemo.DTO
{
    public class EventManager: IEventRepository
    {
        public static List<Event> lstEvent = new List<Event>();
         public EventManager()
        {
            populateAllEvents();
        }
        private  void populateAllEvents()
         {
             if (EventManager.lstEvent.Count() != 0)
                 return;
        
            EventManager.lstEvent.Add(new Event
            {
                EventID = 0,
                Title = "Scrum Meeting",
                ClassName = "none",
                StartDate = new DateTime(2013, 7, 29, 15, 30, 0),
                EndDate = new DateTime(2013, 7, 30, 16, 0, 0),
                IsAllDay = false,
                IsEditable = false,
                Agenda = "Scrum meeting with Team",
                Active=true,
                SlotsLeft=3,
                isLocked=true,
                LockedBy="dso"

            });

            EventManager.lstEvent.Add(new Event
            {
                EventID = 1,
                Title = "Integration Testing",
                ClassName = "none",
                StartDate = new DateTime(2013, 7, 23, 1, 0, 0),
                EndDate = new DateTime(2013, 7, 24, 2, 0, 0),
                IsAllDay = false,
                IsEditable = false,
                Agenda = "HDIS Integration Testing",
                Active = true,
                SlotsLeft = 3,
                isLocked = false,
                LockedBy = string.Empty



            });

            EventManager.lstEvent.Add(new Event
            {
                EventID = 2,
                Title = "Scrum Meeting 2",
                ClassName = "none",
                StartDate = new DateTime(2013, 7, 25, 1, 0, 0),
                EndDate = new DateTime(2013, 7, 26, 2, 0, 0),
                IsAllDay = false,
                IsEditable = false,
                Agenda = "This is a sample Agenda",
                Active = true,
                SlotsLeft = 3,
                isLocked = false,
                LockedBy = string.Empty



            });

            EventManager.lstEvent.Add(new Event
            {
                EventID = 3,
                Title = "Lunch Out",
                ClassName = "none",
                StartDate = new DateTime(2013, 7, 27, 1, 0, 0),
                EndDate = new DateTime(2013, 7, 28, 2, 0, 0),
                IsAllDay = false,
                IsEditable = false,
                Agenda = "Lunch Out with Team IS",
                Active = true,
                SlotsLeft = 3,
                isLocked = false,
                LockedBy = string.Empty



            });

            EventManager.lstEvent.Add(new Event
            {
                EventID = 4,
                Title = "Birthday",
                ClassName = "none",
                StartDate = new DateTime(2013, 7, 29, 1, 0, 0),
                EndDate = new DateTime(2013, 7, 29, 2, 0, 0),
                IsAllDay = false,
                IsEditable = false,
                Agenda = "This is a sample Agenda",
                Active = true,
                SlotsLeft = 3,
                isLocked = false,
                LockedBy = string.Empty



            });

            EventManager.lstEvent.Add(new Event
            {
                EventID = 5,
                Title = "Company Outing",
                ClassName = "none",
                StartDate = new DateTime(2013, 7, 22, 1, 0, 0),
                EndDate = new DateTime(2013, 7, 23, 2, 0, 0),
                IsAllDay = false,
                IsEditable = false,
                Agenda = "This is a sample Agenda",
                Active = true,
                SlotsLeft = 3,
                isLocked = false,
                LockedBy = string.Empty



            });

            EventManager.lstEvent.Add(new Event
            {
                EventID = 6,
                Title = "Trip to Bali",
                ClassName = "none",
                StartDate = new DateTime(2013, 7, 20, 1, 0, 0),
                EndDate = new DateTime(2013, 7, 24, 2, 0, 0),
                IsAllDay = false,
                IsEditable = false,
                Agenda = "This is a sample Agenda",
                Active = true,
                SlotsLeft = 3,
                isLocked = false,
                LockedBy = string.Empty



            });

            EventManager.lstEvent.Add(new Event
            {
                EventID = 7,
                Title = "WOrk Work Work!",
                ClassName = "none",
                StartDate = new DateTime(2013, 7, 31, 1, 0, 0),
                EndDate = new DateTime(2013, 8, 23, 2, 0, 0),
                IsAllDay = false,
                IsEditable = false,
                Agenda = "This is a sample Agenda for August",
                Active = true,
                SlotsLeft = 3,
                isLocked = false,
                LockedBy = string.Empty

            });

            EventManager.lstEvent.Add(new Event
            {
                EventID = 8,
                Title = "Event 2",
                ClassName = "none",
                StartDate = new DateTime(2013, 7, 23, 1, 0, 0),
                EndDate = new DateTime(2013, 7, 23, 2, 0, 0),
                IsAllDay = false,
                IsEditable = false,
                Agenda = "This is a sample Agenda",
                Active = true,
                SlotsLeft = 3,
                isLocked = false,
                LockedBy = string.Empty



            });

            EventManager.lstEvent.Add(new Event
            {
                EventID = 9,
                Title = "Event 2",
                ClassName = "none",
                StartDate = new DateTime(2013, 7, 23, 1, 0, 0),
                EndDate = new DateTime(2013, 7, 23, 2, 0, 0),
                IsAllDay = false,
                IsEditable = false,
                Agenda = "This is a sample Agenda",
                Active = true,
                SlotsLeft = 3,
                isLocked = false,
                LockedBy = string.Empty



            });

            EventManager.lstEvent.Add(new Event
            {
                EventID = 10,
                Title = "Event 2",
                ClassName = "none",
                StartDate = new DateTime(2013, 7, 23, 1, 0, 0),
                EndDate = new DateTime(2013, 7, 23, 2, 0, 0),
                IsAllDay = false,
                IsEditable = false,
                Agenda = "This is a sample Agenda",
                Active = true,
                SlotsLeft = 3,
                isLocked = false,
                LockedBy = string.Empty



            });

            EventManager.lstEvent.Add(new Event
            {
                EventID = 11,
                Title = "Event 2",
                ClassName = "none",
                StartDate = new DateTime(2013, 8, 10, 1, 0, 0),
                EndDate = new DateTime(2013, 8, 10, 2, 0, 0),
                IsAllDay = false,
                IsEditable = false,
                Agenda = "This is a sample Agenda",
                Active = true,
                SlotsLeft = 3,
                isLocked = false,
                LockedBy = string.Empty



            });
        }
        public  List<Event> GetAllEvents()
        {

            return EventManager.lstEvent.FindAll(c => c.Active==true && c.EndDate  >= DateTime.Now);
        }


        public void CreateEvent(Event eventEntity)
        {
            eventEntity.EventID=EventManager.lstEvent.Last<Event>().EventID + 1;
            eventEntity.isLocked = false;
            eventEntity.LockedBy = string.Empty;
            EventManager.lstEvent.Add(eventEntity);
        }

        public void UpdateEvent(Event eventEntity)
        {
            foreach(var x in EventManager.lstEvent.Where(c => c.EventID==eventEntity.EventID)){
               x.Title = eventEntity.Title;
                x.ClassName = eventEntity.ClassName;
                x.StartDate = eventEntity.StartDate;
                x.EndDate = eventEntity.EndDate;
                x.IsAllDay = eventEntity.IsAllDay;
                x.IsEditable = eventEntity.IsEditable;
                x.Agenda = eventEntity.Agenda;
            }
        }

        public void Deactivate(int eventId)
        {
            foreach (var x in EventManager.lstEvent.Where(c => c.EventID == eventId))
            {
                x.Active = false;
            }
        }


        public Event GetEventById(int id)
        {
            var eventEntity =(Event) EventManager.lstEvent.Find(c => c.EventID == id);
            return eventEntity;
        }


        public string CheckIfLocked(int id)
        {
            var myEvent= GetEventById(id);
            return myEvent.isLocked ? myEvent.LockedBy : string.Empty;
        }


        public void UpdateEventOwner(int id, int userId, string userName, bool isLocked)
        {
            var eventEntity= GetEventById(id);
            eventEntity.isLocked = isLocked;
            if(isLocked)
                eventEntity.LockedBy = userName;
            
        }
    }
}
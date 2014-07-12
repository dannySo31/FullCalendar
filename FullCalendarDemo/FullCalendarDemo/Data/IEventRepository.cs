using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FullCalendarDemo.DTO;

namespace FullCalendarDemo.Data
{
    public interface IEventRepository
    {
        List<Event> GetAllEvents();
        void CreateEvent(Event eventEntity);
        void UpdateEvent(Event eventEntity);
        void Deactivate(int eventId);
        Event GetEventById(int id);
        string CheckIfLocked(int id);
        void UpdateEventOwner(int id, int userId, string userName, bool isLocked);

    }
}

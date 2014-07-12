

$(document).ready(function () {

    $('.dateO').each(function () {
        $(this).datetimepicker({
            timeFormat: "hh:mm tt"
        });
    });
    // $('#txtStart').datePicker();
    $('#btnUpdate_Event').click(function () {
        UpdateEvent(convertLocalTimeToUTC($('#txtStart').val()));
        $('#dialog').dialog('close');
        $('#calendar').empty();
        GetAllDate();

    });
    $('#btnEdit_Event').click(function () {
        var id = $('#hfId').val();
       
        editEventRaised(this, id);

    });
    $('#btnCancel_Event').click(function () {
        var id = $('#hfId').val();
        lockEvent(id, $('#MainContent_hfUserID').val(), $('#MainContent_hfUserName').val(), false);
        $('#btnEdit_Event').show('slow');
        $(this).hide('slow');
        $('#btnUpdate_Event').hide('hide');
        $('.eventForm').attr('disabled', 'disabled');
    });
    GetAllDate();
});
function editEventRaised(c, id) {
    
    $.ajax({
        type: "POST",
        url: "Default.aspx/CheckIfLocked",
        data: JSON.stringify({ id: id }),
        contentType: "application/json; charset=utf=8",
        dataType: "json",
        success: function (data) {
            
            var lockedBy = data.d;
            if (lockedBy != '') {
               
                if ($('#MainContent_hfUserName').val() == lockedBy) {
                    $('#btnCancel_Event, #btnUpdate_Event').show('slow');

                    $(c).hide('slow');
                    $('.eventForm').removeAttr('disabled');
                } else
                    $('#divDialogErrorMsg').text('This event is currently being locked by: ' + lockedBy);
            }
            else {
                //lock event
                lockEvent(id, $('#MainContent_hfUserID').val(), $('#MainContent_hfUserName').val(), true);
                $('#btnCancel_Event, #btnUpdate_Event').show('slow');

                $(c).hide('slow');
                $('.eventForm').removeAttr('disabled');
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            debugger
        }
    });

}

function lockEvent(id, userId, userName, isLocked) {
   
    $.ajax({
        type: "POST",
        url: "Default.aspx/UpdateEventOwner",
        data: JSON.stringify({ id: id, userId: userId, userName: userName, isLocked: isLocked}),
        contentType: "application/json; charset=utf=8",
        dataType: "json",
        success: function (data) {
            
           
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            debugger
        }
    });
   
}
function UpdateEvent(startDate) {
   
    $.ajax({
        type: "POST",
        url: "Default.aspx/UpdateEvent",
        data: JSON.stringify({startDate: startDate }),
        contentType: "application/json; charset=utf=8",
        dataType: "json",
        success: function (data) {
            alert(data.d);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            debugger;
        }
    });
}
function GetAllDate() {

    $.ajax({
        type: "POST",
        url: "Default.aspx/GetAllEvents",
        data: "{}",
        contentType: "application/json; charset=utf=8",
        dataType: "json",
        success: function (data) {
            initializeCalendar(data);
            RenderLatestEvents(data);


        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            debugger;
        }
    });
}
function initializeCalendar(data){
    $('#calendar').fullCalendar({
        editable: true,
        disableDragging: true,
        header: {
            left: 'prev,next,today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },


        events: $.map(data.d, function (item, b) {


            return CreateEventObject(item);


        }),
        eventClick: function (data, event, view) {


            launchDetailWindow(data);


        },
        eventRender: function (event, element) {
            var htmlQtip = '<div><b>Title:</b> ' + event.title + '</div><br><div><b>Start: </b>' + event.start.toLocaleString() + '</div><div><b>End: </b>' + event.end.toLocaleString();
            element.qtip({

                content: htmlQtip,
                show: 'mouseover',
                hide: 'mouseout',
                style: {
                    classes: 'qtip-dark'


                },
                position: {
                    target: 'mouse',
                    adjust: { mouse: false }
                }
            });

        }
    });
}
function CreateEventObject(item) {
    var event = new Object();
    event.id = item.EventID;
    event.start = convertUTCToLocalTime(item.Start);
           // alert(convertPSTToLocalTime(event.start));
            event.end = convertUTCToLocalTime(item.End);
            event.title = item.Title;
            event.agenda = item.Agenda;

            event.allDay = item.IsAllDay;
            event.slotsLeft = item.Slots;
            
            return event;
}
function launchDetailWindow(data) {
  
   $('#hfId').val(data.id);
    $('#divDialogErrorMsg').empty();
    $('#txtTitle').val(data.title);
    $('#txtAgenda').val(data.agenda);
    $('#txtStart').val(data.start.toLocaleString());
    $('#txtEnd').val(data.end.toLocaleString());
   
    $('#txtSlotsLeft').val(data.slotsLeft);
    $('.eventForm').attr('disabled', 'disabled');
    $('#btnEdit_Event').show();
    $('#btnCancel_Event').hide();
    $('#btnUpdate_Event').hide();

    $('#dialog').dialog({
        autoOpen: true,
        height: 300,
        width: 500,
        show: {
            effect: "fade",
            duration: 300
        },
        hide: {
            effect: "fade",
            duration: 300
        },
        title: data.title
    });
}
function RenderLatestEvents(data) {
    $('#eventList').empty();
    var container = document.getElementById('eventList');
    $.each(data.d, function (index, item) {
        var eDiv = document.createElement('div');
        eDiv.className = 'eventsDiv';
        eDiv.setAttribute('e-id', item.EventID);
        eDiv.onclick = function (item) {
            return function () {


                launchDetailWindow(CreateEventObject(item));
            }
        } (item);

        var table = document.createElement('table');
        var tbody = document.createElement('tbody');
        var tr1 = document.createElement('tr');
        var td1 = document.createElement('td');
        td1.className = 'dateCss';
        var cStartDate = convertUTCToLocalTime(item.Start);
        $(td1).html(formatDateTime(cStartDate));
        tr1.appendChild(td1);
        var td2 = document.createElement('td');

        $(td2).html('<b>' + item.Title + '</b><br>' + formatDateTime2(cStartDate));
        tr1.appendChild(td2);
        tbody.appendChild(tr1);
        table.appendChild(tbody);
        // var eDivStartDiv = document.createElement('div');
        // eDivStartDiv.innerHTML = formatDateTime(item.Start) + ' PST';
        // eDivStartDiv.className = 'eventsDivStart';
        // eDiv.appendChild(eDivStartDiv);

        // var eDivEndDiv = document.createElement('div');
        //  eDivEndDiv.innerHTML = '<b>End: </b>' + item.End + ' PST';
        // eDivEndDiv.className = 'eventsDivStart';
        //  eDiv.appendChild(eDivEndDiv);
        eDiv.appendChild(table);
        container.appendChild(eDiv);



    });


}

function formatDateTime(t) {

    return moment(t.toLocaleString()).format("MMM D");
}
function formatDateTime2(t) {

    //   return moment(t.toLocaleString()).format("h:m a");
    return moment(t.toLocaleString()).calendar();
}

function convertUTCToLocalTime(t) {
    //get local timeZoneOffset
  //  var d = new Date();
   // var localOffset = d.getTimezoneOffset()/60; //in x`
    // return calcTime(localOffset,t);
   
    var nd = new Date(t + ' UTC');
   // alert(nd);
    return nd;
}
function calcTime(localOffset, t) {

  
    //var utc = t.getTime() + 8*60*1000 +  (PSTOffset * 60000);//PST to UTC
    // var nd = new Date(utc + (3600000 * localOffset));
    var nd = new Date(t.toString() + ' UTC');
    
    return nd;
}

function convertLocalTimeToUTC(t) {
     
    var d = new Date(t);//TODO convert UTC date to local server time.
    return new Date(d.getUTCFullYear(), d.getUTCMonth(), d.getUTCDate(), d.getUTCHours(), d.getUTCMinutes(), d.getUTCSeconds());
   // var utc = d.getTime() + (d.getTimezoneOffset() * 60000);
  //  var nd = new Date(utc + (3600000 * (-8)));
  //  return nd.toLocaleString();
}
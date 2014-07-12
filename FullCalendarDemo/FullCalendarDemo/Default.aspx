<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="FullCalendarDemo._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<link href="Styles/sample.css" rel="Stylesheet" />
<link href="Styles/timePicker.css" rel="Stylesheet" />
<link href="Styles/jquery.qtip.min.css" rel="Stylesheet" />
<script src="Scripts/json2.js" type="text/javascript"></script>
<script src="Scripts/moment.js" type="text/javascript"></script>
<script src="Scripts/timePicker.js" type="text/javascript"></script>
<script src="Scripts/jquery.qtip.min.js" type="text/javascript"></script>
    <div id='loading' style='display:none'>loading...</div>
    <asp:HiddenField ID="hfUserID" runat="server" />
    <asp:HiddenField ID="hfUserName" runat="server" />
    <div id="main_Panel">
        <div id="calendar">
        
        </div>
        <div class=cal_AddEvent>
            <button id="btnCalAddEvent">New Event</button>
        </div>
        <div id="dialog" title="Basic dialog">
            <input type="hidden" id="hfId" />
            <div id="divDialog">
            <div id="divDialogErrorMsg">
                
            </div>
            <table>
                <tr>
                    <td class="propertyColumn">
                        Event:
                    </td>

                    <td class="propertyDetails">
                        <%-- <label id="lblAgenda"></label>--%>
                         <input id="txtTitle" class="eventForm" />
                    </td>
                    
                    
                </tr>
                <tr>
                    <td class="propertyColumn">
                        Agenda:
                    </td>

                    <td class="propertyDetails">
                        <%-- <label id="lblAgenda"></label>--%>
                         <textarea id="txtAgenda" cols="1" rows="4" class="eventForm dateO" ></textarea>
                    </td>
                    
                    
                </tr>
                <tr>
                    <td class="propertyColumn">
                        Slots left:
                    </td>

                    <td class="propertyDetails">
                        <%-- <label id="lblAgenda"></label>--%>
                         <input id="txtSlotsLeft" class="eventForm" />
                    </td>
                    
                    
                </tr>
                <tr>
                    <td class="propertyColumn">
                        Start:
                    </td>

                    <td class="propertyDetails">
                        <%-- <label id="lblAgenda"></label>--%>
                         <input type=text id="txtStart"  class="eventForm dateO" />
                    </td>
                </tr>

                <tr>
                    <td class="propertyColumn">
                        End:
                    </td>

                    <td class="propertyDetails">
                        <%-- <label id="lblAgenda"></label>--%>
                         <input type=text id="txtEnd" class="eventForm dateO" />
                    </td>
                </tr>
            </table>
            </div>
            <div id="divUpdate" class=cal_AddEvent >
                <button id="btnCreate_Event">Create Event</button>
                <button id="btnEdit_Event">Edit</button>
                <button id="btnCancel_Event">Cancel</button>
                 <button id="btnUpdate_Event">Update</button>
            </div>
        </div>
    </div>
    <div id="sidebar">
        <div id="eventsHeader">
            <h2>My Upcoming Events:</h2>
        </div>
        <div class="innerEvent">
        <div id="eventList">
        
        </div>
        </div>
    </div>
    <script src="Scripts/sample.js" type="text/javascript"></script>
</asp:Content>

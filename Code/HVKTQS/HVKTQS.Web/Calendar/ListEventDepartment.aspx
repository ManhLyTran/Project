<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListEventDepartment.aspx.cs" Inherits="HVKTQS.Web.Calendar.ListEventDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-head">
        <div class="page-title break-head">
            <h1>Quản lý sự kiện khoa</h1>
        </div>
        <div class="page-toolbar">
            <asp:LinkButton runat="server" ID="lbtAddEvent" CssClass="btn btn-default" OnClick="lbtAddEvent_Click">
                     <i class="fa fa-plus"></i>Thêm mới sự kiện khoa
            </asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="portlet light portlet-fit bordered calendar">
                <div class="portlet-title">
                    <div class="caption">
                        <i class=" icon-layers font-green"></i>
                        <span class="caption-subject font-green sbold uppercase">Calendar</span>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="row">
                        <div class="col-md-3 col-sm-12">
                            <!-- BEGIN DRAGGABLE EVENTS PORTLET-->
                            <h3 class="event-form-title margin-bottom-20">Draggable Events</h3>
                            <div id="external-events">
                                <form class="inline-form">
                                    <input type="text" value="" class="form-control" placeholder="Event Title..." id="event_title">
                                    <br>
                                    <a href="javascript:;" id="event_add" class="btn green">Add Event </a>
                                </form>
                                <hr>
                                <div id="event_box" class="margin-bottom-10">
                                    <div class="external-event label label-default ui-draggable ui-draggable-handle" style="position: relative; z-index: auto; width: 81px; right: auto; height: 20px; bottom: auto; left: 0px; top: 0px;">My Event 1</div>
                                    <div class="external-event label label-default ui-draggable ui-draggable-handle" style="position: relative; z-index: auto; width: 81px; right: auto; height: 20px; bottom: auto; left: 0px; top: 0px;">My Event 2</div>
                                    <div class="external-event label label-default ui-draggable ui-draggable-handle" style="position: relative;">My Event 3</div>
                                    <div class="external-event label label-default ui-draggable ui-draggable-handle" style="position: relative;">My Event 5</div>
                                </div>
                                <label class="mt-checkbox mt-checkbox-single mt-checkbox-outline" for="drop-remove">
                                    remove after drop
                                                    <input type="checkbox" class="group-checkable" id="drop-remove">
                                    <span></span>
                                </label>
                                <hr class="visible-xs">
                            </div>
                            <!-- END DRAGGABLE EVENTS PORTLET-->
                        </div>
                        <div class="col-md-9 col-sm-12">
                            <div id="calendar" class="has-toolbar fc fc-ltr fc-unthemed">
                                <div class="fc-toolbar">
                                    <div class="fc-left">
                                        <h2>October 16, 2017</h2>
                                    </div>
                                    <div class="fc-right">
                                        <div class="fc-button-group">
                                            <button type="button" class="fc-prev-button fc-button fc-state-default fc-corner-left"><span class="fc-icon fc-icon-left-single-arrow"></span></button>
                                            <button type="button" class="fc-next-button fc-button fc-state-default"><span class="fc-icon fc-icon-right-single-arrow"></span></button>
                                            <button type="button" class="fc-today-button fc-button fc-state-default fc-state-disabled" disabled="disabled">today</button>
                                            <button type="button" class="fc-month-button fc-button fc-state-default">month</button>
                                            <button type="button" class="fc-agendaWeek-button fc-button fc-state-default">week</button>
                                            <button type="button" class="fc-agendaDay-button fc-button fc-state-default fc-corner-right fc-state-active">day</button>
                                        </div>
                                    </div>
                                    <div class="fc-center"></div>
                                    <div class="fc-clear"></div>
                                </div>
                                <div class="fc-view-container" style="">
                                    <div class="fc-view fc-agendaDay-view fc-agenda-view" style="">
                                        <table>
                                            <thead class="fc-head">
                                                <tr>
                                                    <td class="fc-widget-header">
                                                        <div class="fc-row fc-widget-header" style="border-right-width: 1px; margin-right: 16px;">
                                                            <table>
                                                                <thead>
                                                                    <tr>
                                                                        <th class="fc-axis fc-widget-header" style="width: 44px"></th>
                                                                        <th class="fc-day-header fc-widget-header fc-mon">Monday</th>
                                                                    </tr>
                                                                </thead>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </thead>
                                            <tbody class="fc-body">
                                                <tr>
                                                    <td class="fc-widget-content">
                                                        <div class="fc-day-grid">
                                                            <div class="fc-row fc-week fc-widget-content" style="border-right-width: 1px; margin-right: 16px;">
                                                                <div class="fc-bg">
                                                                    <table>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td class="fc-axis fc-widget-content" style="width: 44px"><span>all-day</span></td>
                                                                                <td class="fc-day fc-widget-content fc-mon fc-today fc-state-highlight" data-date="2017-10-16"></td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </div>
                                                                <div class="fc-content-skeleton">
                                                                    <table>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td class="fc-axis" style="width: 44px"></td>
                                                                                <td></td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <hr class="fc-divider fc-widget-header">
                                                        <div class="fc-time-grid-container fc-scroller" style="height: 489px;">
                                                            <div class="fc-time-grid">
                                                                <div class="fc-bg">
                                                                    <table>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td class="fc-axis fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-day fc-widget-content fc-mon fc-today fc-state-highlight" data-date="2017-10-16"></td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </div>
                                                                <div class="fc-slats">
                                                                    <table>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>12am</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>1am</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>2am</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>3am</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>4am</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>5am</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>6am</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>7am</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>8am</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>9am</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>10am</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>11am</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>12pm</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>1pm</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>2pm</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>3pm</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>4pm</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>5pm</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>6pm</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>7pm</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>8pm</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>9pm</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>10pm</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"><span>11pm</span></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                            <tr class="fc-minor">
                                                                                <td class="fc-axis fc-time fc-widget-content" style="width: 44px"></td>
                                                                                <td class="fc-widget-content"></td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </div>
                                                                <hr class="fc-divider fc-widget-header" style="display: none;">
                                                                <div class="fc-content-skeleton">
                                                                    <table>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td class="fc-axis" style="width: 44px"></td>
                                                                                <td>
                                                                                    <div class="fc-event-container">
                                                                                        <a class="fc-time-grid-event fc-v-event fc-event fc-start fc-end fc-draggable fc-resizable" style="top: 351px; bottom: -439px; z-index: 1; left: 0%; right: 0%;">
                                                                                            <div class="fc-content">
                                                                                                <div class="fc-time" data-start="8:00" data-full="8:00 AM"><span>8:00</span></div>
                                                                                                <div class="fc-title">Meeting</div>
                                                                                            </div>
                                                                                            <div class="fc-bg"></div>
                                                                                            <div class="fc-resizer fc-end-resizer"></div>
                                                                                        </a><a class="fc-time-grid-event fc-v-event fc-event fc-start fc-end fc-draggable fc-resizable" style="background-color: rgb(149, 165, 166); top: 527px; bottom: -615px; z-index: 1; left: 0%; right: 0%;">
                                                                                            <div class="fc-content">
                                                                                                <div class="fc-time" data-start="12:00" data-full="12:00 PM - 2:00 PM"><span>12:00 - 2:00</span></div>
                                                                                                <div class="fc-title">Lunch</div>
                                                                                            </div>
                                                                                            <div class="fc-bg"></div>
                                                                                            <div class="fc-resizer fc-end-resizer"></div>
                                                                                        </a>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
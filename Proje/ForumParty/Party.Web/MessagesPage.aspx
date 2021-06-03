<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MessagesPage.aspx.cs" Inherits="Party.Web.MessagesPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script src=' <%=ResolveUrl("~/Scripts/jquery-3.6.0.min.js") %>'>  </script>
    <script src=' <%=ResolveUrl("~/Scripts/jquery.signalR-2.4.2.js") %>'></script>
    <script src=' <%=ResolveUrl("~/signalr/hubs") %>'> </script>
    <script type="text/javascript">

        $(function () {
            // Declare a proxy to reference the hub.
            var chat;
            chat = $.connection.chatHub;

            // Create a function that the hub can call to broadcast messages.
            chat.client.broadcastMessage = function (name, message) {
                // Html encode display name and message.
                var encodedName = $('<div />').text(name).html();
                var encodedMsg = $('<div />').text(message).html();
                // Add the message to the page.
                $('#discussion').append('<li><strong>' + encodedName
                    + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
            };
            // Get the user name and store it to prepend to messages.
            var sessionName = $('#lb_UserName').val();


            $('#displayname').val('<%=Session["UserName"]%>');
            /*.val(prompt('Enter your name:', ''));*/
            // Set initial focus to message input box.
            $('#message').focus();
            // Start the connection.
            $.connection.hub.start().done(function () {
                $('#sendmessage').click(function () {
                    // Call the Send method on the hub. 
                    chat.server.send($('#displayname').val(), $('#message').val());
                    // Clear text box and reset focus for next comment. 
                    $('#message').val('').focus();
                });
            });
        });
    </script>




    <div class="container">


        <!-- Content wrapper start -->
        <div class="content-wrapper">

            <!-- Row start -->
            <div class="row gutters">

                <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">

                    <div class="card m-0">

                        <!-- Row start -->
                        <div class="row no-gutters">

                            <div class="col-xl-8 col-lg-8 col-md-8 col-sm-9 col-9">

                                <div class="chat-container">
                                    <ul class="chat-box chatContainerScroll">

                                        <input type="hidden" id="displayname" />
                                        <ul id="discussion">
                                        </ul>
                                    </ul>
                                    <div class="form-group mt-3 mb-0">
                                        <textarea id="message" class="form-control" type="text" rows="3" placeholder="Type your message here..."></textarea>
                                        <input id="sendmessage" type="button" class="btn btn-primary btn btn-default btn-block" value='SEND' />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Row end -->
                    </div>

                </div>

            </div>
            <!-- Row end -->

        </div>
        <!-- Content wrapper end -->

    </div>
</asp:Content>

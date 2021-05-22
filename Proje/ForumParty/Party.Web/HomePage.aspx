<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Party.Web.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--       <script type="text/javascript">

           $(document).ready(function () {
               var currentPageNumber = 1;
               loadData(currentPageNumber);

               $(window).scroll(function () {
                   if ($(window).scrollTop() == $(document).height() - $(window).height()) {
                       currentPageNumber += 1;
                       loadData(currentPageNumber);
                   }
               });

               function loadData(currentPage) {
                   $.ajax({
                       url: '/WebService/ASMXTest.asmx/GetPostsFromService',
                       type: 'POST',
                       data: {pageNumber:currentPage,pageSize:3},
                       dataType: 'json',
                       success: function (data) {
                           var table = $("#test div");
                           $("#test div").eq(0).remove();
                           
                           $(data).each(function (index, emp) {

                               $(".testTitle", table).html(emp.Title);
                               $(".UserID", table).html(emp.UserID);
                               $(".UserID", table).html(emp.UserID);
                               $(".uploadDate", table).html(emp.UploadDate);
                               $(".description", table).html(emp.Description);
                               $(".like", table).html(emp.Like);
                               $("#test").append(table);
                               table = $("#test div").eq(0).clone(true);


                               //var row = $("#test table tr").eq(0).clone(true);
                               // $(".testTitle", row).text(emp.Title)
                               //$(emp.PostID).html(Follower.find("PostID").text());
                               //$(emp.UserID).html(Follower.find("UserID").text());
                               //$(emp.UserID).html(Follower.find("UserID").text());
                               //$(emp.UploadDate).html(Follower.find("UploadDate").text());
                               //$(emp.Description).html(Follower.find("Description").text());
                               //$(emp.Like).html(Follower.find("Like").text());
                               //   $(".PostImage", row).html(Follower.find("PostImage").text());


                           });
                          
                               },
                       failure: function () {
                           alert("Failure");
                       },
                       error: function () {
                           alert("error");
                       }
                      
                       
                   });

                  
               }

              

           });
               

       </script>--%>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 


   <asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
                 <div  class="card mb-4" id="test_ID">
                            <asp:Image  class="card-img-top" ID="PostImage" runat="server" max-width="%100" max-height="auto"  src='<%#"data:image/jpeg;base64,"+ Convert.ToBase64String((byte[])Eval("PostImage")) %>'  alt="Card image cap"/>
                          
                           <div class="card-body">
                              <h2 class="card-title">
                                  <asp:Label ID="lbl_title" runat="server" Text='<%#Eval("Title") %>' ></asp:Label>
                              </h2>
                               
                              <h6 class="align-content-sm-end"> 
                                  <div class="row">
                                        <asp:Label ID="Label1" runat="server"  Visible="false" Text='<%#Eval("PostID")%>'> 

                                        </asp:Label>
                                      <asp:Label ID="Label2" runat="server"  Visible="false" Text='<%#Eval("UserID")%>'>

                                      </asp:Label>
                                            <div class="col-md-4">
                                                <i class="bi bi-person-fill"></i> <asp:LinkButton ID="lb_UserProfile" OnClick="lb_UserProfile_Click" runat="server" class="text-left" Text='<%#Eval("UserName")%>'> </asp:LinkButton>
                                                

                                            </div>
                                            <div class="col-md-4 ml-auto text-right">
                                                 <i class="bi bi-clock-fill"></i> <asp:Label ID="lbl_date" runat="server" text='<%#Eval("UploadDate")%>'></asp:Label>
                                                <br />
                                                <i class="bi bi-people-fill"></i> <asp:LinkButton ID="community_Linkbtn" OnClick="community_Linkbtn_Click" runat="server"  Text='<%#Eval("CommunityName")%>'></asp:LinkButton>
                                                <asp:LinkButton ID="lb_CommunityID" runat="server"  Text='<%#Eval("CommunityID")%>' Visible="false"></asp:LinkButton>

                                            </div>
                                    
                                  </div>
                              </h6>
                               <asp:Label ID="lbl_description" runat="server" class="card-text"> <%#Eval("Description") %></asp:Label>
                                <div >
                                    <hr />
                                </div>
                               <div style="height:40px;width:fit-content()">
                                            <asp:LinkButton ID="lbl_upvote" OnClick="lbl_upvote_Click" runat="server"  type="button" class="btn btn-success" > <i class="bi bi-chevron-up"></i></asp:LinkButton>
                                            <b><asp:Label ID="lbl_likecount"  runat="server" class="h5" Text='<%#Eval("Like") %>' ></asp:Label></b>
                                            <asp:LinkButton ID="lbl_downvote" OnClick="lbl_downvote_Click"  runat ="server"  type="button" class="btn btn-danger" > <i class="bi bi-chevron-down"></i></asp:LinkButton>
                                            <asp:LinkButton ID="lb_Detail" OnClick="lb_Detail_Click" runat="server"  type="button" class="btn btn-info">Detail <i class="bi bi-info-circle-fill"></i></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" OnClick="lb_Comment_Click" runat="server"  type="button" class="btn btn-info">Comment <i class="bi bi-chat-left-text-fill"></i></asp:LinkButton>
                                            
                                                

                                        
                                   
                               </div>
                                
                           </div>
                </div>
            </ItemTemplate>

        </asp:Repeater>





    
</asp:Content>

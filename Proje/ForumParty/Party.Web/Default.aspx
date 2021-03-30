<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Party.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Party: Forum</title>
    
  <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
  <meta name="description" content="Party is a forum site where communities come together. "/>
  <meta name="author" content="Melih Akkose"/>

    <!-- Icons-->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.4.1/font/bootstrap-icons.css">

      <!-- Bootstrap core JavaScript -->
<script src="Resource/jquery/jquery.min.js"></script>
<script src="Resource/js/bootstrap.bundle.min.js"></script>

  <!-- Bootstrap core CSS -->
<link href="Resource/css/bootstrap.min.css" rel="stylesheet" />

  <!-- Custom styles for this template -->
    <link href="Resource/css/blog-home.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>

    <!-- Navigation -->
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
    <div class="container">
      <a class="navbar-brand" href="#">
        <img width="25" height="25" src="Resource/images/homepageLogo2.jpg" /> Party Forum</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
                 <!-- Search Widget -->

        <div class="container">
          <div class="card-body">
            <div class="input-group">
              <input type="text" class="form-control" placeholder="Search for..."/>
              <span class="input-group-append">
                <button class="btn btn-secondary" type="button">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
                        <path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z"/>
                    </svg>
                </button>
              </span>
            </div>
          </div>
        </div>

      <div class="collapse navbar-collapse" id="navbarResponsive">
        <ul class="navbar-nav ml-auto">
          <li class="nav-item">
            <a class="navbar-brand" href="#">Forum</a>
          </li>
          <li class="nav-item">
            <a class="navbar-brand" href="#">Polls</a>
          </li>
          <li class="nav-item">
            <a class="navbar-brand" href="#">Messages</a>
          </li>
          <li class="nav-item">
            <a class="navbar-brand" href="#">Log In / Sign In</a>
          </li>
          
        </ul>
      </div>
    </div>  
  </nav>
    <header class="jumbotron my-4">
      <h3 text-align="center">Trending Today</h3>
      <div class="container text-center">
          <div class="row">
             <div class="card text-white bg-secondary mb-3 mx-2" style="width: 16rem;">
                <div class="card-body">
                    <h5 class="card-title">Card title</h5>
                    <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    <a href="#" class="card-link">Card link</a>
                    <a href="#" class="card-link">Another link</a>
                </div>
            </div>
              <div class="card text-white bg-secondary mb-3 mx-2" style="width: 16rem;">
                <div class="card-body">
                    <h5 class="card-title">Card title</h5>
                    <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    <a href="#" class="card-link">Card link</a> 
                    <a href="#" class="card-link">Another link</a>
                </div>
            </div>
              <div class="card text-white bg-secondary mb-3 mx-2" style="width: 16rem;">
                <div class="card-body">
                    <h5 class="card-title">Card title</h5>
                    <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    <a href="#" class="card-link">Card link</a>
                    <a href="#" class="card-link">Another link</a>
                </div>
            </div>
              <div class="card text-white bg-secondary mb-3 mx-2" style="width: 16rem;">
                <div class="card-body">
                    <h5 class="card-title">Card title</h5>
                    <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    <a href="#" class="card-link">Card link</a>
                    <a href="#" class="card-link">Another link</a>
                </div>
            </div>

          </div>

      </div>
    </header>
  <!-- Page Content -->
  <div class="container">

    <div class="row">

      <!-- Blog Entries Column -->
      <div class="col-md-8">
                
          <div class="col-md-12">
              <h1 class="my-4">Forum
          <small>Popular Posts</small>
        </h1>
          </div>
        

        <!-- Blog Post -->
        <div class="card mb-4">
          <img class="card-img-top" src="http://placehold.it/750x300" alt="Card image cap"/>
          <div class="card-body">
            <h2 class="card-title">Example Content</h2>
            <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
            <button type="button" class="btn btn-success"><i class="bi bi-chevron-up"></i> 46 </button>
            <button type="button" class="btn btn-danger"><i class="bi bi-chevron-down"></i> 32</button>
            <button type="button" class="btn btn-info">Detail <i class="bi bi-info-circle-fill"></i></button>
            <button type="button" class="btn btn-primary">Comment <i class="bi bi-chat-square-text"></i></button>
          </div>
          <div class="card-footer text-muted">
            Posted on January 1, 2020 by
            <a href="#">Vega</a>
          </div>
        </div>

        <!-- Blog Post -->
        <div class="card mb-4">
          <img class="card-img-top" src="http://placehold.it/750x300" alt="Card image cap"/>
          <div class="card-body">
            <h2 class="card-title">Example Content</h2>
            <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
            <button type="button" class="btn btn-success"><i class="bi bi-chevron-up"></i> 46 </button>
            <button type="button" class="btn btn-danger"><i class="bi bi-chevron-down"></i> 32</button>
            <button type="button" class="btn btn-info">Detail <i class="bi bi-info-circle-fill"></i></button>
            <button type="button" class="btn btn-primary">Comment <i class="bi bi-chat-square-text"></i></button>
          </div>
          <div class="card-footer text-muted">
            Posted on January 1, 2020 by
            <a href="#">Olympos</a>
          </div>
        </div>

        <!-- Blog Post -->
        <div class="card mb-4">
          <img class="card-img-top" src="http://placehold.it/750x300" alt="Card image cap"/>
          <div class="card-body">
            <h2 class="card-title">Example Content</h2>
            <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
            <button type="button" class="btn btn-success"><i class="bi bi-chevron-up"></i> 46 </button>
            <button type="button" class="btn btn-danger"><i class="bi bi-chevron-down"></i> 32</button>
            <button type="button" class="btn btn-info">Detail <i class="bi bi-info-circle-fill"></i></button>
            <button type="button" class="btn btn-primary">Comment <i class="bi bi-chat-square-text"></i></button>
          </div>
          <div class="card-footer text-muted">
            Posted on January 1, 2020 by
            <a href="#">Closer</a>
          </div>
        </div>

        <!-- Pagination -->
        <ul class="pagination justify-content-center mb-4">
          <li class="page-item">
            <a class="page-link" href="#">&larr; Older</a>
          </li>
          <li class="page-item disabled">
            <a class="page-link" href="#">Newer &rarr;</a>
          </li>
        </ul>

      </div>

      <!-- Sidebar Widgets Column -->
      <div class="col-md-4">

 

        <!-- Categories Widget -->
          <div class="card my-6" ">
            <div class="card-header">
                 Categories
            </div>
                <ul class="list-group list-group-flush">
                     <a href="#" class="list-group-item list-group-item-action"><img width="25" height="25" src="Resource/images/business.png" /> Business</a>
                     <a href="#" class="list-group-item list-group-item-action"><img width="25" height="25" src="Resource/images/technology.png" /> Technology</a>
                     <a href="#" class="list-group-item list-group-item-action"><img width="25" height="25" src="Resource/images/science.png" /> Science</a>
                     <a href="#" class="list-group-item list-group-item-action "><img width="25" height="25" src="Resource/images/sports.png" /> Sports</a>
                     <a href="#" class="list-group-item list-group-item-action "><img width="25" height="25" src="Resource/images/gaming.png" /> Gaming</a>
                     <a href="#" class="list-group-item list-group-item-action "><img width="25" height="25" src="Resource/images/entertainment.png" /> Entertainment</a>
                     <a href="#" class="list-group-item list-group-item-action "><img width="25" height="25" src="Resource/images/politics.png" /> Politics</a>
                </ul>
         </div>
      

        <!-- Side Widget -->
        <div class="card my-4">
          <h5 class="card-header">Trending Communities</h5>
          <div class="card-body">
            <ul class="list-group list-group-flush">
                     <a href="#" class="list-group-item list-group-item-action"><img width="25" height="25" src="Resource/images/homepageLogo2.jpg" /> VegaCommunity</a>
                     <a href="#" class="list-group-item list-group-item-action"><img width="25" height="25" src="Resource/images/homepageLogo2.jpg" /> OlymposCommunity</a>
                     <a href="#" class="list-group-item list-group-item-action "><img width="25" height="25" src="Resource/images/homepageLogo2.jpg" /> CloserCommunity</a>
            </ul>
          </div>
        </div>
          <div class="card my-4">
          <h5 class="card-header">Popular This Week</h5>
          <div class="card-body">
            <ul class="list-group list-group-flush">
                     <a href="#" class="list-group-item list-group-item-action"><img width="25" height="25" src="Resource/images/homepageLogo2.jpg" /> VegaCommunity</a>
                     <a href="#" class="list-group-item list-group-item-action"><img width="25" height="25" src="Resource/images/homepageLogo2.jpg" /> OlymposCommunity</a>
                     <a href="#" class="list-group-item list-group-item-action "><img width="25" height="25" src="Resource/images/homepageLogo2.jpg" /> CloserCommunity</a>
            </ul>
          </div>
        </div>

      </div>

    </div>
    <!-- /.row -->

  </div>
  <!-- /.container -->

  <!-- Footer -->
  <footer class="py-5 bg-dark">
    <div class="container">
      <p class="m-0 text-center text-white">Copyright &copy; Your Website 2020</p>
    </div>
    <!-- /.container -->
  </footer>


</body>
</html>

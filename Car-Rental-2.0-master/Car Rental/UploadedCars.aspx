<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadedCars.aspx.cs" Inherits="Car_Rental.UploadedCars" %>

<!DOCTYPE html>
<html>

<head>
  <meta charset="UTF-8">
  <title>My Car Rentals</title>
    <style>
        .car-card {
display: inline-block;
width: 300px;
margin: 10px;
padding: 10px;
border: 1px solid #ccc;
border-radius: 5px;
}

.car-card img {
display: block;
margin: 0 auto;
max-width: 100%;
height: auto;
margin-bottom: 10px;
}

.car-card p {
margin: 5px 0;
}

.car-card button {
display: block;
margin: 10px auto;
padding: 5px 10px;
border-radius: 5px;
background-color: #4CAF50;
color: white;
border: none;
cursor: pointer;
}

.car-card button:hover {
background-color: #3e8e41;
}
    </style>
  <link rel="stylesheet" href="UploadedCarsstyles.css">
</head>
<body>
  <header>
    <h1>My Car Rentals</h1>
  </header>
    <div class="navbar">
      <ul class="options">
 <li><a href="./home.aspx?id=<%=int.Parse(Request.QueryString["id"])%>">Home</a></li>
<li><a href="./cars.aspx?id=<%=int.Parse(Request.QueryString["id"])%>">See Cars</a></li>
<li><a href="./uploadYourCar.aspx?id=<%=int.Parse(Request.QueryString["id"])%>">Upload Car</a></li>
<li><a href="UploadedCars.aspx?id=<%=int.Parse(Request.QueryString["id"])%>">Uploaded Cars</a></li>
<li><a href="RequestsSent.aspx?id=<%=int.Parse(Request.QueryString["id"])%>">Requests Sent</a></li>
<li><a href="HIstory.aspx?id=<%=int.Parse(Request.QueryString["id"])%>">History</a></li>
<li><a href="User Profile.aspx?id=<%=int.Parse(Request.QueryString["id"])%>">User Profile</a></li>
<li><a href="Contact Us.aspx?id=<%=int.Parse(Request.QueryString["id"])%>">Contact Us</a></li>

      
      </ul>
    </div>
  

  <main class="container" runat="server">
 <div id="container" runat="server"></div>
  </main>

  <footer>
    <p>&copy; 2023 My Car Rentals</p>
  </footer>
</body>
</html>

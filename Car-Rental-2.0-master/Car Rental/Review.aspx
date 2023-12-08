<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Review.aspx.cs" Inherits="Car_Rental.Review" %>
<!DOCTYPE html>
<html>
<head>
	<title>Rent a Car - Reviews</title>
	<link rel="stylesheet" type="text/css" href="Reviewstyle.css">
</head>
<header>
	<h1>Reviews Make Us Better</h1>
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
<body>
	<h1>Reviews</h1>
	<div class="container" runat="server" id="reviewsContainer">
		
	</div>
</body>
</html>

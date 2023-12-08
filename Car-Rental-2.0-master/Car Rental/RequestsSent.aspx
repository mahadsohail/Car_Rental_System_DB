<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestsSent.aspx.cs" Inherits="Car_Rental.RequestsSent" %>
<!DOCTYPE html>
<html>
<head>
	<title>Rental Requests</title>
	<link rel="stylesheet" type="text/css" href="RequestsSentstyle.css">
</head>
<body>
	<header>
		<h1>Rental Requests</h1>
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
	<form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTableOutput" runat="server"></asp:Label>
        </div>
    </form>
	<footer>
		<p>&copy; 2023 Rent A Wheel</p>
	</footer>
</body>
</html>

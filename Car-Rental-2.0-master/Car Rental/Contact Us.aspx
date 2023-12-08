<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact Us.aspx.cs" Inherits="Car_Rental.Contact_Us" %>

<!DOCTYPE html>
<html>
<head>
	<title>Contact Us - Rent-a-Car</title>
	<link rel="stylesheet" type="text/css" href="ContactUsstyle.css">
</head>
<body>
	
	<header>
		<h1>Contact Us</h1>
	</header>

        <div class="navbar">
            <ul class="options">
                
             <li><a href="/home.aspx?id=<%=id%>">Home</a></li>
				<li><a href="./cars.aspx?id=<%=id%>">See Cars</a></li>
				<li><a href="./uploadYourCar.aspx?id=<%=id%>">Upload Car</a></li>
				<li><a href="UploadedCars.aspx?id=<%=id%>">Uploaded Cars</a></li>
				<li><a href="RequestsSent.aspx?id=<%=id%>">Requests Sent</a></li>
				<li><a href="HIstory.aspx?id=<%=id%>">History</a></li>
				<li><a href="User Profile.aspx?id=<%=id%>">User Profile</a></li>
				<li><a href="Contact Us.aspx?id=<%=id%>">Contact Us</a></li>
			    <li><a href="Login.aspx">Logout</a></li>
            
            </ul>
        </div>
	
	<main>
		<h2>Contact Us</h2>
		<p>For more information about our services or to make a reservation, please contact us:</p>
		<ul class="listing">
			<li>Phone: 555-1234</li>
			<li>Email: info@rentacar.com</li>
			<li>Address: 123 Main St, Anytown, USA</li>
		</ul>
	</main>
	<footer>
		<p>&copy; 2023 Rent-a-Wheel</p>
	</footer>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User Profile.aspx.cs" Inherits="Car_Rental.User_Profile" %>
<!DOCTYPE html>
<html>
<head>
	<title>Rent a Car - Customer Request Details</title>
	<link rel="stylesheet" type="text/css" href="UserProfilestyle.css">
	<style>
		body {
    margin: 0;
    font-family: Arial, sans-serif;
    }

   header {
    background-color: #333;
    color: white;
    padding: 10px;
     }

    h1 {
    margin: 0;
    font-size: 36px;
    }
	 #Button2{
  background-color: #4CAF50; /* Green */
  color: white;
  border: none;
  border-radius: 5px;
  padding: 10px 20px;
  margin-right: 10px;
  right:499px;
  float: right;
  margin-left: 300px;
}
   #Button1 {
  background-color: #4CAF50; /* Green */
  color: white;
  border: none;
  border-radius: 5px;
  padding: 10px 20px;
  margin-right: 10px;
}

 #Button2:hover,#Button1:hover {
  opacity: 0.8;
}

#Button2 {
  background-color: #008CBA; /* Blue */
}
	</style>
</head>
<body>
	<header>
		<h1>User Profile</h1>
		<div class="navbar">
			<ul class="options">
				<li><a href="./home.aspx?id=<%=int.Parse(Request.QueryString["id"])%>">Home</a></li>
				<li><a href="./cars.aspx?id=<%=int.Parse(Request.QueryString["id"])%>">See Cars</a></li>
				<li><a href="./uploadYourCar.aspx?id=<%=int.Parse(Request.QueryString["id"])%>">Upload Car</a></li>
				<li><a href="UploadedCars.aspx?id=<%=int.Parse(Request.QueryString["id"])%>">Uploaded Cars</a></li>
				<li><a href="RequestsSent.aspx?id=<%=int.Parse(Request.QueryString["id"])%>">Requests Sent</a></li>
				<li><a href="History.aspx?id=<%=int.Parse(Request.QueryString["id"])%>">History</a></li>
				<li><a href="User Profile.aspx?id=<%=int.Parse(Request.QueryString["id"])%>">User Profile</a></li>
				<li><a href="Contact Us.aspx?id=<%=int.Parse(Request.QueryString["id"])%>">Contact Us</a></li>
			</ul>
		</div>
	</header>
	<p>Enter your Current Password to Enable the Edit</p>
	<div class="profile-container" runat="server">      
		<form runat="server">
			<div class="information" runat="server">
				<div class="block" runat="server">
					<label for="username">Username</label>
					<input runat="server" type="text" id="username" name="username" value="johndoe" disabled>
				</div>

				<div class="block" runat="server">
					<label for="password">Password</label>
					<input runat="server" type="text" id="password1" name="password"  disabled>
				</div>

				<div class="block" runat="server">
					<label for="email">Email</label>
					<input runat="server" type="email" id="email" name="email" value="johndoe@example.com" disabled>
				</div>

				<div class="block" runat="server">
					<label for="phone">Phone Number</label>
					<input runat="server" type="tel" id="phone" name="phone" value="(123) 456-7890" disabled>
				</div>

				<div class="block" runat="server">
					<label for="current-password">Current Password</label>
					<input  runat="server" type="password" id="current" name="current-password">
				</div>

				<asp:Button runat="server" class="button" type="button" ID="Button1" OnClick="Button1_Click" Text="Edit"/>
				<br />
				<asp:Button runat="server" class="button" type="submit" ID="Button2" Text="Save" OnClick="Button2_Click" Enabled="false"/>
			</div>
		</form>
	</div>
</body>
</html>

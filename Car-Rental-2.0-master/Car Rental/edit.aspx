<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="Car_Rental.edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit</title>
	<link rel="stylesheet" type="text/css" href="RequestsSentstyle.css">
    <style>
        .page-title {
  font-size: 36px;
  margin-bottom: 20px;
}

.car-edit-form {
  max-width: 500px;
  margin: 0 auto;
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 5px;
  background-color: #f9f9f9;
}

.form-group {
  margin-bottom: 20px;
}

label {
  display: block;
  font-weight: bold;
  margin-bottom: 5px;
}

.form-control {
  width: 100%;
  padding: 10px;
  font-size: 16px;
  border: 1px solid #ccc;
  border-radius: 5px;
}

.btn {
  display: inline-block;
  padding: 10px 20px;
  font-size: 16px;
  font-weight: bold;
  color: #fff;
  background-color: #007bff;
  border: none;
  border-radius: 5px;
  cursor: pointer;
}

.btn:hover {
  background-color: #0069d9;
}

.btn:focus {
  outline: none;
  box-shadow: 0 0 0 2px rgba(0, 123, 255, 0.5);
}
    </style>
</head>
<body>
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
   <h1 class="page-title">Edit Car</h1>
<form method="post" runat="server" class="car-edit-form">
  <div class="form-group" runat="server">
    <label for="startDate">Start Date:</label>
    <input type="date" id="txtstartDate" name="StartDate" class="form-control" runat="server"/>
  </div>
  <div class="form-group" runat="server">
    <label for="endDate">End Date:</label>
    <input type="date" id="txtendDate" name="EndDate" class="form-control" runat="server" />
  </div>
  <div class="form-group" runat="server">
    <label for="txtPrice">Price:</label>
    <input type="text" id="txtPrice" name="Price" class="form-control" runat="server" />
  </div>
  <div class="form-group">
    <asp:button type="submit" runat="server" id="btnSave" onclick="btnSave_Click" class="btn btn-primary" Text="Save"/>
  </div>
</form>
</body>
</html>

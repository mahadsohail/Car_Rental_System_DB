<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="Car_Rental.upload" %>
<!DOCTYPE html>
<html>
<head>
	<title>Rent a Car</title>
	<link rel="stylesheet" type="text/css" href="styleupload.css">
    <style>
        form{
          max-width: 800px;
          margin: 20px auto;
	        padding: 20px;
	        border: 1px solid #ccc;
        }
        label {
          display: block;
          margin-bottom: 10px;
        }
        input[type="text"],
        input[type="email"],
        input[type="tel"],
        input[type="date"],
        select {
          width: 100%;
          padding: 10px;
          border: 1px solid #ccc;
          border-radius: 4px;
          box-sizing: border-box;
          margin-bottom: 20px;
          font-size: 16px;
        }
        input[type="submit"] {
          background-color: #4CAF50;
          color: white;
          padding: 12px 20px;
          border: none;
          border-radius: 4px;
          cursor: pointer;
          font-size: 16px;
        }
        input[type="submit"]:hover {
          background-color: #45a049;
        }
        img{
            
        }
        form{
            background-color: white;

        }
        
      </style>
</head>
  <body>
<header>
    <h1>Get the Car You Want</h1>
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
    <h1>Car Rental System Form</h1>
    <form runat="server">

    <label for="pickup-datetime">Pickup Date and Time:</label>
    <input type="datetime-local" id="pickup-datetime" name="pickup-datetime" required>

    <label for="return-datetime">Return Date and Time:</label>
    <input type="datetime-local" id="return-datetime" name="return-datetime" required>
    <br />
        <br />
    <asp:button type="submit" runat="server" id="submitButton" Text="Submit" OnClick="BUT_Click" />
</form>

    <footer>
      <p>&copy; 2023 Rent A Wheel</p>
    </footer>
</body>
 </html>



  
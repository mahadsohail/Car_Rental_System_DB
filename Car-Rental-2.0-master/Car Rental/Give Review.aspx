hh<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Give Review.aspx.cs" Inherits="Car_Rental.Give_Review" %>

<!DOCTYPE html>
<html>
<head>
	<title>Car Review</title>
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
      input[type="number"],
      input[type="file"],
      textarea {
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
      .navbar ul {
	
	      list-style-type: none;
	      margin: 0;
	      padding: 0;
	      background-color: #333;
	      text-align: center;

      }
      .navbar li {
        display: inline-block;
      }
      .navbar a {
	      width: 100%;
        display: block;
        padding: 25px 20px;
        text-decoration: none;
        color: #fff;
	      font-size: 15px;
      	text-transform: uppercase;
	      font-weight: bold;
	      text-align: center;
      }
      .navbar a:hover{
	      background-color:#555;
      } 
      header{
        text-align: center;
        background-color: #333;
        color:#fff;
        padding:10px;
      }
      footer {
        background-color: #333;
        color: #fff;
        text-align: center;
        padding: 20px;
        margin-top: 50px;
      }

      footer p {
        margin: 0;
      }
 
	</style>
</head>
<header>
  <h1>Share Your Experience</h1>
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
	<h1>Review</h1>
    <form runat="server">
     
  
        <label runat="server" for="Description">Review:</label>
        <input runat="server" type="text" id="Description" name="Description" required>
  
  
        <label runat="server" for="rating">Rating:</label>
        <input runat="server" type="number" id="Rating" name="Rating" min="1" max="5" required>
  
        <asp:button type="submit" runat="server" id="sub" onclick="sub_Click" Text="Submit"/>

    </form>
    <footer>
      <p>&copy; 2023 My Car Rentals</p>
    </footer> 

</body>
</html>
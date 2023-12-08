<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uploadYourCar.aspx.cs" Inherits="Car_Rental.uploadYourCar" %>
<!DOCTYPE html>
<html>
  <head>
    <title>Car Upload Form</title>
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
	    background-color: #555;
       }
       header{
        text-align: center;
        background-color: #333;
        padding: 5px;
        color: white;
       }
    </style>
  </head>
  <body>
    <header>
        <h1 class="tagline">Rent Out Your Car</h1>
    </header>
    <div class="navbar">
		<ul class="options">
			
				<li><a href="./home.aspx?id=<%=id%>">Home</a></li>
				<li><a href="./cars.aspx?id=<%=id%>">See Cars</a></li>
				<li><a href="./uploadYourCar.aspx?id=<%=id%>">Upload Car</a></li>
        <li><a href="UploadedCars.aspx?id=<%=id%>">Uploaded Cars</a></li>
        <li><a href="RequestsSent.aspx?id=<%=id%>">Requests Sent</a></li>
				<li><a href="HIstory.aspx?id=<%=id%>">History</a></li>
        <li><a href="User Profile.aspx?id=<%=id%>">User Profile</a></li>
				<li><a href="Contact Us.aspx?id=<%=id%>">Contact Us</a></li>
		
		</ul>
	</div>
    <h1>Car Upload Form</h1>
    <form runat="server">
      <label for="car-make">Car Make:</label>
      <input runat="server" type="text" id="carmake" name="car-make" required>

      <label for="car-model">Car Model:</label>
      <input runat="server" type="text" id="carmodel" name="car-model" required>

      <label for="car-year">Car Year:</label>
      <input runat="server" type="number" id="caryear" name="car-year" min="1900" max="2099" step="1" required>

      <label for="Location">Location:</label>
      <input runat="server" type="text" id="location" name="location" required>

      <label for="car-priceperhour">Car Price Per Hour:</label>
      <input runat="server" type="number" id="carpriceperhour" name="car-priceperhour" required>

      <label for="car-image">Car Image:</label>
      <input runat="server" type="file" id="carimages" name="car-images[]" multiple accept="image/*" required>

      <label for="car-description">Car Description:</label>
      <textarea runat="server" id="cardescription" name="car-description" required></textarea>
<label for="start-date">Start Date:</label>
<input runat="server" type="date" id="Date1" name="start-date" required>
<br />

<asp:Label ID="lblStartDateError" runat="server" ForeColor="Red" Visible="false" Text="Start date must be greater than end date"></asp:Label>
<br />

<label for="end-date">End Date:</label>
<input runat="server" type="date" id="Date2" name="end-date" required>
<br />

<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Start date must be greater than end date" ControlToValidate="Date2" ControlToCompare="Date1" Operator="GreaterThan"></asp:CompareValidator>
<br />

<asp:button type="submit" runat="server" id="submitButton" Text="Submit" OnClick="BUT_Click" />
    </form>
  </body>
</html>

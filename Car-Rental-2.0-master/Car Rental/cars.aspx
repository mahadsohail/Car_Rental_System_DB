<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cars.aspx.cs" Inherits="Car_Rental.cars" %>

<!DOCTYPE html>
<html>
  <head>
    <title>Car Rental Website</title>
      	<style>
    .car1 {
        border: 1px solid #ccc;
        box-shadow: 2px 2px 6px #ccc;
        margin: 10px;
        padding: 10px;
        width: 800px;
        margin-left:320px;
       
    }

    .carHeader {
        margin-bottom: 10px;
        text-align: center;
    }

    .carHeader label {
        display: block;
        font-size: 16px;
        font-weight: bold;
        margin-bottom: 5px;
    }

    .carFooter {
        border-top: 1px solid #ccc;
        margin-top: 10px;
        padding-top: 10px;
        text-align: center;
    }

    .carFooter label {
        display: block;
        font-size: 14px;
    }

    .carFooter label strong {
        font-weight: bold;
    }

    .carFooter button {
        background-color: #008CBA;
        border: none;
        color: white;
        padding: 10px 20px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 16px;
        margin: 4px 2px;
        cursor: pointer;
        border-radius: 5px;
    }
   .btn-review,.btn-details {
  background-color: #4CAF50; /* Green */
  border: none;
  color: white;
  padding: 10px 20px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  cursor: pointer;
  border-radius: 4px;
}

btn-review,.btn-details:hover {
  background-color: #3e8e41;
}

.btn-review:active,.btn-details:active {
  background-color: #3e8e41;
  transform: translateY(2px);
}
.car1 img {
  max-width: 200px;
  max-height: 200px;
}
     input[type="number"],input[type="text"] {
  font-size: 16px;
  padding: 5px 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
  background-color: #fff;
  color: #333;
  cursor: pointer;
  margin-right: 10px;
}

 .search-container {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
  align-items: center;
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 5px;
}

.search-container label {
  font-size: 16px;
  font-weight: bold;
  margin-right: 10px;
}

.search-container input,
.search-container select {
  font-size: 16px;
  padding: 5px 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
  background-color: #fff;
  color: #333;
  cursor: pointer;
  margin-right: 10px;
}

.search-container input:focus,
.search-container select:focus {
  outline: none;
  border-color: #6ba8ff;
  box-shadow: 0px 0px 5px #6ba8ff;
}

.search-container input[type="date"]::-webkit-inner-spin-button,
.search-container input[type="date"]::-webkit-calendar-picker-indicator,
.search-container input[type="number"]::-webkit-inner-spin-button,
.search-container input[type="number"]::-webkit-outer-spin-button {
  -webkit-appearance: none;
  margin: 0;
}

.search-container input[type="text"] {
  width: 200px;
}

      	    .price-range {
      	        display: flex;
      	        align-items: center;
      	        margin-right: 10px
      	    }

#search{
  font-size: 16px;
  font-weight: bold;
  padding: 8px 16px;
  background-color: #6ba8ff;
  color: #fff;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  margin-left:-700px;
  transition: background-color 0.3s ease;
  height:80px;
}

#search:hover {
  background-color: #4f8ee4;
}


</style>
    <link rel="stylesheet" type="text/css" href="style2.css">
  </head>
  <body>
    <header>
      <div>
        <h1>Get the Best Match</h1>
      </div>
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
      <br />
      <p  style="font-size: 20px;"><strong>Search and Filter</strong></p>
     <form runat="server">
   <div class="search-container">
    <div class="filters" runat="server">
      <label for="date-filter">Date:</label>
      <input  runat="server" type="date" id="datefilter" name="date">
     <label for="location-filter">Location:</label>
      <select  runat="server" id="locationfilter" name="location">
          <option value="">-- Select location --</option>
          <option value="Abbottabad">Abbottabad</option>
          <option value="Bahawalpur">Bahawalpur</option>
          <option value="Faisalabad">Faisalabad</option>
          <option value="Gujranwala">Gujranwala</option>
          <option value="Hyderabad">Hyderabad</option>
          <option value="Islamabad">Islamabad</option>
          <option value="Karachi">Karachi</option>
          <option value="Lahore">Lahore</option>
          <option value="Multan">Multan</option>
          <option value="Peshawar">Peshawar</option>
          <option value="Quetta">Quetta</option>
          <option value="Rawalpindi">Rawalpindi</option>
          <option value="Sialkot">Sialkot</option>
      </select>
        <br />
        <br />

      <label runat="server" for="price-filter">Price Range:</label>
        <label runat="server" for="price-filter">Min:</label>
     <input  runat="server" type="number" id="p1" name="price-min" placeholder="Min" value="0" style="border: 1px solid #ccc;">
        <label runat="server" for="price-filter">Max:</label>
<input  runat="server" type="number" id="p2" name="price-max" placeholder="Max" value="0" style="border: 1px solid #ccc;">
        <br />
        <br />
     
      <label runat="server" for="car-filter">Car Name:</label>
      <input  runat="server" type="text" id="carfilter" name="car-name">
    </div>
    <asp:button runat="server" id="search" onclick="search_Click" Text="Search"/>
       
</div>
      
      <div class="intro">
        <h2>Cars</h2>
        <div class="entry">
        
          <p class="tagline">Welcome to our rent a car website, where you can find a wide selection of cars to suit your needs. We offer a range of vehicles from compact cars to SUVs, luxury cars to minivans, and everything in between. Our cars are well-maintained, reliable, and up-to-date with the latest safety features. We understand that every customer has unique needs and preferences, which is why we have a variety of car models available for rent. Whether you need a car for a short trip or a long-term rental, we have you covered. Explore our website to find the perfect car for your next adventure</p>

        </div>
      
      </div>

   
    <main>
		<asp:Panel ID="carsPanel" runat="server" CssClass="carsPanel"></asp:Panel>
      </main>
	</form>
    
    
  </body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Car Details.aspx.cs" Inherits="Car_Rental.Car_Details" %>

<!DOCTYPE html>
<html>
<head>
	<title>[Car Model] Rental Details</title>
	<link rel="stylesheet" type="text/css" href="styleCarDetails.css">
    <style>
 #form1 {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  margin-top: 50px;
}

/* Style the headings */
h1, h2 {
  text-align: center;
  font-weight: bold;
  color: #333;
}

/* Style the sections */
section {
  margin: 20px 0;
}

/* Style the hr lines */
hr {
  border: 0;
  height: 1px;
  background-color: #ccc;
  margin: 20px 0;
}

/* Style the car information */
#carInfo {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  align-items: center;
}

/* Style the car images */
#carImages {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  align-items: center;
}

.carImage {
  width: 300px;
  height: 300px;
  object-fit: contain;
  margin: 10px;
}
/* Style the car image container */

.car-image-container {
  width: 200px;
  height: 200px;
  margin: 10px;
  overflow: hidden;
}

/* Style the car image */
.car-image-container img {
  width: 100%;
  height: 100%;
  object-fit: contain;
}

/* Style the rental and contact information */
#rentalInfo, #contactInfo {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  align-items: center;
}

  
    </style>
</head>
<body>
	<header>
		<h1>Rental Details</h1>
	</header>
    <div class="navbar">
		<ul class="options">
			
				<li><a href="/home.aspx?id=<%=user_id%>">Home</a></li>
				<li><a href="./cars.aspx?id=<%=user_id%>">See Cars</a></li>
				<li><a href="./uploadYourCar.aspx?id=<%=user_id%>">Upload Car</a></li>
				<li><a href="UploadedCars.aspx?id=<%=user_id%>">Uploaded Cars</a></li>
				<li><a href="RequestsSent.aspx?id=<%=user_id%>">Requests Sent</a></li>
				<li><a href="HIstory.aspx?id=<%=user_id%>">History</a></li>
				<li><a href="User Profile.aspx?id=<%=user_id%>">User Profile</a></li>
				<li><a href="Contact Us.aspx?id=<%=user_id%>">Contact Us</a></li>
		
		</ul>
	</div>
	<main runat="server">
		<form id="form1" runat="server">
        <div>
            <h1 id="carHeading" runat="server"></h1>
            <hr />
            <section>
                <h2>Car Information</h2>
                <div id="carInfo" runat="server"></div>
            </section>
            <hr />
            <hr />
             <section>
                <h2>Car Images</h2>
                <div id="carImages" runat="server"></div>
            </section>
            <hr />
            <section>
                <h2>Rental Information</h2>
                <div id="rentalInfo" runat="server"></div>
            </section>
            <hr />
            <section>
                <h2>Contact Information</h2>
                <div id="contactInfo" runat="server"></div>
            </section>
        </div>
    </form>
        <section class="buttonsection">
         <button onclick="window.location.href = 'upload.aspx?id=<%=user_id%>&carid=<%=car_id%>';" class="FillFormButton">Fill Form</button>
        </section>
	</main>
	<footer>
		<p>&copy; 2023 Rent A Wheel. All rights reserved.</p>
	</footer>
</body>
</html>

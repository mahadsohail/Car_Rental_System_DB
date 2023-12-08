<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deleteComfirmation.aspx.cs" Inherits="Car_Rental.deleteComfirmation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<link rel="stylesheet" type="text/css" href="style.css"/>
<style>
    h1 {
        font-size: 32px;
        font-weight: bold;
        margin-bottom: 10px;
        text-align: center;
    }

    h2 {
        font-size: 24px;
        margin-bottom: 20px;
        text-align: center;
    }

    #form1 {
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        text-align: center;
    }

    #no {
        background-color: #4CAF50;
        color: white;
        border: none;
        padding: 10px 20px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 16px;
        cursor: pointer;
        border-radius: 5px;
        margin-top: 10px;
    }

    #confirm {
        background-color: #4CAF50;
        color: white;
        border: none;
        padding: 10px 20px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 16px;
        cursor: pointer;
        border-radius: 5px;
        margin-top: 10px;
    }

    #confirm:hover, #no:hover {
        background-color: #3e8e41;
    }
</style>

</head>
<body>
	<header>
       
		
	</header>
    <div class="navbar" runat="server">
		<ul class="options">
			
				<li><a href="./home.aspx?id=<%=int.Parse(Request.QueryString["id"])%>">Home</a></li>
				<li><a href="./cars.aspx?id=<%=id%>">See Cars</a></li>
				<li><a href="./uploadYourCar.aspx?id=<%=id%>">Upload Car</a></li>
				<li><a href="UploadedCars.aspx?id=<%=id%>">Uploaded Cars</a></li>
				<li><a href="RequestsSent.aspx?id=<%=id%>">Requests Sent</a></li>
				<li><a href="HIstory.aspx?id=<%=id%>">History</a></li>
				<li><a href="User Profile.aspx?id=<%=id%>">User Profile</a></li>
				<li><a href="Contact Us.aspx?id=<%=id%>">Contact Us</a></li>
		
		</ul>
	</div>
	<h1 >Delete Confirmation</h1>
            <h2 >Are you sure</h2>
    <form id="form1" runat="server">
        <asp:Button  runat="server" ID="confirm" Text="Yes" OnClick="confirm_Click"/>
		<br />
		<asp:Button  runat="server" ID="no" Text="NO" onClick="no_Click"/>
    </form>
</body>
</html>

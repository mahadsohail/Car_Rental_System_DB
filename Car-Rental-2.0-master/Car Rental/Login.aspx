<%@ Page Title="Home Page" Language="C#"  AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Car_Rental._Default" %>
<!DOCTYPE html>
<html>
<head>
	<title>Login Page</title>
	<style>

		body {
			background-color: #f2f2f2;
			font-family: Arial, sans-serif;
		}
		.container {
			margin: 50px auto;
			max-width: 500px;
			padding: 20px;
			background-color: #fff;
			border-radius: 5px;
			box-shadow: 0px 0px 5px 0px rgba(0,0,0,0.2);
		}
		h2 {
			text-align: center;
			color: #555;
		}
		form {
			display: flex;
			flex-direction: column;
			align-items: center;
		}
		input[type="text"], input[type="password"] {
			width: 100%;
			padding: 10px;
			margin-bottom: 10px;
			border: none;
			border-radius: 3px;
			box-shadow: 0px 0px 3px 0px rgba(0,0,0,0.2);
		}
		input[type="submit"] {
			width: 100%;
			padding: 10px;
			background-color: #4CAF50;
			color: #fff;
			border: none;
			border-radius: 3px;
			cursor: pointer;
			transition: background-color 0.3s ease;
		}
		input[type="submit"]:hover {
			background-color: #3e8e41;
		}
		.error {
			color: #f00;
			margin-bottom: 10px;
			font-size: 0.8em;
			text-align: center;
		}
		a {
			color: #333;
			text-decoration: none;
		}

		a:hover {
			text-decoration: underline;
		}
	</style>
</head>
<body>
	<div class="container">
		<h2>Login</h2>
		<form action="#" method="post" runat="server">
			<label for="username">Username:</label>
			<input type="text" runat="server" id="username1" name="username" required>
			<label for="password">Password:</label>
			<input type="password" runat="server" id="pass1" name="password" required>
			<asp:button type="submit" runat="server" id="Log" onclick="Log_Click" Text="Login"/>
			<p>Not registered yet? <a href="Registration.aspx">Sign up here</a></p>
		</form>
		
	
		<div class="error">Incorrect username or password.</div>
	</div>
</body>
</html>
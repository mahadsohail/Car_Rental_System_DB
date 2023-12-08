<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Car_Rental.Registration" %>
<!DOCTYPE html>
<html>
<head>
	<title>Registration Page</title>
	<link rel="stylesheet" type="text/css" href="Registrationstyle.css">
</head>
<body>
	<header>
		<h1>Registration Page</h1>
	</header>
	<main>
		<form runat="server">
			<label for="username">Username:</label>
			<input runat="server" type="text" id="username" name="username" required>
			<label for="password">Password:</label>
			<input runat="server" type="password"  id="password1" name="password1" required>
			<label for="confirm-password">Confirm Password:</label>
			<input type="password" runat="server" id="confirmpassword" name="confirmpassword" required>
			<label for="email">Email:</label>
			<input type="email" runat="server" id="email" name="email" required>
			<label for="phone">Phone:</label>
			<input type="tel" id="phone" runat="server" name="phone" pattern="[0-9]{10}" required>
			<asp:button type="submit" runat="server" onclick="Reg_Click" Text="Register" />
			<p>Already have an account? <a href="login.aspx">Login here</a></p>
		</form>
	</main>
	<footer>
		<p>&copy; 2023 MyCompany</p>
	</footer>
</body>
</html>


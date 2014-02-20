<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_1DV406L1._4.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa hemliga talet</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--Title and user input --%>
            <h1>Gissa det hemliga talet. Labb 4</h1>
            <asp:Label ID="Label1" runat="server" Text="Ange ett tal mellan 1-100"></asp:Label>
            <asp:TextBox ID="userInputTextBox" runat="server" TextMode="SingleLine"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fältet får inte vara tomt" ControlToValidate="userInputTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Talet måste vara mellan 1-100" Type="Integer" MaximumValue="100" MinimumValue="1" ControlToValidate="userInputTextBox"></asp:RangeValidator>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

            <asp:Button ID="guessButton" runat="server" Text="Gissa" OnClick="guessButton_Click" />

            <asp:PlaceHolder ID="labelPlaceHolder" runat="server" Visible="false">                
                <asp:Label ID="messages" runat="server" Text=""></asp:Label>
                <asp:Label ID="result" runat="server" Text=""></asp:Label>   
            </asp:PlaceHolder>

            <asp:PlaceHolder ID="resetButtonPlaceholder" runat="server" Visible="false">
                <asp:Button ID="resetButton" runat="server" Text="Nytt nummer" CausesValidation="false" OnClick="resetButton_Click" />
            </asp:PlaceHolder>
        </div>
    </form>
</body>
</html>

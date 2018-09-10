<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TempConverter.aspx.cs" Inherits="WebApplication2.TempConverter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 94px">
            Us Valeur: <asp:TextBox ID="value" runat="server"></asp:TextBox><br/>
            Resultat en CAD: <asp:TextBox ID="resultat" runat="server"></asp:TextBox><br />
            <asp:Button ID="ButtonConvert" runat="server" Text="Convertir" OnClick="ButtonConvert_Click1" />
        </div>
        <div runat="server" id="res"></div>
    </form>
    </body>
</html>

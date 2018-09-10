<!--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HtmlConverter.aspx.cs" Inherits="WebApplication1.HtmlConverter" %>-->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script runat="server">

        protected void convert_US_CAN(object sender, EventArgs e)
        {
            decimal USAmount = Decimal.Parse(us.Value);

            if (USAmount > 0)
            {
                decimal euroAmount = USAmount * 0.85M;


                can.Value = euroAmount.ToString() + "$ CAN.";
                can.Disabled = true;

                //cadDiv.InnerHtml = euroAmount.ToString() + "$ CAN.";

                HttpContext _context = HttpContext.Current;

                _context.Items.Add("can", euroAmount.ToString());

                Server.Transfer("resultat.aspx");
            }
            else
                //redirection vers la page d'errour , donc une nouvelle requete.
                Response.Redirect("errour.htm");
        }
    </script>

    <script type="text/javascript" >
        function afficher() {

            alert("Clic client sur button");
        }

    </script>

</head>
<body>
    <form method="post" runat="server">
        <table style="width:50%;">
        <tr>
            <td>Montant US</td>
            <td> <input id="us"  type="text" runat="server"/></td>
        </tr>
        <tr><td colspan="2"><input id="submit1" type="submit" value="Convertir" onclick="afficher()" onserverclick="convert_US_CAN" runat="server"/></td>
        </tr>
        <tr>
            <td>Montant $ CAN</td>
            <td><input id="can" type="text" runat="server" /></td>
        </tr>
        <tr>
            <td>Montant $ CAN dans un DIV</td>
            <td><div style="border-style:dotted; " id="cadDiv" runat="server" /></td>
        </tr>
            
        </table>
    </form>
</body>
</html>

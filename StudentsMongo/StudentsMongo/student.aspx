<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="StudentsMongo.student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Management System</title>
    <link rel="stylesheet" href="StyleSheet1.css"/>
    
</head>
<body>
    <div class="MTU">
        <h1>Munster Technological University</h1>
    </div>
    <div class="container">
        <form id="form1" runat="server">
                <asp:Label ID="lblId" runat="server" Text="Id"></asp:Label>
                <asp:TextBox ID="txtId" runat="server" ></asp:TextBox><br />
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                <asp:Label ID="lblResults" runat="server" ></asp:Label><br /><br />

                <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
           
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
           
                <asp:Label ID="lblTnumber" runat="server" Text="tNumber"></asp:Label>
                <asp:TextBox ID="txtTnumber" runat="server" CssClass="form-control"></asp:TextBox>
          
                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox><br /><br />
          
                <asp:Label ID="lblFees" runat="server" Text="Fees Paid"></asp:Label>
                <asp:TextBox ID="txtFees" runat="server" CssClass="form-control"></asp:TextBox>
            
                <asp:Label ID="lblCollege" runat="server" Text="College"></asp:Label>
                <asp:TextBox ID="txtCollege" runat="server" CssClass="form-control"></asp:TextBox><br /><br />
                <div>
                    <h3>College subjects</h3>
                </div>
                <asp:Label ID="lblSub1" runat="server" Text="Subject 1"></asp:Label>
                <asp:TextBox ID="txtSub1" runat="server" CssClass="form-control"></asp:TextBox>
         
                <asp:Label ID="lblSub2" runat="server" Text="Subject 2"></asp:Label>
                <asp:TextBox ID="txtSub2" runat="server" CssClass="form-control"></asp:TextBox>
            
                <asp:Label ID="lblSub3" runat="server" Text="Subject 3"></asp:Label>
                <asp:TextBox ID="txtSub3" runat="server" CssClass="form-control"></asp:TextBox>
          
                <asp:Label ID="lblSub4" runat="server" Text="Subject 4"></asp:Label>
                <asp:TextBox ID="txtSub4" runat="server" CssClass="form-control"></asp:TextBox>
           
                <asp:Label ID="lblSub5" runat="server" Text="Subject 5"></asp:Label>
                <asp:TextBox ID="txtSub5" runat="server" CssClass="form-control"></asp:TextBox><br /><br />
            
                <asp:Button ID="btnInsert" runat="server" Text="Insert new Student" OnClick="btnInsert_Click"/>
                <asp:Button ID="btnEdit" runat="server" Text="Edit Student Details" OnClick="btnEdit_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete Student" OnClick="btnDelete_Click" />
                <asp:Button ID="btnClean" runat="server" Text="Clear fields" OnClick="btnClean_Click" /><br />
                <asp:Label ID="lblResults1" runat="server" ></asp:Label><br /><br />
            
        </form>
    </div>
</body>
</html>

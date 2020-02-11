<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SEM.CMS.Web.Login" %>

<!DOCTYPE html>
<!--[if IE 8]> <html lang="en" class="ie8"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9"> <![endif]-->
<!--[if !IE]><!--> <html lang="en"> <!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
  <meta charset="utf-8" />
  <title>Competition Management System</title>
  <meta content="width=device-width, initial-scale=1.0" name="viewport" />
  <meta content="" name="description" />
  <meta content="" name="author" />
  <link href="/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
  <link href="/assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
  <link href="/assets/css/style.css" rel="stylesheet" />
  <link href="/assets/css/style_responsive.css" rel="stylesheet" />
  <link href="/assets/css/style_default.css" rel="stylesheet" id="style_color" />
  <link rel="stylesheet" type="text/css" href="/assets/uniform/css/uniform.default.css" />
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body>
  <!-- BEGIN LOGO -->
  <div id="logo" class="center">
    <%--<img src="/assets/img/logo.png" alt="logo" class="center" /> --%>
  </div>
  <!-- END LOGO -->
  <!-- BEGIN LOGIN -->
  <div id="login">
    <!-- BEGIN LOGIN FORM -->
    <form id="loginform" class="form-vertical no-padding no-margin" runat="server" DefaultButton="btnLogin">
      <asp:ScriptManager runat="server"></asp:ScriptManager>
      <asp:Label ID="lblLoginRespMsg" runat="server" Text="" class="center" ForeColor="Red"></asp:Label>
      <p class="center">Enter your username and password.</p>
      <div class="control-group">
        <div class="controls">
          <div class="input-prepend">
            <span class="add-on"><i class="icon-user"></i></span>
              <asp:TextBox ID="txtLoginID" AutoCompleteType="None" MaxLength="20" placeholder="Username" runat="server"></asp:TextBox>
          </div>
        </div>
      </div>
      <div class="control-group">
        <div class="controls">
          <div class="input-prepend">
            <span class="add-on"><i class="icon-lock"></i></span>
              <asp:TextBox ID="txtPassword" AutoCompleteType="None" autocomplete="off" TextMode="Password" placeholder="Password" runat="server"></asp:TextBox>         
          </div>
        </div>
      </div>
      <div class="control-group">
        <div class="controls">
          <div class="input-prepend">
            <span class="add-on"><i class="icon-check"></i></span>
              <asp:TextBox ID="txtCode" AutoCompleteType="None" MaxLength="4" placeholder="Code" runat="server"></asp:TextBox>
          </div>
          <div class="block-hint pull-left">
              <asp:UpdatePanel ID="UpdatePanelCaptcha" runat="server" UpdateMode="Conditional">
                  <ContentTemplate>
                      <asp:ImageButton ID="img_captcha" CssClass="btn btn-block" runat="server" OnClick="img_captcha_Click" ToolTip="Click to refresh the Code" />
                  </ContentTemplate>
              </asp:UpdatePanel>
          </div>
          <div class="block-hint pull-right">
            <%--<a href="javascript:;" class="" id="forget-password">Forgot Password?</a>--%>
          </div>
          <div class="clearfix space5"></div>
        </div>
      </div>
      <asp:Button ID="btnLogin" class="btn btn-block btn-inverse" Text="Login" runat="server" OnClick="btnLogin_Click" OnClientClick="return validate();" />
    </form>
    <!-- END LOGIN FORM -->        
    <!-- BEGIN FORGOT PASSWORD FORM -->
    <form id="forgotform" class="form-vertical no-padding no-margin hide">
      <p class="center">Enter your e-mail address below to reset your password.</p>
      <div class="control-group">
        <div class="controls">
          <div class="input-prepend">
            <span class="add-on"><i class="icon-envelope"></i></span><input id="input-email" type="text" placeholder="Email" />
          </div>
        </div>
        <div class="space10"></div>
      </div>
      <input type="button" id="forget-btn" class="btn btn-block btn-inverse" value="Submit" />
    </form>
    <!-- END FORGOT PASSWORD FORM -->
  </div>
  <!-- END LOGIN -->
  <!-- BEGIN COPYRIGHT -->
  <div id="login-copyright">
    2015 &copy; CMS. Admin Site.
  </div>
  <!-- END COPYRIGHT -->
  <!-- BEGIN JAVASCRIPTS -->
  <script src="/assets/js/jquery-1.8.2.min.js"></script>
  <script src="/assets/bootstrap/js/bootstrap.min.js"></script>
  <script src="/assets/js/jquery.blockui.js"></script>
  <script src="/assets/js/app.js"></script>
  <script>
    jQuery(document).ready(function() {     
      App.initLogin();
    });
  </script>

    <script type="text/javascript">

        function validate() {
            var LoginID = document.getElementById('<%=txtLoginID.ClientID %>').value;
            var Password = document.getElementById('<%=txtPassword.ClientID %>').value;
            var Code = document.getElementById('<%=txtCode.ClientID %>').value;

            if (LoginID == "") {
                alert("Enter Username.");
                return false;
            }
            if (Password == "") {
                alert("Enter Password.");
                return false;
            }
            if (Code == "") {
                alert("Enter Code.");
                return false;
            }
        }

    </script>

  <!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>

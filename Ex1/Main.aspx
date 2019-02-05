<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Ex1.Main" %>

<!DOCTYPE html>

<html>

    <head>
    <title>Ex1</title>
    <link rel="stylesheet" href="https://getbootstrap.com/docs/4.2/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://getbootstrap.com/docs/3.3/assets/css/docs.min.css">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js" ></script>    
	<script type="text/javascript" src="https://getbootstrap.com/docs/4.2/dist/js/bootstrap.bundle.js"></script>
    <script type="text/javascript" src="scripts/jquery.maskedinput.min.js"></script>    
    </head>    
   
    <body>	
      <nav class="navbar navbar-expand-lg navbar-light bg-light">
	    <a class="navbar-brand" href="#">Exercício 1</a>
	  </nav>
      <form id="form1" class="offset-sm-1" runat="server">           
	  <div class="form-group">
          <div class="row">
              <div class="col">
	   <label class="offset-md-5 font-weight-bold">Nome</label>	   
	   <input type="text" maxlength="50" required class="offset-md-5 form-control col-md-7" id="nome" runat="server"  placeholder="Digite um nome">	
       <%--<p></p>--%>
                  </div>
              <div class="col">
        <div class="input-group">
                <script>
                jQuery(function ($)
                {
                    $("#cnpj").mask("99.999.999/9999-99");
                    $("#cpf").mask("999.999.999-99");
                    $("#tel").mask("(99) 9999-9999?9");
                });
            </script>
            <script>
                $(document).ready
                    (function () {
                        $('.funkyradio-default').click(
                            function () {
                                $('#radio1').click(
                                    function () {
                                        document.getElementById('cpf').required = true;
                                        document.getElementById('cnpj').required = false;
                                    });
                                $('#radio2').click
                                    (
                                    function () {
                                        document.getElementById('cpf').required = false;
                                        document.getElementById('cnpj').required = true;
                                    });
                            });
                    })                           
            </script>
        <div class="funkyradio-default col-md-5">
        <div class="funkyradio-default">
            <input type="radio" name="radio" id="radio1" runat="server" checked/>
            <label for="radio1">CPF</label>
            <input type="text" name="txt" class="form-control" id="cpf" required runat="server" maxlength="14" placeholder="CPF">            
        </div>
        <div class="funkyradio-default">
            <input type="radio" name="radio" id="radio2" runat="server"/>
            <label for="radio2">CNPJ</label>
            <input type="text" name="txt" class="form-control" id="cnpj" runat="server" maxlenght="18" placeholder="CNPJ">
        </div>
       </div> 
       </div>  
                  </div>
              </div>
      </div>
   <div class="row">  
   <div class="col">
	  <div class="form-group">
	    <label class="offset-md-5 font-weight-bold">Telefone</label>        
	    <input type="text" required class="offset-md-5 form-control col-md-7" id="tel" runat="server" placeholder="Digite um telefone">         
        </div>
   </div> 
     <div class="col">
        <label class="font-weight-bold">Tipo</label>
		<select class="form-control col-md-5" runat="server" id="tipotel">
            <option>Residencial</option>
            <option>Comercial</option>
            <option>Celular</option>
        </select>
         </div>
  </div>
	  <div class="form-group">
          <div class="row">
          <div class="col">
	    <label class="offset-md-5 font-weight-bold">Endereço</label>
	    <input type="text" required maxlength="100" class="offset-md-5 col-md-7 form-control" id="end" runat="server" placeholder="Digite um endereço">		
          </div>
          <div class="col">
              <label class="font-weight-bold">Tipo</label>
          <select class="form-control col-md-5" runat="server" id="tipoend">
            <option>Cobrança</option>
            <option>Comercial</option>
            <option>Correspondência</option>
            <option>Entrega</option>
            <option>Residencial</option>
        </select>
              </div>
              </div>
	  </div>
	  <div class="row">
          <button runat="server" class="offset-md-5 btn btn-primary" onserverclick="Save" id="salvar">Salvar</button> 
          &nbsp
          <button runat="server" class="btn btn-danger" onserverclick="Cancel" visible="false" id="btnCancel">Cancelar</button>
      </div> 

          <p></p>
          <p></p>
          <div class="offset-sm-1 col-lg-8">
              <asp:gridview CssClass="table table-borderless table-hover" OnRowEditing="dt_RowEditing" OnRowDeleting="dt_RowDeleting" runat="server" ID="dt" BorderStyle="None" AllowPaging="True" PageSize="10" OnPageIndexChanged="dt_PageIndexChanged" OnPageIndexChanging="dt_PageIndexChanging" PageIndex="0" AllowCustomPaging="False"></asp:gridview>
          </div>
      
	</form>
    
    <p></p>   
    <p></p>
    
    <footer>
    </footer>
    </body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuario_View.aspx.cs" Inherits="SistemaGestionIndicadores.Usuario_Vista" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
            <title>Usuarios</title>
        <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round"/>
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css"/>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons"/>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
        <link href="../Content/css/styles.css" rel="stylesheet"/>
		<script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
		<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>
		<script>
            $(document).ready(function () {
                // Activate tooltip
                $('[data-toggle="tooltip"]').tooltip();

                // Select/Deselect checkboxes
                var checkbox = $('table tbody input[type="checkbox"]');
                $("#selectAll").click(function () {
                    if (this.checked) {
                        checkbox.each(function () {
                            this.checked = true;
                        });
                    } else {
                        checkbox.each(function () {
                            this.checked = false;
                        });
                    }
                });
                checkbox.click(function () {
                    if (!this.checked) {
                        $("#selectAll").prop("checked", false);
                    }
                });
            });
        </script>	
	
	</head>
    <body>
        <form id="form1" runat="server">
            <div>
				<div class="container-xl">
					<div class="table-responsive">
						<div class="table-wrapper">
							<div class="table-title">
								<div class="row">
									<div class="col-sm-6">
										<h2> <b>Usuarios</b></h2>
									</div>
									<div class="col-sm-6">
										<a href="#crudModal" class="btn btn-success" data-toggle="modal"><i class="material-icons">&#xE147;</i> <span>Gestión Usuarios</span></a>						
									</div>
								</div>
							</div>
							<table class="table table-striped table-hover">
								<thead>
									<tr>
										<th>
											<span class="custom-checkbox">
												<input type="checkbox" id="selectAll">
												<label for="selectAll"></label>
											</span>
										</th>
										<th>Email</th>
										<th>Contraseña</th>
									</tr>
								</thead>
								<tbody>
								<%for (int i = 0; i < arrayUsuario.Length; i++)
									{
								%>
									<tr>
										<td>
											<span class="custom-checkbox">
												<input type="checkbox" id="checkbox1" name="options[]" value="1">
												<label for="checkbox1"></label>
											</span>
										</td>
                                        <td><%Response.Write(arrayUsuario[i].Email); %></td>
										<td><%Response.Write(arrayUsuario[i].Contrasena); %></td>
									</tr>
								<%	} %>
								</tbody>
							</table>
							<div class="clearfix">
								<div class="hint-text">Showing <b>1</b> out of <b>1</b> entries</div>
								<ul class="pagination">
									<li class="page-item disabled"><a href="#">Previous</a></li>
									<li class="page-item"><a href="#" class="page-link">1</a></li>
									<li class="page-item"><a href="#" class="page-link">2</a></li>
									<li class="page-item"><a href="#" class="page-link">Next</a></li>
								</ul>
							</div>
						</div>
					</div>        
				</div>
				<!-- Edit Modal HTML -->
				<div id="crudModal" class="modal fade">
					<div class="modal-dialog">
						<div class="modal-content">
								<div class="modal-header">						
									<h4 class="modal-title">Gestión de Usuarios</h4>
									<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
								</div>
								<div class="modal-body">					
									<div class="form-group">
										<label>Email</label>
										<asp:TextBox ID="txtEmail" class="form-control" runat="server" required=""></asp:TextBox>
									</div>
									<div class="form-group">
										<label>Contraseña</label>
										<asp:TextBox ID="txtContrasena" runat="server" class="form-control"></asp:TextBox>
									</div>
									<div class="form-group">
                                        <asp:Button ID="btnGuardar" class="btn btn-success" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                                        <asp:Button ID="btnConsultar" runat="server" class="btn btn-success" Text="Consultar" OnClick="btnConsultar_Click" />
                                        <asp:Button ID="btnModificar" runat="server" class="btn btn-warning" Text="Modificar" OnClick="btnModificar_Click" />
                                        <asp:Button ID="btnBorrar" runat="server" class="btn btn-warning" Text="Borrar" OnClick="btnBorrar_Click" />
									</div>
								</div>
								<div class="modal-footer">
									<input type="button" class="btn btn-default" data-dismiss="modal" value="Cancel">
								</div>
						</div>
					</div>
				</div>
			</div>
        </form>
    </body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Winser._default" Theme="" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        /* Enlace a la fuente Montserrat desde Google Fonts */
        @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500;600&display=swap');

        /* Aplicando la fuente Montserrat a toda la página */
        body {
            background-color: #121212; /* Fondo oscuro */
            color: #e0e0e0; /* Texto claro */
            font-family: 'Montserrat', sans-serif; /* Fuente Montserrat */
            margin: 0;
            padding: 0;
            height: 100vh; /* Asegura que la altura sea del 100% de la pantalla */
            display: flex;
            flex-direction: column;
        }

        /* Estilos para los contenedores */
        #contenedorPrincipal {
            display: flex;
            justify-content: space-between;
            margin: 20px;
            flex-grow: 1; /* Hace que el contenedor principal ocupe todo el espacio restante */
            overflow-y: auto; /* Habilita el desplazamiento si es necesario */
        }

        /* Estilo para el contenedor izquierdo */
        #contenedorIzquierdo {
            width: 33%;
            background-color: #1e1e1e; /* Fondo oscuro para el contenedor izquierdo */
            padding: 10px;
            border-radius: 8px;
            height: 100%; /* Se ajusta al alto disponible */
            box-sizing: border-box; /* Incluye el padding en el tamaño total */
            overflow-y: auto; /* Habilita el desplazamiento en caso de contenido largo */
        }

        /* Estilo para el contenedor derecho */
        #contenedorDerecho {
            width: 65%; /* Ajuste del tamaño del contenedor derecho */
            padding-left: 20px;
            background-color: #1e1e1e; /* Fondo oscuro */
            padding: 10px;
            border-radius: 8px;
            height: 100%; /* Se ajusta al alto disponible */
            box-sizing: border-box; /* Incluye el padding en el tamaño total */
            overflow-y: auto;
            margin-left: 0px;
        }

        /* Estilo para los campos de texto */
        input[type="text"], textarea {
            background-color: #333; /* Fondo oscuro para los inputs */
            color: #e0e0e0; /* Texto claro */
            border: 1px solid #555; /* Borde suave */
            padding: 8px;
            width: 100%;
            border-radius: 5px;
            box-sizing: border-box; /* Incluye el padding en el tamaño total */
            margin-bottom: 10px; /* Separación entre campos */
        }

        /* Estilo para la textArea de sinopsis (sin redimensionamiento) */
        #sinopsis {
            resize: none; /* Deshabilita el redimensionamiento */
            height: 80px; /* Ajusta el tamaño de la sinopsis */
        }

        /* Estilo para los botones */
        .button {
            background-color: #6200ea; /* Color morado para los botones */
            color: white;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
            width: 100%;
            box-sizing: border-box; /* Incluye el padding en el tamaño total */
        }

        .button:hover {
            background-color: #3700b3; /* Color morado más oscuro al pasar el mouse */
        }

        /* Estilo para la tabla */
        table {
            width: 100%;
            border-collapse: collapse;
            color: #e0e0e0; /* Texto claro para la tabla */
        }

        table, th, td {
            border: 1px solid #444; /* Bordes más suaves */
        }

        th, td {
            padding: 10px;
            text-align: left;
        }

        th {
            background-color: #333; /* Fondo oscuro para las cabeceras de la tabla */
        }

        tr:nth-child(even) {
            background-color: #333; /* Filas alternadas con un fondo más oscuro */
        }

        tr:nth-child(odd) {
            background-color: #2c2c2c; /* Filas alternadas con un fondo intermedio */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenedorPrincipal">
            <!-- Contenedor de la izquierda -->
            <div id="contenedorIzquierdo">
                <h3>AGREGAR LIBRO</h3>
                <label for="isbn">ISBN:</label><br />
                <asp:TextBox ID="isbn" runat="server" CssClass="input" Width="100%"></asp:TextBox><br />

                <label for="titulo">Título:</label><br />
                <asp:TextBox ID="titulo" runat="server" CssClass="input" Width="100%"></asp:TextBox><br />

                <label for="autor">Autor:</label><br />
                <asp:TextBox ID="autor" runat="server" CssClass="input" Width="100%"></asp:TextBox><br />

                <label for="edicion">Edición:</label><br />
                <asp:TextBox ID="edicion" runat="server" CssClass="input" Width="100%"></asp:TextBox><br />

                <label for="ano">Año:</label><br />
                <asp:TextBox ID="ano" runat="server" CssClass="input" Width="100%"></asp:TextBox><br />

                <label for="pais">País:</label><br />
                <asp:TextBox ID="pais" runat="server" CssClass="input" Width="100%"></asp:TextBox><br />

                <label for="sinopsis">Sinopsis:</label><br />
                <textarea id="sinopsis" runat="server" name="S1" class="input"></textarea><br />
                <label for="carrera">
                Carrera:</label><br />
                <asp:TextBox ID="carrera" runat="server" CssClass="input" Width="100%"></asp:TextBox><br />

                <label for="materia">Materia:</label><br />
                <asp:TextBox ID="materia" runat="server" CssClass="input" Width="100%"></asp:TextBox>
                <br />
                <br />

                <asp:Button ID="agregar" runat="server" Text="Agregar Libro" CssClass="button" OnClick="agregar_Click" />
            </div>

            <div id="contenedorDerecho">
                <h3>LIBROS</h3>
                <table border="1" id="tablaLibros" runat="server">
                    <tr>
                        <th>ID</th>
                        <th>ISBN</th>
                        <th>Título</th>
                        <th>Autor</th>
                        <th>Edición</th>
                        <th></th>
                        <th></th>
                    </tr>
                    <!-- Las filas de libros se agregarán aquí desde el code-behind -->
                </table>
            </div>
        </div>
    </form>
</body>
</html>

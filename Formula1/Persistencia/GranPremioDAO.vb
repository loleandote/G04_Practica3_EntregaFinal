Imports System.Data.SqlClient
Imports Formula1.EntidadesAuxiliares
Imports MySql.Data.MySqlClient

Public Class GranPremioDAO
   ' Esta función recupera todas los grandes premios de la base de datos y las devuelve como
   ' una lista de objetos `GranPremio`. Utiliza una consulta SQL para unir las tablas `gran_premio` y
   ' `pais` y recuperar los campos `idGRAN_PREMIO`, `PAIS`, `pais.nombre` y `gran_premio.nombre`.
   ' Luego itera sobre los resultados y crea un nuevo objeto `GranPremio` para cada fila, configurando
   ' sus propiedades con los valores recuperados. Finalmente, agrega cada objeto `GranPremio` a una
   ' lista y devuelve la lista.
    Public Shared Function ObtenerTodosGranPremio() As List(Of GranPremio)
        Dim GrandesPremios As New List(Of GranPremio)
        Try
            For Each premio In AgenteBD.ObtenerAgente.Leer("select idGRAN_PREMIO, PAIS,pais.nombre, gran_premio.nombre from gran_premio join pais on pais.idPAIS=gran_premio.PAIS")
                GrandesPremios.Add(New GranPremio With {
                .idGranPremio = premio(1).ToString,
                .Pais = New Pais() With {
                .IdPais = premio(2).ToString,
                .Nombre = premio(3).ToString
                },
                .Nombre = premio(4).ToString
                       })
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return GrandesPremios
    End Function
    ' La recupera todos los grandes premios de la base de datos y
    ' los devuelve como una lista de objetos `ClaveValor`. Utiliza una consulta SQL para seleccionar
    ' los campos `idGRAN_PREMIO` y `nombre` de la tabla `gran_premio`. Luego, itera sobre los
    ' resultados y crea un nuevo objeto `ClaveValor` para cada fila, asignando su propiedad `Clave` al
    ' valor `idGRAN_PREMIO` y su propiedad `Valor` al valor `nombre`. Finalmente, agrega cada objeto
    ' `ClaveValor` a una lista y devuelve la lista.
    Public Shared Function ObtenerTodosGranPremioClaveValor() As List(Of ClaveValor)
        Dim GrandesPremios As New List(Of ClaveValor)
        Try
            For Each premio In AgenteBD.ObtenerAgente.Leer("select idGRAN_PREMIO, gran_premio.nombre from gran_premio")
                GrandesPremios.Add(New ClaveValor With {
                .Clave = Integer.Parse(premio(1).ToString),
                .Valor = premio(2).ToString})
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return GrandesPremios
    End Function

    ' La  recupera todos los grandes premios
    ' en los que ha participado un piloto y los devuelve como una lista de objetos `ClaveValor` .
    ' Utiliza una consulta SQL para unir las tablas `gran_premio`, `edicion` y `clasificacion_carrera`
    ' y recuperar los campos `idGRAN_PREMIO` y `nombre` de la tabla `gran_premio` donde el campo
    ' `piloto` en la tabla `clasificacion_carrera` coincide con el `idPiloto` dado. Luego, itera sobre
    ' los resultados y crea un nuevo objeto `ClaveValor` para cada fila, asignando su propiedad
    ' `Clave` al valor de `idGRAN_PREMIO` y su propiedad `Valor` al valor de `nombre`. Finalmente,
    ' agrega cada objeto `ClaveValor` a una lista y devuelve la lista.
    Public Shared Function obtenerGrandesPremiosPiloto(idPiloto As Integer) As List(Of ClaveValor)
        Dim GrandesPremios As New List(Of ClaveValor)
        Try
            For Each premio In AgenteBD.ObtenerAgente.Leer("select distinct(gran_premio.idGRAN_PREMIO), gran_premio.nombre from gran_premio join edicion on edicion.idgran_premio = gran_premio.idGRAN_PREMIO join clasificacion_carrera on  " +
                                                           "clasificacion_carrera.edicion= edicion.idedicion where clasificacion_carrera.piloto=" + idPiloto.ToString)
                GrandesPremios.Add(New ClaveValor With {
                .Clave = Integer.Parse(premio(1).ToString),
                .Valor = premio(2).ToString})
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return GrandesPremios
    End Function
    ' La función inserta unnuevo objeto `GranPremio` en la base de datos. Primero obtiene el número 
    ' actual de objetos GranPremio` en la base de datos llamando a la función `ObtenerTodosGranPremio`
    ' y contando el número de elementos en la lista devuelta. A continuación, construye una instrucción
    ' SQL `INSERT`para agregar el nuevo objeto `GranPremio` a la base de datos, utilizando 
    ' la función `max` para obtener el siguiente valor `idGRAN_PREMIO` disponible. Si no existen objetos 
    ' `GranPremio` en la base de datos, establece el valor `idGRAN_PREMIO` en 1. Si hay un error durante 
    ' la inserción, muestra un mensaje de error.
    Public Shared Sub InsertarGranPremio(granPremio As GranPremio)
        Dim id = ObtenerTodosGranPremio.Count
        Try
            If id > 0 Then
                AgenteBD.ObtenerAgente.Modificar("insert into gran_premio values((select max(idGRAN_PREMIO) from gran_premio e)+1 , '" & granPremio.Pais.IdPais & "', '" & granPremio.Nombre & "')")
            Else
                AgenteBD.ObtenerAgente.Modificar("insert into gran_premio values(1, '" & granPremio.Pais.IdPais & "', '" & granPremio.Nombre & "')")
            End If
        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la insercion")
        End Try

    End Sub

   ' La función actualiza un objeto `GranPremio` existente en la base de
   ' datos. Toma un objeto `GranPremio` como parámetro y usa sus propiedades para construir una
   ' declaración SQL `UPDATE` que modifica la fila correspondiente en la tabla `gran_premio`. Se llama
   ' al método `AgenteBD.ObtenerAgente.Modificar` para ejecutar la sentencia SQL. Si hay un error
   ' durante la actualización, se muestra un cuadro de mensaje con el mensaje de error.
    Public Shared Sub EditarGranPremio(granPremio As GranPremio)
        Try
            AgenteBD.ObtenerAgente.Modificar("update gran_premio set PAIS='" & granPremio.Pais.IdPais & "', NOMBRE='" & granPremio.Nombre & "' where 'idGRAN_PREMIO'='" & granPremio.idGranPremio & "'")

        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la insercion")
        End Try
    End Sub

    ' Este es un método que elimina un objeto `GranPremio` de la base de
    ' datos. Toma un parámetro `idGranPremio` como un número entero y construye una instrucción SQL
    ' `DELETE` para eliminar la fila correspondiente de la tabla `gran_premio`. Si hay un error
    ' durante la eliminación, muestra un cuadro de mensaje con el mensaje de error.
    Public Shared Sub EliminarGranPremio(idGranPremio As Integer)
        Try
            AgenteBD.ObtenerAgente.Modificar("delete from gran_premio where idGRAN_PREMIO= " & idGranPremio)
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la eliminación")
        End Try
    End Sub
End Class

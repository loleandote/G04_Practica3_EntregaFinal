Imports Formula1.EntidadesAuxiliares
Imports MySql.Data.MySqlClient

Public Class CircuitoDAO
    ' Esta función recupera todos los circuitos de la base de datos y los devuelve como una lista de
    ' objetos `Circuito`. Utiliza una consulta SQL para unir las tablas `circuito` y `pais` y luego
    ' itera sobre los resultados para crear nuevos objetos `Circuito` y agregarlos a la lista. Si hay
    ' un error en la consulta de la base de datos, mostrará un cuadro de mensaje con el mensaje de
    ' error.
    Public Shared Function ObtenerTodosCircuitos() As List(Of Circuito)
        Dim circuitos As New List(Of Circuito)
        Try
            For Each circuito In AgenteBD.ObtenerAgente.Leer("select * from circuito join pais on circuito.pais= pais.idpais")
                circuitos.Add(New Circuito(circuito(1).ToString, circuito(2).ToString, circuito(3).ToString, Integer.Parse(circuito(5).ToString), Integer.Parse(circuito(6).ToString), circuito(7).ToString, circuito(8).ToString))
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return circuitos
    End Function

  ' La función recupera todos los circuitos de la base
  ' de datos que pertenecen a un país específico (identificado por `idPais`) y devolviéndolos como una
  ' lista de objetos `ClaveValor`. La clase `ClaveValor` es una clase personalizada que tiene dos
  ' propiedades: `Clave` (clave) y `Valor` (valor). En este caso, la propiedad `Clave` se establece en
  ' el ID del circuito y la propiedad `Valor` se establece en el nombre del circuito. La función
  ' utiliza una consulta SQL para unir las tablas `circuito` y `pais` y filtrar por el ID de país
  ' especificado. Si hay un error en la consulta de la base de datos, se muestra un cuadro de mensaje
  ' con el mensaje de error.
    Public Shared Function ObtenerTodosCircuitosPaisClaveValor(idPais As String) As List(Of ClaveValor)
        Dim circuitos As New List(Of ClaveValor)
        Try
            For Each circuito In AgenteBD.ObtenerAgente.Leer("select idCIRCUITO, circuito.nombre from circuito join pais on circuito.pais= pais.idpais where pais.idpais='" & idPais & "'")
                circuitos.Add(New ClaveValor() With {.Clave = Integer.Parse(circuito(1).ToString), .Valor = circuito(2).ToString})
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return circuitos
    End Function
   ' La función recupera un circuito de la base de datos en función de
   ' su ID (`idCircuito`). Utiliza una consulta SQL para unir las tablas `circuito` y `pais` y filtrar
   ' por el ID especificado. Luego crea un nuevo objeto `Circuito` con los datos recuperados y lo
   ' devuelve. Si hay un error en la consulta de la base de datos, muestra un mensaje de error.
    Public Shared Function ObtenerCircuitoPorId(idCircuito As Integer) As Circuito
        Dim circuitos As Circuito
        Try
            For Each circuito In AgenteBD.ObtenerAgente.Leer("select * from circuito join pais on circuito.pais= pais.idpais where circuito.idCircuito=" & idCircuito)
                circuitos = New Circuito() With {.IdCircuito = Integer.Parse(circuito(1).ToString), .Nombre = circuito(2).ToString, .Ciudad = circuito(3).ToString, .Longitud = Integer.Parse(circuito(5).ToString), .Curvas = Integer.Parse(circuito(6).ToString), .Pais = New Pais With {.IdPais = circuito(7).ToString, .Nombre = circuito(8).ToString}}
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return circuitos
    End Function
    ' La función recupera un circuito de la base de datos basado en su ID (`idCircuito`) y el
    ' ID de la edición (`idEdicion`). Utiliza una consulta SQL para unir las tablas `circuito`, `pais`
    ' y `edicion` y filtrar por el ID de edición especificado. Luego crea un nuevo objeto `Circuito`
    ' con los datos recuperados y lo devuelve. Si hay un error en la consulta de la base de datos,
    ' muestra un mensaje de error.
    Public Shared Function ObtenerCircuitoPorIdEdicion(idEdicion As Integer) As Circuito
        Dim circuitos As New Circuito
        Try
            For Each circuito In AgenteBD.ObtenerAgente.Leer("select * from circuito join pais on circuito.pais= pais.idpais join edicion on edicion.circuito = circuito.idcircuito where edicion.idedicion=" & idEdicion)
                circuitos = New Circuito() With {.IdCircuito = Integer.Parse(circuito(1).ToString), .Nombre = circuito(2).ToString, .Ciudad = circuito(3).ToString, .Longitud = Integer.Parse(circuito(5).ToString), .Curvas = Integer.Parse(circuito(6).ToString), .Pais = New Pais With {.IdPais = circuito(7).ToString, .Nombre = circuito(8).ToString}}
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return circuitos
    End Function

   ' La función inserta un nuevo circuito en la base de datos. Primero
   ' verifica el número de circuitos existentes en la base de datos y asigna una nueva ID al circuito
   ' que se está insertando. Luego usa una instrucción SQL `INSERT` para agregar el nuevo circuito a
   ' la tabla `circuito` en la base de datos. Si hay un error durante la inserción, muestra un cuadro
   ' de mensaje con el mensaje de error.
    Public Shared Sub InsertarCircuito(circuito As Circuito)
        Try
            Dim id = ObtenerTodosCircuitos.Count
            If id > 0 Then
                AgenteBD.ObtenerAgente.Modificar("insert into circuito values((select max(idCircuito) from circuito e)+1, '" & circuito.Nombre & "', '" & circuito.Ciudad & "', '" & circuito.Pais.IdPais & "', " & circuito.Longitud & ", " & circuito.Curvas & ")")
            Else
                AgenteBD.ObtenerAgente.Modificar("insert into circuito values(" & 1 & ", '" & circuito.Nombre & "', '" & circuito.Ciudad & "', '" & circuito.Pais.IdPais & "', " & circuito.Longitud & ", " & circuito.Curvas & ")")
            End If
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la inserción")
        End Try
    End Sub

  ' La función actualiza un circuito existente en la base de datos con la
  ' nueva información proporcionada en el parámetro `circuito`. Utiliza una instrucción SQL `UPDATE`
  ' para modificar la tabla `circuito` con los nuevos valores para `nombre`, `ciudad`, `pais`,
  ' `longitud` y `curvas` donde `idCircuito` coincide con `circuito. IdCircuito`. Si hay un error
  ' durante la actualización, muestra un cuadro de mensaje con el mensaje de error.
    Public Shared Sub EditarCircuito(circuito As Circuito)
        Try
            AgenteBD.ObtenerAgente.Modificar("update circuito set nombre='" & circuito.Nombre & "', ciudad='" & circuito.Ciudad & "', pais='" & circuito.Pais.IdPais & "', longitud=" & circuito.Longitud & ", curvas=" & circuito.Curvas & " where idCircuito='" & circuito.IdCircuito & "'")
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la edición")
        End Try
    End Sub

    ' La función `comprueba si hay ediciones de un circuito en la
    ' base de datos. Toma un parámetro entero `idCircuito` que representa la ID del circuito a
    ' verificar. Utiliza una consulta SQL para seleccionar todas las ediciones de la tabla `edición`
    ' donde la columna `circuito` coincide con el parámetro `idCircuito`. Si el recuento de la lista
    ' resultante es mayor que 0, devuelve `Verdadero`, lo que indica que hay ediciones del circuito en
    ' la base de datos. De lo contrario, devuelve `Falso`.
    Public Shared Function obtenerEdicionesCircuito(idCircuito As Integer) As Boolean
        Return AgenteBD.ObtenerAgente.Leer("select * from ediciones where circuito= " + idCircuito.ToString).Count > 0
    End Function
    ' La función borra un circuito de la base de datos. Toma un parámetro
    ' entero `idCircuito` que representa el ID del circuito a borrar. La función primero borra todas
    ' las entradas en la tabla `clasificacion_carrera` donde la columna `edicion` coincide con la
    ' columna `idEdicion` en la tabla `edicion` donde la columna `circuito` coincide con el parámetro
    ' `idCircuito`. Luego borra el circuito de la tabla `circuito` donde la columna `idCircuito`
    ' coincide con el parámetro `idCircuito`. Si hay un error durante la eliminación, muestra un
    ' cuadro de mensaje con el mensaje de error.
    Public Shared Sub EliminarCircuito(idCircuito As Integer)
        Try
            AgenteBD.ObtenerAgente.Modificar("delete from clasificacion_carrera where edicion in (select idEdicion from edicion where circuito=" + idCircuito.ToString + ")")
            AgenteBD.ObtenerAgente.Modificar("delete from circuito where idCircuito= " & idCircuito)
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la eliminación")
        End Try
    End Sub

End Class

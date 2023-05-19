Imports MySql.Data.MySqlClient

Public Class PaisDAO
    ' Esta función recupera todos los países de la base de datos y los devuelve como una lista de
    ' objetos `Pais`. Primero crea una lista vacía de objetos `Pais`, luego usa un bucle `For Each`
    ' para iterar a través de los resultados de una consulta SQL que selecciona todas las columnas de
    ' la tabla `pais`. Para cada fila devuelta por la consulta, crea un nuevo objeto `Pais` con las
    ' propiedades `IdPais` y `Nombre` establecidas en los valores de la segunda y tercera columna,
    ' respectivamente. Luego agrega este objeto a la lista de objetos `Pais`. Si hay un error al
    ' ejecutar la consulta, muestra un mensaje de error. Finalmente, devuelve la lista de objetos
    ' `Pais`.
    Public Shared Function ObtenerTodosPaises() As List(Of Pais)
        Dim paises As New List(Of Pais)
        Try
            For Each pais In AgenteBD.ObtenerAgente.Leer("select * from pais")
                paises.Add(New Pais With {
                .IdPais = pais(1).ToString,
                .Nombre = pais(2).ToString
                       })
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return paises
    End Function

   ' Este es un método que inserta un nuevo objeto `Pais` en la base de datos.
   ' Toma un objeto `Pais` como parámetro y usa sus propiedades `IdPais` y `Nombre` para construir una
   ' declaración SQL `INSERT` que agrega una nueva fila a la tabla `pais` con los valores
   ' correspondientes. Si hay un error al ejecutar la instrucción SQL, muestra un mensaje de error.
    Public Shared Sub InsertarPais(pais As Pais)
        Try
            AgenteBD.ObtenerAgente.Modificar("insert into pais values('" & pais.IdPais & "', '" & pais.Nombre & "')")
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la inserción")
        End Try
    End Sub

    ' Este es un método que actualiza un objeto `Pais` existente en la base de
    ' datos. Toma un objeto `Pais` como parámetro y usa sus propiedades `IdPais` y `Nombre` para
    ' construir una declaración SQL `UPDATE` que modifica la fila correspondiente en la tabla `pais`
    ' con los nuevos valores. Si hay un error al ejecutar la instrucción SQL, muestra un mensaje de
    ' error.
    Public Shared Sub EditarPais(pais As Pais)
        Try
            AgenteBD.ObtenerAgente.Modificar("update pais set nombre='" & pais.Nombre & "' where idPais= '" & pais.IdPais & "'")
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la edición")
        End Try
    End Sub
    ' Esta función comprueba si hay pilotos en la base de datos que pertenecen a un país específico
    ' identificado por el parámetro `idPais`. Lo hace ejecutando una consulta SQL que selecciona todas
    ' las filas de la tabla `piloto` donde la columna `pais` coincide con el parámetro `idPais`. Si la
    ' consulta devuelve filas, la función devuelve `Verdadero`, lo que indica que hay pilotos de ese
    ' país en la base de datos. De lo contrario, devuelve `Falso`.
    Public Shared Function obtenerPilotosPais(idPais As String) As Boolean
        Return AgenteBD.ObtenerAgente.Leer("select * from piloto where pais='" + idPais + "'").Count > 0
    End Function
    ' El método elimina un país de la base de datos. Toma un parámetro `String`
    ' `idPais` que es el ID del país a eliminar. El método primero borra todas las entradas en la
    ' tabla `inscripcion_mundial` donde la columna `piloto` coincide con la columna `idpiloto` en la
    ' tabla `piloto` donde la columna `pais` coincide con el parámetro `idPais`. Luego borra todas las
    ' entradas en la tabla `clasificacion_carrera` donde la columna `piloto` coincide con la columna
    ' `idpiloto` en la tabla `piloto` donde la columna `pais` coincide con el parámetro `idPais`.
    ' Después de eso, borra todas las entradas en la tabla `piloto` donde la columna `pais` coincide
    ' con el parámetro `idPais`. Finalmente, elimina la entrada en la tabla `pais` donde la columna
    ' `idPais` coincide con el parámetro `idPais`. Si hay un error al ejecutar cualquiera de las
    ' sentencias SQL, muestra un mensaje de error.
    Public Shared Sub EliminarPais(idPais As String)
        Try
            AgenteBD.ObtenerAgente.Modificar("delete from inscripcion_mundial where piloto in (select idpiloto from piloto where pais='" + idPais + "')")
            AgenteBD.ObtenerAgente.Modificar("delete from clasificacion_carrera where piloto in (select idpiloto from piloto where pais='" + idPais + "')")
            AgenteBD.ObtenerAgente.Modificar("delete from piloto where pais= '" + idPais + "'")
            AgenteBD.ObtenerAgente.Modificar("delete from pais where idPais= '" & idPais & "'")
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la eliminación")
        End Try
    End Sub
End Class

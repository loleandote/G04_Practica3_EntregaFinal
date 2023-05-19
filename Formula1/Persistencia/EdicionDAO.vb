Imports Formula1.EntidadesAuxiliares
Imports MySql.Data.MySqlClient

Public Class EdicionDAO
   ' Esta función verifica si hay ediciones de un Gran Premio específico consultando la tabla de la
   ' base de datos "edición" con el idGranPremio dado. Devuelve un valor booleano que indica si hay
   ' ediciones o no.
    Public Shared Function ObtenterEdicionesGranPremio(idGranPremio As Integer) As Boolean
        Return AgenteBD.ObtenerAgente.Leer("select * from edicion where idgran_premio=" + idGranPremio.ToString).Count > 0
    End Function
    ' Esta función recupera una lista de ediciones para un Gran Premio específico de la tabla
    ' "edición" en la base de datos. Toma un parámetro entero "idGranPremio" que se usa en la consulta
    ' SQL para filtrar los resultados. La función crea una nueva lista de objetos "ClaveValor", que
    ' tienen una propiedad "Clave" (clave) y "Valor" (valor). Luego recorre los resultados de la
    ' consulta SQL y agrega un nuevo objeto "ClaveValor" a la lista para cada edición encontrada, con
    ' la propiedad "Clave" establecida en el nombre de la edición y la propiedad "Valor" establecida
    ' en el ID de la edición. Si hay un error en la consulta SQL, se muestra un cuadro de mensaje con
    ' el mensaje de error. Finalmente, la función devuelve la lista de ediciones.
    Public Shared Function obtenerEdicionesGranPremio(idGranPremio As Integer) As List(Of ClaveValor)
        Dim ediciones As New List(Of ClaveValor)
        Try
            For Each edicion In AgenteBD.ObtenerAgente.Leer("select idEDICION, NOMBRE from edicion where idgran_premio=" + idGranPremio.ToString)
                ediciones.Add(New ClaveValor() With {
                          .Clave = edicion(1),
                           .Valor = edicion(2)
                          })
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return ediciones
    End Function

   ' La función inserta un nuevo registro en la tabla `edición` en la base
   ' de datos. Toma como parámetro un objeto de tipo `Edicion`, que contiene los datos a insertar. La
   ' función primero recupera el número actual de registros en la tabla `edición` y lo usa para
   ' generar una nueva ID para el nuevo registro. Luego construye una instrucción SQL INSERT usando
   ' los datos del objeto `Edicion` y la ejecuta usando el objeto `AgenteBD`. Si hay un error durante
   ' la inserción, se muestra un cuadro de mensaje con el mensaje de error. La función devuelve el ID
   ' del registro recién insertado.
    Public Shared Function InsertarEdicion(edicion As Edicion) As Integer
        Dim id = AgenteBD.ObtenerAgente.Leer("select * from edicion").Count

        Try
            If id > 0 Then
                For Each ediciones In AgenteBD.ObtenerAgente.Leer("select max(idEdicion) from edicion")
                    id = Integer.Parse(ediciones(1).ToString) + 1
                Next
            Else
                id = 1
            End If
            AgenteBD.ObtenerAgente.Modificar("INSERT INTO edicion VALUES (" & id & ", " & edicion.GranPremio.idGranPremio & ", '" & edicion.Nombre & "', " & edicion.Circuito.IdCircuito & ", '" + edicion.Fecha.ToString("yyyy-MM-dd") + "', " & edicion.Año & ", " & edicion.Piloto_VR.IdPiloto & ")")
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la inserción")
        End Try
        Return id
    End Function

    ' La función recupera una lista de años distintos de la tabla `edición` en
    ' la base de datos. Crea una nueva lista de enteros y luego ejecuta una consulta SQL para
    ' seleccionar distintos años de la tabla `edición`. Luego recorre los resultados de la consulta y
    ' agrega cada año a la lista. Si hay un error durante la consulta, se muestra un cuadro de mensaje
    ' con el mensaje de error. Finalmente, la función devuelve la lista de años.
    Public Shared Function ObtenerAños() As List(Of Integer)
        Dim años As New List(Of Integer)
        Try
            For Each edicion In AgenteBD.ObtenerAgente.Leer("select distinct(anio) from edicion")

                años.Add(edicion(1))
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return años
    End Function

    ' La función borra todas las ediciones de un Gran Premio
    ' específico de la base de datos. Toma un parámetro entero `idGranPremio` que se usa en las
    ' consultas SQL para filtrar los resultados. La función primero elimina todos los registros de la
    ' tabla `clasificacion_carrera` que tienen un valor de `edición` que coincide con la `idEdicion`
    ' de cualquier edición del Gran Premio especificado. Luego borra todos los registros de la tabla
    ' `edición` que tienen un valor `idgran_premio` que coincide con el Gran Premio especificado. Si
    ' hay un error durante la eliminación, se muestra un cuadro de mensaje con el mensaje de error. La
    ' función no devuelve ningún valor.
    Public Shared Sub eliminarEdicionesGranPremio(idGranPremio As Integer)
        Try
            AgenteBD.ObtenerAgente.Modificar("delete from clasificacion_carrera where edicion in (select idEdicion from edicion where idgran_premio=" + idGranPremio.ToString + ")")
            AgenteBD.ObtenerAgente.Modificar("delete from clasificacion_carrera where edicion in (select idEdicion from edicion where idgran_premio=" + idGranPremio.ToString + ")")
            AgenteBD.ObtenerAgente.Modificar("delete from edicion where idgran_premio=" + idGranPremio.ToString)
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la eliminación")
        End Try
    End Sub
End Class

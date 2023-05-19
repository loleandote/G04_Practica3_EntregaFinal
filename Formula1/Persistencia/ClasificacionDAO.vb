Imports MySql.Data.MySqlClient

Public Class ClasificacionDAO
    Public Shared puntos As New List(Of Integer) From {25, 18, 15, 12, 10, 8, 6, 4, 2, 1}
   ' Esta función recupera una lista de objetos `ClasificacionEdicionPiloto` basada en los parámetros
   ' `idGranPremio` e `idPiloto`. Utiliza una consulta SQL para unir las tablas
   ' `clasificacion_carrera`, `piloto` y `edition` y recuperar los campos `nombre`, `posicion` y
   ' `piloto_vr`. Luego crea un nuevo objeto 'PilotEditionClassification' para cada fila devuelta por
   ' la consulta, establece sus propiedades 'Edición' y 'Posición', calcula su 'Puntuación' en función
   ' de su posición y si tiene el valor 'piloto_vr', y lo agrega. a la lista de `clasificaciones`.
   ' Finalmente, devuelve la lista de objetos `ClasificacionEdicionPiloto`.
    Public Shared Function ObtenerClasificacionesPiloto(idGranPremio As Integer, idPiloto As Integer) As List(Of ClasificacionEdicionPiloto)
        Dim clasificaciones As New List(Of ClasificacionEdicionPiloto)
        Try
            For Each clasificacion In AgenteBD.ObtenerAgente.Leer("select edicion.nombre,clasificacion_carrera.posicion, edicion.piloto_vr from clasificacion_carrera join piloto on piloto.idPiloto = clasificacion_carrera.piloto join edicion on clasificacion_carrera.edicion = edicion.idedicion where" +
                                        " edicion.idgran_premio=" + idGranPremio.ToString + " and piloto.idpiloto=" + idPiloto.ToString)
                Dim clasif As New ClasificacionEdicionPiloto With {.Edicion = clasificacion(1), .Posicion = clasificacion(2)}
                If clasif.Posicion <= puntos.Count Then
                    clasif.Puntuacion = puntos.Item(clasif.Posicion - 1)
                    If idPiloto = Integer.Parse(clasificacion(3).ToString) Then
                        clasif.Puntuacion += 1
                    End If
                End If
                clasificaciones.Add(clasif)

            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return clasificaciones
    End Function

    ' La función recupera una lista de objetos
    ' `ClasificacionGranPremioPiloto` en función de los parámetros `año` y `idPiloto`. Utiliza una consulta
    ' SQL para unir las tablas `clasificacion_carrera`, `piloto`, `edicion` y `gran_premio` y recuperar
    ' los campos `nombre`, `posicion` y `piloto_vr`. Luego crea un nuevo objeto `ClasificacionGranPremioPiloto
    ' Classification` para cada fila devuelta por la consulta, establece sus propiedades `GranPremio`
    ' y `Posicion`, calcula su `Puntuacion` en función de su posición y si tiene el valor `piloto_vr`, y
    ' agrega a la lista de `clasificaciones`. Finalmente, devuelve la lista de objetos `Clasificación
    ' Gran Premio Piloto`.
    Public Shared Function ObtenerClasificacionesGranPremioPiloto(año As Integer, idPiloto As Integer) As List(Of ClasificacionGranPremioPiloto)
        Dim clasificaciones As New List(Of ClasificacionGranPremioPiloto)
        Try
            For Each clasificacion In AgenteBD.ObtenerAgente.Leer("select gran_premio.nombre,clasificacion_carrera.posicion, edicion.piloto_vr from clasificacion_carrera join piloto on piloto.idPiloto = clasificacion_carrera.piloto join edicion on clasificacion_carrera.edicion = edicion.idedicion " +
                    "join gran_premio on gran_premio.idgran_premio= edicion.idgran_premio where edicion.anio=" + año.ToString + " and piloto.idpiloto=" + idPiloto.ToString)
                Dim clasif As New ClasificacionGranPremioPiloto With {.GranPremio = clasificacion(1), .Posicion = clasificacion(2)}
                If clasif.Posicion <= puntos.Count Then
                    clasif.Puntuacion = puntos.Item(clasif.Posicion - 1)
                    If idPiloto = Integer.Parse(clasificacion(3).ToString) Then
                        clasif.Puntuacion += 1
                    End If
                End If
                If idPiloto = Integer.Parse(clasificacion(3).ToString) Then
                    clasif.VueltaRapida = "Si"
                Else
                    clasif.VueltaRapida = "No"
                End If
                clasificaciones.Add(clasif)
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return clasificaciones
    End Function
   ' La función inserta un nuevo registro en la tabla
   ' `clasificacion_carrera` con los valores de `IdEdicion`, `IdPiloto` y `Posicion` del objeto
   ' `Clasificacion` pasado como parámetro. Utiliza la clase `AgenteBD` para ejecutar una sentencia
   ' SQL `INSERT`. Si ocurre una excepción, muestra un mensaje de error en un cuadro de mensaje.
    Public Shared Sub InsertarClasificacion(clasificacion As Clasificacion)
        Try
            AgenteBD.ObtenerAgente.Modificar("insert into clasificacion_carrera values(" & clasificacion.Edicion.IdEdicion & ", " & clasificacion.Piloto.IdPiloto & ", " & clasificacion.Posicion & ")")
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la insercion")
        End Try
    End Sub
End Class

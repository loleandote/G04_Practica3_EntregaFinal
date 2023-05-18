Imports MySql.Data.MySqlClient

Public Class ClasificacionDAO
    Public Shared puntos As New List(Of Integer) From {25, 18, 15, 12, 10, 8, 6, 4, 2, 1}
    Public Shared Function ObtenerTodasClasificaciones() As List(Of Clasificacion)
        Dim clasificaciones As New List(Of Clasificacion)
        Return clasificaciones
    End Function
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
    Public Shared Sub InsertarClasificacion(clasificacion As Clasificacion)
        Try
            AgenteBD.ObtenerAgente.Modificar("insert into clasificacion_carrera values(" & clasificacion.Edicion.IdEdicion & ", " & clasificacion.Piloto.IdPiloto & ", " & clasificacion.Posicion & ")")
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la insercion")
        End Try
    End Sub
End Class

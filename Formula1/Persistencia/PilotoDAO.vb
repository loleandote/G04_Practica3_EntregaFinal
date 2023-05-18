Imports Formula1.EntidadesAuxiliares
Imports MySql.Data.MySqlClient

Public Class PilotoDAO
    Public Shared Function ObtenerTodosPilotos() As List(Of Piloto)
        Dim pilotos As New List(Of Piloto)
        Try
            For Each piloto In AgenteBD.ObtenerAgente.Leer("select * from piloto join pais on piloto.pais= pais.idpais")

                Dim pilot As New Piloto With {
                .IdPiloto = piloto(1).ToString,
                .Pais = New Pais() With {
                    .IdPais = piloto(5).ToString,
                    .Nombre = piloto(6).ToString
                }
                }
                If Not piloto(2).ToString.Equals("") Then
                    pilot.Nombre = piloto(2).ToString
                End If
                Try
                    If Not piloto(3).ToString.Equals("") Then
                        pilot.FechaNacimiento = Convert.ToDateTime(piloto(3).ToString)
                    End If
                Catch ex As Exception
                End Try
                pilotos.Add(pilot)
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return pilotos
    End Function

    Public Shared Function ObtenerTodosPilotosClaveValor() As List(Of ClaveValor)
        Dim pilotos As New List(Of ClaveValor)
        Try
            For Each piloto In AgenteBD.ObtenerAgente.Leer("select * from piloto join pais on piloto.pais= pais.idpais")

                pilotos.Add(New ClaveValor With {
                .Clave = piloto(1).ToString,
                .Valor = piloto(2).ToString
                })
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return pilotos
    End Function

    Public Shared Function obtenerPilotosEdicion(temporada As Integer) As List(Of Piloto)
        Dim pilotos As New List(Of Piloto)
        Try
            For Each piloto In AgenteBD.ObtenerAgente.Leer("select * from piloto join pais on piloto.pais= pais.idpais join inscripcion_mundial on inscripcion_mundial.piloto= piloto.idPiloto where inscripcion_mundial.temporada=" & temporada)
                pilotos.Add(New Piloto With {
                .IdPiloto = Integer.Parse(piloto(1).ToString),
                .Nombre = piloto(2).ToString,
                .FechaNacimiento = Convert.ToDateTime(piloto(3)),
                .Pais = New Pais() With {
                    .IdPais = piloto(5).ToString,
                    .Nombre = piloto(6).ToString
                }
            })
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return pilotos
    End Function

    Public Shared Function obtenerAñosParticipación(idPiloto As Integer) As List(Of Integer)
        Dim años As New List(Of Integer)
        Try
            For Each año In AgenteBD.ObtenerAgente.Leer("select temporada from inscripcion_mundial where piloto=" + idPiloto.ToString)
                años.Add(Integer.Parse(año(1).ToString))
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return años
    End Function

    Public Shared Function obtenerParticipantes(idEdicion As Integer) As List(Of PilotoReporte)
        Dim participantes As New List(Of PilotoReporte)
        Try
            Dim idPilotoRapido As Integer = Integer.Parse(AgenteBD.ObtenerAgente.Leer("select piloto_vr from edicion where idEdicion= " + idEdicion.ToString).Item(1).item(1).ToString)
            For Each piloto In AgenteBD.ObtenerAgente.Leer("select piloto.nombre, pais.nombre, clasificacion_carrera.posicion, piloto.idpiloto from piloto join pais on piloto.pais= pais.idpais join clasificacion_carrera on piloto.idPiloto= clasificacion_carrera.piloto where clasificacion_carrera.edicion= " + idEdicion.ToString)
                Dim participante = New PilotoReporte With {
                    .Nombre = piloto(1).ToString,
                    .Pais = piloto(2).ToString,
                    .Posicion = Integer.Parse(piloto(3).ToString)
                                 }
                If participante.Posicion <= ClasificacionDAO.puntos.Count Then
                    participante.Puntos = ClasificacionDAO.puntos(participante.Posicion - 1)
                    If Integer.Parse(piloto(4).ToString) = idPilotoRapido Then
                        participante.Puntos += 1
                    End If
                End If
                participantes.Add(participante)
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return participantes
    End Function

    Public Shared Function obtenerParticipantesTemporada(año As Integer) As List(Of ClaveValor)
        Dim participantes As New List(Of ClaveValor)
        Try
            For Each piloto In AgenteBD.ObtenerAgente.Leer("select distinct(inscripcion_mundial.piloto), nombre from piloto join inscripcion_mundial on inscripcion_mundial.piloto= piloto.idpiloto where inscripcion_mundial.temporada=" & año.ToString)
                Dim puntos = 0
                For Each punto In AgenteBD.ObtenerAgente.Leer("select posicion ,edicion.piloto_vr from clasificacion_carrera join edicion on edicion.idedicion= clasificacion_carrera.edicion where edicion.anio=" + año.ToString + " and clasificacion_carrera.piloto=" + piloto(1))
                    puntos += punto(1)
                    If Integer.Parse(punto(2).ToString) = piloto(1) Then
                        puntos += 1
                    End If

                Next
                participantes.Add(New ClaveValor With {.Valor = piloto(2), .Clave = puntos})
            Next
            participantes = participantes.OrderByDescending(Function(x) x.Clave).ToList
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return participantes
    End Function
    Public Shared Sub InsertarPiloto(piloto As Piloto)
        Try
            Dim id = ObtenerTodosPilotos.Count
            If id > 0 Then
                AgenteBD.ObtenerAgente.Modificar("insert into piloto values((select max(idPiloto) from piloto e)+1, '" + piloto.Nombre + "', '" + piloto.FechaNacimiento.Value.ToString("yyyy-MM-dd") + "', '" + piloto.Pais.IdPais + "')")
            Else
                AgenteBD.ObtenerAgente.Modificar("insert into piloto values(" & 1 & ", '" + piloto.Nombre + "', '" + piloto.FechaNacimiento.Value.ToString("yyyy-MM-dd") + "', '" + piloto.Pais.IdPais + "')")

            End If
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la inserción")
        End Try
    End Sub

    Public Shared Sub EditarPiloto(piloto As Piloto)
        Try
            AgenteBD.ObtenerAgente.Modificar("update piloto set nombre='" + piloto.Nombre + "', fecha_nacimiento='" + piloto.FechaNacimiento.Value.ToString("yyyy-MM-dd") + "', pais='" + piloto.Pais.IdPais + "' where idpiloto='" + piloto.IdPiloto.ToString & "'")
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la edición")
        End Try
    End Sub

    Public Shared Function obtenerParticipacionesPiloto(idPiloto As Integer) As Boolean
        Return AgenteBD.ObtenerAgente.Leer("select * from inscripcion_mundial where piloto=" + idPiloto.ToString).Count > 0
    End Function
    Public Shared Sub EliminarPiloto(idPiloto As Integer)
        Try
            AgenteBD.ObtenerAgente.Modificar("delete from inscripcion_mundial where piloto=" + idPiloto.ToString)
            AgenteBD.ObtenerAgente.Modificar("delete from clasificacion_carrera where piloto=" + idPiloto.ToString)
            AgenteBD.ObtenerAgente.Modificar("delete from piloto where idpiloto=" + idPiloto.ToString)
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la eliminación")
        End Try
    End Sub
End Class

Imports Formula1.EntidadesAuxiliares
Imports MySql.Data.MySqlClient

Public Class EdicionDAO
    Public Shared Function ObtenterTodasEdiciones() As List(Of Edicion)
        Dim ediciones As New List(Of Edicion)
        Return ediciones
    End Function
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
End Class

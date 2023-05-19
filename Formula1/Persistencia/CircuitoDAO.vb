Imports Formula1.EntidadesAuxiliares
Imports MySql.Data.MySqlClient

Public Class CircuitoDAO
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

    Public Shared Sub EditarCircuito(circuito As Circuito)
        Try
            AgenteBD.ObtenerAgente.Modificar("update circuito set nombre='" & circuito.Nombre & "', ciudad='" & circuito.Ciudad & "', pais='" & circuito.Pais.IdPais & "', longitud=" & circuito.Longitud & ", curvas=" & circuito.Curvas & " where idCircuito='" & circuito.IdCircuito & "'")
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la edición")
        End Try
    End Sub

    Public Shared Function obtenerEdicionesCircuito(idCircuito As Integer) As Boolean
        Return AgenteBD.ObtenerAgente.Leer("select * from ediciones where circuito= " + idCircuito.ToString).Count > 0
    End Function
    Public Shared Sub EliminarCircuito(idCircuito As Integer)
        Try
            AgenteBD.ObtenerAgente.Modificar("delete from clasificacion_carrera where edicion in (select idEdicion from edicion where circuito=" + idCircuito.ToString + ")")
            AgenteBD.ObtenerAgente.Modificar("delete from circuito where idCircuito= " & idCircuito)
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la eliminación")
        End Try
    End Sub

End Class

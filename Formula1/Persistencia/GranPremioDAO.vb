Imports System.Data.SqlClient
Imports Formula1.EntidadesAuxiliares
Imports MySql.Data.MySqlClient

Public Class GranPremioDAO
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

    Public Shared Sub EditarGranPremio(granPremio As GranPremio)
        Try
            AgenteBD.ObtenerAgente.Modificar("update gran_premio set PAIS='" & granPremio.Pais.IdPais & "', NOMBRE='" & granPremio.Nombre & "' where 'idGRAN_PREMIO'='" & granPremio.idGranPremio & "'")

        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la insercion")
        End Try
    End Sub

    Public Shared Sub EliminarGranPremio(idGranPremio As Integer)
        Try
            AgenteBD.ObtenerAgente.Modificar("delete from gran_premio where idGRAN_PREMIO= " & idGranPremio)
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la eliminación")
        End Try
    End Sub
End Class

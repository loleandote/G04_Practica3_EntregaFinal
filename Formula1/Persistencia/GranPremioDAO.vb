Public Class GranPremioDAO
    Public Shared Function ObtenerTodosGranPremio() As List(Of GranPremio)
        Dim GrandesPremios As New List(Of GranPremio)
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
        Return GrandesPremios
    End Function

    Public Shared Sub InsertarGranPremio(granPremio As GranPremio)

    End Sub

    Public Shared Sub EditarGranPremio(granPremio As GranPremio)

    End Sub

    Public Shared Sub EliminarGranPremio(idGranPremio As Integer)

    End Sub
End Class

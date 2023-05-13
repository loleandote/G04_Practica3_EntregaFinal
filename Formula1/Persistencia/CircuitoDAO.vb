Imports Formula1.EntidadesAuxiliares

Public Class CircuitoDAO
    Public Shared Function ObtenerTodosCircuitos() As List(Of Circuito)
        Dim circuitos As New List(Of Circuito)
        For Each circuito In AgenteBD.ObtenerAgente.Leer("select * from circuito join pais on circuito.pais= pais.idpais")
            circuitos.Add(New Circuito(circuito(1).ToString, circuito(2).ToString, circuito(3).ToString, Integer.Parse(circuito(5).ToString), Integer.Parse(circuito(6).ToString), circuito(7).ToString, circuito(8).ToString))
        Next
        Return circuitos
    End Function

    Public Shared Function ObtenerTodosCircuitosPaisClaveValor(idPais As String) As List(Of ClaveValor)
        Dim circuitos As New List(Of ClaveValor)
        For Each circuito In AgenteBD.ObtenerAgente.Leer("select idCIRCUITO, circuito.nombre from circuito join pais on circuito.pais= pais.idpais where pais.idpais='" & idPais & "'")
            circuitos.Add(New ClaveValor() With {.Clave = Integer.Parse(circuito(1).ToString), .Valor = circuito(2).ToString})
        Next
        Return circuitos
    End Function

    Public Shared Sub InsertarCircuito(circuito As Circuito)

    End Sub

    Public Shared Sub EditarCircuito(circuito As Circuito)

    End Sub

    Public Shared Sub EliminarCircuito(idCircuito As Integer)

    End Sub

End Class

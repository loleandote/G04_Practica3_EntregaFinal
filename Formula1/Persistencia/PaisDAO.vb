Public Class PaisDAO
    Public Shared Function ObtenerTodosPaises() As List(Of Pais)
        Dim paises As New List(Of Pais)
        For Each pais In AgenteBD.ObtenerAgente.Leer("select * from pais")
            paises.Add(New Pais With {
                .IdPais = pais(1).ToString,
                .Nombre = pais(2).ToString
                       })
        Next
        Return paises
    End Function

    Public Shared Sub InsertarPais(pais As Pais)

    End Sub

    Public Shared Sub EditarPais(pais As Pais)

    End Sub

    Public Shared Sub EliminarPais(pais As Pais)

    End Sub
End Class

Public Class PilotoDAO
    Public Shared Function ObtenerTodosPilotos() As List(Of Piloto)
        Dim pilotos As New List(Of Piloto)
        For Each piloto In AgenteBD.ObtenerAgente.Leer("select * from piloto join pais on piloto.pais= pais.idpais")
            pilotos.Add(New Piloto With {
                .IdPiloto = piloto(1).ToString,
                .Nombre = piloto(2).ToString,
                .FechaNacimiento = piloto(3),
                .Pais = New Pais() With {
                .IdPais = piloto(5).ToString,
                .Nombre = piloto(6).ToString
                }
                       })
        Next
        Return pilotos
    End Function

    Public Shared Sub InsertarPiloto(piloto As Piloto)

        For Each id In AgenteBD.ObtenerAgente.Leer("select count(*) from piloto").Item(1)
            piloto.IdPiloto = Integer.Parse(id.ToString) + 1
        Next
        AgenteBD.ObtenerAgente.Modificar("insert into piloto (idpiloto, nombre, fecha_nacimiento, pais) values(" + piloto.IdPiloto.ToString + ", '" + piloto.Nombre + "', '" + piloto.FechaNacimiento.ToString("yyyy-MM-dd") + "', '" + piloto.Pais.IdPais + "')")
    End Sub

    Public Shared Sub EditarPiloto(piloto As Piloto)
        AgenteBD.ObtenerAgente.Modificar("update piloto set nombre='" + piloto.Nombre + "', fecha_nacimiento='" + piloto.FechaNacimiento.ToString("yyyy-MM-dd") + "', pais='" + piloto.Pais.IdPais + "' where idpiloto=" + piloto.IdPiloto.ToString)
    End Sub

    Public Shared Sub EliminarPiloto(idPiloto As Integer)
        AgenteBD.ObtenerAgente.Modificar("delete from piloto where idpiloto=" + idPiloto.ToString)
    End Sub
End Class

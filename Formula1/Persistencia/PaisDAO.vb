Imports MySql.Data.MySqlClient

Public Class PaisDAO
    Public Shared Function ObtenerTodosPaises() As List(Of Pais)
        Dim paises As New List(Of Pais)
        Try
            For Each pais In AgenteBD.ObtenerAgente.Leer("select * from pais")
                paises.Add(New Pais With {
                .IdPais = pais(1).ToString,
                .Nombre = pais(2).ToString
                       })
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return paises
    End Function

    Public Shared Sub InsertarPais(pais As Pais)
        Try
            AgenteBD.ObtenerAgente.Modificar("insert into pais values('" & pais.IdPais & "', '" & pais.Nombre & "')")
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la inserción")
        End Try
    End Sub

    Public Shared Sub EditarPais(pais As Pais)
        Try
            AgenteBD.ObtenerAgente.Modificar("update pais set nombre='" & pais.Nombre & "' where idPais= '" & pais.IdPais & "'")
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la edición")
        End Try
    End Sub

    Public Shared Sub EliminarPais(idPais As String)
        Try
            AgenteBD.ObtenerAgente.Modificar("delete from pais where idPais= '" & idPais & "'")
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la eliminación")
        End Try
    End Sub
End Class

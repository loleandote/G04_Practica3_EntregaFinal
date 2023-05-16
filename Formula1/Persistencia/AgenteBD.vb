
Imports System.Data

Public Class AgenteBD

    Private Shared _instancia As AgenteBD
    Private Shared conexion As MySql.Data.MySqlClient.MySqlConnection
    Private Const cadenaConexion As String = "server=localhost;database=mydb;uid=root;pwd=root"

    Private Sub New()
        AgenteBD.conexion = New MySql.Data.MySqlClient.MySqlConnection(AgenteBD.cadenaConexion)
    End Sub

    Public Shared Function ObtenerAgente() As AgenteBD
        If AgenteBD._instancia Is Nothing Then
            AgenteBD._instancia = New AgenteBD
        End If
        Return AgenteBD._instancia
    End Function

    Public Function Leer(sql As String) As Collection
        Dim result As New Collection
        Try
            Dim fila As Collection
            Dim i As Integer
            Dim reader As MySql.Data.MySqlClient.MySqlDataReader
            Dim com As New MySql.Data.MySqlClient.MySqlCommand(sql, AgenteBD.conexion)
            Conectar()
            reader = com.ExecuteReader
            While reader.Read
                fila = New Collection
                For i = 0 To reader.FieldCount - 1
                    fila.Add(reader(i).ToString)
                Next
                result.Add(fila)
            End While
        Catch ex As Exception
            Throw
            Return result
        Finally
            Desconectar()
        End Try
        Return result
    End Function

    Public Function Modificar(sql As String) As Integer
        Dim result As Integer
        Try
            Dim com As New MySql.Data.MySqlClient.MySqlCommand(sql, AgenteBD.conexion)

            Conectar()
            result = com.ExecuteNonQuery
            Return result
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return -1
        Finally
            Desconectar()
        End Try
    End Function

    Private Sub Conectar()
        If AgenteBD.conexion.State = ConnectionState.Closed Then
            AgenteBD.conexion.Open()
        End If
    End Sub

    Private Sub Desconectar()
        If AgenteBD.conexion.State = ConnectionState.Open Then
            AgenteBD.conexion.Close()
        End If
    End Sub

End Class

Public Class Circuito
    Public Sub New()

    End Sub
    Public Sub New(IdCircuito As Integer, Nombre As String, Ciudad As String, Longitud As Integer, Curvas As Integer, idPais As String, nombrePais As String)
        Me.IdCircuito = IdCircuito
        Me.Nombre = Nombre
        Me.Ciudad = Ciudad
        Pais = New Pais() With {.IdPais = idPais, .Nombre = nombrePais}
        Me.Longitud = Longitud
        Me.Curvas = Curvas
    End Sub
    Public Property IdCircuito As Integer
    Public Property Nombre As String
    Public Property Ciudad As String
    Public Property Pais As Pais
    Public Property Longitud As Integer
    Public Property Curvas As Integer
End Class

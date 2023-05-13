Public Class ClasificacionDAO
    Public Shared Function ObtenerTodasClasificaciones() As List(Of Clasificacion)
        Dim clasificaciones As New List(Of Clasificacion)
        Return clasificaciones
    End Function
    Public Shared Function ObtenerClasificacionesPiloto(idPiloto As Integer) As List(Of ClasificacionPiloto)
        Dim clasificaciones As New List(Of ClasificacionPiloto)
        Return clasificaciones
    End Function
End Class

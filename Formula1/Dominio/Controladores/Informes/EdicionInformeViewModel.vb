Imports Formula1.EntidadesAuxiliares

Public Class EdicionInformeViewModel
    Public Sub New(edicion As ClaveValor)
        Titulo = "Estadisticas de " + edicion.Valor
        Participanes = PilotoDAO.obtenerParticipantes(edicion.Clave)
    End Sub
    Public Property Titulo As String
    Public Property Participanes As List(Of PilotoReporte)
End Class

Imports Formula1.EntidadesAuxiliares

Public Class TemporadaInformeViewModel
    Public Sub New(añoTemporada As Integer)
        Pilotos = PilotoDAO.obtenerParticipantesTemporada(añoTemporada)
    End Sub
    Public Property Pilotos As List(Of ClaveValor)
End Class

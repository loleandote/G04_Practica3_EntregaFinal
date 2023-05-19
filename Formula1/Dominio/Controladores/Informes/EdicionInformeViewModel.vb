Imports Formula1.EntidadesAuxiliares

Public Class EdicionInformeViewModel
    Public Sub New(edicion As ClaveValor)
        Titulo = "Estadisticas de " + edicion.Valor
        Circuito = CircuitoDAO.ObtenerCircuitoPorIdEdicion(edicion.Clave)
        Ubicacion = Circuito.Ciudad + " (" + Circuito.Pais.Nombre + ")"
        Participanes = PilotoDAO.obtenerParticipantes(edicion.Clave)
    End Sub
    Public Property Titulo As String
    Public Property Participanes As List(Of PilotoReporte)
    Public Property Circuito As Circuito
    Public Property Ubicacion As String
End Class

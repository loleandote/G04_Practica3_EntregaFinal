Imports Formula1.EntidadesAuxiliares

Public Class PilotoInformeViewModel
    Inherits ViewModelBase.ViewModelBase
    Private _GranPremioSeleccionado As ClaveValor
    Private _AñoSeleccionado As Integer
    Private pilotoSeleccionado As ClaveValor
    Private _ClasificacionesEdicion As List(Of ClasificacionEdicionPiloto)
    Private _ClasificacionesGranPremio As List(Of ClasificacionGranPremioPiloto)

    Public Sub New(pilotoSeleccionado As ClaveValor)
        Me.pilotoSeleccionado = pilotoSeleccionado
        Titulo = "Resultados de " + pilotoSeleccionado.Valor
        Años = PilotoDAO.obtenerAñosParticipación(pilotoSeleccionado.Clave)
        GrandesPremios = GranPremioDAO.obtenerGrandesPremiosPiloto(pilotoSeleccionado.Clave)
    End Sub
    Public Property Titulo As String
    Public Property GrandesPremios As List(Of ClaveValor)
    Public Property GranPremioSeleccionado As ClaveValor
        Get
            Return _GranPremioSeleccionado
        End Get
        Set
            _GranPremioSeleccionado = Value

            ClasificacionesEdicion = ClasificacionDAO.ObtenerClasificacionesPiloto(Value.Clave, pilotoSeleccionado.Clave)
            OnPropertyChanged("GranPremioSeleccionado")
        End Set
    End Property
    Public Property ClasificacionesEdicion As List(Of ClasificacionEdicionPiloto)
        Get
            Return _ClasificacionesEdicion
        End Get
        Set
            _ClasificacionesEdicion = Value
            OnPropertyChanged("ClasificacionesEdicion")
        End Set
    End Property

    Public Property ClasificacionesGranPremio As List(Of ClasificacionGranPremioPiloto)
        Get
            Return _ClasificacionesGranPremio
        End Get
        Set
            _ClasificacionesGranPremio = Value
            OnPropertyChanged("ClasificacionesGranPremio")
        End Set
    End Property

    Public Property Años As List(Of Integer)
    Public Property AñoSeleccionado As Integer
        Get
            Return _AñoSeleccionado
        End Get
        Set
            _AñoSeleccionado = Value
            ClasificacionesGranPremio = ClasificacionDAO.ObtenerClasificacionesGranPremioPiloto(AñoSeleccionado, pilotoSeleccionado.Clave)
            OnPropertyChanged("AñoSeleccionado")
        End Set
    End Property
End Class

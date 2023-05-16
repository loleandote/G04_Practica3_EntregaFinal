Imports Formula1.EntidadesAuxiliares
Imports Formula1.ViewModelBase

Public Class InformesViewModel
    Inherits ViewModelBase.ViewModelBase

    Private _GranPremioSeleccionado As ClaveValor
    Private _PilotoSeleccionado As ClaveValor
    Private _TemporadaSeleccionada As Integer
    Private _Ediciones As List(Of ClaveValor)
    Private _EdicionSeleccionada As ClaveValor

    Public Sub New()
        GrandesPremios = GranPremioDAO.ObtenerTodosGranPremioClaveValor

        Pilotos = PilotoDAO.ObtenerTodosPilotosClaveValor
        Temporadas = EdicionDAO.ObtenerAños
        VerParticipantesEdicionCommand = New DelegateCommand(AddressOf verParticipantesEdicion)
        VerPilotoCommand = New DelegateCommand(AddressOf verPiloto)
        VerGranPremioCommand = New DelegateCommand(AddressOf verGranPremio)
    End Sub

    Public Property GrandesPremios As List(Of ClaveValor)
    Public Property Pilotos As List(Of ClaveValor)
    Public Property Temporadas As List(Of Integer)

    Public Property GranPremioSeleccionado As ClaveValor
        Get
            Return _GranPremioSeleccionado
        End Get
        Set
            _GranPremioSeleccionado = Value
            EdicionSeleccionada = Nothing
            Ediciones = EdicionDAO.obtenerEdicionesGranPremio(Value.Clave)
            OnPropertyChanged("GranPremioSeleccionado")
        End Set
    End Property

    Public Property PilotoSeleccionado As ClaveValor
        Get
            Return _PilotoSeleccionado
        End Get
        Set
            _PilotoSeleccionado = Value
            OnPropertyChanged("PilotoSeleccionado")
        End Set
    End Property

    Public Property TemporadaSeleccionada As Integer
        Get
            Return _TemporadaSeleccionada
        End Get
        Set
            _TemporadaSeleccionada = Value
            OnPropertyChanged("TemporadaSeleccionada")
        End Set
    End Property

    Public Property Ediciones As List(Of ClaveValor)
        Get
            Return _Ediciones
        End Get
        Set
            _Ediciones = Value
            OnPropertyChanged("Ediciones")
        End Set
    End Property

    Public Property EdicionSeleccionada As ClaveValor
        Get
            Return _EdicionSeleccionada
        End Get
        Set
            _EdicionSeleccionada = Value
            OnPropertyChanged("EdicionSeleccionada")
        End Set
    End Property

    Public Property VerParticipantesEdicionCommand As ICommand
    Public Property VerPilotoCommand As ICommand
    Public Property VerGranPremioCommand As ICommand


    Private Sub verParticipantesEdicion()
        If EdicionSeleccionada IsNot Nothing Then
            Dim ventana As New EdicionInformeWindow With {
                .DataContext = New EdicionInformeViewModel(EdicionSeleccionada)
                }
            ventana.Show()
        Else
            MsgBox("Selecciona una edición de un gran premio")
        End If
    End Sub

    Private Sub verPiloto()
        If PilotoSeleccionado IsNot Nothing Then
            Dim ventana As New PilotoInformeWindow With {
                .DataContext = New PilotoInformeViewModel(PilotoSeleccionado)
                }
            ventana.Show()
        Else
            MsgBox("Selecciona un piloto")
        End If
    End Sub

    Private Sub verGranPremio()
        If Not TemporadaSeleccionada = 0 Then
            Dim ventana As New TemporadaInformeWindow With
             {
            .DataContext = New TemporadaInformeViewModel(TemporadaSeleccionada)
             }
            ventana.Show()
        Else
            MsgBox("Selecciona una temporada")
        End If
    End Sub
End Class

Imports Formula1.ViewModelBase

Public Class MainWindowViewModel
    Inherits ViewModelBase.ViewModelBase
    Private _Pantalla As Page

    Public Sub New()
        PilotosCommand = New DelegateCommand(AddressOf AbrirPilotos)
        PaisesCommand = New DelegateCommand(AddressOf AbrirPaises)
        PremiosCommand = New DelegateCommand(AddressOf AbrirPremios)
        CircuitosCommand = New DelegateCommand(AddressOf AbrirCircuitos)
        ClasificaciónCommand = New DelegateCommand(AddressOf AbrirClasificacion)
    End Sub

    Public Property Pantalla As Page
        Get
            Return _Pantalla
        End Get
        Set
            _Pantalla = Value
            OnPropertyChanged("Pantalla")
        End Set
    End Property

    Public Property PilotosCommand As ICommand
    Public Property PaisesCommand As ICommand
    Public Property PremiosCommand As ICommand
    Public Property CircuitosCommand As ICommand
    Public Property ClasificaciónCommand As ICommand


    Private Sub AbrirPilotos()
        Pantalla = New PilotosPage With {
            .DataContext = New PilotosViewModel.PilotosConsultaViewModel
        }
    End Sub
    Private Sub AbrirPaises()
        Pantalla = New PaisesPage With {
        .DataContext = New PaisesViewModel.PaisesConsultaViewModel
        }
    End Sub
    Private Sub AbrirPremios()
        Pantalla = New PremiosPage With {
            .DataContext = New PremiosViewModel.PremiosConsultaViewModel
        }
    End Sub
    Private Sub AbrirCircuitos()
        Pantalla = New CircuitosPage With {
            .DataContext = New CircuitosViewModel.CircuitosConsultaViewModel
        }
    End Sub
    Private Sub AbrirClasificacion()
        Pantalla = New ClasificacionPage With {
            .DataContext = New ClasificacionViewModel
        }
    End Sub
End Class

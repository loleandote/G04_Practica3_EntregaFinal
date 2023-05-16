Imports Formula1.ViewModelBase

Namespace PilotosViewModel
    Public Class PilotosConsultaViewModel
        Inherits ViewModelBase.ViewModelBase

        Private _Pilotos As List(Of Piloto)
        Private _PilotoSeleccionado As Piloto
        Private _PilotoFiltro As String
        Public PilotoEdicion As PilotosEdicionWindow
        Private TodosPilotos As List(Of Piloto)
        Private _PaisSeleccionado As Pais
        Private _Paises As List(Of Pais)

        Public Sub New()
            EditarPilotoCommand = New DelegateCommand(AddressOf EditarPiloto)
            CrearPilotoCommand = New DelegateCommand(AddressOf CrearPiloto)
            LimpiarCommand = New DelegateCommand(AddressOf LipiarPiloto)
            Dim paisesaux = New List(Of Pais) From {
                New Pais With {.IdPais = "", .Nombre = "Todos los paises"}
            }
            Try
                paisesaux.AddRange(PaisDAO.ObtenerTodosPaises)
                Paises = paisesaux
                _PaisSeleccionado = Paises.First

                CargarDatos()

            Catch ex As Exception

            End Try

        End Sub

        Public Property Paises As List(Of Pais)
            Get
                Return _Paises
            End Get
            Set
                _Paises = Value
                OnPropertyChanged("Paises")
            End Set
        End Property

        Public Property PaisSeleccionado As Pais
            Get
                Return _PaisSeleccionado
            End Get
            Set
                _PaisSeleccionado = Value
                Filtar()
                OnPropertyChanged("PaisSeleccionado")
            End Set
        End Property

        Public Property Pilotos As List(Of Piloto)
            Get
                Return _Pilotos
            End Get
            Set
                _Pilotos = Value
                OnPropertyChanged("Pilotos")
            End Set
        End Property

        Public Property PilotoSeleccionado As Piloto
            Get
                Return _PilotoSeleccionado
            End Get
            Set
                _PilotoSeleccionado = Value
                OnPropertyChanged("PilotoSeleccionado")
            End Set
        End Property

        Public Property PilotoFiltro As String
            Get
                Return _PilotoFiltro
            End Get
            Set
                _PilotoFiltro = Value
                Filtar()
                OnPropertyChanged("PilotoFiltro")
            End Set
        End Property

        Public Property EditarPilotoCommand As ICommand
        Public Property CrearPilotoCommand As ICommand
        Public Property LimpiarCommand As ICommand

        Public Sub CargarDatos()
            TodosPilotos = PilotoDAO.ObtenerTodosPilotos()
            Filtar()
        End Sub

        Private Sub Filtar()
            Dim pilotosaux As List(Of Piloto) = TodosPilotos
            If PilotoFiltro IsNot Nothing AndAlso Not PilotoFiltro.Equals("") Then
                pilotosaux = (From p In pilotosaux Select p Where p.Nombre.ToUpper.StartsWith(PilotoFiltro.ToUpper)).ToList
            End If
            If Not PaisSeleccionado.IdPais.Equals("") Then
                pilotosaux = (From p In pilotosaux Select p Where p.Pais.IdPais = PaisSeleccionado.IdPais).ToList
            End If
            Pilotos = pilotosaux
        End Sub

        Private Sub EditarPiloto()
            If PilotoEdicion Is Nothing Then
                crearVentana(PilotoSeleccionado)
            Else
                Try
                    PilotoEdicion.Show()
                    MsgBox("Ya tienes una ventana abierta")
                    PilotoEdicion.Focus()
                Catch ex As Exception
                    crearVentana(PilotoSeleccionado)
                End Try
            End If
        End Sub

        Private Sub CrearPiloto()
            If PilotoEdicion Is Nothing Then
                crearVentana(New Piloto)
            Else
                Try
                    PilotoEdicion.Show()
                    MsgBox("Ya tienes una ventana abierta")
                    PilotoEdicion.Focus()
                Catch ex As Exception
                    crearVentana(New Piloto)
                End Try
            End If
        End Sub

        Private Sub crearVentana(pilto As Piloto)
            PilotoEdicion = New PilotosEdicionWindow
            PilotoEdicion.DataContext = New PilotosEdicionViewModel(pilto, PilotoEdicion, Me)
            PilotoEdicion.Show()
        End Sub

        Private Sub LipiarPiloto()
            PilotoFiltro = ""
        End Sub
    End Class

    Public Class PilotosEdicionViewModel
        Inherits ViewModelBase.ViewModelBase
        Private piloto As Piloto
        Private view As PilotosEdicionWindow
        Private viewModel As PilotosConsultaViewModel
        Private _PaisSeleccionado As Pais

        Public Sub New(piloto As Piloto, view As PilotosEdicionWindow, viewModel As PilotosConsultaViewModel)
            Me.piloto = piloto
            Me.view = view
            Me.viewModel = viewModel
            Me.piloto = piloto
            Try
                Paises = PaisDAO.ObtenerTodosPaises
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            If piloto.IdPiloto = Nothing Then
                Titulo = "Crear piloto"
                FechaNacimiento = Date.Now
                VerCreacion = Visibility.Visible
                VerEdicion = Visibility.Collapsed
                GuardarPilotoCommand = New DelegateCommand(AddressOf CrearPiloto)
            Else
                Titulo = "Editar: " + piloto.Nombre
                Nombre = piloto.Nombre
                FechaNacimiento = piloto.FechaNacimiento
                'Comprobar con datos
                PaisSeleccionado = piloto.Pais
                Try
                    PaisSeleccionado = (From p In Paises Select p Where p.IdPais = piloto.Pais.IdPais).FirstOrDefault
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                VerCreacion = Visibility.Collapsed
                VerEdicion = Visibility.Visible
                GuardarPilotoCommand = New DelegateCommand(AddressOf GuardarPiltoto)
                EliminarPilotoCommand = New DelegateCommand(AddressOf EliminarPiloto)
            End If

        End Sub

        Public Property Titulo As String
        Public Property Nombre As String
        Public Property FechaNacimiento As Date
        Public Property VerEdicion As Visibility
        Public Property VerCreacion As Visibility

        Public Property Paises As List(Of Pais)

        Public Property PaisSeleccionado As Pais
            Get
                Return _PaisSeleccionado
            End Get
            Set
                _PaisSeleccionado = Value
                OnPropertyChanged("PaisSeleccionado")
            End Set
        End Property
        Public Property GuardarPilotoCommand As ICommand

        Public Property EliminarPilotoCommand As ICommand

        Private Sub GuardarPiltoto()
            piloto.Nombre = Nombre
            piloto.Pais = PaisSeleccionado
            piloto.FechaNacimiento = FechaNacimiento
            PilotoDao.EditarPiloto(piloto)
            Cerrar()
        End Sub

        ' Guardar pais creado
        Private Sub CrearPiloto()
            piloto.Nombre = Nombre
            piloto.Pais = PaisSeleccionado
            piloto.FechaNacimiento = FechaNacimiento
            PilotoDao.InsertarPiloto(piloto)
            Cerrar()
        End Sub

        Private Sub EliminarPiloto()
            PilotoDao.EliminarPiloto(piloto.IdPiloto)
            Cerrar()
        End Sub
        'Cerrar formulario y recargar paises
        Private Sub Cerrar()
            view.Close()
            viewModel.CargarDatos()
        End Sub

    End Class

End Namespace
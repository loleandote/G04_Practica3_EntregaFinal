Imports Formula1.EdicionesViewModel
Imports Formula1.ViewModelBase

Namespace PremiosViewModel
    Public Class PremiosConsultaViewModel
        Inherits ViewModelBase.ViewModelBase
        Public PremioEdicion As PremiosEdicionWindow
        Private _PremioSeleccionado As GranPremio
        Private TodosGranPremio As List(Of GranPremio)
        Private _GranPremios As List(Of GranPremio)
        Public Sub New()
            CrearGranPremioCommand = New DelegateCommand(AddressOf CrearGranPremio)
            EditarGranPremioCommand = New DelegateCommand(AddressOf EditarGranPremio)
            Dim paisesaux = New List(Of Pais) From {
               New Pais With {.IdPais = "", .Nombre = "Todos los paises"}
           }

            paisesaux.AddRange(PaisDAO.ObtenerTodosPaises)
            Paises = paisesaux
            _PaisSeleccionado = Paises.First
            Cargar()
        End Sub

        Public Property GranPremios As List(Of GranPremio)
            Get
                Return _GranPremios
            End Get
            Set
                _GranPremios = Value
                OnPropertyChanged("GranPremios")
            End Set
        End Property

        Public Property PremioSeleccionado As GranPremio
            Get
                Return _PremioSeleccionado
            End Get
            Set
                _PremioSeleccionado = Value
                OnPropertyChanged("PremioSeleccionado")
            End Set
        End Property
        Public Property Paises As List(Of Pais)
        Public Property PaisSeleccionado As Pais

        Public Property CrearGranPremioCommand As ICommand
        Public Property EditarGranPremioCommand As ICommand
        Private Sub EditarGranPremio()
            If PremioEdicion Is Nothing Then
                crearVentana(PremioSeleccionado)
            Else
                Try
                    PremioEdicion.Show()
                    MsgBox("Ya tienes una ventana abierta")
                    PremioEdicion.Focus()
                Catch ex As Exception
                    crearVentana(PremioSeleccionado)
                End Try
            End If
        End Sub
        Private Sub CrearGranPremio()
            If PremioEdicion Is Nothing Then
                crearVentana(New GranPremio)
            Else
                Try
                    PremioEdicion.Show()
                    MsgBox("Ya tienes una ventana abierta")
                    PremioEdicion.Focus()
                Catch ex As Exception
                    crearVentana(New GranPremio)
                End Try
            End If
        End Sub
        Private Sub crearVentana(premio As GranPremio)
            PremioEdicion = New PremiosEdicionWindow
            PremioEdicion.DataContext = New PremiosEdicionViewModel(premio, PremioEdicion, Me)
            PremioEdicion.Show()
        End Sub

        Public Sub Cargar()
            GranPremios = GranPremioDAO.ObtenerTodosGranPremio
        End Sub

    End Class
    Public Class PremiosEdicionViewModel
        Private premio As GranPremio
        Private view As PremiosEdicionWindow
        Public EdicionInsercion As EdicionInsercionWindow
        Private viewModel As PremiosConsultaViewModel

        Public Sub New(premio As GranPremio, view As PremiosEdicionWindow, viewModel As PremiosConsultaViewModel)
            Me.premio = premio
            Me.view = view
            Me.viewModel = viewModel
            Paises = PaisDAO.ObtenerTodosPaises
            If premio.idGranPremio = Nothing Then
                Titulo = "Crear gran premio"
                VerCreacion = Visibility.Visible
                VerEdicion = Visibility.Hidden
                GuardarGranPremioCommand = New DelegateCommand(AddressOf CrearGranPremio)
            Else
                Titulo = "Editar gran premio de: " + premio.Nombre
                Nombre = premio.Nombre
                'Comprobar con datos
                PaisSeleccionado = premio.Pais
                VerCreacion = Visibility.Collapsed
                VerEdicion = Visibility.Visible
                PaisSeleccionado = (From p In Paises Select p Where p.IdPais = premio.Pais.IdPais).First
                GuardarGranPremioCommand = New DelegateCommand(AddressOf GuardarGranPremio)
                EliminarGranPremioCommand = New DelegateCommand(AddressOf EliminarGranPremio)
                CrearEdicionCommand = New DelegateCommand(AddressOf CrearEdicion)
            End If
        End Sub

        Public Property Titulo As String
        Public Property VerEdicion As Visibility
        Public Property VerCreacion As Visibility
        Public Property CrearEdicionCommand As ICommand
        Public Property GuardarGranPremioCommand As ICommand
        Public Property EliminarGranPremioCommand As ICommand
        Public Property Nombre As String
        Public Property Paises As List(Of Pais)
        Public Property PaisSeleccionado As Pais

        Private Sub CrearGranPremio()
            premio.Nombre = Nombre
            premio.Pais = PaisSeleccionado
            GranPremioDAO.InsertarGranPremio(premio)
            Cerrar()
        End Sub

        Private Sub GuardarGranPremio()
            premio.Nombre = Nombre
            premio.Pais = PaisSeleccionado
            GranPremioDAO.EditarGranPremio(premio)
            Cerrar()
        End Sub

        Private Sub EliminarGranPremio()
            Dim eliminar As Boolean = True
            If EdicionDAO.ObtenterEdicionesGranPremio(premio.idGranPremio) Then
                eliminar = MsgBox("Hay alguna edicion de este gran premio" + vbCrLf + "¿Quieres eliminar las ediciones?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes
                If eliminar Then
                    EdicionDAO.eliminarEdicionesGranPremio(premio.idGranPremio)
                End If
            End If
            If eliminar Then
                GranPremioDAO.EliminarGranPremio(premio.idGranPremio)
            End If
            Cerrar()
        End Sub



        Private Sub CrearEdicion()
            If EdicionInsercion Is Nothing Then
                crearVentana(premio)
            Else
                Try
                    EdicionInsercion.Show()
                    MsgBox("Ya tienes una ventana abierta")
                    EdicionInsercion.Focus()
                Catch ex As Exception
                    crearVentana(premio)
                End Try
            End If
        End Sub

        Private Sub crearVentana(premio As GranPremio)
            EdicionInsercion = New EdicionInsercionWindow
            EdicionInsercion.DataContext = New EdicionInsercionViewModel(EdicionInsercion, premio)
            EdicionInsercion.Show()
        End Sub

        'Cerrar formulario y recargar premios
        Private Sub Cerrar()
            view.Close()
            viewModel.Cargar()
        End Sub
    End Class

End Namespace

Imports Formula1.ViewModelBase

Namespace PaisesViewModel
    Public Class PaisesConsultaViewModel
        Inherits ViewModelBase.ViewModelBase

        Private _PaisFiltro As String
        Private _Paises As List(Of Pais)
        Private TodosPaises As List(Of Pais)
        Private _PaisSeleccionado As Pais
        Public PaisEdicion As PaisesEdicionWindow
        Public Sub New()
            EditarPaisCommand = New DelegateCommand(AddressOf EditarPais)
            CrearPaisCommand = New DelegateCommand(AddressOf CrearPais)
            LimpiarCommand = New DelegateCommand(AddressOf LipiarPais)
            CargarDtos()
        End Sub

        Public Property EditarPaisCommand As ICommand
        Public Property CrearPaisCommand As ICommand
        Public Property LimpiarCommand As ICommand

        Public Property PaisSeleccionado As Pais
            Get
                Return _PaisSeleccionado
            End Get
            Set
                _PaisSeleccionado = Value
                OnPropertyChanged("PaisSeleccionado")
            End Set
        End Property

        Public Property Paises As List(Of Pais)
            Get
                Return _Paises
            End Get
            Set
                _Paises = Value
                OnPropertyChanged("Paises")
            End Set
        End Property

        Public Property PaisFiltro As String
            Get
                Return _PaisFiltro
            End Get
            Set
                _PaisFiltro = Value
                If Not Value.Equals("") Then
                    Paises = (From p In TodosPaises Select p Where p.Nombre.ToUpper.StartsWith(Value.ToUpper)).ToList
                Else
                    Paises = TodosPaises
                End If
                OnPropertyChanged("PaisFiltro")
            End Set
        End Property


        Public Sub CargarDtos()
            TodosPaises = PaisDAO.ObtenerTodosPaises
            If PaisFiltro IsNot Nothing AndAlso Not PaisFiltro.Equals("") Then
                Paises = (From p In TodosPaises Select p Where p.Nombre.ToUpper.StartsWith(PaisFiltro.ToUpper)).ToList
            Else
                Paises = TodosPaises
            End If
        End Sub

        Private Sub EditarPais()
            If PaisEdicion Is Nothing Then
                crearVentana(PaisSeleccionado)
            Else
                Try
                    PaisEdicion.Show()
                    MsgBox("Ya tienes una ventana abierta")
                    PaisEdicion.Focus()
                Catch ex As Exception
                    crearVentana(PaisSeleccionado)
                End Try
            End If
        End Sub

        Private Sub CrearPais()
            If PaisEdicion Is Nothing Then
                crearVentana(New Pais)
            Else
                Try
                    PaisEdicion.Show()
                    MsgBox("Ya tienes una ventana abierta")
                    PaisEdicion.Focus()
                Catch ex As Exception
                    crearVentana(New Pais)
                End Try
            End If
        End Sub

        Private Sub crearVentana(pais As Pais)
            PaisEdicion = New PaisesEdicionWindow
            PaisEdicion.DataContext = New PaisesEdicionViewModel(pais, PaisEdicion, Me)
            PaisEdicion.Show()
        End Sub

        Private Sub LipiarPais()
            PaisFiltro = ""
        End Sub

    End Class

    Public Class PaisesEdicionViewModel
        Inherits ViewModelBase.ViewModelBase
        Private _Nombre As String
        Private _Identificador As String
        Private viewModel As PaisesConsultaViewModel
        Private view As PaisesEdicionWindow
        Private pais As Pais
        Public Sub New(pais As Pais, view As PaisesEdicionWindow, viewModel As PaisesConsultaViewModel)
            Me.pais = pais
            Me.view = view
            Me.viewModel = viewModel
            If pais.IdPais Is Nothing Then
                Titulo = "Crear país"
                pais = New Pais
                VerCreacion = Visibility.Visible
                VerEdicion = Visibility.Collapsed
                GuardarPaisCommand = New DelegateCommand(AddressOf CrearPais)
            Else
                Titulo = "Editar: " + pais.Nombre
                Identificador = pais.IdPais
                Nombre = pais.Nombre
                VerCreacion = Visibility.Collapsed
                VerEdicion = Visibility.Visible
                GuardarPaisCommand = New DelegateCommand(AddressOf GuardarPais)
                EliminarPaisCommand = New DelegateCommand(AddressOf EliminarPais)
            End If
        End Sub
        Public Property Titulo As String

        Public Property VerEdicion As Visibility
        Public Property VerCreacion As Visibility
        Public Property Identificador As String
            Get
                Return _Identificador
            End Get
            Set
                _Identificador = Value
                OnPropertyChanged("Identificador")
            End Set
        End Property

        Public Property Nombre As String
            Get
                Return _Nombre
            End Get
            Set
                _Nombre = Value
                If _Nombre IsNot Nothing Then
                    If _Nombre.Length > 2 Then
                        Identificador = _Nombre.Substring(0, 3).ToUpper
                    Else
                        Identificador = _Nombre.ToUpper
                    End If
                End If
                OnPropertyChanged("Nombre")
            End Set
        End Property

        Public Property GuardarPaisCommand As ICommand
        Public Property EliminarPaisCommand As ICommand
        ' Guardar pais modificado
        Private Sub GuardarPais()
            pais.IdPais = Identificador
            pais.Nombre = Nombre
            PaisDAO.EditarPais(pais)
            Cerrar()
        End Sub

        ' Guardar pais creado
        Private Sub CrearPais()
            pais.IdPais = Identificador
            pais.Nombre = Nombre
            PaisDAO.InsertarPais(pais)
            Cerrar()
        End Sub

        Private Sub EliminarPais()
            PaisDAO.EliminarPais(pais)
            Cerrar()
        End Sub

        'Cerrar formulario y recargar paises
        Private Sub Cerrar()
            view.Close()
            viewModel.CargarDtos()
        End Sub
    End Class
End Namespace
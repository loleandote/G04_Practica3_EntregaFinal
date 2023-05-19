Imports System.Web.UI.WebControls
Imports Formula1.ViewModelBase

Namespace CircuitosViewModel
    Public Class CircuitosConsultaViewModel
        Inherits ViewModelBase.ViewModelBase
        Private _Paises As List(Of Pais)
        Private _PaisSeleccionado As Pais
        Private TodosCircuitos As List(Of Circuito)
        Private _Circuitos As List(Of Circuito)
        Private _CircuitoFiltro As String
        Private _CircuitoSeleccionado As Circuito
        Public CircuitoEdicion As CircuitoEdicionWindow
        Public Sub New()
            Dim paisesaux = New List(Of Pais) From {
               New Pais With {.IdPais = "", .Nombre = "Todos los paises"}
}
            LimpiarCommand = New DelegateCommand(AddressOf LipiarCircuito)
            CrearCircuitoCommand = New DelegateCommand(AddressOf CrearCircuito)
            EditarCircuitoCommand = New DelegateCommand(AddressOf EditarCircuito)
            paisesaux.AddRange(PaisDAO.ObtenerTodosPaises)
            Paises = paisesaux
            _PaisSeleccionado = Paises.First
            Cargar()

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
                If Not Value.IdPais.Equals("") Then
                    Circuitos = (From p In TodosCircuitos Select p Where p.Pais.IdPais = Value.IdPais).ToList
                Else
                    Circuitos = TodosCircuitos
                End If
                OnPropertyChanged("PaisSeleccionado")
            End Set
        End Property

        Public Property Circuitos As List(Of Circuito)
            Get
                Return _Circuitos
            End Get
            Set
                _Circuitos = Value
                OnPropertyChanged("Circuitos")
            End Set
        End Property

        Public Property CircuitoSeleccionado As Circuito
            Get
                Return _CircuitoSeleccionado
            End Get
            Set
                _CircuitoSeleccionado = Value
                OnPropertyChanged("CircuitoSeleccionado")
            End Set
        End Property

        Public Property CrearCircuitoCommand As ICommand

        Public Property EditarCircuitoCommand As ICommand

        Public Property CircuitoFiltro As String
            Get
                Return _CircuitoFiltro
            End Get
            Set
                _CircuitoFiltro = Value
                OnPropertyChanged("CircuitoFiltro")
            End Set
        End Property


        Public Property LimpiarCommand As ICommand

        Private Sub CrearCircuito()
            If CircuitoEdicion Is Nothing Then
                crearVentana(New Circuito)
            Else
                Try
                    CircuitoEdicion.Show()
                    MsgBox("Ya tienes una ventana abierta")
                    CircuitoEdicion.Focus()
                Catch ex As Exception
                    crearVentana(New Circuito)
                End Try
            End If
        End Sub

        Private Sub EditarCircuito()
            If CircuitoEdicion Is Nothing Then
                crearVentana(CircuitoSeleccionado)
            Else
                Try
                    CircuitoEdicion.Show()
                    MsgBox("Ya tienes una ventana abierta")
                    CircuitoEdicion.Focus()
                Catch ex As Exception
                    crearVentana(CircuitoSeleccionado)
                End Try
            End If
        End Sub

       ' Este metodo crea una nueva instancia de la ventana `CircuitoEdicionWindow` y
       ' establece su contexto de datos en una nueva instancia del modelo de vista
       ' `CircuitoEdicionViewModel`. El parámetro `circuito` se pasa al constructor del modelo de
       ' vista junto con la instancia `CircuitoEdicionWindow` y la instancia
       ' `CircuitosConsultaViewModel` (`Me`). Finalmente, se muestra la ventana. Este sub se llama
       ' cuando el usuario hace clic en los botones "CrearCircuito" o "EditarCircuito" en el modelo de
       ' vista `CircuitosConsultaViewModel`.
        Private Sub crearVentana(circuito As Circuito)
            CircuitoEdicion = New CircuitoEdicionWindow
            CircuitoEdicion.DataContext = New CircuitoEdicionViewModel(circuito, CircuitoEdicion, Me)
            CircuitoEdicion.Show()
        End Sub

        Private Sub LipiarCircuito()
            CircuitoFiltro = ""
        End Sub

        Public Sub Cargar()
            TodosCircuitos = CircuitoDAO.ObtenerTodosCircuitos()
            Circuitos = TodosCircuitos
        End Sub
    End Class

    Public Class CircuitoEdicionViewModel
        Inherits ViewModelBase.ViewModelBase
        Private view As CircuitoEdicionWindow
        Private viewModel As CircuitosConsultaViewModel
        Private Circuito As Circuito
        Private _Nombre As String
        Private _PaisSeleccionado As Pais
        Private _Ciudad As String
        Private _Longitud As Integer?
        Private _Curvas As Integer?

        Public Sub New(circuito As Circuito, view As CircuitoEdicionWindow, viewModel As CircuitosConsultaViewModel)
            Me.Circuito = circuito
            Me.view = view
            Me.viewModel = viewModel
            Paises = PaisDAO.ObtenerTodosPaises
            If circuito.IdCircuito = 0 Then
                Titulo = "Crear circuito"
                VerCreacion = Visibility.Visible
                VerEdicion = Visibility.Collapsed
                GuardarCircuitoCommand = New DelegateCommand(AddressOf CrearCircuito)
            Else
                Titulo = "Editar circuito de: " + circuito.Nombre
                Nombre = circuito.Nombre
                Ciudad = circuito.Ciudad
                Longitud = circuito.Longitud
                Curvas = circuito.Curvas
                VerCreacion = Visibility.Collapsed
                VerEdicion = Visibility.Visible
                PaisSeleccionado = (From p In Paises Select p Where p.IdPais = circuito.Pais.IdPais).First
                GuardarCircuitoCommand = New DelegateCommand(AddressOf GuardarCircuito)
                EliminarCircuitoCommand = New DelegateCommand(AddressOf EliminarCircuito)
            End If
        End Sub
        Public Property Titulo As String

        Public Property VerEdicion As Visibility
        Public Property VerCreacion As Visibility
        Public Property Nombre As String
            Get
                Return _Nombre
            End Get
            Set
                _Nombre = Value
                OnPropertyChanged("Nombre")
            End Set
        End Property

        Public Property Ciudad As String
            Get
                Return _Ciudad
            End Get
            Set
                _Ciudad = Value
                OnPropertyChanged("Ciudad")
            End Set
        End Property

        Public Property Longitud As Integer?
            Get
                Return _Longitud
            End Get
            Set
                _Longitud = Value
                OnPropertyChanged("Longitud")
            End Set
        End Property

        Public Property Curvas As Integer?
            Get
                Return _Curvas
            End Get
            Set
                Try
                    _Curvas = Value
                Catch ex As Exception

                End Try
                OnPropertyChanged("Curvas")
            End Set
        End Property

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

        Public Property GuardarCircuitoCommand As ICommand
        Public Property EliminarCircuitoCommand As ICommand
        Private Sub GuardarCircuito()
            Circuito.Ciudad = Ciudad
            Circuito.Curvas = Curvas.Value
            Circuito.Longitud = Longitud.Value
            Circuito.Pais = PaisSeleccionado
            Circuito.Nombre = Nombre
            CircuitoDAO.EditarCircuito(Circuito)
            Cerrar()
        End Sub

        ' Guardar circuito creado
        Private Sub CrearCircuito()
            If PaisSeleccionado IsNot Nothing Then
                Circuito.Ciudad = Ciudad
                If Curvas.HasValue Then
                    Circuito.Curvas = Curvas.Value
                End If
                If Longitud.HasValue Then
                    Circuito.Longitud = Longitud.Value
                End If
                Circuito.Pais = PaisSeleccionado
                Circuito.Nombre = Nombre
                CircuitoDAO.InsertarCircuito(Circuito)
                Cerrar()
            Else
                MsgBox("Revisa que has introducido bien los datos")
            End If
        End Sub
        Private Sub EliminarCircuito()
            CircuitoDAO.EliminarCircuito(Circuito.IdCircuito)
            Cerrar()
        End Sub

        'Cerrar formulario y recargar paises
        Private Sub Cerrar()
            view.Close()
            viewModel.Cargar()
        End Sub
    End Class
End Namespace
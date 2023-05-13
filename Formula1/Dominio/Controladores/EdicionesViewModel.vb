Imports Formula1.EntidadesAuxiliares
Imports Formula1.ViewModelBase

Namespace EdicionesViewModel
    Public Class EdicionesConsultaViewModel
        Inherits ViewModelBase.ViewModelBase

        Public EdicionInsercion As EdicionInsercionWindow
        Public Sub New()
            CrearEdicionCommand = New DelegateCommand(AddressOf CrearEdicion)
            CargarDatos()
        End Sub
        Public Property Ediciones As List(Of Edicion)
        Public Property CrearEdicionCommand As ICommand
        Private Sub CrearEdicion()
            If EdicionInsercion Is Nothing Then
                crearVentana()
            Else
                Try
                    EdicionInsercion.Show()
                    MsgBox("Ya tienes una ventana abierta")
                    EdicionInsercion.Focus()
                Catch ex As Exception
                    crearVentana()
                End Try
            End If
        End Sub
        Private Sub crearVentana()
            EdicionInsercion = New EdicionInsercionWindow
            EdicionInsercion.DataContext = New EdicionInsercionViewModel(EdicionInsercion, Me)
            EdicionInsercion.Show()
        End Sub
        Public Sub CargarDatos()
            Ediciones = EdicionDAO.ObtenterTodasEdiciones
        End Sub
    End Class
    Public Class EdicionInsercionViewModel
        Private vista As EdicionInsercionWindow
        Private viewModel As EdicionesConsultaViewModel
        Private granPremio As GranPremio
        Public Sub New(view As EdicionInsercionWindow, viewModel As EdicionesConsultaViewModel)
            vista = view
            Me.viewModel = viewModel
            CrearEdicionCommand = New DelegateCommand(AddressOf CrearEdicion)
        End Sub
        Public Sub New(view As EdicionInsercionWindow, granPremio As GranPremio)
            vista = view
            Me.granPremio = granPremio
            Circuitos = CircuitoDAO.ObtenerTodosCircuitosPaisClaveValor(granPremio.Pais.IdPais)
            CrearEdicionCommand = New DelegateCommand(AddressOf CrearEdicion)
            Titulo = "Edicion del gran premio de " + granPremio.Nombre
            Año = Date.Now.Year
        End Sub

        Public Property Nombre As String
        Public Property Titulo As String
        Public Property Año As Integer
        Public Property Fecha As Date
        Public Property Circuitos As List(Of ClaveValor)
        Public Property CircuitoSeleccionado As ClaveValor
        Public Property CrearEdicionCommand As ICommand
        Private Sub CrearEdicion()
            Dim edicion As New Edicion With {
                .GranPremio = granPremio,
                .Nombre = Nombre,
                .Fecha = Fecha
            }

            EdicionDAO.InsertarEdicion(edicion)
            Cerrar()
        End Sub
        Private Sub Cerrar()
            MsgBox(Año)
            vista.Close()
            If viewModel IsNot Nothing Then
                viewModel.CargarDatos()
            End If
        End Sub
    End Class


End Namespace

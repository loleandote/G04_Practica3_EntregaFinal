Imports Formula1.EntidadesAuxiliares
Imports Formula1.ViewModelBase

Namespace EdicionesViewModel

    Public Class EdicionInsercionViewModel
        Inherits ViewModelBase.ViewModelBase
        Private vista As EdicionInsercionWindow
        Private granPremio As GranPremio
        Private clasificaciones As List(Of Clasificacion)
        Private _Fecha As Date?

        Public Sub New(view As EdicionInsercionWindow, granPremio As GranPremio)
            vista = view
            Me.granPremio = granPremio
            Circuitos = CircuitoDAO.ObtenerTodosCircuitosPaisClaveValor(granPremio.Pais.IdPais)
            CrearEdicionCommand = New DelegateCommand(AddressOf CrearEdicion)
            Titulo = "Edicion del gran premio de " + granPremio.Nombre

        End Sub

        Public Property Nombre As String
        Public Property Titulo As String
        Public Property Fecha As Date?
            Get
                Return _Fecha
            End Get
            Set
                _Fecha = Value
                OnPropertyChanged("Fecha")
            End Set
        End Property
        Public Property Circuitos As List(Of ClaveValor)
        Public Property CircuitoSeleccionado As ClaveValor
        Public Property CrearEdicionCommand As ICommand
        Private Sub CrearEdicion()
            Dim pilotos = PilotoDAO.obtenerPilotosEdicion(Fecha.Value.Year)
            If pilotos.Count > 0 Then
                Dim posicion = CInt(Int((pilotos.Count * Rnd()) + 1)) - 1
                Dim circuitoAux = CircuitoDAO.ObtenerCircuitoPorId(CircuitoSeleccionado.Clave)
                Dim edicion As New Edicion With {
                    .GranPremio = granPremio,
                    .Nombre = Nombre,
                    .Fecha = Fecha,
                    .Año = Fecha.Value.Year,
                    .Piloto_VR = pilotos.Item(posicion)
                }
                If circuitoAux IsNot Nothing Then
                    edicion.Circuito = circuitoAux
                    edicion.IdEdicion = EdicionDAO.InsertarEdicion(edicion)
                    RealizarCarrera(pilotos, edicion)
                Else
                    MsgBox("Selecciona un circuito para esta edicion")
                End If
                Dim ventana As New PilotosParticipantesWindow With {.DataContext = New PilotosParticipantesViewModel(edicion, clasificaciones)}
                ventana.Show()
            Else
                MsgBox("No hay pilotos inscritos esta temporada")
            End If
            Cerrar()
        End Sub
        Private Sub RealizarCarrera(pilotos As List(Of Piloto), edicion As Edicion)
            clasificaciones = New List(Of Clasificacion)
            Dim clasificacioncarrera = 1
            While pilotos.Count > 0
                Dim posicion = CInt(Int((pilotos.Count * Rnd()) + 1)) - 1
                Dim piloto = pilotos.Item(posicion)
                pilotos.Remove(pilotos.Item(posicion))
                Dim clasificacion As New Clasificacion With {.Edicion = edicion, .Piloto = piloto, .Posicion = clasificacioncarrera}
                clasificacioncarrera += 1
                ClasificacionDAO.InsertarClasificacion(clasificacion)
                clasificaciones.Add(clasificacion)
            End While
        End Sub
        Private Sub Cerrar()
            vista.Close()
        End Sub
    End Class

    Public Class PilotosParticipantesViewModel
        Public Sub New(edicion As Edicion, clasificaciones As List(Of Clasificacion))
            Titulo = "Clasificaciones de " + edicion.Nombre
            VueltaRapida = "El piloto que realizo la vuelta rápida fue " + edicion.Piloto_VR.Nombre
            Me.Clasificaciones = clasificaciones
        End Sub
        Public Property Titulo As String
        Public Property VueltaRapida As String
        Public Property Clasificaciones As List(Of Clasificacion)
    End Class
End Namespace

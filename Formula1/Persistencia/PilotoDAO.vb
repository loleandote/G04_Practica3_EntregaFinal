Imports Formula1.EntidadesAuxiliares
Imports MySql.Data.MySqlClient

Public Class PilotoDAO
   ' La función recupera todos los pilotos de la base de datos y
   ' devolviéndolos como una lista de objetos `Piloto`. Utiliza una consulta SQL para unir las tablas
   ' `piloto` y `pais` y recuperar la información necesaria. Luego crea un nuevo objeto `Piloto` para
   ' cada fila en el conjunto de resultados y lo agrega a la lista. Si los campos `Nombre` o
   ' `FechaNacimiento` no están vacíos, también se configuran en el objeto `Piloto`. Cualquier
   ' excepción que ocurra durante el proceso se detecta y se muestra un cuadro de mensaje con el
   ' mensaje de error.
    Public Shared Function ObtenerTodosPilotos() As List(Of Piloto)
        Dim pilotos As New List(Of Piloto)
        Try
            For Each piloto In AgenteBD.ObtenerAgente.Leer("select * from piloto join pais on piloto.pais= pais.idpais")

                Dim pilot As New Piloto With {
                .IdPiloto = piloto(1).ToString,
                .Pais = New Pais() With {
                    .IdPais = piloto(5).ToString,
                    .Nombre = piloto(6).ToString
                }
                }
                If Not piloto(2).ToString.Equals("") Then
                    pilot.Nombre = piloto(2).ToString
                End If
                Try
                    If Not piloto(3).ToString.Equals("") Then
                        pilot.FechaNacimiento = Convert.ToDateTime(piloto(3).ToString)
                    End If
                Catch ex As Exception
                End Try
                pilotos.Add(pilot)
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return pilotos
    End Function

    ' La Función recupera todos los pilotos de la base de datos y los
    ' devuelve como una lista de objetos `ClaveValor`. Utiliza una consulta SQL para unir las tablas
    ' `piloto` y `pais` y recuperar la información necesaria. Luego, crea un nuevo objeto `ClaveValor`
    ' para cada fila en el conjunto de resultados y lo agrega a la lista. La propiedad `Clave` se
    ' establece en el ID del piloto y la propiedad `Valor` se establece en el nombre del piloto. Si
    ' ocurre alguna excepción durante el proceso, se muestra un cuadro de mensaje con el mensaje de
    ' error.
    Public Shared Function ObtenerTodosPilotosClaveValor() As List(Of ClaveValor)
        Dim pilotos As New List(Of ClaveValor)
        Try
            For Each piloto In AgenteBD.ObtenerAgente.Leer("select * from piloto join pais on piloto.pais= pais.idpais")

                pilotos.Add(New ClaveValor With {
                .Clave = piloto(1).ToString,
                .Valor = piloto(2).ToString
                })
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return pilotos
    End Function

   ' La función recupera todos los pilotos que participaron en una temporada
   ' concreta del campeonato de Fórmula 1. Utiliza una consulta SQL para unir las tablas `piloto`,
   ' `pais` e `inscripcion_mundial` para recuperar la información necesaria. Luego, crea un nuevo
   ' objeto `Piloto` para cada fila en el conjunto de resultados y lo agrega a la lista. Si los campos
   ' `Nombre` o `FechaNacimiento` no están vacíos, también se configuran en el objeto `Piloto`. Si
   ' ocurre alguna excepción durante el proceso, se muestra un cuadro de mensaje con el mensaje de
   ' error. Finalmente, la función devuelve la lista de objetos `Piloto`.
    Public Shared Function obtenerPilotosEdicion(temporada As Integer) As List(Of Piloto)
        Dim pilotos As New List(Of Piloto)
        Try
            For Each piloto In AgenteBD.ObtenerAgente.Leer("select * from piloto join pais on piloto.pais= pais.idpais join inscripcion_mundial on inscripcion_mundial.piloto= piloto.idPiloto where inscripcion_mundial.temporada=" & temporada)
                pilotos.Add(New Piloto With {
                .IdPiloto = Integer.Parse(piloto(1).ToString),
                .Nombre = piloto(2).ToString,
                .FechaNacimiento = Convert.ToDateTime(piloto(3)),
                .Pais = New Pais() With {
                    .IdPais = piloto(5).ToString,
                    .Nombre = piloto(6).ToString
                }
            })
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return pilotos
    End Function

    ' La función recupera una lista de años en los que un determinado
    ' piloto ha participado en el campeonato de Fórmula 1. Toma un parámetro entero `idPiloto` que
    ' representa el ID del piloto y devuelve una lista de enteros que representan los años en los que
    ' ha participado el piloto. La función ejecuta una consulta SQL para recuperar la información
    ' requerida de la tabla `inscripcion_mundial` y luego recorre los resultados para extraer los
    ' valores del año y agregarlos a la lista. Si ocurre una excepción durante el proceso, se muestra
    ' un cuadro de mensaje con el mensaje de error. Finalmente, la función devuelve la lista de años.
    Public Shared Function obtenerAñosParticipación(idPiloto As Integer) As List(Of Integer)
        Dim años As New List(Of Integer)
        Try
            For Each año In AgenteBD.ObtenerAgente.Leer("select temporada from inscripcion_mundial where piloto=" + idPiloto.ToString)
                años.Add(Integer.Parse(año(1).ToString))
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return años
    End Function

    ' La función consulta una base de datos para recuperar información sobre los participantes en una
    ' carrera (identificados por el parámetro "idEdicion") y sus posiciones, países y nombres. 
    ' Luego calcula los puntos obtenidos por cada participante en función de su posición y 
    ' agrega la información a los objetos "PilotoReporte", que luego se agregan a la lista de participantes. 
    ' Si se cumple una condición adicional (el participante tiene el mismo ID que un el piloto que realiza la 
    ' vuelta rápida
    Public Shared Function obtenerParticipantes(idEdicion As Integer) As List(Of PilotoReporte)
        Dim participantes As New List(Of PilotoReporte)
        Try
            Dim idPilotoRapido As Integer = Integer.Parse(AgenteBD.ObtenerAgente.Leer("select piloto_vr from edicion where idEdicion= " + idEdicion.ToString).Item(1).item(1).ToString)
            For Each piloto In AgenteBD.ObtenerAgente.Leer("select piloto.nombre, pais.nombre, clasificacion_carrera.posicion, piloto.idpiloto from piloto join pais on piloto.pais= pais.idpais join clasificacion_carrera on piloto.idPiloto= clasificacion_carrera.piloto where clasificacion_carrera.edicion= " + idEdicion.ToString)
                Dim participante = New PilotoReporte With {
                    .Nombre = piloto(1).ToString,
                    .Pais = piloto(2).ToString,
                    .Posicion = Integer.Parse(piloto(3).ToString)
                                 }
                If participante.Posicion <= ClasificacionDAO.puntos.Count Then
                    participante.Puntos = ClasificacionDAO.puntos(participante.Posicion - 1)
                    If Integer.Parse(piloto(4).ToString) = idPilotoRapido Then
                        participante.Puntos += 1
                    End If
                End If
                participantes.Add(participante)
            Next
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return participantes
    End Function

    ' La función consulta una base de datos para recuperar una lista de distintos pilotos que
    ' participaron en una temporada determinada (especificada por el parámetro del año) y sus nombres. 
   ' Para cada piloto, la función calcula el total de puntos ganados en la temporada consultando 
   ' la base de datos para conocer sus posiciones en cada carrera y sumando los puntos correspondientes.
   '  Si el piloto tuvo la vuelta más rápida en cualquier carrera, gana un punto adicional. 
   ' La función luego agrega el nombre del piloto y el total de puntos como ClaveValor
    Public Shared Function obtenerParticipantesTemporada(año As Integer) As List(Of ClaveValor)
        Dim participantes As New List(Of ClaveValor)
        Try
            For Each piloto In AgenteBD.ObtenerAgente.Leer("select distinct(inscripcion_mundial.piloto), nombre from piloto join inscripcion_mundial on inscripcion_mundial.piloto= piloto.idpiloto where inscripcion_mundial.temporada=" & año.ToString)
                Dim puntos = 0
                For Each punto In AgenteBD.ObtenerAgente.Leer("select posicion ,edicion.piloto_vr from clasificacion_carrera join edicion on edicion.idedicion= clasificacion_carrera.edicion where edicion.anio=" + año.ToString + " and clasificacion_carrera.piloto=" + piloto(1))
                    puntos += punto(1)
                    If Integer.Parse(punto(2).ToString) = piloto(1) Then
                        puntos += 1
                    End If

                Next
                participantes.Add(New ClaveValor With {.Valor = piloto(2), .Clave = puntos})
            Next
            participantes = participantes.OrderByDescending(Function(x) x.Clave).ToList
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la consulta")
        End Try
        Return participantes
    End Function
   ' El método inserta un nuevo objeto "Piloto" (que representa un piloto) en una tabla de base de datos 
   ' llamada "piloto". El método primero verifica el número de pilotos existentes en la tabla y
   '  asigna una nueva ID al nuevo piloto en consecuencia. Luego construye una consulta SQL
   '  para insertar la información del nuevo piloto (nombre, fecha de nacimiento e identificación del país)
   '  en la tabla utilizando la clase AgenteBD para ejecutar la consulta. Si hay un error durante la inserción,
   '  se muestra un cuadro de mensaje con el mensaje de error.
    Public Shared Sub InsertarPiloto(piloto As Piloto)
        Try
            Dim id = ObtenerTodosPilotos.Count
            If id > 0 Then
                AgenteBD.ObtenerAgente.Modificar("insert into piloto values((select max(idPiloto) from piloto e)+1, '" + piloto.Nombre + "', '" + piloto.FechaNacimiento.Value.ToString("yyyy-MM-dd") + "', '" + piloto.Pais.IdPais + "')")
            Else
                AgenteBD.ObtenerAgente.Modificar("insert into piloto values(" & 1 & ", '" + piloto.Nombre + "', '" + piloto.FechaNacimiento.Value.ToString("yyyy-MM-dd") + "', '" + piloto.Pais.IdPais + "')")

            End If
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la inserción")
        End Try
    End Sub

   ' El método  edita la información de un piloto en una base de datos.
   ' Toma como parámetro un objeto Piloto y actualiza el registro correspondiente en la base
   ' de datos con la nueva información. Si hay un error en la operación de la base de datos, muestra
   ' un mensaje de error.
    Public Shared Sub EditarPiloto(piloto As Piloto)
        Try
            AgenteBD.ObtenerAgente.Modificar("update piloto set nombre='" + piloto.Nombre + "', fecha_nacimiento='" + piloto.FechaNacimiento.Value.ToString("yyyy-MM-dd") + "', pais='" + piloto.Pais.IdPais + "' where idpiloto='" + piloto.IdPiloto.ToString & "'")
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la edición")
        End Try
    End Sub

   ' La función en Visual Basic que toma un parámetro entero "idPiloto" y devuelve un valor booleano.
   ' La función consulta una tabla de la base de datos "inscripcion_mundial"
   ' para verificar si hay algún registro donde la columna "piloto" coincida con
   ' el "idPiloto" dado. Si hay registros coincidentes, la función devuelve verdadero, de lo
   ' contrario, devuelve falso.
    Public Shared Function obtenerParticipacionesPiloto(idPiloto As Integer) As Boolean
        Return AgenteBD.ObtenerAgente.Leer("select * from inscripcion_mundial where piloto=" + idPiloto.ToString).Count > 0
    End Function
    ' El método elimina un piloto de una base de datos.
    ' Primero borra todas las entradas de la tabla "inscripcion_mundial" y tabla
    ' "clasificacion_carrera" que corresponden al piloto que se está borrando, y luego borra la
    ' entrada del piloto de la tabla "piloto". Si hay una excepción de MySQL, muestra un mensaje de
    ' error.
    Public Shared Sub EliminarPiloto(idPiloto As Integer)
        Try
            AgenteBD.ObtenerAgente.Modificar("delete from inscripcion_mundial where piloto=" + idPiloto.ToString)
            AgenteBD.ObtenerAgente.Modificar("delete from clasificacion_carrera where piloto=" + idPiloto.ToString)
            AgenteBD.ObtenerAgente.Modificar("delete from piloto where idpiloto=" + idPiloto.ToString)
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error en la eliminación")
        End Try
    End Sub
End Class

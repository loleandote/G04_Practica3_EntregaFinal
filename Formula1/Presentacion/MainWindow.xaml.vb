Class MainWindow

    Public Property DataContexto As MainWindowViewModel

    Public Sub New()
        DataContexto = New MainWindowViewModel
        DataContext = DataContexto
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub


End Class

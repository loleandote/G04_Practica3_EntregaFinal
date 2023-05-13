Imports System.ComponentModel
Imports Formula1.PaisesViewModel

Namespace ViewModelBase
    Public Class ViewModelBase
        Implements INotifyPropertyChanged
        Public Sub New()
        End Sub

        Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

        Protected Sub OnPropertyChanged(propName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propName))
        End Sub
    End Class

    Public Class DelegateCommand
        Implements ICommand
        Private m_executeAction As Action(Of Object)

        Public Event CanExecuteChanged(sender As Object, e As System.EventArgs) Implements ICommand.CanExecuteChanged

        Public Sub New(executeAction As Action(Of Object))
            m_executeAction = executeAction
        End Sub

        Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
            Return True
        End Function

        Public Sub Execute(parameter As Object) Implements ICommand.Execute
            m_executeAction(parameter)
        End Sub
    End Class
End Namespace

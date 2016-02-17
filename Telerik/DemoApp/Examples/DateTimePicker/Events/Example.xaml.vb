Imports System.Collections
Imports System.Linq
Imports Telerik.Windows.Controls

#If Not SILVERLIGHT Then
Imports System.Windows.Controls
#End If

Namespace Telerik.Windows.Examples.DateTimePicker.Events
	Public Partial Class Example
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Function GetEnumItemsSource(enumType As Type) As EnumDataSource
			Dim source As New EnumDataSource()
			source.EnumType = enumType
			Return source
		End Function

		Private Function GetFirstOrDefault(list As IList) As Object
			Return If(list Is Nothing, Nothing, list.Cast(Of Object)().FirstOrDefault())
		End Function

		Private Sub LogEvent(eventName As String, message As String)
			Dim item As New Message()
			item.EventName = eventName
			item.Text = message

			EventsLog.Items.Add(item)

			EventsLog.ScrollIntoView(item)
		End Sub

		Private Sub dateTimePicker_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
			Me.LogEvent("SelectionChanged", String.Format("{0} -> {1}", If(GetFirstOrDefault(e.RemovedItems), "Null"), GetFirstOrDefault(e.AddedItems)))
		End Sub

		Private Sub dateTimePicker_ParseDateTimeValue(sender As Object, args As ParseDateTimeEventArgs)
			Me.LogEvent("ParseDateTimeValue", If(args.IsParsingSuccessful, "Successfull", "Unsuccessfull"))
		End Sub

		Private Sub dateTimePicker_DropDownOpened(sender As Object, e As System.Windows.RoutedEventArgs)
			Me.LogEvent("DropDownOpened", "")
		End Sub

		Private Sub dateTimePicker_DropDownClosed(sender As Object, e As System.Windows.RoutedEventArgs)
			Me.LogEvent("DropDownClosed", "")
		End Sub

		Public Class Message
			Private m_eventName As String

			Public Property EventName() As String
				Get
					Return m_eventName
				End Get
				Set
					m_eventName = value
				End Set
			End Property

			Private m_text As String

			Public Property Text() As String
				Get
					Return m_text
				End Get
				Set
					m_text = value
				End Set
			End Property
		End Class
	End Class
End Namespace

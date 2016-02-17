Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports Telerik.Windows.QuickStart
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Collections
Imports Telerik.Windows.Controls

Namespace Telerik.Windows.Examples.OutlookBar.Events
	Public Partial Class Example
		Inherits Telerik.Windows.QuickStart.Example
		Private counter As Integer = 5
		Public Sub New()
			InitializeComponent()
			Me.PositionChangedEventSubscription = True
			Me.SelectedEventSubscription = True
			Me.AddedItemEventSubscription = True
			Me.RemovedItemEventSubscription = True
			Me.DataContext = Me
		End Sub

		Public Property PositionChangedEventSubscription() As System.Nullable(Of Boolean)
			Get
			End Get
			Set
			End Set
		End Property
		Public Property SelectedEventSubscription() As System.Nullable(Of Boolean)
			Get
			End Get
			Set
			End Set
		End Property
		Public Property AddedItemEventSubscription() As System.Nullable(Of Boolean)
			Get
			End Get
			Set
			End Set
		End Property
		Public Property RemovedItemEventSubscription() As System.Nullable(Of Boolean)
			Get
			End Get
			Set
			End Set
		End Property

		Private Sub ButtonAdd_Click(sender As Object, e As RoutedEventArgs)
			Dim createdItem As RadOutlookBarItem = Me.CreateOutlookBarItem()
			If Convert.ToBoolean(Me.AddedItemEventSubscription) Then
				Dim header As String = createdItem.Header.ToString()
				Dim message As String = [String].Format("{0} added.", header)
				Me.WriteToLog(message)
			End If
		End Sub

		Private Sub ButtonRemove_Click(sender As Object, e As RoutedEventArgs)
			If Me.outlookBar.SelectedItem IsNot Nothing Then
				Me.outlookBar.Items.Remove(Me.outlookBar.SelectedItem)
				If Me.outlookBar.Items.Count = 0 Then
					Me.counter = 0
				End If
				If Convert.ToBoolean(Me.RemovedItemEventSubscription) Then
					Dim header As String = Me.GetHeader(outlookBar.SelectedItem)
					Dim message As String = [String].Format("{0} removed.", header)
					Me.WriteToLog(message)
				End If
			End If
		End Sub

		Private Sub ButtonClearLog_Click(sender As Object, e As RoutedEventArgs)
			Me.log.Items.Clear()
		End Sub

		Private Sub ButtonClearOutlookBar_Click(sender As Object, e As RoutedEventArgs)
			Me.outlookBar.Items.Clear()
		End Sub

		Private Sub OutlookBar_ItemPositionChanged(sender As Object, e As PositionChangedEventArgs)
			If Convert.ToBoolean(Me.PositionChangedEventSubscription) Then
				Dim header As String = Me.GetHeader(e.OriginalSource)
				Dim message As String = [String].Format("{0}'s position: {1}", header, e.NewPosition.ToString())
				Me.WriteToLog(message)
			End If
		End Sub

		Private Sub OutlookBar_SelectionChanged(sender As Object, e As RoutedEventArgs)
			If Convert.ToBoolean(Me.SelectedEventSubscription) Then
				Dim header As String = Me.GetHeader(outlookBar.SelectedItem)
				Dim message As String = [String].Format("{0} selected.", header)
				Me.WriteToLog(message)
			End If
		End Sub

		Private Function CreateOutlookBarItem() As RadOutlookBarItem
			Dim item As New RadOutlookBarItem()
			item.Header = "Item " & Me.counter
			item.Content = "Item " & Me.counter
			Me.outlookBar.Items.Add(item)
			Me.counter += 1

			Return item
		End Function

		Private Sub WriteToLog(message As String)
			Dim logItem As New LogItem(message)
			Me.log.Items.Insert(0, logItem)
			Me.log.SelectedItem = logItem
		End Sub

		Private Function GetHeader(outlookBarItem As Object) As String
			Dim obItem As RadOutlookBarItem = TryCast(Me.outlookBar.ItemContainerGenerator.ContainerFromItem(outlookBarItem), RadOutlookBarItem)
			Return obItem.Header.ToString()
		End Function
	End Class

	Public Class LogItem
		Public Sub New(eventMessage As String)
			Me.TimeStamp = DateTime.Now.TimeOfDay
			Me.EventMessage = eventMessage
		End Sub

		Public Property TimeStamp() As TimeSpan
			Get
			End Get
			Set
			End Set
		End Property
		Public Property EventMessage() As String
			Get
			End Get
			Set
			End Set
		End Property
	End Class
End Namespace

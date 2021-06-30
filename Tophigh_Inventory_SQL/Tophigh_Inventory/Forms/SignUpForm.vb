Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Collections.Generic
Imports System
Imports MySql.Data.MySqlClient
Imports System.Net
Imports System.Text
Imports System.Net.NetworkInformation
Imports System.Management

Public Class SignUpForm
    Private Sub SignUpForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            GetMACAddress()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub GetMACAddress()
        Try

            Dim objMOS As New ManagementObjectSearcher("Select * FROM Win32_NetworkAdapterConfiguration")
            Dim objMOC As ManagementObjectCollection = objMOS.[Get]()
            Dim macAddress As String = [String].Empty
            For Each objMO As ManagementObject In objMOC
                Dim tempMacAddrObj As Object = objMO("MacAddress")

                If tempMacAddrObj Is Nothing Then
                    'Skip objects without a MACAddress
                    Continue For
                End If
                If macAddress = [String].Empty Then
                    ' only return MAC Address from first card that has a MAC Address
                    macAddress = tempMacAddrObj.ToString()
                End If
                objMO.Dispose()
            Next
            macAddress = macAddress.Replace(":", "")
            txtmacaddress.Text = macAddress

        Catch ex As Exception

        End Try
    End Sub

End Class
Imports System.Runtime.InteropServices

Public Class EmployeesForm

    Dim emp As New EmpClass

    Const WM_CAP As Short = &H400S
    Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
    Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
    Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30
    Public Const WM_CAP_GET_STATUS As Integer = WM_CAP + 54
    Public Const WM_CAP_DLG_VIDEOFORMAT As Integer = WM_CAP + 41
    Const WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50
    Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
    Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
    Const WS_CHILD As Integer = &H40000000
    Const WS_VISIBLE As Integer = &H10000000
    Const SWP_NOMOVE As Short = &H2S
    Const SWP_NOSIZE As Short = 1
    Const SWP_NOZORDER As Short = &H4S
    Const HWND_BOTTOM As Short = 1
    Private DeviceID As Integer = 0 ' Current device ID
    Private hHwnd As Integer ' Handle to preview window

    Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
        (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer,
        ByRef lParam As CAPSTATUS) As Boolean

    Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
       (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Boolean,
       ByRef lParam As Integer) As Boolean

    Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
         (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer,
         ByRef lParam As Integer) As Boolean

    Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer,
        ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer,
        ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

    Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean

    Structure POINTAPI
        Dim x As Integer
        Dim y As Integer
    End Structure

    Public Structure CAPSTATUS
        Dim uiImageWidth As Integer                    '// Width of the image
        Dim uiImageHeight As Integer                   '// Height of the image
        Dim fLiveWindow As Integer                     '// Now Previewing video?
        Dim fOverlayWindow As Integer                  '// Now Overlaying video?
        Dim fScale As Integer                          '// Scale image to client?
        Dim ptScroll As POINTAPI                    '// Scroll position
        Dim fUsingDefaultPalette As Integer            '// Using default driver palette?
        Dim fAudioHardware As Integer                  '// Audio hardware present?
        Dim fCapFileExists As Integer                  '// Does capture file exist?
        Dim dwCurrentVideoFrame As Integer             '// # of video frames cap'td
        Dim dwCurrentVideoFramesDropped As Integer     '// # of video frames dropped
        Dim dwCurrentWaveSamples As Integer            '// # of wave samples cap'td
        Dim dwCurrentTimeElapsedMS As Integer          '// Elapsed capture duration
        Dim hPalCurrent As Integer                     '// Current palette in use
        Dim fCapturingNow As Integer                   '// Capture in progress?
        Dim dwReturn As Integer                        '// Error value after any operation
        Dim wNumVideoAllocated As Integer              '// Actual number of video buffers
        Dim wNumAudioAllocated As Integer              '// Actual number of audio buffers
    End Structure

    Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
         (ByVal lpszWindowName As String, ByVal dwStyle As Integer,
         ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer,
         ByVal nHeight As Short, ByVal hWndParent As Integer,
         ByVal nID As Integer) As Integer

    Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short,
        ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String,
        ByVal cbVer As Integer) As Boolean

    Private Sub EmployeesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            emp.empno()
            txtpicname.Text = "savedata"
            emp.GetEmpData()
            emp.GetEmpAdd()
            emp.GetEmpSal()
        Catch ex As Exception

        End Try

        Try

            LoadDeviceList()
            If lstDevices.Items.Count > 0 Then
                btnstart.Enabled = True
                lstDevices.SelectedIndex = 0
                btnstart.Enabled = True
            Else
                lstDevices.Items.Add("No Capture Device")
                btnstart.Enabled = False
            End If
            Me.AutoScrollMinSize = New Size(100, 100)
            btnimagesave.Enabled = False

            picguest.SizeMode = PictureBoxSizeMode.StretchImage

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EmployeesForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If btnStop.Enabled Then
                ClosePreviewWindow()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadDeviceList()
        Try

            Dim strName As String = Space(100)
            Dim strVer As String = Space(100)
            Dim bReturn As Boolean
            Dim x As Short = 0
            ' 
            ' Load name of all avialable devices into the lstDevices
            '
            Do
                '
                '   Get Driver name and version
                '
                bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)
                '
                ' If there was a device add device name to the list
                '
                If bReturn Then lstDevices.Items.Add(strName.Trim)
                x += CType(1, Short)
            Loop Until bReturn = False

        Catch ex As Exception

        End Try
    End Sub

    Private Sub OpenPreviewWindow()
        Try

            Dim iHeight As Integer = picguest.Height
            Dim iWidth As Integer = picguest.Width
            '
            ' Open Preview window in picturebox
            '
            hHwnd = capCreateCaptureWindowA(DeviceID.ToString, WS_VISIBLE Or WS_CHILD, 0, 0, 1280,
                1024, picguest.Handle.ToInt32, 0)
            '
            ' Connect to device
            '
            If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, DeviceID, 0) Then
                '
                'Set the preview scale
                '
                SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)

                '
                'Set the preview rate in milliseconds
                '
                SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)

                '
                'Start previewing the image from the camera
                '
                SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)

                '
                ' Resize window to fit in picturebox
                '
                SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, picguest.Width, picguest.Height,
                        SWP_NOMOVE Or SWP_NOZORDER)

                btnimagesave.Enabled = True

                btnstart.Enabled = False

            Else
                '
                ' Error connecting to device close window
                ' 
                DestroyWindow(hHwnd)

            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub ClosePreviewWindow()
        Try
            '
            ' Disconnect from device
            '
            SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, DeviceID, 0)
            '
            ' close window
            '
            DestroyWindow(hHwnd)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click

        Try

            dtdob.Format = DateTimePickerFormat.Custom
            dtdob.CustomFormat = "yyyy-MM-dd"

            If cbodesignation.Text = "" Then
                MsgBox("Select department")
                cbodesignation.Focus()
                Exit Sub
            End If

            If cbocountry.Text = "" Then
                MsgBox("Type in or select a country")
                cbocountry.Focus()
                Exit Sub
            End If

            emp.checkEmp()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnload_Click(sender As Object, e As EventArgs) Handles btnload.Click
        Try

            Dim result As DialogResult = OpenFile.ShowDialog
            If result = DialogResult.OK Then
                If (OpenFile.FileName IsNot Nothing) Or (OpenFile.FileName <> String.Empty) Then

                    picguest.Image = Image.FromFile(OpenFile.FileName)
                    txtpicname.Text = OpenFile.FileName

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnstart_Click(sender As Object, e As EventArgs) Handles btnstart.Click
        Try
            DeviceID = lstDevices.SelectedIndex
            OpenPreviewWindow()
            Dim bReturn As Boolean
            Dim s As CAPSTATUS
            bReturn = SendMessage(hHwnd, WM_CAP_GET_STATUS, Marshal.SizeOf(s), s)
            Debug.WriteLine(String.Format("Video Size {0} x {1}", s.uiImageWidth, s.uiImageHeight))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnimagesave_Click(sender As Object, e As EventArgs) Handles btnimagesave.Click
        Try
            Dim data As IDataObject = Clipboard.GetDataObject()
            Dim bmap As Bitmap

            '
            ' Copy image to clipboard
            '
            SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)
            '
            ' Get image from clipboard and convert it to a bitmap
            '
            If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
                bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Bitmap)
                picguest.Image = bmap
                ClosePreviewWindow()

                btnstart.Enabled = True

                Trace.Assert(Not (bmap Is Nothing))
                If sfdImage.ShowDialog = DialogResult.OK Then
                    bmap.Save(sfdImage.FileName, Imaging.ImageFormat.Jpeg)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Try
            emp.ClearData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        Try
            ClosePreviewWindow()
            btnimagesave.Enabled = False
            btnstart.Enabled = True
            btnStop.Enabled = False
            picguest.Image = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtbasSal_SizeChanged(sender As Object, e As EventArgs) Handles txtbasSal.SizeChanged
        Try
            txtbasSal.Text = Format(txtbasSal.Text, "Standard")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtAllowa_Leave(sender As Object, e As EventArgs) Handles txtAllowa.Leave
        Try
            txtAllowa.Text = Format(txtAllowa.Text, "Standard")
        Catch ex As Exception

        End Try
    End Sub
End Class
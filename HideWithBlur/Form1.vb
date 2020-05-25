Public Class Form1
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            Const CS_NOCLOSE As Integer = &H200
            cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
            Return cp
        End Get
    End Property

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim k As Integer = Me.Handle
        Me.WindowState = Windows.Forms.FormWindowState.Maximized
        NativeHelper.SetWindowPos(k, NativeHelper.HWND_TOPMOST, Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, NativeHelper.SWP_NOMOVE Or NativeHelper.SWP_NOSIZE Or NativeHelper.SWP_NOREDRAW Or NativeHelper.SWP_DEFERERASE)
        Aero.SetAero10(k)
        Dim o As New KeyBoardHooking
        o.HookKeyboard()
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        ' Listen for operating system messages
        If (m.Msg) = &H2 Then 'destroy
            ' The WM_ACTIVATEAPP message occurs when the application
            '   While True
            ' MessageBox.Show("Destroy")
            ' End While

            Process.Start(Application.ExecutablePath)
        ElseIf m.Msg = &H10 Then
            ' MessageBox.Show("Close")

            '
            '   Process.Start(Application.ExecutablePath)
        ElseIf m.Msg = &HF Then 'paint

            '    MessageBox.Show("Sir !")

        End If
        MyBase.WndProc(m)
    End Sub







End Class

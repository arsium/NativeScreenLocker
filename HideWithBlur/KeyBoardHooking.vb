Public Class KeyBoardHooking

    'https://www.daniweb.com/programming/software-development/threads/420235/disabling-windows-key-in-vb-net

    Private Const WM_KEYDOWN As Short = &H100S
    Private Const WM_SYSKEYDOWN As Integer = &H104

    Public Structure KBDLLHOOKSTRUCT
        Public vkCode As Integer
        Public scanCode As Integer
        Public flags As Integer
        Public time As Integer
        Public dwExtraInfo As Integer
    End Structure
    Private Declare Function UnhookWindowsHookEx Lib "user32" (ByVal hHook As Integer) As Integer
    Private Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" (ByVal idHook As Integer, ByVal lpfn As KeyboardHookDelegate, ByVal hmod As Integer, ByVal dwThreadId As Integer) As Integer

    Private Declare Function CallNextHookEx Lib "user32" (ByVal hHook As Integer, ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As KBDLLHOOKSTRUCT) As Integer
    Private Delegate Function KeyboardHookDelegate(ByVal Code As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer
    '  Private KeyboardHandle As IntPtr = 0 'Handle of the hook
    Private callback As KeyboardHookDelegate
    '  Return KeyboardHandle <> 0 'If KeyboardHandle = 0 it means that it isn't hooked so return false, otherwise return true
    ' End Function
    Public Sub HookKeyboard()
        callback = New KeyboardHookDelegate(AddressOf KeyboardCallback)
        '  KeyboardHandle = SetWindowsHookEx(13, callback, Process.GetCurrentProcess.MainModule.BaseAddress, 0)

        SetWindowsHookEx(13, callback, Process.GetCurrentProcess.MainModule.BaseAddress, 0)
        ''  If KeyboardHandle <> 0 Then
        '' Debug.Write(vbCrLf & "[Keyboard Hooked]" & vbCrLf)
        ''   End If
    End Sub
    Public Sub UnhookKeyboard()

        '   UnhookWindowsHookEx(KeyboardHandle)
        '     KeyboardHandle = 0 ' unhooked 

    End Sub
    Public Function KeyboardCallback(ByVal Code As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer

        Dim Key = lParam.vkCode

        If wParam = WM_KEYDOWN Or wParam = WM_SYSKEYDOWN Then
            'If we can block events
            If Code >= 0 Then
                If Key = 91 Or Key = 92 Then
                    Return 1 'Block event
                End If
            End If
        End If

        'Return CallNextHookEx(KeyboardHandle, Code, wParam, lParam) 'Let event go to the other applications
    End Function
End Class

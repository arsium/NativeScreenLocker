Imports System.Runtime.InteropServices

Public Class NativeHelper
    <DllImport("user32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Int32, ByVal Y As Int32, ByVal cx As Int32, ByVal cy As Int32, ByVal uFlags As Int32) As Boolean
    End Function

    Public Const HWND_BOTTOM = 1

    Public Const HWND_NOTOPMOST = -2

    Public Const HWND_TOP = 0

    Public Const HWND_TOPMOST = -1


    Public Const SWP_NOSIZE As Int32 = &H1
    Public Const SWP_NOMOVE As Int32 = &H2
    Public Const SWP_NOREDRAW As Int32 = &H8

    Public Const SWP_DEFERERASE As Int32 = &H2000
End Class

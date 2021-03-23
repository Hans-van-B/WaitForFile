Module Glob
    Public AppName As String = "WaitForFile"
    Public AppVer As String = "0.03"
    Public Temp As String = Environment.GetEnvironmentVariable("TEMP")

    Public LogFile As String = Temp & "\" & AppName & ".log"
    Public Verbose As Boolean = False
    Public CTrace As Integer = 1        ' Console Trace Level
    Public ErrorCount As Integer = 0

    Public Delay As Integer = 2
    Public FileName As String = "X"
    Public FileGo As Boolean = True     ' Wait for file to go
    Public MaxWait As Integer = 0
    Public ExitProgram As Boolean = False
End Module

Module Log
    Sub xtrace_init()
        My.Computer.FileSystem.WriteAllText(LogFile, "xtrace_init" & vbNewLine, False)
        xtrace(AppName & " V" & AppVer, 1)
    End Sub

    '---- xtrace
    Sub xtrace(Msg As String)
        My.Computer.FileSystem.WriteAllText(LogFile, Msg & vbNewLine, True)
    End Sub

    Sub xtrace(Msg As String, TV As Integer)
        If TV <= CTrace Then
            Console.Write(Msg & vbNewLine)
        End If

        xtrace(Msg)
    End Sub

    '---- xtrace_i
    Sub xtrace_i(Msg As String)
        xtrace(" * " & Msg)
    End Sub

    Sub xtrace_i(Msg As String, TV As Integer)
        xtrace(" * " & Msg, TV)
    End Sub

    '---- xtrace_err
    Sub xtrace_err(Msg As String)
        xtrace("ERROR: " & Msg)
        Console.WriteLine("ERROR: " & Msg)
        ErrorCount = ErrorCount + 1
    End Sub
End Module

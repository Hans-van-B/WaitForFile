Module CommandLineArg
    Sub Read_XCommand_Line_Arg()
        xtrace("Read_XCommand_Line_Arg")

        Dim SwName As String = ""
        Dim SwString As String = ""
        Dim P1 As Integer
        Dim Name As String
        Dim ValS As String

        For Each argument As String In My.Application.CommandLineArgs
            xtrace_i("Argument=""" & argument & """")

            '---- Double-dash arguments
            If Left(argument, 2) = "--" Then
                SwName = Mid(argument, 3)
                xtrace_i("DDA:" & SwName)

                ' Assign
                P1 = InStr(argument, "=")
                If P1 > 0 Then
                    Name = Left(argument, P1 - 1)
                    ValS = Mid(argument, P1 + 1)

                    If Name = "wt" Then
                        Delay = Val(ValS) * 1000
                        xtrace_i("Set Delay = " & Delay.ToString)
                    End If

                    If Name = "F" Then
                        FileName = ValS
                        xtrace_i("Set FileName = " & FileName)
                    End If

                Else    ' No assign
                    If SwName = "help" Then
                        xtrace_i("Call Help")
                        Help()
                        ExitProgram = True
                    End If


                End If

                    Continue For
            End If

            '---- Single-dash arguments
            If Left(argument, 1) = "-" Then
                ' Switch String = remaining switches
                SwString = Mid(argument, 2)

                ' for each switch in the string
                While Len(SwString) > 0
                    SwName = Left(SwString, 1)
                    SwString = Mid(SwString, 2)
                    xtrace_i("SDA:" & SwName & "," & SwString)

                    If SwName = "v" Then
                        xtrace_i("Set verbose = True")
                        Console.WriteLine("Log file = " & LogFile)
                        Verbose = True
                    End If

                    If SwName = "h" Then
                        Help()
                        ExitProgram = True
                    End If
                End While

                Continue For
            End If

            '---- Else (No dashes)
            P1 = InStr(argument, "=")
            If P1 > 0 Then
                Name = Left(argument, P1 - 1)
                ValS = Mid(argument, P1 + 1)
                xtrace_i("NDA: """ & Name & "=" & ValS & """")

                If Name = "F" Then
                    FileName = ValS.Replace("""", "").Trim
                    xtrace_i("Set ProcName = " & FileName)
                End If

                If Name = "wt" Then
                    Delay = Val(ValS)
                    xtrace_i("Set Delay = " & Delay.ToString)
                End If

                If Name = "mw" Then
                    MaxWait = Val(ValS)
                    xtrace_i("Set MaxWait = " & MaxWait.ToString)
                End If

                If Name = "go" Then
                    If UCase(ValS) = "TRUE" Then
                        FileGo = True
                        xtrace_i("Set FileGo = " & FileGo.ToString)
                    End If

                    If UCase(ValS) = "FALSE" Then
                        FileGo = False
                        xtrace_i("Set FileGo = " & FileGo.ToString)
                    End If

                    MaxWait = Val(ValS)
                    xtrace_i("Set MaxWait = " & MaxWait.ToString)
                End If

            End If

            If argument = "/?" Then
                Help()
                ExitProgram = True
            End If
        Next

    End Sub
End Module

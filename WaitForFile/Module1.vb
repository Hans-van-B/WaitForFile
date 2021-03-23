Module Module1

    Sub Main()
        Dim Waiting As Boolean = True
        Dim Count As Integer = 0

        xtrace_init()

        Read_XCommand_Line_Arg()
        If ExitProgram Then Exit Sub

        If FileName = "X" Then
            xtrace_err("File name is not defined (F=Name)")
            Help()
            Exit Sub
        End If

        While Waiting
            Count = Count + 1
            wait(Delay)

            If (Count > MaxWait) And (MaxWait > 0) Then
                xtrace("MaxWait exceeded", 1)
                Exit While
            End If

            If Verbose Then
                xtrace("-------------------------------", 2)
                xtrace("Waiting " & Count.ToString, 1)
            Else
                xtrace("Waiting " & Count.ToString, 1)
            End If


            If My.Computer.FileSystem.FileExists(FileName) Then
                If Verbose Then xtrace_i("File exists", 1)

                If Not FileGo Then
                    Waiting = False
                    xtrace("File has been created", 1)
                End If

            Else
                If Verbose Then xtrace_i("File does not exist", 1)

                If FileGo Then
                    Waiting = False
                    xtrace("File is gone", 1)
                End If

            End If
        End While

    End Sub

End Module

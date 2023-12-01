Module mdlPrincipal
    Public diretorio, SQL As String
    Public db As New ADODB.Connection
    Public rs As New ADODB.Recordset
    Public caminho = Application.StartupPath & "\database\banco.mdb"
    Public cont, aux As Integer
    Public auxCPF, resp, auxHorario, auxData, auxEspec As String

    Sub conectar_banco()
        Try
            db = CreateObject("ADODB.Connection")
            db.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & caminho & "")
            MsgBox("Seja Bem-Vindo!!!", MsgBoxStyle.Information + vbOKOnly, "ATENCAO")
        Catch ex As Exception
            MsgBox("Conexao falhou", MsgBoxStyle.Information + vbOKOnly, "ATENCAO")
        End Try
    End Sub
End Module

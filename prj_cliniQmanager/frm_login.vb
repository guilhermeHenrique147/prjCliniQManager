Public Class frm_login

    Private Sub btn_entrar_Click(sender As Object, e As EventArgs) Handles btn_entrar.Click
        Try
            SQL = "Select * from tb_usuarios where cpf='" & txt_login.Text & "' and senha='" & txt_senha.Text & "'"
            rs = db.Execute(SQL)
            If rs.EOF = True Then
                MsgBox("Login ou Senha Incorretos!!!!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
            Else
                If rs.Fields(3).Value = "admin" Then
                    MsgBox("Login realizado com sucesso!!!!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
                    frm_menuAdmin.Show()
                    limpaCampos()
                    Hide()
                Else
                    MsgBox("Login realizado com sucesso!!!!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
                    frm_menuAtendente.Show()
                    limpaCampos()
                    Hide()
                End If
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar logar!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
        End Try
    End Sub

    Private Sub frm_login_Load(sender As Object, e As EventArgs) Handles Me.Load
        conectar_banco()
    End Sub

    Private Sub limpaCampos()
        txt_login.Clear()
        txt_senha.Clear()
    End Sub
End Class

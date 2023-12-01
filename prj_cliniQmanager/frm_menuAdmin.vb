Public Class frm_menuAdmin
    Private Sub btn_sair_Click(sender As Object, e As EventArgs) Handles btn_sair.Click
        frm_login.Show()
        Hide()
    End Sub

    Private Sub btn_funcionarios_Click(sender As Object, e As EventArgs) Handles btn_funcionarios.Click
        frm_funcionarios.Show()
        Hide()
    End Sub

    Private Sub btn_medicos_Click(sender As Object, e As EventArgs) Handles btn_medicos.Click
        frm_medicos.Show()
        Hide()
    End Sub
End Class
Public Class frm_menuAtendente
    Private Sub btn_pacientes_Click(sender As Object, e As EventArgs) Handles btn_pacientes.Click
        frm_pacientes.Show()
        Hide()
    End Sub

    Private Sub btn_sair_Click(sender As Object, e As EventArgs) Handles btn_sair.Click
        frm_login.Show()
        Hide()
    End Sub

    Private Sub btn_consultas_Click(sender As Object, e As EventArgs) Handles btn_consultas.Click
        frm_consultas.Show()
        Hide()
    End Sub
End Class
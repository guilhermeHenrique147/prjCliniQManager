Public Class frm_medicos
    Private Sub frm_medicos_Load(sender As Object, e As EventArgs) Handles Me.Load
        conectar_banco()
        carrega_dgv_dados()
    End Sub
    Private Sub limpar_campos()
        txt_crm.Clear()
        txt_nome.Clear()
        txt_especialidade.Clear()
        txt_crm.Focus()
    End Sub
    Private Sub btn_limpar_Click(sender As Object, e As EventArgs) Handles btn_limpar.Click
        limpar_campos()
    End Sub

    Private Sub btn_sair_Click(sender As Object, e As EventArgs) Handles btn_sair.Click
        frm_menuAdmin.Show()
        Hide()
    End Sub

    Private Sub carrega_dgv_dados()
        Try
            SQL = "select * from tb_medico order by nome asc"
            rs = db.Execute(SQL)
            With dgv_dados
                cont = 1
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(cont, rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value)
                    rs.MoveNext()
                    cont = cont + 1
                Loop
            End With
        Catch ex As Exception
            MsgBox("Erro ao carregar dados", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERRO")
        End Try
    End Sub

    Private Sub dgv_dados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_dados.CellContentClick
        Try
            With dgv_dados
                If .CurrentRow.Cells(4).Selected = True Then
                    auxCPF = .CurrentRow.Cells(1).Value
                    SQL = "Select * from tb_medico where crm='" & auxCPF & "'"
                    rs = db.Execute(SQL)
                    If rs.EOF = False Then
                        resp = MsgBox("Deseja Realmente excluir?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Atencao")
                        If resp = MsgBoxResult.Yes Then
                            SQL = "delete * from tb_medico where crm='" & auxCPF & "'"
                            rs = db.Execute(SQL)
                            limpar_campos()
                        End If
                        limpar_campos()
                    End If
                Else
                    Exit Sub
                End If
                carrega_dgv_dados()
            End With
        Catch ex As Exception
            MsgBox("Erro de processamento: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENCAO")
        End Try
    End Sub

    Private Sub btn_gravar_Click(sender As Object, e As EventArgs) Handles btn_gravar.Click
        Try
            SQL = "Select * from tb_medico where crm='" & txt_crm.Text & "'"
            rs = db.Execute(SQL)
            If rs.EOF = True Then
                SQL = "Insert into tb_medico values('" & txt_crm.Text & "', '" & txt_nome.Text & "', '" & txt_especialidade.Text & "')"
                rs = db.Execute(UCase(SQL))
                MsgBox("Dados gravados com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
            Else
                SQL = "update tb_medico set nome='" & txt_nome.Text & "', especialidade='" & txt_especialidade.Text & "' where cpf='" & txt_crm.Text & "'"
                rs = db.Execute(UCase(SQL))
                MsgBox("Dados atualizados com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
            End If
            carrega_dgv_dados()
            limpar_campos()
        Catch ex As Exception
            MsgBox("Erro ao gravar os dados", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
        End Try
    End Sub

    Private Sub txt_crm_LostFocus(sender As Object, e As EventArgs) Handles txt_crm.LostFocus
        Try
            SQL = "Select * from tb_medico where crm='" & txt_crm.Text & "'"
            rs = db.Execute(SQL)
            If rs.EOF = False Then
                txt_nome.Text = rs.Fields(1).Value
                txt_especialidade.Text = rs.Fields(2).Value
            Else
                txt_nome.Focus()
            End If
        Catch ex As Exception
            MsgBox("Erro", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
        End Try
    End Sub
    Private Sub txt_pesquisa_TextChanged(sender As Object, e As EventArgs) Handles txt_pesquisa.TextChanged
        Try
            SQL = "select * from tb_medico where especialidade like '" & txt_pesquisa.Text & "%'"
            rs = db.Execute(SQL)
            With dgv_dados
                cont = 1
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(cont, rs.Fields(0).Value, rs.Fields(1).Value, rs.Fields(2).Value)
                    rs.MoveNext()
                    cont = cont + 1
                Loop
            End With
        Catch ex As Exception
            MsgBox("Erro ao pesquisar dados", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERRO")
        End Try
    End Sub
End Class
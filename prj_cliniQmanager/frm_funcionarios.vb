Public Class frm_funcionarios
    Private Sub frm_funcionarios_Load(sender As Object, e As EventArgs) Handles Me.Load
        conectar_banco()
        limpar_campos()
        carrega_dgvdados()
    End Sub

    Private Sub limpar_campos()
        txt_cpf.Clear()
        txt_senha.Clear()
        txt_status.Clear()
        txt_nome.Clear()
        cmb_data.Value = Now
    End Sub
    Private Sub carrega_dgvdados()
        Try
            SQL = "select * from tb_usuarios order by nome asc"
            rs = db.Execute(SQL)
            With dgv_dados
                cont = 1
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(cont, rs.Fields(1).Value, rs.Fields(4).Value, Nothing, Nothing)
                    rs.MoveNext()
                    cont = cont + 1
                Loop
            End With
        Catch ex As Exception
            MsgBox("Erro ao carregar dados", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERRO")
        End Try
    End Sub

    Private Sub txt_pesquisa_TextChanged(sender As Object, e As EventArgs) Handles txt_pesquisa.TextChanged
        Try
            SQL = "select * from tb_usuarios where cpf like '" & txt_pesquisa.Text & "%'"
            rs = db.Execute(SQL)
            With dgv_dados
                cont = 1
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(cont, rs.Fields(1).Value, rs.Fields(4).Value, Nothing, Nothing)
                    rs.MoveNext()
                    cont = cont + 1
                Loop
            End With
        Catch ex As Exception
            MsgBox("Erro ao pesquisar dados", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERRO")
        End Try
    End Sub

    Private Sub dgv_dados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_dados.CellContentClick
        Try
            With dgv_dados
                If .CurrentRow.Cells(3).Selected = True Then
                    auxCPF = .CurrentRow.Cells(1).Value
                    SQL = "Select * from tb_usuarios where cpf='" & auxCPF & "'"
                    rs = db.Execute(SQL)
                    If rs.EOF = False Then
                        TabControl1.SelectTab(0) 'explorando a aba dados pessoais
                        txt_cpf.Text = rs.Fields(1).Value
                        txt_senha.Text = rs.Fields(2).Value
                        txt_status.Text = rs.Fields(3).Value
                        txt_nome.Text = rs.Fields(4).Value
                        cmb_data.Value = rs.Fields(5).Value
                    End If
                ElseIf .CurrentRow.Cells(4).Selected = True Then
                    auxCPF = .CurrentRow.Cells(1).Value
                    SQL = "Select * from tb_usuarios where cpf='" & auxCPF & "'"
                    rs = db.Execute(SQL)
                    If rs.EOF = False Then
                        resp = MsgBox("Deseja Realmente excluir?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Atencao")
                        If resp = MsgBoxResult.Yes Then
                            SQL = "delete * from tb_usuarios where cpf='" & auxCPF & "'"
                            rs = db.Execute(SQL)
                            limpar_campos()
                        End If
                        limpar_campos()
                    End If
                Else
                    Exit Sub
                End If
                carrega_dgvdados()
            End With
        Catch ex As Exception
            MsgBox("Erro de processamento", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENCAO")
        End Try
    End Sub

    Private Sub btn_limpar_Click(sender As Object, e As EventArgs) Handles btn_limpar.Click
        limpar_campos()
    End Sub

    Private Sub txt_cpf_LostFocus(sender As Object, e As EventArgs) Handles txt_cpf.LostFocus
        Try
            SQL = "Select * from tb_usuarios where cpf='" & txt_cpf.Text & "'"
            rs = db.Execute(SQL)
            If rs.EOF = False Then
                txt_senha.Text = rs.Fields(2).Value
                txt_status.Text = rs.Fields(3).Value
                txt_nome.Text = rs.Fields(4).Value
                cmb_data.Value = rs.Fields(5).Value
            Else
                txt_nome.Focus()
            End If
        Catch ex As Exception
            MsgBox("Erro", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
        End Try
    End Sub

    Private Sub btn_gravar_Click(sender As Object, e As EventArgs) Handles btn_gravar.Click
        Try
            SQL = "Select * from tb_usuarios where cpf='" & txt_cpf.Text & "'"
            rs = db.Execute(SQL)
            If rs.EOF = True Then
                SQL = "Insert into tb_usuarios (cpf, senha, status, nome, dataNasc) values('" & txt_cpf.Text & "', '" & txt_senha.Text & "', '" & txt_status.Text & "', '" & txt_nome.Text & "', '" & cmb_data.Value.Date & "')"
                rs = db.Execute(UCase(SQL))
                MsgBox("Dados gravados com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
            Else
                SQL = "update tb_usuarios set senha='" & txt_senha.Text & "', status='" & txt_status.Text & "', nome='" & txt_nome.Text & "', dataNasc='" & cmb_data.Value.Date & "', where cpf='" & txt_cpf.Text & "'"
                rs = db.Execute(UCase(SQL))
                MsgBox("Dados atualizados com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
            End If
            carrega_dgvdados()
            limpar_campos()
        Catch ex As Exception
            MsgBox("Erro ao gravar os dados", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
        End Try
    End Sub

    Private Sub btn_voltar_Click(sender As Object, e As EventArgs) Handles btn_voltar.Click
        frm_menuAdmin.Show()
        Hide()
    End Sub
End Class
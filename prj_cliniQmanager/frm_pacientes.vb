Public Class frm_pacientes
    Private Sub frm_pacientes_Load(sender As Object, e As EventArgs) Handles Me.Load
        conectar_banco()
        limpar_campos()
        carrega_dados()
    End Sub
    Private Sub btn_voltar_Click(sender As Object, e As EventArgs) Handles btn_voltar.Click
        frm_menuAtendente.Show()
        limpar_campos()
        carrega_dados()
        Hide()
    End Sub

    Private Sub txt_cep_LostFocus(sender As Object, e As EventArgs) Handles txt_cep.LostFocus
        Try
            SQL = "Select * from tb_cep where cep='" & txt_cep.Text & "'"
            rs = db.Execute(SQL)
            If rs.EOF = False Then
                txt_rua.Text = rs.Fields(1).Value
                txt_cidade.Text = rs.Fields(2).Value
                txt_bairro.Text = rs.Fields(3).Value
                txt_uf.Text = rs.Fields(4).Value
            Else
                txt_num.Focus()
            End If
        Catch ex As Exception
            MsgBox("Erro", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
        End Try
    End Sub

    Private Sub txt_cpf_LostFocus(sender As Object, e As EventArgs) Handles txt_cpf.LostFocus
        Try
            SQL = "Select * from tb_clientes where CPF='" & txt_cpf.Text & "'"
            rs = db.Execute(SQL)
            If rs.EOF = False Then
                txt_nome.Text = rs.Fields(1).Value
                cmb_data.Value = rs.Fields(2).Value
                txt_estado.Text = rs.Fields(3).Value
                txt_nacionalidade.Text = rs.Fields(4).Value
                txt_rua.Text = rs.Fields(5).Value
                txt_num.Text = rs.Fields(6).Value
                txt_bairro.Text = rs.Fields(7).Value
                txt_cidade.Text = rs.Fields(8).Value
                txt_uf.Text = rs.Fields(9).Value
                txt_cep.Text = rs.Fields(10).Value
            Else
                txt_nome.Focus()
            End If
        Catch ex As Exception
            MsgBox("Erro", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
        End Try
    End Sub

    Private Sub btn_gravar_Click(sender As Object, e As EventArgs) Handles btn_gravar.Click
        Try
            SQL = "Select * from tb_clientes where CPF='" & txt_cpf.Text & "'"
            rs = db.Execute(SQL)
            If rs.EOF = True Then
                SQL = "Insert into tb_clientes values('" & txt_cpf.Text & "', '" & txt_nome.Text & "', '" & cmb_data.Value.Date & "', '" & txt_estado.Text & "', '" & txt_nacionalidade.Text & "', '" & txt_rua.Text & "', '" & txt_num.Text & "', '" & txt_bairro.Text & "', '" & txt_cidade.Text & "', '" & txt_uf.Text & "', '" & txt_cep.Text & "')"
                rs = db.Execute(UCase(SQL))
                MsgBox("Dados gravados com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
            Else
                SQL = "update tb_clientes set NOME='" & txt_nome.Text & "', DATANASC='" & cmb_data.Value.Date & "', ESTADOCIVIL='" & txt_estado.Text & "', NACIONALIDADE='" & txt_nacionalidade.Text & "', RUA='" & txt_rua.Text & "', NUMERO='" & txt_num.Text & "', BAIRRO='" & txt_bairro.Text & "', CIDADE='" & txt_cidade.Text & "', UF='" & txt_uf.Text & "', CEP='" & txt_cep.Text & "' where cpf='" & txt_cpf.Text & "'"
                rs = db.Execute(UCase(SQL))
                MsgBox("Dados atualizados com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
            End If
            carrega_dados()
            limpar_campos()
        Catch ex As Exception
            MsgBox("Erro ao gravar os dados", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
        End Try
    End Sub

    Sub carrega_dados()
        Try
            SQL = "select * from tb_clientes order by nome asc"
            rs = db.Execute(SQL)
            With dgv_dados
                cont = 1
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(cont, rs.Fields(0).Value, rs.Fields(1).Value, Nothing, Nothing)
                    rs.MoveNext()
                    cont = cont + 1
                Loop
            End With
        Catch ex As Exception
            MsgBox("Erro ao carregar dados", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERRO")
        End Try
    End Sub

    Sub limpar_campos()
        txt_cpf.Clear()
        txt_nome.Clear()
        cmb_data.Value = Now
        txt_estado.Clear()
        txt_nacionalidade.Clear()
        txt_rua.Clear()
        txt_num.Clear()
        txt_bairro.Clear()
        txt_cidade.Clear()
        txt_uf.Clear()
        txt_cep.Clear()
        txt_cpf.Focus()
    End Sub

    Private Sub txt_pesquisa_TextChanged(sender As Object, e As EventArgs) Handles txt_pesquisa.TextChanged
        Try
            SQL = "select * from tb_clientes where CPF like '" & txt_pesquisa.Text & "%'"
            rs = db.Execute(SQL)
            With dgv_dados
                cont = 1
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(cont, rs.Fields(0).Value, rs.Fields(1).Value, Nothing, Nothing)
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
                    auxCpf = .CurrentRow.Cells(1).Value
                    SQL = "Select * from tb_clientes where CPF='" & auxCPF & "'"
                    rs = db.Execute(SQL)
                    If rs.EOF = False Then
                        TabControl1.SelectTab(0) 'explorando a aba dados pessoais
                        txt_cpf.Text = rs.Fields(0).Value
                        txt_nome.Text = rs.Fields(1).Value
                        cmb_data.Value = rs.Fields(2).Value
                        txt_estado.Text = rs.Fields(3).Value
                        txt_nacionalidade.Text = rs.Fields(4).Value
                        txt_rua.Text = rs.Fields(5).Value
                        txt_num.Text = rs.Fields(6).Value
                        txt_bairro.Text = rs.Fields(7).Value
                        txt_cidade.Text = rs.Fields(8).Value
                        txt_uf.Text = rs.Fields(9).Value
                        txt_cep.Text = rs.Fields(10).Value
                    End If
                ElseIf .CurrentRow.Cells(4).Selected = True Then
                    auxCpf = .CurrentRow.Cells(1).Value
                    SQL = "Select * from tb_clientes where CPF='" & auxCPF & "'"
                    rs = db.Execute(SQL)
                    If rs.EOF = False Then
                        resp = MsgBox("Deseja Realmente excluir?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Atencao")
                        If resp = MsgBoxResult.Yes Then
                            SQL = "delete * from tb_clientes where cpf='" & auxCPF & "'"
                            rs = db.Execute(SQL)
                            limpar_campos()
                        End If
                        limpar_campos()
                    End If
                Else
                    Exit Sub
                End If
                carrega_dados()
            End With
        Catch ex As Exception
            MsgBox("Erro de processamento", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENCAO")
        End Try
    End Sub

    Private Sub btn_limpar_Click(sender As Object, e As EventArgs) Handles btn_limpar.Click
        limpar_campos()
    End Sub
End Class

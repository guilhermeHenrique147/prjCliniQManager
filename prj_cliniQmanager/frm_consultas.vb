Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class frm_consultas
    Private Sub frm_consultas_Load(sender As Object, e As EventArgs) Handles Me.Load
        conectar_banco()
        carrega_combo()
        carrega_esp()
        carrega_dgvConsulta()
        carrega_dgvPaciente()
        cmb_medico.Items.Clear()
        cmb_consulta.Items.Clear()
    End Sub
    Private Sub btn_voltar_Click(sender As Object, e As EventArgs) Handles btn_voltar.Click
        frm_menuAtendente.Show()
        Hide()
    End Sub
    Sub carrega_dgvConsulta()
        Try
            SQL = "select * from tb_consulta order by idConsulta asc"
            rs = db.Execute(SQL)
            With dgv_consultas
                cont = 1
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(cont, rs.Fields(1).Value, rs.Fields(2).Value, rs.Fields(3).Value, rs.Fields(4).Value, Nothing)
                    rs.MoveNext()
                    cont = cont + 1
                Loop
            End With
        Catch ex As Exception
            MsgBox("Erro ao carregar dados", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERRO")
        End Try
    End Sub
    Private Sub txt_especialidade_TextChanged(sender As Object, e As EventArgs) Handles txt_especialidade.TextChanged
        Try
            SQL = "select * from tb_consulta where especialidade like '" & txt_especialidade.Text & "%'"
            rs = db.Execute(SQL)
            With dgv_consultas
                cont = 1
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(cont, rs.Fields(1).Value, rs.Fields(2).Value, rs.Fields(3).Value, rs.Fields(4).Value, Nothing)
                    rs.MoveNext()
                    cont = cont + 1
                Loop
            End With
        Catch ex As Exception
            MsgBox("Erro ao pesquisar dados", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERRO")
        End Try
    End Sub
    Private Sub dgv_consultas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_consultas.CellContentClick
        Try
            With dgv_consultas
                If .CurrentRow.Cells(5).Selected = True Then
                    auxCPF = .CurrentRow.Cells(2).Value
                    SQL = "Select * from tb_consulta where medico='" & auxCPF & "'"
                    rs = db.Execute(SQL)
                    If rs.EOF = False Then
                        resp = MsgBox("Deseja Realmente excluir?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Atencao")
                        If resp = MsgBoxResult.Yes Then
                            SQL = "delete * from tb_consulta where medico='" & auxCPF & "'"
                            rs = db.Execute(SQL)
                            limpar_campos()
                        End If
                        limpar_campos()
                    End If
                Else
                    Exit Sub
                End If
                carrega_dgvConsulta()
            End With
        Catch ex As Exception
            MsgBox("Erro de processamento: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENCAO")
        End Try
    End Sub
    '---------------------------------------------------------------------------------------------------------
    'DGVPaciente
    Sub carrega_dgvPaciente()
        Try
            SQL = "select * from tb_agendamento order by idAgendamento asc"
            rs = db.Execute(SQL)
            With dgv_paciente
                cont = 1
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(cont, rs.Fields(1).Value, rs.Fields(2).Value, rs.Fields(3).Value, rs.Fields(4).Value, Nothing)
                    rs.MoveNext()
                    cont = cont + 1
                Loop
            End With
        Catch ex As Exception
            MsgBox("Erro ao carregar dados", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERRO")
        End Try
    End Sub
    Private Sub txt_paciente_TextChanged(sender As Object, e As EventArgs) Handles txt_paciente.TextChanged
        Try
            SQL = "select * from tb_agendamento where cpf like '" & txt_paciente.Text & "%'"
            rs = db.Execute(SQL)
            With dgv_paciente
                cont = 1
                .Rows.Clear()
                Do While rs.EOF = False
                    .Rows.Add(cont, rs.Fields(1).Value, rs.Fields(2).Value, rs.Fields(3).Value, rs.Fields(4).Value, Nothing)
                    rs.MoveNext()
                    cont = cont + 1
                Loop
            End With
        Catch ex As Exception
            MsgBox("Erro ao pesquisar dados", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERRO")
        End Try
    End Sub
    Private Sub dgv_paciente_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_paciente.CellContentClick
        Try
            With dgv_paciente
                If .CurrentRow.Cells(5).Selected = True Then
                    auxCPF = .CurrentRow.Cells(1).Value
                    SQL = "Select * from tb_agendamento where cpf='" & auxCPF & "'"
                    rs = db.Execute(SQL)
                    If rs.EOF = False Then
                        resp = MsgBox("Deseja Realmente excluir?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Atencao")
                        If resp = MsgBoxResult.Yes Then
                            SQL = "delete * from tb_agendamento where cpf='" & auxCPF & "'"
                            rs = db.Execute(SQL)
                            limpar_campos()
                        End If
                        limpar_campos()
                    End If
                Else
                    Exit Sub
                End If
                carrega_dgvPaciente()
            End With
        Catch ex As Exception
            MsgBox("Erro de processamento: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ATENCAO")
        End Try
    End Sub

    'AGENDAR CONSULTAS
    '-----------------------------------------------------------------------------------------------------------
    Private Sub carrega_combo()
        Try
            SQL = "Select DISTINCT especialidade from tb_medico"
            rs = db.Execute(SQL)
            If rs.EOF = False Then
                cmb_especialidade.Items.Clear()
                Do While Not rs.EOF
                    cmb_especialidade.Items.Add(rs.Fields("especialidade").Value.ToString())
                    rs.MoveNext()
                Loop
            Else
            End If
        Catch ex As Exception
            MsgBox("Erro ao carregar especialidades", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
        End Try
    End Sub
    Private Sub cmb_especialidade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_especialidade.SelectedIndexChanged
        ' Chama a função para carregar os médicos com base na especialidade selecionada
        carrega_combo_medicos()
        PreencherComboBoxConsulta()
    End Sub

    Private Sub carrega_combo_medicos()
        Try
            SQL = "SELECT nome FROM tb_medico WHERE especialidade = '" & cmb_especialidade.Text & "'"
            rs = db.Execute(SQL)

            If Not rs.EOF Then
                cmb_medico.Items.Clear() ' Limpa os itens antigos da ComboBox

                Do While Not rs.EOF
                    cmb_medico.Items.Add(rs.Fields("nome").Value.ToString())
                    rs.MoveNext()
                Loop
            Else
                MsgBox("Não foram encontrados médicos para a especialidade selecionada.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENÇÃO")
            End If
        Catch ex As Exception
            MsgBox("Erro ao carregar médicos: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERRO")
        End Try
    End Sub
    'Private Sub cmb_medico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_medico.SelectedIndexChanged
    ' Quando o médico é alterado, preencher o ComboBox de consulta
    'PreencherComboBoxConsulta()
    'End Sub

    Private Sub PreencherComboBoxConsulta()
        Try
            SQL = "SELECT data, hora FROM tb_consulta WHERE especialidade = '" & cmb_especialidade.Text & "' and medico ='" & cmb_medico.Text & "'"
            rs = db.Execute(SQL)

            If Not rs.EOF Then
                cmb_consulta.Items.Clear() ' Limpa os itens antigos da ComboBox
                cmb_hora.Items.Clear() ' Limpa os itens antigos da ComboBox

                Do While Not rs.EOF
                    cmb_consulta.Items.Add(rs.Fields("data").Value.ToString())
                    cmb_hora.Items.Add(rs.Fields("hora").Value.ToString())
                    rs.MoveNext()
                Loop
            Else
                MsgBox("Não foram encontrados médicos para a especialidade selecionada.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENÇÃO")
            End If
        Catch ex As Exception
            MsgBox("Erro ao carregar horarios: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERRO")
        End Try
    End Sub
    Private Sub btn_agendar_Click(sender As Object, e As EventArgs) Handles btn_agendar.Click
        Try
            SQL = "Insert into tb_agendamento (cpf,nome,medico,consulta) values ('" & txt_cpf.Text & "', '" & txt_nome.Text & "', '" & cmb_medico.Text & "', '" & cmb_consulta.Text & "')"
            rs = db.Execute(SQL)
            MsgBox("Dados gravados com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
            limpar_agendamentos()
            carrega_dgvConsulta()
            txt_cpf.Focus
        Catch ex As Exception
            MsgBox("Erro ao gravar os dados: " & ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
        End Try
    End Sub
    Sub limpar_agendamentos()
        txt_cpf.Clear()
        txt_nome.Clear()
        carrega_combo()
        cmb_medico.Items.Clear()
        cmb_consulta.Items.Clear()
    End Sub
    '-----------------------------------------------------------------------------------------------------------
    'CADASTRAR CONSULTAS
    '-----------------------------------------------------------------------------------------------------------
    Private Sub carrega_esp()
        Try
            SQL = "Select DISTINCT especialidade from tb_medico"
            rs = db.Execute(SQL)
            If rs.EOF = False Then
                cmb_esp.Items.Clear()
                Do While Not rs.EOF
                    cmb_esp.Items.Add(rs.Fields("especialidade").Value.ToString())
                    rs.MoveNext()
                Loop
            Else
            End If
        Catch ex As Exception
            MsgBox("Erro ao carregar especialidades", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
        End Try
    End Sub
    Private Sub cmb_esp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_esp.SelectedIndexChanged
        ' Chama a função para carregar os médicos com base na especialidade selecionada
        carrega_combo_medic(cmb_esp.Text)
    End Sub
    Private Sub carrega_combo_medic(especialidade As String)
        Try
            SQL = "SELECT nome FROM tb_medico WHERE especialidade = '" & especialidade & "'"
            rs = db.Execute(SQL)

            If Not rs.EOF Then
                cmb_med.Items.Clear() ' Limpa os itens antigos da ComboBox

                Do While Not rs.EOF
                    cmb_med.Items.Add(rs.Fields("nome").Value.ToString())
                    rs.MoveNext()
                Loop
            Else
                MsgBox("Não foram encontrados médicos para a especialidade selecionada.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENÇÃO")
            End If
        Catch ex As Exception
            MsgBox("Erro ao carregar médicos: " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERRO")
        End Try
    End Sub
    Private Sub btn_cadastrar_Click(sender As Object, e As EventArgs) Handles btn_cadastrar.Click
        Try
            SQL = "Insert into tb_consulta (especialidade,medico,data,horario,status) values ('" & cmb_esp.Text & "', '" & cmb_med.Text & "', '" & cmb_data.Value.Date & "', '" & txt_hora.Text & "' , 'Livre')"
            rs = db.Execute(UCase(SQL))
            limpar_campos()
            carrega_esp()
            MsgBox("Dados gravados com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
        Catch ex As Exception
            MsgBox("Erro ao gravar os dados: " & ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
        End Try
    End Sub
    Private Sub limpar_campos()
        cmb_esp.Items.Clear()
        cmb_med.Items.Clear()
        cmb_data.Value = Now
        txt_hora.Clear()
    End Sub

    Private Sub txt_cpf_LostFocus(sender As Object, e As EventArgs) Handles txt_cpf.LostFocus
        Try
            SQL = "Select * from tb_clientes where CPF='" & txt_cpf.Text & "'"
            rs = db.Execute(SQL)
            If rs.EOF = False Then
                txt_nome.Text = rs.Fields(1).Value
            End If
        Catch ex As Exception
            MsgBox("Erro", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ATENCAO")
        End Try
    End Sub

    Private Sub cmb_consulta_Click(sender As Object, e As EventArgs) Handles cmb_consulta.Click
        PreencherComboBoxConsulta()
    End Sub
    '-----------------------------------------------------------------------------------------------------------   
End Class
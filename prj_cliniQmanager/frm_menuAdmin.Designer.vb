<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_menuAdmin
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_menuAdmin))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_funcionarios = New System.Windows.Forms.Button()
        Me.btn_sair = New System.Windows.Forms.Button()
        Me.btn_medicos = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(364, 56)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(152, 88)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btn_funcionarios
        '
        Me.btn_funcionarios.BackColor = System.Drawing.Color.Cyan
        Me.btn_funcionarios.Image = CType(resources.GetObject("btn_funcionarios.Image"), System.Drawing.Image)
        Me.btn_funcionarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_funcionarios.Location = New System.Drawing.Point(333, 177)
        Me.btn_funcionarios.Name = "btn_funcionarios"
        Me.btn_funcionarios.Size = New System.Drawing.Size(217, 38)
        Me.btn_funcionarios.TabIndex = 1
        Me.btn_funcionarios.Text = "Gerenciamento Funcionarios"
        Me.btn_funcionarios.UseVisualStyleBackColor = False
        '
        'btn_sair
        '
        Me.btn_sair.BackColor = System.Drawing.Color.Crimson
        Me.btn_sair.Image = CType(resources.GetObject("btn_sair.Image"), System.Drawing.Image)
        Me.btn_sair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_sair.Location = New System.Drawing.Point(333, 336)
        Me.btn_sair.Name = "btn_sair"
        Me.btn_sair.Size = New System.Drawing.Size(217, 40)
        Me.btn_sair.TabIndex = 3
        Me.btn_sair.Text = "Sair"
        Me.btn_sair.UseVisualStyleBackColor = False
        '
        'btn_medicos
        '
        Me.btn_medicos.BackColor = System.Drawing.Color.Cyan
        Me.btn_medicos.Image = CType(resources.GetObject("btn_medicos.Image"), System.Drawing.Image)
        Me.btn_medicos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_medicos.Location = New System.Drawing.Point(333, 244)
        Me.btn_medicos.Name = "btn_medicos"
        Me.btn_medicos.Size = New System.Drawing.Size(217, 38)
        Me.btn_medicos.TabIndex = 4
        Me.btn_medicos.Text = "Gerenciamento Médicos"
        Me.btn_medicos.UseVisualStyleBackColor = False
        '
        'frm_menuAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(839, 432)
        Me.Controls.Add(Me.btn_medicos)
        Me.Controls.Add(Me.btn_sair)
        Me.Controls.Add(Me.btn_funcionarios)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "frm_menuAdmin"
        Me.Text = "frm_menuAdmin"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btn_funcionarios As Button
    Friend WithEvents btn_sair As Button
    Friend WithEvents btn_medicos As Button
End Class

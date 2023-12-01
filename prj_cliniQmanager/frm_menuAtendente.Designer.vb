<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_menuAtendente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_menuAtendente))
        Me.btn_pacientes = New System.Windows.Forms.Button()
        Me.btn_consultas = New System.Windows.Forms.Button()
        Me.btn_sair = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_pacientes
        '
        Me.btn_pacientes.BackColor = System.Drawing.Color.MediumTurquoise
        Me.btn_pacientes.Image = CType(resources.GetObject("btn_pacientes.Image"), System.Drawing.Image)
        Me.btn_pacientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_pacientes.Location = New System.Drawing.Point(316, 166)
        Me.btn_pacientes.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_pacientes.Name = "btn_pacientes"
        Me.btn_pacientes.Size = New System.Drawing.Size(239, 46)
        Me.btn_pacientes.TabIndex = 0
        Me.btn_pacientes.Text = "Gerenciamento de Pacientes"
        Me.btn_pacientes.UseVisualStyleBackColor = False
        '
        'btn_consultas
        '
        Me.btn_consultas.BackColor = System.Drawing.Color.MediumTurquoise
        Me.btn_consultas.Image = CType(resources.GetObject("btn_consultas.Image"), System.Drawing.Image)
        Me.btn_consultas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_consultas.Location = New System.Drawing.Point(316, 243)
        Me.btn_consultas.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_consultas.Name = "btn_consultas"
        Me.btn_consultas.Size = New System.Drawing.Size(239, 46)
        Me.btn_consultas.TabIndex = 1
        Me.btn_consultas.Text = "Gerenciamento de Consultas"
        Me.btn_consultas.UseVisualStyleBackColor = False
        '
        'btn_sair
        '
        Me.btn_sair.BackColor = System.Drawing.Color.Red
        Me.btn_sair.Image = CType(resources.GetObject("btn_sair.Image"), System.Drawing.Image)
        Me.btn_sair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_sair.Location = New System.Drawing.Point(316, 328)
        Me.btn_sair.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_sair.Name = "btn_sair"
        Me.btn_sair.Size = New System.Drawing.Size(239, 46)
        Me.btn_sair.TabIndex = 2
        Me.btn_sair.Text = "Sair"
        Me.btn_sair.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(361, 34)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(137, 92)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'frm_menuAtendente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(839, 432)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btn_sair)
        Me.Controls.Add(Me.btn_consultas)
        Me.Controls.Add(Me.btn_pacientes)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frm_menuAtendente"
        Me.Text = "Menu"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_pacientes As Button
    Friend WithEvents btn_consultas As Button
    Friend WithEvents btn_sair As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class

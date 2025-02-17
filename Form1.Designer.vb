<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        entrada = New MaskedTextBox()
        saida = New MaskedTextBox()
        Label1 = New Label()
        Label2 = New Label()
        Calcular = New Button()
        tabelatxtbox = New TextBox()
        tabela_label = New Label()
        GerenciaTabelas = New Button()
        SuspendLayout()
        ' 
        ' entrada
        ' 
        entrada.BorderStyle = BorderStyle.FixedSingle
        entrada.Location = New Point(24, 33)
        entrada.Mask = "00/00/0000 90:00"
        entrada.Name = "entrada"
        entrada.Size = New Size(107, 23)
        entrada.TabIndex = 0
        entrada.ValidatingType = GetType(Date)
        ' 
        ' saida
        ' 
        saida.BorderStyle = BorderStyle.FixedSingle
        saida.Location = New Point(24, 102)
        saida.Mask = "00/00/0000 90:00"
        saida.Name = "saida"
        saida.Size = New Size(107, 23)
        saida.TabIndex = 1
        saida.ValidatingType = GetType(Date)
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BorderStyle = BorderStyle.FixedSingle
        Label1.FlatStyle = FlatStyle.System
        Label1.Location = New Point(23, 13)
        Label1.Name = "Label1"
        Label1.Size = New Size(108, 17)
        Label1.TabIndex = 2
        Label1.Text = "Horário de entrada"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label2
        ' 
        Label2.BorderStyle = BorderStyle.FixedSingle
        Label2.Location = New Point(24, 76)
        Label2.Name = "Label2"
        Label2.Size = New Size(107, 23)
        Label2.TabIndex = 3
        Label2.Text = "Horário de saída"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Calcular
        ' 
        Calcular.Location = New Point(102, 131)
        Calcular.Name = "Calcular"
        Calcular.Size = New Size(178, 63)
        Calcular.TabIndex = 4
        Calcular.Text = "Calcular"
        Calcular.UseVisualStyleBackColor = True
        ' 
        ' tabelatxtbox
        ' 
        tabelatxtbox.BorderStyle = BorderStyle.FixedSingle
        tabelatxtbox.Font = New Font("Segoe UI", 12F)
        tabelatxtbox.Location = New Point(222, 37)
        tabelatxtbox.Name = "tabelatxtbox"
        tabelatxtbox.Size = New Size(45, 29)
        tabelatxtbox.TabIndex = 6
        tabelatxtbox.TextAlign = HorizontalAlignment.Center
        ' 
        ' tabela_label
        ' 
        tabela_label.AutoSize = True
        tabela_label.Location = New Point(194, 19)
        tabela_label.Name = "tabela_label"
        tabela_label.Size = New Size(104, 15)
        tabela_label.TabIndex = 5
        tabela_label.Text = "tabela selecionada"
        ' 
        ' GerenciaTabelas
        ' 
        GerenciaTabelas.Location = New Point(401, 56)
        GerenciaTabelas.Margin = New Padding(3, 2, 3, 2)
        GerenciaTabelas.Name = "GerenciaTabelas"
        GerenciaTabelas.Size = New Size(115, 44)
        GerenciaTabelas.TabIndex = 7
        GerenciaTabelas.Text = "Gerenciar"
        GerenciaTabelas.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(534, 302)
        Controls.Add(GerenciaTabelas)
        Controls.Add(tabelatxtbox)
        Controls.Add(tabela_label)
        Controls.Add(Calcular)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(saida)
        Controls.Add(entrada)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents entrada As MaskedTextBox
    Friend WithEvents saida As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Calcular As Button
    Friend WithEvents tabelatxtbox As TextBox
    Friend WithEvents tabela_label As Label
    Friend WithEvents GerenciaTabelas As Button
End Class

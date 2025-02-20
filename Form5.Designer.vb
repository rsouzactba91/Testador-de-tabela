<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
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
        lblpagamento = New Label()
        TxtPlaca = New TextBox()
        pagamento = New Button()
        SuspendLayout()
        ' 
        ' lblpagamento
        ' 
        lblpagamento.AutoSize = True
        lblpagamento.Location = New Point(70, 37)
        lblpagamento.Name = "lblpagamento"
        lblpagamento.Size = New Size(184, 15)
        lblpagamento.TabIndex = 0
        lblpagamento.Text = "Obtendo a placa para pagamento"
        ' 
        ' TxtPlaca
        ' 
        TxtPlaca.BorderStyle = BorderStyle.FixedSingle
        TxtPlaca.Location = New Point(82, 73)
        TxtPlaca.Name = "TxtPlaca"
        TxtPlaca.Size = New Size(162, 23)
        TxtPlaca.TabIndex = 1
        ' 
        ' pagamento
        ' 
        pagamento.Location = New Point(108, 129)
        pagamento.Name = "pagamento"
        pagamento.Size = New Size(115, 34)
        pagamento.TabIndex = 2
        pagamento.Text = "Pagar"
        pagamento.UseVisualStyleBackColor = True
        ' 
        ' Form5
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(311, 220)
        Controls.Add(pagamento)
        Controls.Add(TxtPlaca)
        Controls.Add(lblpagamento)
        Name = "Form5"
        Text = "Form5"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblpagamento As Label
    Friend WithEvents TxtPlaca As TextBox
    Friend WithEvents pagamento As Button
End Class

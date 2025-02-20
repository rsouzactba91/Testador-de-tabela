<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        dgvpatio = New DataGridView()
        placa = New DataGridViewTextBoxColumn()
        ticket = New DataGridViewTextBoxColumn()
        Entrada = New DataGridViewTextBoxColumn()
        Saida = New DataGridViewTextBoxColumn()
        ValorPago = New DataGridViewTextBoxColumn()
        CType(dgvpatio, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvpatio
        ' 
        dgvpatio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvpatio.Columns.AddRange(New DataGridViewColumn() {placa, ticket, Entrada, Saida, ValorPago})
        dgvpatio.Location = New Point(19, 12)
        dgvpatio.Name = "dgvpatio"
        dgvpatio.Size = New Size(769, 429)
        dgvpatio.TabIndex = 0
        ' 
        ' placa
        ' 
        placa.HeaderText = "placa"
        placa.Name = "placa"
        ' 
        ' ticket
        ' 
        ticket.HeaderText = "ticket"
        ticket.Name = "ticket"
        ' 
        ' Entrada
        ' 
        Entrada.HeaderText = "Entrada"
        Entrada.Name = "Entrada"
        ' 
        ' Saida
        ' 
        Saida.HeaderText = "Saida"
        Saida.Name = "Saida"
        ' 
        ' ValorPago
        ' 
        ValorPago.HeaderText = "ValorPago"
        ValorPago.Name = "ValorPago"
        ' 
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(562, 513)
        Controls.Add(dgvpatio)
        Name = "Form4"
        Text = "Form4"
        CType(dgvpatio, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvpatio As DataGridView
    Friend WithEvents placa As DataGridViewTextBoxColumn
    Friend WithEvents ticket As DataGridViewTextBoxColumn
    Friend WithEvents Entrada As DataGridViewTextBoxColumn
    Friend WithEvents Saida As DataGridViewTextBoxColumn
    Friend WithEvents ValorPago As DataGridViewTextBoxColumn
End Class

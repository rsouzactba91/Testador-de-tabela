<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        btnGravarTabela = New Button()
        Label5 = New Label()
        TxtTabelaSelecionada = New TextBox()
        txtTolerancia = New TextBox()
        txt30minutos = New TextBox()
        txt1Hora = New TextBox()
        txtFracao = New TextBox()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(39, 70)
        Label1.Name = "Label1"
        Label1.Size = New Size(60, 15)
        Label1.TabIndex = 4
        Label1.Text = "Tolerância"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(33, 97)
        Label2.Name = "Label2"
        Label2.Size = New Size(66, 15)
        Label2.TabIndex = 5
        Label2.Text = "30 minutos"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(47, 126)
        Label3.Name = "Label3"
        Label3.Size = New Size(40, 15)
        Label3.TabIndex = 6
        Label3.Text = "1 hora"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(47, 155)
        Label4.Name = "Label4"
        Label4.Size = New Size(42, 15)
        Label4.TabIndex = 7
        Label4.Text = "Fração"
        ' 
        ' btnGravarTabela
        ' 
        btnGravarTabela.Location = New Point(39, 195)
        btnGravarTabela.Name = "btnGravarTabela"
        btnGravarTabela.Size = New Size(122, 41)
        btnGravarTabela.TabIndex = 12
        btnGravarTabela.Text = "GravarTabela"
        btnGravarTabela.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(33, 37)
        Label5.Name = "Label5"
        Label5.Size = New Size(105, 15)
        Label5.TabIndex = 13
        Label5.Text = "Tabela selecionada"
        ' 
        ' TxtTabelaSelecionada
        ' 
        TxtTabelaSelecionada.BorderStyle = BorderStyle.FixedSingle
        TxtTabelaSelecionada.Location = New Point(148, 35)
        TxtTabelaSelecionada.Name = "TxtTabelaSelecionada"
        TxtTabelaSelecionada.Size = New Size(24, 23)
        TxtTabelaSelecionada.TabIndex = 14
        ' 
        ' txtTolerancia
        ' 
        txtTolerancia.BorderStyle = BorderStyle.FixedSingle
        txtTolerancia.Location = New Point(123, 64)
        txtTolerancia.Name = "txtTolerancia"
        txtTolerancia.Size = New Size(38, 23)
        txtTolerancia.TabIndex = 15
        ' 
        ' txt30minutos
        ' 
        txt30minutos.BorderStyle = BorderStyle.FixedSingle
        txt30minutos.Location = New Point(123, 97)
        txt30minutos.Name = "txt30minutos"
        txt30minutos.Size = New Size(38, 23)
        txt30minutos.TabIndex = 16
        ' 
        ' txt1Hora
        ' 
        txt1Hora.BorderStyle = BorderStyle.FixedSingle
        txt1Hora.Location = New Point(123, 126)
        txt1Hora.Name = "txt1Hora"
        txt1Hora.Size = New Size(38, 23)
        txt1Hora.TabIndex = 17
        ' 
        ' txtFracao
        ' 
        txtFracao.BorderStyle = BorderStyle.FixedSingle
        txtFracao.Location = New Point(123, 153)
        txtFracao.Name = "txtFracao"
        txtFracao.Size = New Size(38, 23)
        txtFracao.TabIndex = 18
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(216, 283)
        Controls.Add(txtFracao)
        Controls.Add(txt1Hora)
        Controls.Add(txt30minutos)
        Controls.Add(txtTolerancia)
        Controls.Add(TxtTabelaSelecionada)
        Controls.Add(Label5)
        Controls.Add(btnGravarTabela)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Margin = New Padding(3, 2, 3, 2)
        Name = "Form2"
        Text = "Form2"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnGravarTabela As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents TabelaSelecionada As TextBox
    Friend WithEvents TxtTabelaSelecionada As TextBox
    Friend WithEvents txtTolerancia As TextBox
    Friend WithEvents txt30minutos As TextBox
    Friend WithEvents txt1Hora As TextBox
    Friend WithEvents txtFracao As TextBox
End Class

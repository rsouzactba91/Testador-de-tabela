<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Lista = New Button()
        ListadePatio = New Label()
        entrada = New TextBox()
        saida = New TextBox()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(31, 29)
        Label1.Name = "Label1"
        Label1.Size = New Size(47, 15)
        Label1.TabIndex = 0
        Label1.Text = "Entrada"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(31, 99)
        Label2.Name = "Label2"
        Label2.Size = New Size(35, 15)
        Label2.TabIndex = 1
        Label2.Text = "Saída"
        ' 
        ' Lista
        ' 
        Lista.Location = New Point(111, 47)
        Lista.Name = "Lista"
        Lista.Size = New Size(186, 57)
        Lista.TabIndex = 4
        Lista.Text = "Exibir"
        Lista.UseVisualStyleBackColor = True
        ' 
        ' ListadePatio
        ' 
        ListadePatio.AutoSize = True
        ListadePatio.Location = New Point(156, 29)
        ListadePatio.Name = "ListadePatio"
        ListadePatio.Size = New Size(77, 15)
        ListadePatio.TabIndex = 5
        ListadePatio.Text = "Lista de patio"
        ' 
        ' entrada
        ' 
        entrada.Location = New Point(27, 47)
        entrada.Name = "entrada"
        entrada.Size = New Size(51, 23)
        entrada.TabIndex = 6
        ' 
        ' saida
        ' 
        saida.Location = New Point(27, 117)
        saida.Name = "saida"
        saida.Size = New Size(51, 23)
        saida.TabIndex = 7
        ' 
        ' Form3
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(329, 214)
        Controls.Add(saida)
        Controls.Add(entrada)
        Controls.Add(ListadePatio)
        Controls.Add(Lista)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "Form3"
        Text = "Form3"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Lista As Button
    Friend WithEvents ListadePatio As Label
    Friend WithEvents entrada As TextBox
    Friend WithEvents saida As TextBox
End Class

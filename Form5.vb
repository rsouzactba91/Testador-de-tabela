Public Class Form5
    Public PagamentoConcluido As Boolean = False

    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles pagamento.Click
        ' Simula o pagamento e confirma a ação
        PagamentoConcluido = True
        MessageBox.Show("Pagamento realizado com sucesso!", "Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub
End Class

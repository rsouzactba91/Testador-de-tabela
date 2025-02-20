Public Class Form4
    ' Lista de veículos recebida do Form3
    Public ListaPatio As New List(Of Form3.Veiculo)

    ' 🔹 Carregar os veículos ao iniciar o Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarDataGridView()
        AtualizarListaPatio()
    End Sub

    ' 🔹 Configurar as colunas do DataGridView
    Private Sub ConfigurarDataGridView()
        dgvpatio.ColumnCount = 5
        dgvpatio.Columns(0).Name = "Placa"
        dgvpatio.Columns(1).Name = "Ticket"
        dgvpatio.Columns(2).Name = "Entrada"
        dgvpatio.Columns(3).Name = "Saída"
        dgvpatio.Columns(4).Name = "Valor Pago"
    End Sub

    ' 🔹 Atualizar o DataGridView com os veículos do pátio
    Private Sub AtualizarListaPatio()
        dgvpatio.Rows.Clear()

        For Each veiculo In ListaPatio
            Dim horarioSaida As String = If(veiculo.HorarioSaida = DateTime.MinValue, "Ainda no pátio", veiculo.HorarioSaida.ToString("yyyy-MM-dd HH:mm:ss"))
            Dim valorPago As String = If(veiculo.HorarioSaida = DateTime.MinValue, "-", "R$ " & veiculo.ValorAPagar.ToString("F2"))

            dgvpatio.Rows.Add(veiculo.Placa, veiculo.Ticket, veiculo.HorarioEntrada.ToString("yyyy-MM-dd HH:mm:ss"), horarioSaida, valorPago)
        Next
    End Sub

    Private Sub dgvpatio_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpatio.CellContentClick

    End Sub
End Class

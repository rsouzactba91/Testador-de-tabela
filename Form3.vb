Imports System.IO

Public Class Form3
    ' Lista para armazenar os veículos no pátio
    Dim ListaPatio As New List(Of Veiculo)

    ' Estrutura para armazenar os dados do veículo
    Public Structure Veiculo
        Public Placa As String
        Public Ticket As String
        Public HorarioEntrada As DateTime
        Public HorarioSaida As DateTime
        Public ValorAPagar As Decimal
    End Structure

    ' 🔹 Carregar os veículos ao iniciar o Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarVeiculos()
    End Sub

    ' 🔹 Função para salvar os veículos no arquivo patio.txt
    Private Sub SalvarVeiculos()
        Dim caminhoArquivo As String = "patio.txt"
        Dim linhas As New List(Of String)

        For Each veiculo In ListaPatio
            Dim linha As String = veiculo.Placa & ";" & veiculo.Ticket & ";" & veiculo.HorarioEntrada.ToString("yyyy-MM-dd HH:mm:ss") & ";" &
                                  If(veiculo.HorarioSaida = DateTime.MinValue, "", veiculo.HorarioSaida.ToString("yyyy-MM-dd HH:mm:ss")) & ";" &
                                  veiculo.ValorAPagar.ToString("F2")
            linhas.Add(linha)
        Next

        File.WriteAllLines(caminhoArquivo, linhas)
    End Sub

    ' 🔹 Função para carregar os veículos do arquivo patio.txt
    Private Sub CarregarVeiculos()
        Dim caminhoArquivo As String = "patio.txt"

        If Not File.Exists(caminhoArquivo) Then Return

        Dim linhas As String() = File.ReadAllLines(caminhoArquivo)
        ListaPatio.Clear()

        For Each linha In linhas
            Dim dados As String() = linha.Split(";"c)
            Dim veiculo As New Veiculo With {
                .Placa = dados(0),
                .Ticket = dados(1),
                .HorarioEntrada = DateTime.Parse(dados(2)),
                .HorarioSaida = If(dados(3) = "", DateTime.MinValue, DateTime.Parse(dados(3))),
                .ValorAPagar = Decimal.Parse(dados(4))
            }
            ListaPatio.Add(veiculo)
        Next
    End Sub

    ' 🔹 Registrar entrada automaticamente ao digitar no campo "entrada"
    Private Sub entrada_TextChanged(sender As Object, e As EventArgs) Handles entrada.TextChanged
        Dim placa As String = entrada.Text.Trim()

        ' Verifica se a placa tem o tamanho correto antes de registrar
        If placa.Length < 7 Then Exit Sub

        ' Verifica se o veículo já está no pátio
        If ListaPatio.Any(Function(v) v.Placa = placa AndAlso v.HorarioSaida = DateTime.MinValue) Then
            MessageBox.Show("O veículo já está no pátio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            entrada.Clear()
            Exit Sub
        End If

        ' Registra a entrada do veículo
        Dim novoVeiculo As New Veiculo With {
            .Placa = placa,
            .Ticket = placa & "_" & DateTime.Now.ToString("yyyyMMddHHmmss"),
            .HorarioEntrada = DateTime.Now,
            .HorarioSaida = DateTime.MinValue,
            .ValorAPagar = 0
        }

        ListaPatio.Add(novoVeiculo)
        SalvarVeiculos()

        ' Limpa o campo após registrar
        entrada.Clear()
    End Sub
    Private Sub saida_TextChanged(sender As Object, e As EventArgs) Handles saida.TextChanged
        Dim placa = saida.Text.Trim()

        ' Verifica se a placa tem o tamanho correto antes de registrar
        If placa.Length < 7 Then Exit Sub

        ' Procura o veículo na lista
        Dim veiculo = ListaPatio.FirstOrDefault(Function(v) v.Placa = placa AndAlso v.HorarioSaida = DateTime.MinValue)

        If veiculo.Placa = Nothing Then
            MessageBox.Show("Veículo não encontrado no pátio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            saida.Clear()
            Exit Sub
        End If

        ' Atualiza o horário de saída
        veiculo.HorarioSaida = DateTime.Now

        ' Converte o tempo de permanência para horas e minutos
        Dim duracao = veiculo.HorarioSaida - veiculo.HorarioEntrada
        Dim totalHoras As Integer = Math.Floor(duracao.TotalHours)
        Dim totalMinutos = duracao.Minutes

        ' Calcula o valor a pagar
        veiculo.ValorAPagar = CalcularValorTabela1(totalHoras, totalMinutos)

        ' 🛑 Se houver valor a pagar, redireciona para o Form5
        If veiculo.ValorAPagar > 0 Then
            Dim formPagamento As New Form5()
            formPagamento.TxtPlaca.Text = placa ' Define a placa no campo de texto do Form5
            formPagamento.ShowDialog()

            ' Verifica se o pagamento foi concluído antes de permitir a saída
            If formPagamento.PagamentoConcluido = False Then
                MessageBox.Show("Pagamento não efetuado. A saída não foi registrada!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                saida.Clear()
                Exit Sub
            End If
        End If

        ' Remove o veículo antigo e adiciona o atualizado
        ListaPatio.RemoveAll(Function(v) v.Placa = placa AndAlso v.HorarioSaida = DateTime.MinValue)
        ListaPatio.Add(veiculo)

        SalvarVeiculos()

        ' Confirma a saída
        MessageBox.Show("Saída registrada com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Limpa o campo após registrar
        saida.Clear()
    End Sub



    ' 🔹 Função para calcular o valor com base na lógica do testador de tabela
    Private Function CalcularValorTabela1(totalHoras As Integer, totalMinutos As Integer) As Decimal
        Dim valor As Decimal = 0

        ' Obtém os valores das configurações e usa valores padrão como backup
        Dim valorAte30Min As Decimal = If(My.Settings.Tab1_Minutos30 > 0, My.Settings.Tab1_Minutos30, 13) ' Padrão: 13
        Dim valorAte3Horas As Decimal = If(My.Settings.Tab1_UmaHora > 0, My.Settings.Tab1_UmaHora, 19) ' Padrão: 19
        Dim valorExtra As Decimal = If(My.Settings.Tab1_Fracao > 0, My.Settings.Tab1_Fracao, 2.5) ' Padrão: 2.5

        ' Até 15 minutos é grátis
        If totalHoras = 0 AndAlso totalMinutos <= 15 Then
            valor = 0
        ElseIf totalHoras = 0 AndAlso totalMinutos > 15 AndAlso totalMinutos <= 30 Then
            valor = valorAte30Min
        ElseIf totalHoras < 3 Then
            valor = valorAte3Horas
        ElseIf totalHoras >= 3 Then
            valor = valorAte3Horas

            ' Calcula os minutos extras corretamente
            Dim minutosExtras As Integer = (totalHoras * 60 + totalMinutos) - (3 * 60)
            If minutosExtras > 0 Then
                Dim blocosDe15Min As Integer = CInt(Math.Ceiling(minutosExtras / 15.0))
                valor += (blocosDe15Min * valorExtra)
            End If
        End If

        Return valor
    End Function

    ' 🔹 Abrir o Form4 ao clicar no botão "Lista"
    Private Sub Lista_Click(sender As Object, e As EventArgs) Handles Lista.Click
        Dim formLista As New Form4()
        formLista.ListaPatio = ListaPatio ' Passa a lista de veículos para o Form4
        formLista.ShowDialog()
    End Sub

End Class

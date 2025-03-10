
Imports System.IO
Imports System.Windows.Forms
Imports Testador_de_tabela.Form3

Public Class Form4
    ' Lista de veículos recebida do Form3
    Public ListaPatio As New List(Of Form3.Veiculo)

    ' Ao iniciar o Form4, carrega os veículos, configura o DataGridView e atualiza a lista
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarVeiculos()
        ConfigurarDataGridView()
        AtualizarListaPatio()
    End Sub

    ' Função para carregar os veículos do arquivo "patio.txt"
    Private Sub CarregarVeiculos()
        Try
            Dim caminhoArquivo As String = Path.Combine(Application.StartupPath, "patio.txt")

            ' Verifica se o arquivo existe; se não, exibe mensagem e encerra o método
            If Not File.Exists(caminhoArquivo) Then
                MessageBox.Show("Arquivo não encontrado: " & caminhoArquivo, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Lê todas as linhas do arquivo
            Dim linhas As String() = File.ReadAllLines(caminhoArquivo)
            ListaPatio.Clear()  ' Limpa a lista antes de carregar os novos dados

            ' Processa cada linha do arquivo
            For Each linha As String In linhas
                ' Pula linhas vazias
                If String.IsNullOrWhiteSpace(linha) Then Continue For

                Dim dados As String() = linha.Split(";"c)

                ' Verifica se a linha contém os 5 campos necessários
                If dados.Length < 5 Then
                    MessageBox.Show("Linha com dados incompletos: " & linha, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Continue For
                End If

                ' Cria um novo veículo a partir dos dados lidos
                Dim veiculo As New Veiculo With {
                    .Placa = dados(0).Trim(),
                    .Ticket = dados(1).Trim(),
                    .HorarioEntrada = DateTime.Parse(dados(2).Trim()),
                    .HorarioSaida = If(String.IsNullOrWhiteSpace(dados(3).Trim()), DateTime.MinValue, DateTime.Parse(dados(3).Trim())),
                    .ValorAPagar = Decimal.Parse(dados(4).Trim())
                }

                ' Adiciona o veículo à lista
                ListaPatio.Add(veiculo)
            Next

        Catch ex As FormatException
            MessageBox.Show("Erro de formato nos dados do arquivo: " & ex.Message, "Erro de Formatação", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar os veículos: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Função para configurar as colunas do DataGridView
    Private Sub ConfigurarDataGridView()
        dgvpatio.ColumnCount = 5
        dgvpatio.Columns(0).Name = "Placa"
        dgvpatio.Columns(1).Name = "Ticket"
        dgvpatio.Columns(2).Name = "Entrada"
        dgvpatio.Columns(3).Name = "Saída"
        dgvpatio.Columns(4).Name = "Valor Pago"
    End Sub

    ' Função para atualizar o DataGridView com os veículos da lista
    Private Sub AtualizarListaPatio()
        dgvpatio.Rows.Clear()
        For Each veiculo In ListaPatio
            Dim horarioSaida As String = If(veiculo.HorarioSaida = DateTime.MinValue, "Ainda no pátio", veiculo.HorarioSaida.ToString("yyyy-MM-dd HH:mm:ss"))
            Dim valorPago As String = If(veiculo.HorarioSaida = DateTime.MinValue, "-", "R$ " & veiculo.ValorAPagar.ToString("F2"))
            dgvpatio.Rows.Add(veiculo.Placa,
                              veiculo.Ticket,
                              veiculo.HorarioEntrada.ToString("yyyy-MM-dd HH:mm:ss"),
                              horarioSaida,
                              valorPago)
        Next
    End Sub

End Class
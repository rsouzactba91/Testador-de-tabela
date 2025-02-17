Imports System.Globalization
Imports System.Reflection.Metadata

Public Class Form1
    ' Construtor do formulário
    Public Sub New()
        ' Inicializa os componentes do formulário
        InitializeComponent()
    End Sub

    ' Evento Load do formulário - Configura os MaskedTextBox e carrega a última tabela salva
    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        entrada.Mask = "00/00/0000 00:00"
        saida.Mask = "00/00/0000 00:00"

        ' Verifica se há um valor salvo antes de carregar
        If My.Settings.UltimaTabela > 0 Then
            tabelatxtbox.Text = My.Settings.UltimaTabela.ToString()
        Else
            tabelatxtbox.Text = "1" ' Define um valor padrão caso não haja um salvo
        End If
        ' Define a hora atual nos MaskedTextBox
        Dim now As DateTime = DateTime.Now
        entrada.Text = now.ToString("dd/MM/yyyy HH:mm")
        saida.Text = now.ToString("dd/MM/yyyy HH:mm")
    End Sub

    ' Evento Click do botão "Calcular" - Verifica o tempo percorrido e busca o valor correspondente
    Private Sub calcular_Click(sender As Object, e As EventArgs) Handles Calcular.Click
        Dim entradaTexto As String = entrada.Text
        Dim saidaTexto As String = saida.Text
        Dim tabelaSelecionada As Integer

        ' Verifica se o usuário digitou um número válido na tabela
        If Not Integer.TryParse(tabelatxtbox.Text, tabelaSelecionada) Then
            MessageBox.Show("Por favor, selecione uma tabela válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Salva a última tabela digitada
        My.Settings.UltimaTabela = tabelaSelecionada
        My.Settings.Save()

        ' Tenta converter os textos para DateTime
        Dim entradaHora As DateTime
        Dim saidaHora As DateTime

        If DateTime.TryParseExact(entradaTexto, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, entradaHora) AndAlso
           DateTime.TryParseExact(saidaTexto, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, saidaHora) Then

            ' Verifica se a saída é maior que a entrada
            If saidaHora <= entradaHora Then
                MessageBox.Show("A hora de saída deve ser maior que a hora de entrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' Calcula a diferença total corretamente
            Dim diferenca As TimeSpan = saidaHora - entradaHora
            Dim totalHoras As Integer = diferenca.Days * 24 + diferenca.Hours ' Converte dias para horas e soma as horas restantes
            Dim minutosRestantes As Integer = diferenca.Minutes ' Obtém os minutos restantes

            ' Variável para armazenar o valor a ser cobrado
            Dim valorCobrado As Decimal = 0

            ' Busca o valor correspondente na tabela selecionada
            Select Case tabelaSelecionada
                Case 1
                    valorCobrado = CalcularValorTabela1(totalHoras, minutosRestantes)
                Case 2
                    valorCobrado = CalcularValorTabela2(totalHoras, minutosRestantes)
                Case Else
                    MessageBox.Show("Tabela não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
            End Select

            ' Exibe o resultado final
            MessageBox.Show("Tabela selecionada: " & tabelaSelecionada & vbCrLf &
                            "Tempo total: " & totalHoras.ToString("N0") & " horas e " & minutosRestantes.ToString("N0") & " minutos" & vbCrLf &
                            "Valor a pagar: R$ " & valorCobrado.ToString("N2"),
                            "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Por favor, insira horários válidos no formato dd/MM/yyyy HH:mm.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Function CalcularValorTabela1(totalHoras As Integer, totalMinutos As Integer) As Decimal
        Dim valor As Decimal = 0

        ' Obtém os valores das configurações e converte para Decimal
        Dim valorAte30Min As Decimal = Convert.ToDecimal(My.Settings.Minutos30, System.Globalization.CultureInfo.InvariantCulture)
        Dim valorAte3Horas As Decimal = Convert.ToDecimal(My.Settings.UmaHora, System.Globalization.CultureInfo.InvariantCulture)
        Dim valorExtra As Decimal = Convert.ToDecimal(My.Settings.Fracao, System.Globalization.CultureInfo.InvariantCulture)

        ' Até 15 minutos é grátis
        If totalHoras = 0 AndAlso totalMinutos <= 15 Then
            valor = 0
            ' De 16 a 30 minutos
        ElseIf totalHoras = 0 AndAlso totalMinutos > 15 AndAlso totalMinutos <= 30 Then
            valor = valorAte30Min
            ' De 31 minutos até 3 horas
        ElseIf totalHoras < 3 Then
            valor = valorAte3Horas
            ' Acima de 3 horas
        ElseIf totalHoras >= 3 Then
            valor = valorAte3Horas

            ' Calcula minutos extras
            Dim minutosExtras As Integer = (totalHoras - 3) * 60 + totalMinutos
            If minutosExtras > 0 Then
                Dim blocosDe15Min As Integer = Math.Ceiling(minutosExtras / 15.0)
                valor += blocosDe15Min * valorExtra
            End If
        End If

        Return valor
    End Function

    ' Função para calcular o valor da Tabela 2
    Private Function CalcularValorTabela2(totalHoras As Integer, totalMinutos As Integer) As Decimal
        Dim valor As Decimal = 0

        If totalHoras = 0 And totalMinutos <= 15 Then
            valor = 5 ' Até 15 minutos custa R$ 5,00
        ElseIf totalHoras = 0 And totalMinutos > 15 Then
            valor = 15 ' Até 1 hora custa R$ 15,00
        ElseIf totalHoras >= 1 And totalHoras < 3 Then
            valor = 25 ' De 1 a 3 horas custa R$ 25,00
        ElseIf totalHoras >= 3 Then
            valor = 25 ' Cobra o valor de 3 horas

            ' Calcula o tempo extra após 3 horas
            Dim minutosExtras As Integer = ((totalHoras - 3) * 60) + totalMinutos
            Dim blocosDe15Min As Integer = Math.Ceiling(minutosExtras / 15.0) ' Arredonda corretamente

            ' Adiciona R$ 3,00 por cada bloco de 15 minutos
            valor += blocosDe15Min * 3.0
        End If

        Return valor
    End Function

    Private Sub GerenciaTabelas_Click(sender As Object, e As EventArgs) Handles GerenciaTabelas.Click
        Dim formGerenciar As New Form2() ' Cria uma instância do Form2
        formGerenciar.ShowDialog() ' Abre o Form2 como uma janela modal
    End Sub

    Private Sub FontDialog1_Apply(sender As Object, e As EventArgs)

    End Sub
End Class

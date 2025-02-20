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
        entrada.Text = now.AddHours(-1).ToString("dd/MM/yyyy HH:mm")
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

            ' Se a saída for no dia seguinte, ajusta a data corretamente
            If saidaHora < entradaHora Then
                saidaHora = saidaHora.AddDays(1)
            End If

            ' Calcula a diferença total corretamente
            Dim diferenca As TimeSpan = saidaHora - entradaHora
            Dim totalHoras As Integer = Math.Floor(diferenca.TotalMinutes / 60) ' Converte minutos totais para horas inteiras
            Dim minutosRestantes As Integer = diferenca.TotalMinutes Mod 60 ' Obtém os minutos restantes

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

            ' 🔹 Área reservada para a lógica de saída estimada
            Dim saidaate As DateTime
            ' 🔹 Implementação da lógica de `saidaate`
            If totalHoras = 3 AndAlso minutosRestantes = 0 Then
                saidaate = saidaHora ' Se for exatamente 3 horas, não há tempo restante
            ElseIf totalHoras < 3 Then
                saidaate = entradaHora.AddHours(3) ' Se for menor que 3 horas, define a saída para 3 horas após a entrada
            Else
                saidaate = saidaHora.AddMinutes(15) ' Caso contrário, adiciona 15 minutos
            End If

            ' 🔹 Calcula o tempo restante até `saidaate`
            Dim temporestante As TimeSpan = saidaate - saidaHora

            ' 🔹 Se o tempo total for exatamente 3 horas, o tempo restante deve ser 0
            If totalHoras = 3 AndAlso minutosRestantes = 0 Then
                temporestante = TimeSpan.Zero
            End If

            ' Exibe o resultado final
            MessageBox.Show("Tabela selecionada: " & tabelaSelecionada & vbCrLf &
                        "Tempo total: " & totalHoras.ToString("N0") & " horas e " & minutosRestantes.ToString("N0") & " minutos" & vbCrLf &
                        "Valor a pagar: R$ " & valorCobrado.ToString("N2") & vbCrLf &
                        "Saída até: " & saidaate.ToString("dd/MM/yyyy HH:mm") & vbCrLf &
                        "Tempo restante: " & temporestante.Hours.ToString("N0") & " horas e " & temporestante.Minutes.ToString("N0") & " minutos",
                        "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Por favor, insira horários válidos no formato dd/MM/yyyy HH:mm.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Public Function CalcularValorTabela1(totalHoras As Integer, totalMinutos As Integer) As Decimal
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

            ' 🔹 Agora os minutos extras são calculados corretamente
            Dim minutosExtras As Integer = (totalHoras * 60 + totalMinutos) - (3 * 60) ' Minutos além das 3 horas
            If minutosExtras > 0 Then
                Dim blocosDe15Min As Integer = CInt(Math.Ceiling(minutosExtras / 15.0)) ' Arredonda corretamente para cima
                valor += (blocosDe15Min * valorExtra) ' 🔹 Agora o valor extra é somado corretamente
            End If
        End If

        Return valor
    End Function





    Private Function CalcularValorTabela2(totalHoras As Integer, totalMinutos As Integer) As Decimal
        Dim valor As Decimal = 0

        ' Obtém os valores das configurações e usa valores padrão como backup
        Dim valorAte30Min As Decimal = If(My.Settings.Tab2_Minutos30 > 0, My.Settings.Tab2_Minutos30, 15) ' Padrão: 15
        Dim valorAte3Horas As Decimal = If(My.Settings.Tab2_UmaHora > 0, My.Settings.Tab2_UmaHora, 22) ' Padrão: 22
        Dim valorExtra As Decimal = If(My.Settings.Tab2_Fracao > 0, My.Settings.Tab2_Fracao, 3.0) ' Padrão: 3.0

        ' Até 15 minutos é grátis
        If totalHoras = 0 AndAlso totalMinutos <= 15 Then
            valor = 0
        ElseIf totalHoras = 0 AndAlso totalMinutos > 15 AndAlso totalMinutos <= 30 Then
            valor = valorAte30Min
        ElseIf totalHoras < 3 Then
            valor = valorAte3Horas
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



    Private Sub GerenciaTabelas_Click(sender As Object, e As EventArgs) Handles GerenciaTabelas.Click
        Dim formGerenciar As New Form2() ' Cria uma instância do Form2
        formGerenciar.ShowDialog() ' Abre o Form2 como uma janela modal
    End Sub

    Private Sub FontDialog1_Apply(sender As Object, e As EventArgs)

    End Sub

    Private Sub testar_Click(sender As Object, e As EventArgs) Handles testar.Click
        Dim testar As New Form3()
        testar.ShowDialog()
    End Sub
End Class

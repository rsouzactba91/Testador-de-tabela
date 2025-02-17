Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Verifica se há um valor salvo antes de carregar
        If My.Settings.UltimaTabela > 0 Then
            TxtTabelaSelecionada.Text = My.Settings.UltimaTabela.ToString()
        Else
            TxtTabelaSelecionada.Text = "1" ' Define um valor padrão caso não haja um salvo
        End If

        ' Atualiza os valores ao abrir o formulário
        AtualizarValores()
    End Sub

    Private Sub AtualizarValores()
        Try
            ' Agora os valores são carregados diretamente como Decimal
            txtTolerancia.Text = My.Settings.Tolerancia.ToString("F2")
            txt30minutos.Text = My.Settings.Minutos30.ToString("F2")
            txt1Hora.Text = My.Settings.UmaHora.ToString("F2")
            txtFracao.Text = My.Settings.Fracao.ToString("F2")
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar os valores: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGravarTabela_Click(sender As Object, e As EventArgs) Handles btnGravarTabela.Click
        Try
            ' Agora os valores são salvos diretamente como Decimal
            My.Settings.Tolerancia = Convert.ToDecimal(txtTolerancia.Text)
            My.Settings.Minutos30 = Convert.ToDecimal(txt30minutos.Text)
            My.Settings.UmaHora = Convert.ToDecimal(txt1Hora.Text)
            My.Settings.Fracao = Convert.ToDecimal(txtFracao.Text)
            My.Settings.UltimaTabela = Convert.ToInt32(TxtTabelaSelecionada.Text) ' Salva a tabela selecionada

            ' Salva as configurações
            My.Settings.Save()

            MessageBox.Show("Tabela salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Erro ao salvar os valores: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

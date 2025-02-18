Imports System.Globalization

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


    Private Sub TxtTabelaSelecionada_TextChanged(sender As Object, e As EventArgs) Handles TxtTabelaSelecionada.TextChanged
        ' Atualiza os valores sempre que a tabela for alterada
        AtualizarValores()
    End Sub

    Private Sub AtualizarValores()
        Try
            If TxtTabelaSelecionada.Text = "1" Then
                ' Carrega os valores da Tabela 1
                txtTolerancia.Text = My.Settings.Tab1_Tolerancia.ToString("F2", CultureInfo.InvariantCulture)
                txt30minutos.Text = My.Settings.Tab1_Minutos30.ToString("F2", CultureInfo.InvariantCulture)
                txt1Hora.Text = My.Settings.Tab1_UmaHora.ToString("F2", CultureInfo.InvariantCulture)
                txtFracao.Text = My.Settings.Tab1_Fracao.ToString("F2", CultureInfo.InvariantCulture)
            ElseIf TxtTabelaSelecionada.Text = "2" Then
                ' Carrega os valores da Tabela 2
                txtTolerancia.Text = My.Settings.Tab2_tolerancia.ToString("F2", CultureInfo.InvariantCulture)
                txt30minutos.Text = My.Settings.Tab2_Minutos30.ToString("F2", CultureInfo.InvariantCulture)
                txt1Hora.Text = My.Settings.Tab2_UmaHora.ToString("F2", CultureInfo.InvariantCulture)
                txtFracao.Text = My.Settings.Tab2_Fracao.ToString("F2", CultureInfo.InvariantCulture)
            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar os valores: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnGravarTabela_Click(sender As Object, e As EventArgs) Handles btnGravarTabela.Click
        Try
            ' Verifica qual tabela está selecionada e salva os valores corretamente
            If TxtTabelaSelecionada.Text = "1" Then
                My.Settings.Tab1_Tolerancia = Convert.ToDecimal(txtTolerancia.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
                My.Settings.Tab1_Minutos30 = Convert.ToDecimal(txt30minutos.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
                My.Settings.Tab1_UmaHora = Convert.ToDecimal(txt1Hora.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
                My.Settings.Tab1_Fracao = Convert.ToDecimal(txtFracao.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
            ElseIf TxtTabelaSelecionada.Text = "2" Then
                My.Settings.Tab2_tolerancia = Convert.ToDecimal(txtTolerancia.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
                My.Settings.Tab2_Minutos30 = Convert.ToDecimal(txt30minutos.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
                My.Settings.Tab2_UmaHora = Convert.ToDecimal(txt1Hora.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
                My.Settings.Tab2_Fracao = Convert.ToDecimal(txtFracao.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
            End If

            ' Salva a tabela selecionada
            My.Settings.UltimaTabela = Convert.ToInt32(TxtTabelaSelecionada.Text)

            ' 🔥 Salva as configurações para garantir persistência
            My.Settings.Save()

            MessageBox.Show("Tabela salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Erro ao salvar os valores: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class

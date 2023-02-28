Imports System.Globalization

Class MainWindow
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Loaded
        lblCFICA.Content = ""
        lblCFT.Content = ""
        lblCST.Content = ""
        lblCNet.Content = ""
        tbxGP.Clear()
        tbxGP.Focus()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As RoutedEventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As RoutedEventArgs) Handles btnClear.Click
        lblCFICA.Content = ""
        lblCFT.Content = ""
        lblCST.Content = ""
        lblCNet.Content = ""
        tbxGP.Clear()
        tbxGP.Focus()

    End Sub

    Private Sub btnTaxCalc_Click(sender As Object, e As RoutedEventArgs) Handles btnTaxCalc.Click
        Dim strIncome As String
        Dim decIncome As Decimal
        Dim decFica As Decimal
        Dim decFederal As Decimal
        Dim decState As Decimal
        Dim decNet As Decimal
        Const cdecFica = 0.0765D
        Const cdecFed = 0.22D
        Const cdecState = 0.04D

        strIncome = tbxGP.Text
        Try
            decIncome = Convert.ToDecimal(strIncome)
            decFica = cdecFica * decIncome
            decFederal = cdecFed * decIncome
            decState = cdecState * decIncome
            lblCFICA.Content = decFica.ToString("C", New CultureInfo("en-US"))
            lblCFT.Content = decFederal.ToString("C", New CultureInfo("en-US"))
            lblCST.Content = decState.ToString("C", New CultureInfo("en-US"))
            decNet = decIncome - decFica - decFederal - decState
            lblCNet.Content = decNet.ToString("C", New CultureInfo("en-US"))
        Catch ex As FormatException
            lblCFICA.Content = "NaN"
            lblCFT.Content = "NaN"
            lblCST.Content = "NaN"
            lblCNet.Content = "NaN"
            tbxGP.Clear()
            tbxGP.Focus()

        End Try
    End Sub
End Class

Imports System.IO

Public Class Highscore
    Dim path As String = "C:\Users\suede.lang-sadler\Desktop\Highscores\Highscores.txt"
    Dim sw As StreamWriter = File.CreateText(path)
    Private Sub Highscore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = Form1.Label3.Text

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sw.WriteLine("Name: " + TextBox1.Text)
        sw.WriteLine(Label2.Text)
        sw.Close()
        Close()
    End Sub
End Class
Public Class Form1
    Dim UpPressed As Boolean
    Dim DownPressed As Boolean
    Dim LeftPressed As Boolean
    Dim RightPressed As Boolean
    Dim Score As Integer = 0
    Dim Lives As Integer = 1
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Up Then
            PictureBox1.Top -= 5
        End If

        If e.KeyCode = Keys.Down Then
            PictureBox1.Top += 5
        End If

        If e.KeyCode = Keys.Left Then
            PictureBox1.Left -= 5
        End If

        If e.KeyCode = Keys.Right Then
            PictureBox1.Left += 5
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If UpPressed = True Then
            PictureBox1.Top -= 5
            If PictureBox1.Top <= 0 Then
                PictureBox1.Top = 0
            End If
        End If

        If DownPressed = True Then
            PictureBox1.Top += 5
            If PictureBox1.Top + PictureBox1.Height >= Me.Height Then
                PictureBox1.Top = Me.Height - PictureBox1.Height
            End If
        End If

        If LeftPressed = True Then
            PictureBox1.Left -= 5
            If PictureBox1.Left <= 0 Then
                PictureBox1.Left = 0
            End If
        End If

        If RightPressed = True Then
            PictureBox1.Left += 5

            If PictureBox1.Left + PictureBox1.Height >= Me.Height Then
                PictureBox1.Left = Me.Height - PictureBox1.Height
            End If
        End If

        If Collision(PictureBox1, PictureBox2) = True Then
            PictureBox2.Top = Int(Rnd() * (Me.Height - PictureBox2.Height))
            PictureBox2.Left = Int(Rnd() * (Me.Width - PictureBox2.Width))

            Score = Score + 1
            Label3.Text = "Score: " & Score
        End If

        Chase(PictureBox3, PictureBox1)

        Label2.Text = "Lives: " & Lives

        If Collision(PictureBox1, PictureBox3) = True Then
            If Lives > 1 Then
                Lives = Lives - 1

                PictureBox1.Top = 0
                PictureBox1.Left = 0

                PictureBox3.Top = Me.Height - PictureBox3.Height
                PictureBox3.Left = Me.Width - PictureBox3.Width
            Else
                Lives = 0
                Label2.Text = "Lives:  0"
                Timer1.Stop()
                Dim form As Highscore
                form = New Highscore
                form.Show()
            End If
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Up Then
            UpPressed = False
        End If

        If e.KeyCode = Keys.Down Then
            DownPressed = False
        End If

        If e.KeyCode = Keys.Left Then
            LeftPressed = False
        End If

        If e.KeyCode = Keys.Right Then
            RightPressed = False
        End If
    End Sub

    Private Function Collision(ByVal Object1 As Object, ByVal Object2 As Object) As Boolean
        If Object1.Bounds.IntersectsWith(Object2.Bounds) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Function Chase(ByRef Object1 As Object, ByRef Object2 As Object)
        If Object1.Left > Object2.Left Then
            Object1.Left -= 2
        End If
        If Object1.Left < Object2.Left Then
            Object1.Left += 2
        End If
        If Object1.Top > Object2.Top Then
            Object1.Top -= 2
        End If
        If Object1.Top < Object2.Top Then
            Object1.Top += 2
        End If
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Timer1.Start()

    End Sub
End Class

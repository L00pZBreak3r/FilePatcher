Imports System.IO

Public Class Form1

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    Dim sS As String = TextBox1.Text.Trim
    Dim sD As String = TextBox2.Text.Trim
    If Not String.IsNullOrEmpty(sS) AndAlso Not String.IsNullOrEmpty(sD) Then
      Dim i1 As Integer
      If Integer.TryParse(TextBox3.Text.Trim, i1) AndAlso i1 >= 0 Then
        Dim i2 As Integer
        If Integer.TryParse(TextBox4.Text.Trim, i2) AndAlso i2 >= 0 Then
          Dim l As Integer
          If Integer.TryParse(TextBox5.Text.Trim, l) AndAlso l >= 0 Then
            If File.Exists(sS) Then
              If File.Exists(sD) Then
                Dim fS As FileStream = File.OpenRead(sS)
                Dim lS As Integer = fS.Length
                If l = 0 Then
                  l = lS - i1
                  If l <= 0 Then l = 1
                End If
                If lS >= i1 + l Then
                  Dim fD As FileStream = File.OpenWrite(sD)
                  If fD.Length >= i2 + l Then
                    Dim buf(l - 1) As Byte
                    Dim l0 As Integer = fS.Read(buf, i1, l)
                    If l0 = l Then
                      fD.Write(buf, i2, l)
                      Label3.Text = "Patch successful. Ready to go."
                    Else
                      Label3.Text = "Can't read source file. Ready to go."
                    End If
                  Else
                    Label3.Text = "Destination file is too small. Ready to go."
                  End If
                  fD.Close()
                Else
                  Label3.Text = "Source file is too small. Ready to go."
                End If
                fS.Close()
              Else
                Label3.Text = "Destination file doesn't exist. Ready to go."
              End If
            Else
              Label3.Text = "Source file doesn't exist. Ready to go."
            End If
          Else
            Label3.Text = "Wrong length. Ready to go."
          End If
        Else
          Label3.Text = "Wrong destination start position. Ready to go."
        End If
      Else
        Label3.Text = "Wrong source start position. Ready to go."
      End If
    End If
  End Sub

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    TextBox1.Focus()
    TextBox3.Text = 0
    TextBox4.Text = 0
    TextBox5.Text = 0
  End Sub
End Class
